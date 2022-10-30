using Profile.Application.Common.Interfaces;

namespace Profile.Infra.Services;

public sealed class DateTimeService : IDateTimeService
{
    public DateTime GetUtcNow() => DateTime.UtcNow;
}
