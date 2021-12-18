using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer sl.A-ZPkpHsTJfpYMFmhUPxIxCkx4mLkY2Jm6c2ZVbp5dQBBU1KQ2vD4Ak6_YoA-xcm_gMuygOqJFgRBHW-G2x3jLGjTzWH7eTsMjRMzob67EEK98CufbZJVkmBOhLIveI7OSij7-EXEGg";
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