using RestSharp;

namespace DropBox
{
    public abstract class RequestSender
    {
        protected static readonly string _token = "Bearer sl.A-ZIIrYVjPjNvoi-a6EYwYP-WByqmEzaM2gyE0O0Vi50tXh6rt6GATIxys3jqoH0yFgVDrzz9Rz1Jg9T6GZxLs0crHpfQ3CvMkg_OPZx0CqfOzBRJNszjbEBZxJL6RfXekaBrrqEG9E";
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