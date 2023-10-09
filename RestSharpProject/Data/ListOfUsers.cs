namespace RestSharpProject.Data;

public class ListOfUsers
{
    public long Page { get; set; }
    public long PerPage { get; set; }
    public long Total { get; set; }
    public long TotalPages { get; set; }
    public List<Datum> Data { get; set; }
    public Support Support { get; set; }
}

public abstract class Datum
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string First_Name { get; set; }
    public string last_Name { get; set; }
    public Uri Avatar { get; set; }
}

public abstract class Support
{
    public Uri Url { get; set; }
    public string Text { get; set; }
}