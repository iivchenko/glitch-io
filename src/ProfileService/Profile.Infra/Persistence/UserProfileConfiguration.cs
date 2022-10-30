using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Infra.Persistence;

public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("profiles");

        builder.OwnsOne(x => x.Name).Property(x => x.Value)
            .HasMaxLength(UserProfileConstraints.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(UserProfileConstraints.DescriptionMaxLength);
    }
}
