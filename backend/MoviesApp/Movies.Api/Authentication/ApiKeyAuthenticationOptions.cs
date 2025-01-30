using Microsoft.AspNetCore.Authentication;

namespace Movies.Api.Authentication
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string? ApiKey { get; set; }
    }
}
