using AutoMapper;

namespace Profile.Application.Common.Mapping;

public interface IMapFrom<T>
{
    void Mapping(AutoMapper.Profile profile) => profile.CreateMap(typeof(T), GetType());
}