using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharpProject;

namespace APITests;

[AllureNUnit]
public class Tests
{
    [Test]
    [AllureDescription("Verifying list of users")]
    public void VerifyPageListOfUsers()
    {
        var response = ApiSteps.GetUsersStep();
        Assert.That(response?.Page, Is.EqualTo(2));
    }

    [Test]
    public void VerifyNameListOfUsers()
    {
        var response = ApiSteps.GetUsersStep();
        Assert.That(response?.Data[1].First_Name, Is.EqualTo("Lindsay"));
    }

    [Test]
    public void PostNewUser()
    {
        const string requestBody = @"{
                     ""name"": ""morpheus"",
                     ""job"": ""leader""
                                }";

        var response = ApiSteps.PostUserStep(requestBody);
        Assert.That(response?.Name, Is.EqualTo("morpheus"));
    }

    [Test]
    public void UpdateUser()
    {
        const string requestBody = @"{
                     ""name"": ""morpheus"",
                     ""job"": ""zion resident""
                                }";
        var response = ApiSteps.UpdateUserStep(requestBody);
        Assert.That(response?.UpdatedAt.ToString(), Does.Contain(DateTimeOffset.Now.DateTime.Minute.ToString()));
    }

    [Test]
    public void Delete()
    {
        Assert.That(ApiSteps.DeleteStep().StatusCode == HttpStatusCode.NoContent);
    }

    [Test]
    public void LoginSuccessful()
    {
        var response = ApiSteps.LoginStep("eve.holt@reqres.in","cityslicka");
        Assert.That(response?.Token, Does.Match("QpwL5tke4Pnpja7X4"));
    }

    [Test]
    public void LoginUnsuccessful()
    {
        var response = ApiSteps.LoginStep("eve.holt@reqres.in","");
        Assert.That(response?.Error, Does.Match("Missing password"));
    }
}