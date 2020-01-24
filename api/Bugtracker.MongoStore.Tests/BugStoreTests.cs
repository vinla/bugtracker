using Moq;
using Bugtracker.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace Bugtracker.MongoStore.Tests
{
    public class BugStoreTests
    {
        [Fact]
        public async Task UpdateAppliesActionToSelectedRecord()
        {
            var mockOptions = new Mock<IOptions<MongoOptions>>();
            mockOptions.SetupGet(m => m.Value).Returns(new MongoOptions{});
            var classUserTest = new TestBugStore(mockOptions.Object);
            var bug = new Bug{};

            var mockCursor = new MockAsyncCursor<Bug>();
            mockCursor.List.Add(bug);
            
            classUserTest.Mock.Setup(m => 
                m.FindAsync<Bug>(
                    It.IsAny<FilterDefinition<Bug>>(),
                    It.IsAny<FindOptions<Bug, Bug>>(),
                    It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor);
            
            await classUserTest.Update("test", b => b.Title = "affected by store");

            Assert.Equal("affected by store", bug.Title);
        }

        [Fact]
        public async Task UpdateThrowsExceptionIfRecordNotFound()
        {
            var mockOptions = new Mock<IOptions<MongoOptions>>();
            mockOptions.SetupGet(m => m.Value).Returns(new MongoOptions{});
            var classUserTest = new TestBugStore(mockOptions.Object);
            var mockCursor = new MockAsyncCursor<Bug>();
            
            classUserTest.Mock.Setup(m => 
                m.FindAsync<Bug>(
                    It.IsAny<FilterDefinition<Bug>>(),
                    It.IsAny<FindOptions<Bug, Bug>>(),
                    It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor);
            
            await Assert.ThrowsAsync<System.InvalidOperationException>(() => classUserTest.Update("test", b => b.Title = "affected by store"));
        }
    }
}
