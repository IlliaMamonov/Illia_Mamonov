using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer sl.A-YIHcBY83n552CM8H4aIhwuoj3k9_otp6ur-37SFSyMDJ3VfwqMCdE2gLjTZ5AgJi3XxyAvZsY-U5PSGPKgRQTk6ztqJEmxDelrwOFCLxTdKjHN8b0U_b2-s-EG2AII7xLomOfSV00";
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