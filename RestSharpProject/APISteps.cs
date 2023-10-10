using RestSharpProject.Data;

namespace RestSharpProject;

public static class ApiSteps
{
    public static ListOfUsers? GetUsersStep()
    {
        var user = new ApiHelper<ListOfUsers>();
        var client = user.SetUrl("api/users?page=2");
        var request = user.CreateGetRequest();
        user.GetResponse(client, request);
        var response = client.Execute(user.CreateGetRequest());
        return ApiHelper<ListOfUsers>.GetContent<ListOfUsers>(response);
    }

    public static PostUser? PostUserStep(string requestBody)
    {
        var user = new ApiHelper<PostUser>();
        var client = user.SetUrl("api/users");
        var request = user.CreatePostRequest(requestBody);
        user.GetResponse(client, request);
        var response = client.Execute(user.CreatePostRequest(requestBody));
        return ApiHelper<PostUser>.GetContent<PostUser>(response);
    }

    public static Login? LoginStep(string requestBody)
    {
        var user = new ApiHelper<Login>();
        var client = user.SetUrl("api/login");
        var request = user.CreatePostRequest(requestBody);
        user.GetResponse(client, request);
        var response = client.Execute(user.CreatePostRequest(requestBody));
        return ApiHelper<Login>.GetContent<Login>(response);
    }

    public static UpdateUser? UpdateUserStep(string requestBody)
    {
        var user = new ApiHelper<UpdateUser>();
        var client = user.SetUrl("api/users/2");
        var request = user.CreatePutRequest(requestBody);
        user.GetResponse(client, request);
        var response = client.Execute(user.CreatePutRequest(requestBody));
        return ApiHelper<UpdateUser>.GetContent<UpdateUser>(response);
    }

    public static int DeleteStep()
    {
        var user = new ApiHelper<ListOfUsers>();
        var client = user.SetUrl("api/users/2");
        var request = user.DeleteRequest();
        user.GetResponse(client, request);
        var response = client.Execute(user.DeleteRequest());
        return (int)response.StatusCode;
    }
}