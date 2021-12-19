using RestSharp;
using System.Collections.Generic;

namespace DropBox
{
    public sealed class FileMetaDataReceiver : RequestSender
    {
        private readonly Dictionary<string, string> _body = new Dictionary<string, string>()
        {
            {"path", "/IlliaMamonov.txt"}
        };

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "Authorization", _token },
            { "Content-Type", "application/json"}
        };

        private readonly string _url = "https://api.dropboxapi.com/2/files/get_metadata";

        public FileMetaDataReceiver() : base() => _client = new RestClient(_url);

        public override void BuildRequest()
        {
            _request.AddHeaders(_headers);
            _request.AddJsonBody(_body);
        }

        public void GetMetaData()
        {
            _response = _client.Post(_request);
        }
    }
}