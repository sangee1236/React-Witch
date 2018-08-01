using ResourceManagement.Data.Abstract;
using ResourceManagement.Data.Repositories;
using ResourceManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProjectsRepository ProjectsRepository { get; }

        IResourceRepository ResourceRepository { get; }

        IEngagementResourceRepository EngagementResourceRepository { get; }

        ITimeSheetEntryRepository TimeSheetEntryRepository { get; }

        ITimeSheetInfoRepository TimeSheetInfoRepository { get; }

        void Commit();
    }
}
