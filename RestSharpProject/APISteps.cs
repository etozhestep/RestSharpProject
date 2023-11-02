using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using RestSharp;
using RestSharpProject.Builder;
using RestSharpProject.Data;

namespace RestSharpProject;

public static class ApiSteps
{
    [AllureStep("Get Users Step")]
    public static ListOfUsers? GetUsersStep()
    {
        var user = new ApiHelper<ListOfUsers>();
        var client = user.SetUrl("api/users?page=2");
        var request = user.CreateGetRequest();
        var response = user.GetResponse(client, request);
        return ApiHelper<ListOfUsers>.GetContent(response);
    }

    [AllureStep("Post User Step")]
    public static PostUser? PostUserStep(string requestBody)
    {
        var user = new ApiHelper<PostUser>();
        var client = user.SetUrl("api/users");
        var request = user.CreatePostRequest(requestBody);
        var response = user.GetResponse(client, request);
        return ApiHelper<PostUser>.GetContent(response);
    }

    [AllureStep("Login Step")]
    public static Login? LoginStep(string email, string? pass)
    {
        var requestBody = new User.UserBuilder()
            .WithEmail(email)
            .WithPassword(pass)
            .Build();
        var user = new ApiHelper<Login>();
        var client = user.SetUrl("api/login");
        var i = JsonConvert.SerializeObject(requestBody);
        var request = user.CreatePostRequest(JsonConvert.SerializeObject(requestBody));
        var response = user.GetResponse(client, request);
        return ApiHelper<Login>.GetContent(response);
    }

    [AllureStep("Update User Step")]
    public static UpdateUser? UpdateUserStep(string requestBody)
    {
        var user = new ApiHelper<UpdateUser>();
        var client = user.SetUrl("api/users/2");
        var request = user.CreatePutRequest(requestBody);
        var response = user.GetResponse(client, request);
        return ApiHelper<UpdateUser>.GetContent(response);
    }

    [AllureStep("Delete User Step")]
    public static IRestResponse DeleteStep()
    {
        var user = new ApiHelper<ListOfUsers>();
        var client = user.SetUrl("api/users/2");
        var request = user.CreateDeleteRequest();
        var response = user.GetResponse(client, request);
        return response;
    }
}