using RestSharp;
using System;
using System.Collections.Generic;

namespace DropBox
{
    public sealed class FileUploader : RequestSender
    {
        private static int s_randomNumber = new Random().Next(1000, 10000);
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "Authorization", _token },
            { "Dropbox-API-Arg", $"{{\"path\": \"/IlliaMamonov{s_randomNumber}.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}}" },
            { "Content-Type", "application/octet-stream" }
        };

        private readonly string _url = "https://content.dropboxapi.com/2/files/upload";

        public FileUploader() : base()
        {
            _client = new RestClient(_url);
            s_fileName = $"IlliaMamonov{s_randomNumber}.txt";
        }

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