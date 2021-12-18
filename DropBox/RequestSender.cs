using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer sl.A-YJxi9eP506xC0LOtuw2835piDkSaUDurWdO47W2GJdRwZSoBAkO2N3pi6-mMVXCugEybLu8Hxsh0vL5EW9oQzEVDCcyjfnI2xekWCWrUIoNo8y-y0-zyyA8liGvfsHfQqq0p0";
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