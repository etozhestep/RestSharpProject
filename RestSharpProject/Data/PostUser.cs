namespace RestSharpProject.Data;

public class PostUser
{
    public string Name { get; set; }
    public string Job { get; set; }
    public long Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}