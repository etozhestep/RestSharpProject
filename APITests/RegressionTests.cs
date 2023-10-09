using NUnit.Framework;
using RestSharpProject;

namespace APITests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
        Assert.That(ApiSteps.DeleteStep().ToString(), Does.Match("204"));
    }
}