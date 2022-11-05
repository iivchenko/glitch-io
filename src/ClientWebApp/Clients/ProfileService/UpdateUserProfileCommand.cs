namespace ClientWeb.Clients.ProfileService;

public sealed class UpdateUserProfileCommand
{
    public string UserName { get; init; }

    public string? UserDescription { get; init; }
}