namespace ClientWeb.Clients.ProfileService;

// TODO: Change it - remove commands with dto or view model
public sealed class CreateUserProfileCommand
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
