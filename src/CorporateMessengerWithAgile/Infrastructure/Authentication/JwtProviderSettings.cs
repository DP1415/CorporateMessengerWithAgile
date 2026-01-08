namespace Infrastructure.Authentication
{
    public class JwtProviderSettings
    {
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; } = null!;
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
