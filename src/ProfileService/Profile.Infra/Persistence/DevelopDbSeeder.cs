using Microsoft.Extensions.Logging;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Infra.Persistence;

public sealed class DevelopDbSeeder
{
    private readonly ILogger<DevelopDbSeeder> _logger;
    private readonly ApplicationDbContext _context;

    public DevelopDbSeeder(
        ILogger<DevelopDbSeeder> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Profiles.Any())
        {
            _context.Profiles.Add(UserProfile.Create(UserProfileName.Create("Ivan"), "Cool guy!"));
            _context.Profiles.Add(UserProfile.Create(UserProfileName.Create("Slava"), "Cool girl!"));
           
            await _context.SaveChangesAsync();
        }
    }
}
