using System;
using System.Collections.Generic;
using System.Text;
using ResourceManagement.Data.Repositories;
using ResourceManagement.Data.Abstract;
using ResourceManagement.Model;

namespace ResourceManagement.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ResourceManagementContext _context;

        public UnitOfWork(ResourceManagementContext context) 
        {
            _context = context;
        }

        public IProjectsRepository ProjectsRepository => new ProjectsRepository(_context) ;
        //public IEntityBaseRepository<Projects> ProjectsRepository => new EntityBaseRepository<Projects>(_context) ;

        public IResourceRepository ResourceRepository => new ResourceRepository(_context);

        public IEngagementResourceRepository EngagementResourceRepository => new EngagementResourceRepository(_context);

        public ITimeSheetEntryRepository TimeSheetEntryRepository => new TimeSheetEntryRepository(_context);

        public ITimeSheetInfoRepository TimeSheetInfoRepository => new TimeSheetRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }
    }

}
