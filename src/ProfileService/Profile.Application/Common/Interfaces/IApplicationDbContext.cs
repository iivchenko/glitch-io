using Microsoft.EntityFrameworkCore;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserProfile> Profiles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}