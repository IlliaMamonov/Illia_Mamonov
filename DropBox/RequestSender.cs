using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer sl.A-YPKHfkxJH_7SEpHMuZ5rojxIO_8bHMsTAgRA6uTsKACKFKNqFLOZJDDSjalI-Q7gO9pbN-E7FrK0w9S0P3gS7LZWnmfdV8A_1j5w4rlSvq7WEtyhPTzfAfEWrkpdWdh2yqxnxnCeQ";
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