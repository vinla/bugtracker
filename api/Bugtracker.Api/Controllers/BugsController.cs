using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bugtracker.Core;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker.Api.Controllers
{
    [Route("v1/api/bugs")]
    [ApiController]
    public class BugsController : ControllerBase
    {        
        private readonly IDataStore<Bug> _bugStore;

        public BugsController(IDataStore<Bug> bugStore)
        {
            _bugStore = bugStore ?? throw new ArgumentNullException(nameof(bugStore));            
        }

        /// <summary>
        /// Creates a new bug in the bugtracker
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Bug>> Create([FromBody] CreateBugRequest request)
        {            
            var bug = new Bug
            {
                Id = await _bugStore.GetNextId(),
                CreatedOn = DateTime.Now,
                Title = request.Title,
                Description = request.Description
            };
            await _bugStore.Insert(bug);
            return Ok(bug);
        }
        
        /// <summary>
        /// Gets details of a specific bug
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetById(string id)
        {
            return await _bugStore.GetById(id);
        }
        
        /// <summary>
        /// Gets a list of all bugs in the system
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Bug>> GetList()
        {
            return await _bugStore.Get();
        }                    

        /// <summary>
        /// Close a specific bug
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Close(string id)
        {
            await _bugStore.Update(id, bug => bug.IsClosed = true);
            return Ok();
        }

        /// <summary>
        /// Assign a user to a bug
        /// </summary>
        [HttpPut("{id}/assignee")]
        public async Task<ActionResult> Assign(string id, [FromBody] AssignUserRequest request)
        {
            await _bugStore.Update(id, bug => bug.AssignedTo = request.UserId);
            return Ok();
        }

        public class CreateBugRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class AssignUserRequest
        {
            public string UserId { get; set; }
        }
    }    
}
