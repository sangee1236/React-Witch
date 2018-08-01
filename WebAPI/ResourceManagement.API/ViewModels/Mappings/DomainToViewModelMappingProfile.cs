using AutoMapper;
using ResourceManagement.Model;

namespace ResourceManagement.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ResourceInfo, ResourceViewModel>();
        }
    }
}
