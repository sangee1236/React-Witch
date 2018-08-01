using ResourceManagement.Data.Abstract;
using ResourceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagement.Data.UnitOfWork;

namespace ResourceManagement.Data.Model
{
    public class ProjectModel : IProjectModal 
    {
        #region Private declartions
        private IUnitOfWork _unitOfWork;
        #endregion
        #region constructor
        public ProjectModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Crud Projects 

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :13 Jan ,2017
        /// Description: To Add a new project 
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        public bool AddProjects(Projects projects)
        {
            try
            {
                _unitOfWork.ProjectsRepository.Add(projects);
                _unitOfWork.Commit();
                if (projects.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :13 Jan ,2017
        /// Description :To update a existing project details
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool UpdateProject(Projects project)
        {
            try
            {
                Projects _projectDb = _unitOfWork.ProjectsRepository.GetSingle(project.Id);

                if (_projectDb == null)
                    return false;
                else
                {
                    if (!string.IsNullOrEmpty(project.Name))
                        _projectDb.Name = project.Name;
                    if (!string.IsNullOrEmpty(project.Status.ToString()))
                        _projectDb.Status = project.Status;
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :13 Jan ,2017
        /// Description :To delete a existing project 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public bool DeleteProject(int ProjectId)
        {
            try
            {
                Projects _projectsDb = _unitOfWork.ProjectsRepository.GetSingle(ProjectId);
                if (_projectsDb == null)
                    return false;
                else
                {
                    _unitOfWork.ProjectsRepository.Delete(_projectsDb);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        #endregion

        #region Get project
        /// <summary>
        /// CreatedBy : Dalz,Ranjith,Gouthami ella
        /// CreatedOn : 13 Jan ,2017
        /// Description: To get entire project List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Projects> GetProjectsList()
        {
            IEnumerable<Projects> projects = Enumerable.Empty<Projects>();
            try
            {
                projects = _unitOfWork.ProjectsRepository.GetAll();
                return projects;
            }
            catch (Exception ex) { return projects; }
        }

        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn : 13 Jan ,2017
        /// Description: get Projects based on resource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Projects> GetProjectsList(int resoureId)
        {
            IEnumerable<Projects> projectList = Enumerable.Empty<Projects>();
            try
            {
                projectList = from e in _unitOfWork.EngagementResourceRepository.FindBy(x => x.ResourceId == resoureId)
                              join d in _unitOfWork.ProjectsRepository.FindBy(y=>y.Status == true) on e.ProjectId equals d.Id
                              select new Projects
                              {
                                  Id = e.ProjectId,
                                  Name = d.Name
                              };
                return projectList;
            }
            catch (Exception ex) { return projectList; }
        }
        #endregion

        #region assign project to resources
        /// <summary>
        /// CreatedBy  : Dalz,Ranjith,Gouthami ella
        /// CreatedOn  : 13 Jan , 2017
        /// Description : Add new Project to resource
        /// </summary>
        /// <param name="engagementResource"></param>
        /// <returns></returns>
        public bool AddResourceProject(EngagementResource engagementResource)
        {
            try
            {
                EngagementResource _resourceExistDb = _unitOfWork.EngagementResourceRepository.GetSingle(x => x.ProjectId == engagementResource.ProjectId && x.ResourceId == engagementResource.ResourceId);
                if (_resourceExistDb == null)
                    _unitOfWork.EngagementResourceRepository.Add(engagementResource);
                else
                    _unitOfWork.EngagementResourceRepository.Update(engagementResource);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// Created By  : Dalz,Ranjith,Gouthami ella
        /// Created On  : 13 Jan , 2017
        /// Description : Delete an project for a resource
        /// </summary>
        /// <param name="engagementResource"></param>
        /// <returns></returns>
        public bool DeleteResourceProject(EngagementResource engagementResource)
        {
            try
            {
                EngagementResource _resourceExistDb = _unitOfWork.EngagementResourceRepository.GetSingle(x => x.ProjectId == engagementResource.ProjectId && x.ResourceId == engagementResource.ResourceId);
                if (_resourceExistDb == null)
                    return false;
                _unitOfWork.EngagementResourceRepository.DeleteWhere(x => x.ResourceId == engagementResource.ResourceId && x.ProjectId == engagementResource.ProjectId);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        #endregion
    }
}
