
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResourceManagement.API.Core;
using ResourceManagement.API.ViewModels;
using ResourceManagement.Data.Abstract;
using ResourceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Resource info api controller
/// </summary>
namespace ResourceManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ResourcesController : Controller
    {

        #region Private declartions
        private IResourceRepository _resourceRepository;
        private int page = 1;
        private int pageSize = 10;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resourceRepository"></param>
        public ResourcesController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        #endregion

        #region CRUD Action methods

        /// <summary>
        /// Get all the resouces
        /// </summary>
        /// <returns></returns>'
        [HttpGet]
        public IActionResult Get()
        {

            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalResources = _resourceRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalResources / pageSize);

            IEnumerable<ResourceInfo> _resources = _resourceRepository
                .GetAll()
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            IEnumerable<ResourceViewModel> _resourcesVM = Mapper.Map<IEnumerable<ResourceInfo>, IEnumerable<ResourceViewModel>>(_resources);

            Response.AddPagination(page, pageSize, totalResources, totalPages);

            return new OkObjectResult(_resourcesVM);
        }


        /// <summary>
        /// Get resource by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetResource")]
        public IActionResult Get(int id)
        {
            ResourceInfo _resource = _resourceRepository.GetSingle(u => u.Id == id, u => u.Status);

            if (_resource != null)
            {
                ResourceViewModel _resourceVM = Mapper.Map<ResourceInfo, ResourceViewModel>(_resource);
                return new OkObjectResult(_resourceVM);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("LogCreds")]
        //[Route("LogCreds")]
        public IActionResult Credentials(string EmailID, string password)
        {

            ResourceInfo _userCredentials = new ResourceInfo { EmailID = EmailID, Password = password };
            //EmailID = userCredentials.EmailID , Password=userCredentials.password};
            ResourceInfo _resource = _resourceRepository.GetCredentials(x => x.EmailID == EmailID && x.Password == password);
            if (_resource != null)
            {
                ResourceViewModel _resourceVM = Mapper.Map<ResourceInfo, ResourceViewModel>(_resource);
                return new OkObjectResult(_resourceVM);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a new Resource
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody]ResourceViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResourceInfo _newResource = new ResourceInfo { Name = user.Name, Status = true, Avatar = user.Avatar };

            _resourceRepository.Add(_newResource);
            _resourceRepository.Commit();

            user = Mapper.Map<ResourceInfo, ResourceViewModel>(_newResource);

            CreatedAtRouteResult result = CreatedAtRoute("GetResource", new { controller = "Resources", id = user.Id }, user);
            return result;
        }

        /// <summary>
        /// Update a Resource
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ResourceViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResourceInfo _resourceDb = _resourceRepository.GetSingle(id);

            if (_resourceDb == null)
            {
                return NotFound();
            }
            else
            {
                _resourceDb.Name = user.Name;
                _resourceDb.Avatar = user.Avatar;
                _resourceRepository.Commit();
            }

            user = Mapper.Map<ResourceInfo, ResourceViewModel>(_resourceDb);

            return new NoContentResult();
        }

        /// <summary>
        /// Removes the Resource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResourceInfo _resourceDb = _resourceRepository.GetSingle(id);

            if (_resourceDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _resourceRepository.Delete(_resourceDb);
                _resourceRepository.Commit();
                return new NoContentResult();
            }
        }

        #endregion
    }

}


