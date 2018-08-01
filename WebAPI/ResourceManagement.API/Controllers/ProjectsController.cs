using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Data.Abstract;
using ResourceManagement.Model;
using ResourceManagement.Data.Repositories;
using ResourceManagement.Data.Model;
using ResourceManagement.Data.UnitOfWork;


namespace ResourceManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        #region Private declartions
        private readonly IProjectModal projectModel;
        #endregion

        #region constructor
        public ProjectsController(IProjectModal _projectModal)
        {
            projectModel = _projectModal;
        }
        #endregion

        #region Adding Project

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :13 Jan ,2017
        /// Description: To Add a new project 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addproject")]
        public IActionResult AddProject(string projectName)
        {
            try
            {
                if (string.IsNullOrEmpty(projectName))
                    return BadRequest();
                else
                {
                    Projects projects = new Projects { Name = projectName, Status = true };
                    bool status = projectModel.AddProjects(projects);
                    if (status)
                        return Ok();
                    else
                        return NotFound();
                }
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :13 Jan ,2017
        /// Description :To update a existing project details
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateproject")]
        public IActionResult UpdateProject([FromBody]Projects project)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = projectModel.UpdateProject(project);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :13 Jan ,2017
        /// Description :To delete a existing project 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteproject")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                bool status = projectModel.DeleteProject(projectId);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion

        #region Get project list
        /// <summary>
        /// Created By : Dalz,Ranjith,Gouthami ella
        /// Created On : 13 Jan ,2017
        /// Description: To get entire project List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allprojectlist")]
        public IActionResult GetProjectsList()
        {
            try
            {
                IEnumerable<Projects> projects = projectModel.GetProjectsList();
                return Ok(projects);
            }
            catch (Exception ex) { return NotFound(ex); }
        }

        /// <summary>
        /// get Projects based on resource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("projectslistbyid")]
        public IActionResult GetProjectsList(int resourceId)
        {
            try
            {
                IEnumerable<Projects> projectList = projectModel.GetProjectsList(resourceId);
                if (projectList == null)
                    return NotFound();
                else
                    return Ok(projectList);
            }
            catch (Exception ex) { return BadRequest(ex); }
            //var studentToStandard = _projectsRepository.GetAll().Join(_engagementResourceRepository.GetAll(),
            //                     Project => Project.Id,
            //                     EngagementResource => EngagementResource.ProjectId,
            //                     (stud, stand) => new { Student = stud, Standard = stand }).ToList();
            //         if (customUser != null)
        }

        #endregion

        #region assign project to resources
        /// <summary>
        ///  Add new Project to resource
        /// Created By  :   Dalz,Ranjith,Gouthami ella
        /// </summary>
        /// <param name="engagementResource"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("addprojectresource")]
        public IActionResult AddResourceProject([FromBody]EngagementResource engagementResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool status = projectModel.AddResourceProject(engagementResource);
                if (status)
                    return Ok();
                else
                    return new NotFoundResult();
            }
            catch (Exception ex) { return NotFound(ex); }
        }

        /// <summary>
        /// Delete an project for a resource
        /// Created By  :   Dalz,Ranjith,Gouthami ella
        /// </summary>
        /// <param name="engagementResource"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("deleteprojectresource")]
        public IActionResult DeleteResourceProject([FromBody]EngagementResource engagementResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = projectModel.DeleteResourceProject(engagementResource);
                if (status)
                    return Ok();
                else
                    return new NotFoundResult();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion
    }
}
