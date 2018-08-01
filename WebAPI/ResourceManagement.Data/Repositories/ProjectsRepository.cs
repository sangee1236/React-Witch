using System;
using System.Collections.Generic;
using System.Text;
using ResourceManagement.Model;
using ResourceManagement.Data.Abstract;
namespace ResourceManagement.Data.Repositories
{
    public class ProjectsRepository : EntityBaseRepository<Projects>, IProjectsRepository
    {
        public ProjectsRepository(ResourceManagementContext context) : base(context)
        {
        }
    }

    public class EngagementResourceRepository : EntityBaseRepository<EngagementResource>, IEngagementResourceRepository
    {
        public EngagementResourceRepository(ResourceManagementContext context) :base(context) {
        }
    }

}
