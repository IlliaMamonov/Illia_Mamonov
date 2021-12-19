using RestSharp;
using System.Collections.Generic;

namespace DropBox
{
    public sealed class FileDeleter : RequestSender
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

        private readonly string _url = "https://api.dropboxapi.com/2/files/delete_v2";

        public FileDeleter() : base() => _client = new RestClient(_url);

        public override void BuildRequest()
        {
            _request.AddHeaders(_headers);
            _request.AddJsonBody(_body);
        }

        public void Delete()
        {
            _response = _client.Post(_request);
        }
    }
}