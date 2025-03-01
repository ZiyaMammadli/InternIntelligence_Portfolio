namespace Portfolio.Infrastructure.Tokens;

public class TokenSettings
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecretKey { get; set; }
    public int AccessTokenValidityInMinutes { get; set; }

}
