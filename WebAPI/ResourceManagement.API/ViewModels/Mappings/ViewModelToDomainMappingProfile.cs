using AutoMapper;
using ResourceManagement.Model;

namespace ResourceManagement.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ResourceViewModel, ResourceInfo>();
        }
    }
}
