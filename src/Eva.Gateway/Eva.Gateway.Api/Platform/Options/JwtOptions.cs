namespace Eva.Gateway.Api.Platform.Options;

public sealed class JwtOptions
{
    public static readonly string SectionName = "JwtConfiguration";

    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
}
