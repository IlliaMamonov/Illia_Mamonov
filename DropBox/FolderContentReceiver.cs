using RestSharp;
using System;
using System.Collections.Generic;

namespace DropBox
{
    public sealed partial class FolderContentReceiver : RequestSender
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "Authorization", _token},
            { "Content-type", "application/json"}
        };

        private readonly string _nextUrl = "https://api.dropboxapi.com/2/files/list_folder/continue";
        private readonly ResponseDeserializer _responseDeserializer;
        private readonly string _startUrl = "https://api.dropboxapi.com/2/files/list_folder";

        // "path" value is set to String.Empty so the root folder will be explored

        private string _startBody = $"{{\"path\": \"{String.Empty}\",\"recursive\": false," +
            "\"include_media_info\": false,\"include_deleted\": false," +
            "\"include_has_explicit_shared_members\": false," +
            "\"include_mounted_folders\": true,\"include_non_downloadable_files\": true}";

        public FolderContentReceiver() : base()
        {
            _client = new RestClient(_startUrl);
            _responseDeserializer = new ResponseDeserializer();
        }

        public override void BuildRequest()
        {
            _request.AddHeaders(_headers);
            _request.AddJsonBody(_startBody);
        }

        public IEnumerable<string> GetFiles()
        {
            var files = new List<string>();
            BuildRequest();
            SendRequest();
            var deserializedResponse = _responseDeserializer.GetDeserializedResponse(_response);
            var entries = _responseDeserializer.GetEntries(deserializedResponse);
            var hasMore = _responseDeserializer.HasMore(deserializedResponse);

            // no files found

            if (entries.Count < 1)
            {
                return files;
            }

            var fileNames = _responseDeserializer.GetFileNames(entries);
            files.InsertRange(0, fileNames);
            if (hasMore)
            {
                _client = new RestClient(_nextUrl);
            }
            while (hasMore)
            {
                string cursor = _responseDeserializer.GetCursor(deserializedResponse);
                BuildNextRequest(cursor);
                SendRequest();
                deserializedResponse = _responseDeserializer.GetDeserializedResponse(_response);
                entries = _responseDeserializer.GetEntries(deserializedResponse);
                fileNames = _responseDeserializer.GetFileNames(entries);
                files.InsertRange(0, fileNames);
                hasMore = _responseDeserializer.HasMore(deserializedResponse);
            }
            return files;
        }

        private void BuildNextRequest(string cursor)
        {
            _request = new RestRequest();
            var cursorBody = new Dictionary<string, string>()
            {
                { "cursor", cursor }
            };

            _request.AddHeaders(_headers);
            _request.AddJsonBody(cursorBody);
        }

        private void SendRequest()
        {
            _response = _client.Post(_request);
        }

        internal sealed partial class ResponseDeserializer
        { }
    }
}