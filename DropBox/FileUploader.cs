using RestSharp;
using System.Collections.Generic;

namespace DropBox
{
    public sealed class FileUloader : RequestSender
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "Authorization", _token },
            { "Dropbox-API-Arg", "{\"path\": \"/IlliaMamonov.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}" },
            { "Content-Type", "application/octet-stream" }
        };

        private readonly string _url = "https://content.dropboxapi.com/2/files/upload";

        public FileUloader() : base() => _client = new RestClient(_url);

        public override void BuildRequest()
        {
            _request.AddHeaders(_headers);
        }

        public void Upload()
        {
            _response = _client.Post(_request);
        }
    }
}