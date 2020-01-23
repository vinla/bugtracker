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

        [HttpPost]
        public async Task<ActionResult<Bug>> Create([FromBody] CreateBugRequest request)
        {            
            var bug = new Bug
            {
                Id = await _bugStore.GetNextId(),
                Title = request.Title,
                Description = request.Description
            };
            await _bugStore.Insert(bug);
            return Ok(bug);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetById(string id)
        {
            return await _bugStore.GetById(id);
        }
        
        [HttpGet]
        public async Task<IEnumerable<Bug>> GetList()
        {
            return await _bugStore.Get();
        }                    

        [HttpDelete("{id}")]
        public async Task<ActionResult> Close(string id)
        {
            await _bugStore.Update(id, bug => bug.IsClosed = true);
            return Ok();
        }

        public class CreateBugRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }    
}
