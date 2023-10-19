using RestSharp;
using RestSharpProject.Data;

namespace RestSharpProject;

public static class ApiSteps
{
    public static ListOfUsers? GetUsersStep()
    {
        var user = new ApiHelper<ListOfUsers>();
        var client = user.SetUrl("api/users?page=2");
        var request = user.CreateGetRequest();
        var response = user.GetResponse(client, request);
        return ApiHelper<ListOfUsers>.GetContent(response);
    }

    public static PostUser? PostUserStep(string requestBody)
    {
        var user = new ApiHelper<PostUser>();
        var client = user.SetUrl("api/users");
        var request = user.CreatePostRequest(requestBody);
        var response = user.GetResponse(client, request);
        return ApiHelper<PostUser>.GetContent(response);
    }

    public static Login? LoginStep(string requestBody)
    {
        var user = new ApiHelper<Login>();
        var client = user.SetUrl("api/login");
        var request = user.CreatePostRequest(requestBody);
        var response = user.GetResponse(client, request);
        return ApiHelper<Login>.GetContent(response);
    }

    public static UpdateUser? UpdateUserStep(string requestBody)
    {
        var user = new ApiHelper<UpdateUser>();
        var client = user.SetUrl("api/users/2");
        var request = user.CreatePutRequest(requestBody);
        var response = user.GetResponse(client, request);
        return ApiHelper<UpdateUser>.GetContent(response);
    }

    public static IRestResponse DeleteStep()
    {
        var user = new ApiHelper<ListOfUsers>();
        var client = user.SetUrl("api/users/2");
        var request = user.CreateDeleteRequest();
        var response = user.GetResponse(client, request);
        return response;
    }
    
}