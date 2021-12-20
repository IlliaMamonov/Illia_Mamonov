using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer -MOdbWNZszcAAAAAAAAAAbtCE3IppawONF1s1pPR-4wPIJvTalAXfQcL4hMAyZ0L";
        protected static string s_fileName;
        protected IRestClient _client;
        protected IRestRequest _request;
        protected IRestResponse _response;

        public RequestSender()
        {
            _request = new RestRequest();
        }

        public static string FileName => s_fileName;

        public IRestResponse Response => _response;

        public abstract void BuildRequest();
    }
}