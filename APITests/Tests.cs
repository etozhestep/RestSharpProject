using System.Net;
using NUnit.Framework;
using RestSharpProject;

namespace APITests;

public class Tests
{
    [Test]
    public void VerifyPageListOfUsers()
    {
        var response = ApiSteps.GetUsersStep();
        Assert.That(response!.Page, Is.EqualTo(2));
    }

    [Test]
    public void VerifyNameListOfUsers()
    {
        var response = ApiSteps.GetUsersStep();
        Assert.That(response!.Data[1].First_Name, Is.EqualTo("Lindsay"));
    }

    [Test]
    public void PostNewUser()
    {
        const string requestBody = @"{
                     ""name"": ""morpheus"",
                     ""job"": ""leader""
                                }";

        var response = ApiSteps.PostUserStep(requestBody);
        Assert.That(response!.Name, Is.EqualTo("morpheus"));
    }

    [Test]
    public void UpdateUser()
    {
        const string requestBody = @"{
                     ""name"": ""morpheus"",
                     ""job"": ""zion resident""
                                }";
        var response = ApiSteps.UpdateUserStep(requestBody);
        Assert.That(response!.UpdatedAt.ToString(), Does.Contain(DateTimeOffset.Now.DateTime.Minute.ToString()));
    }

    [Test]
    public void Delete()
    {
        Assert.That(ApiSteps.DeleteStep().StatusCode == HttpStatusCode.NoContent);
    }

    [Test]
    public void LoginSuccessful()
    {
        const string requestBody = @"{
                     ""email"": ""eve.holt@reqres.in"",
                     ""password"": ""cityslicka""
                                      }";
        var response = ApiSteps.LoginStep(requestBody);
        Assert.That(response!.Token, Does.Match("QpwL5tke4Pnpja7X4"));
    }

    [Test]
    public void LoginUnsuccessful()
    {
        const string requestBody = @"{
                     ""email"": ""eve.holt@reqres.in""
                                      }";
        var response = ApiSteps.LoginStep(requestBody);
        Assert.That(response!.Error, Does.Match("Missing password"));
    }
}