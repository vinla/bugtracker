using Moq;
using Bugtracker.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bugtracker.MongoStore.Tests
{
    public class TestBugStore : BugStore
    {
        private readonly Mock<IMongoCollection<Bug>> _mockCollection;
        public TestBugStore(IOptions<MongoOptions> options) : base(options)
        {            
            _mockCollection = new Mock<IMongoCollection<Bug>>();
        }

        public Mock<IMongoCollection<Bug>> Mock => _mockCollection;

        protected override IMongoCollection<Bug> Collection => _mockCollection.Object; 
    }
}
