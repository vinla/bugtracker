using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bugtracker.Core;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker.Api.Controllers
{
    [Route("v1/api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {        
        private readonly IDataStore<User> _userStore;

        public UsersController(IDataStore<User> userStore)
        {
            _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserRequest request)
        {            
            var user = new User
            {
                Id = await _userStore.GetNextId(),
                Name = request.UserName
            };
            await _userStore.Insert(user);
            return Ok(user);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            return await _userStore.GetById(id);
        }
        
        [HttpGet]
        public async Task<IEnumerable<User>> GetList()
        {
            return await _userStore.Get();
        }
        
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserName(string id, [FromBody] UserRequest request)
        {
            await _userStore.Update(id, user => user.Name = request.UserName);
            return Ok();
        }
    }

    public class UserRequest
    {
        public string UserName { get; set; }
    }
}
