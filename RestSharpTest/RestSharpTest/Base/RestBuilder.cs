using RestSharp;

namespace RestSharpTest.Base
{
    public interface IRestBuilder
    {
        IRestBuilder WithBody(object body);
        Task<T?> WithDelete<T>();
        Task<T?> WithGet<T>();
        IRestBuilder WithHeader(string name, string value);
        IRestBuilder WithFile(string file, string path, string contentType);
        Task<T?> WithPatch<T>();
        Task<T?> WithPost<T>();
        Task<RestResponse> WithPost();
        Task<T?> WithPut<T>();
        IRestBuilder WithQueryParameter(string name, string value);
        IRestBuilder WithRequest(string request);
        IRestBuilder WithUrlSegment(string name, string value);
    }

    public class RestBuilder : IRestBuilder
    {
        private readonly IRest _rest;
        public RestBuilder(IRest rest)
        {
            _rest = rest;
        }

        private RestRequest RestRequest { get; set; } = null!;

        public IRestBuilder WithRequest(string request)
        {
            RestRequest = new RestRequest(request);
            return this;
        }

        public IRestBuilder WithHeader(string name, string value)
        {
            RestRequest.AddHeader(name, value);
            return this;
        }

        public IRestBuilder WithQueryParameter(string name, string value)
        {
            RestRequest.AddQueryParameter(name, value);
            return this;
        }

        public IRestBuilder WithUrlSegment(string name, string value)
        {
            RestRequest.AddUrlSegment(name, value);
            return this;
        }

        public IRestBuilder WithBody(object body)
        {
            RestRequest.AddJsonBody(body);
            return this;
        }

        public IRestBuilder WithFile(string file, string path, string contentType)
        {
            RestRequest.AddFile(file, path, contentType);
            return this;
        }

        public async Task<T?> WithGet<T>()
        {
            return await _rest.RestClient.GetAsync<T>(RestRequest);
        }

        public async Task<T?> WithPost<T>()
        {
            return await _rest.RestClient.PostAsync<T>(RestRequest);
        }

        public async Task<RestResponse> WithPost()
        {
            return await _rest.RestClient.PostAsync(RestRequest);
        }

        public async Task<T?> WithPut<T>()
        {
            return await _rest.RestClient.PutAsync<T>(RestRequest);
        }

        public async Task<T?> WithDelete<T>()
        {
            return await _rest.RestClient.DeleteAsync<T>(RestRequest);
        }

        public async Task<T?> WithPatch<T>()
        {
            return await _rest.RestClient.PatchAsync<T>(RestRequest);
        }
    }
}
