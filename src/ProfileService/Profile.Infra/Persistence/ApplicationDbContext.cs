using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Profile.Application.Common.Interfaces;
using MediatR;
using Profile.Domain.UserProfileAggregate;
using Profile.Domain.Common;
using Microsoft.EntityFrameworkCore.Internal;

namespace Profile.Infra.Persistence
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<UserProfile> Profiles => Set<UserProfile>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // TODO : Eventually refactor to make it more functional
            var entities = 
                ChangeTracker
                   .Entries<Entity>()
                   .Where(e => e.Entity.DomainEvents.Any())
                   .Select(e => e.Entity);

            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            foreach (var entity in entities)
            {
                entity.ClearDomainEvents();
            }

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
