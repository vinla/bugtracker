using System;
using System.Threading.Tasks;
using Bugtracker.Core;
using Microsoft.Extensions.Options;

namespace Bugtracker.MongoStore
{
    public class UserStore : BaseDataStore<User>, IDataStore<User>
    {
        public UserStore(IOptions<MongoOptions> options) : base(options)
        {            
        }
        
        public Task<string> GetNextId()
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }

        protected override string CollectionName => "Users";
    }
}