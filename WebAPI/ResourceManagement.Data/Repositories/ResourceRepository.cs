using ResourceManagement.Data.Abstract;
using ResourceManagement.Model;

namespace ResourceManagement.Data.Repositories
{ 
    public class ResourceRepository : EntityBaseRepository<ResourceInfo>, IResourceRepository
    {
        public ResourceRepository(ResourceManagementContext context)
            : base(context)
        { }
    }
}
