using ResourceManagement.Model;

namespace ResourceManagement.Data.Abstract
{
    public interface IResourceRepository : IEntityBaseRepository<ResourceInfo> { }

    //Sangee
    public interface ITimeSheetInfoRepository : IEntityBaseRepository<TimeSheetInfo> { }

    public interface IProjectsRepository : IEntityBaseRepository<Projects> { }

    public interface ITimeSheetEntryRepository : IEntityBaseRepository<TimeSheetEntry> { }

    public interface IEngagementResourceRepository : IEntityBaseRepository<EngagementResource> { }
    
}
