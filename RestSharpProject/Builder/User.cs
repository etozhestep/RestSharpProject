using Newtonsoft.Json;

namespace RestSharpProject.Builder;

public class User
{
    [JsonProperty("email")] 
    public string? Email { get; private set; }

    [JsonProperty("password")] 
    public string? Pass { get; private set; }

    public class UserBuilder
    {
        private readonly User _user = new();

        public UserBuilder WithEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public UserBuilder WithPassword(string? pass)
        {
            _user.Pass = pass;
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}