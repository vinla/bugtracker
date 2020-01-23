using System.Linq;
using System.Threading.Tasks;
using Bugtracker.Core;
using Microsoft.Extensions.Options;

namespace Bugtracker.MongoStore
{
    public class BugStore : BaseDataStore<Bug>, IDataStore<Bug>
    {
        public BugStore(IOptions<MongoOptions> options) : base(options)
        {            
        }
        
        public async Task<string> GetNextId()
        {
            var bugCount = (await Get()).Count();
            return $"BUG-{bugCount+1}";
        }

        protected override string CollectionName => "Bugs";
    }
}