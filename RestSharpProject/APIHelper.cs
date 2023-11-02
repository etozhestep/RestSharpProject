using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using RestSharp;

namespace RestSharpProject;

public class ApiHelper<T>
{
    private const string BaseUrl = "https://reqres.in/";

    [AllureStep("Set up Url")]
    public RestClient SetUrl(string endpoint)
    {
        var url = Path.Combine(BaseUrl, endpoint);
        var restClient = new RestClient(url);
        return restClient;
    }

    [AllureStep("Create Get Request")]
    public RestRequest CreateGetRequest()
    {
        var restRequest = new RestRequest(Method.GET);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.RequestFormat = DataFormat.Json;
        return restRequest;
    }

    [AllureStep("Create Post Request")]
    public RestRequest CreatePostRequest(string requestBody)
    {
        var restRequest = new RestRequest(Method.POST);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
        return restRequest;
    }

    [AllureStep("Create Put Request")]
    public RestRequest CreatePutRequest(string requestBody)
    {
        var restRequest = new RestRequest(Method.PUT);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
        return restRequest;
    }

    [AllureStep("Create Delete Request")]
    public RestRequest CreateDeleteRequest()
    {
        var restRequest = new RestRequest(Method.DELETE);
        return restRequest;
    }

    [AllureStep("Get Response")]
    public IRestResponse GetResponse(RestClient client, RestRequest request)
    {
        return client.Execute(request);
    }

    [AllureStep("Get Content of Response")]
    public static T? GetContent(IRestResponse response)
    {
        var content = response.Content;
        var tObject = JsonConvert.DeserializeObject<T>(content);
        return tObject;
    }
}