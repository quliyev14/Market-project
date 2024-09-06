namespace mini_Market_Project;

public sealed class GmailService
{
    public GmailService(string? gmail, string? password)
    {
        this.gmail = gmail;
        this.password = password;
    }

    public string? gmail { get; init; } = default!;
    public string? password { get; set; } = default!;

    public override string ToString() => $"{gmail} {password}";
}