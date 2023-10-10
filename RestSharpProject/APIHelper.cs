using Newtonsoft.Json;
using RestSharp;

namespace RestSharpProject;

public class ApiHelper<T>
{
    private const string BaseUrl = "https://reqres.in/";

    public RestClient SetUrl(string endpoint)
    {
        var url = Path.Combine(BaseUrl, endpoint);
        var restClient = new RestClient(url);
        return restClient;
    }

    public RestRequest CreateGetRequest()
    {
        var restRequest = new RestRequest(Method.GET);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.RequestFormat = DataFormat.Json;
        return restRequest;
    }

    public RestRequest CreatePostRequest(string requestBody)
    {
        var restRequest = new RestRequest(Method.POST);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
        return restRequest;
    }

    public RestRequest CreatePutRequest(string requestBody)
    {
        var restRequest = new RestRequest(Method.PUT);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
        return restRequest;
    }

    public RestRequest CreateDeleteRequest()
    {
        var restRequest = new RestRequest(Method.DELETE);
        return restRequest;
    }

    public IRestResponse GetResponse(RestClient client, RestRequest request)
    { 
       return client.Execute(request);
    }

    public static T? GetContent<T>(IRestResponse response)
    {
        var content = response.Content;
        var tObject = JsonConvert.DeserializeObject<T>(content);
        return tObject;
    }
}