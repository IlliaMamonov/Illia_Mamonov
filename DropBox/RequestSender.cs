using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer -MOdbWNZszcAAAAAAAAAAbtCE3IppawONF1s1pPR-4wPIJvTalAXfQcL4hMAyZ0L";
        protected IRestClient _client;
        protected IRestRequest _request;
        protected IRestResponse _response;
        
        public RequestSender()
        {
            _request = new RestRequest();
        }

        public abstract void BuildRequest();

        public IRestResponse Response => _response;
    }
}