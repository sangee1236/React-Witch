using System;
using System.Collections.Generic;
using System.Text;
using ResourceManagement.Model;

namespace ResourceManagement.Data.Model
{
    public interface IProjectModal
    {
        bool AddProjects(Projects projects);
        bool UpdateProject(Projects project);
        bool DeleteProject(int ProjectId);
        IEnumerable<Projects> GetProjectsList();
        IEnumerable<Projects> GetProjectsList(int resoureId);
        bool AddResourceProject(EngagementResource engagementResource);
        bool DeleteResourceProject(EngagementResource engagementResource);
    }
}

