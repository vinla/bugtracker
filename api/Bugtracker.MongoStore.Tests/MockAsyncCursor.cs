using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bugtracker.MongoStore.Tests
{
    public class MockAsyncCursor<T> : IAsyncCursor<T>
    {
        private int _index = -1;
        private List<T> _list;

        public MockAsyncCursor()
        {
            _list = new List<T>();
        }
        public IEnumerable<T> Current => _list;

        public List<T> List => _list;

        public void Dispose()
        {
        }

        public bool MoveNext(CancellationToken cancellationToken = default)
        {
            _index++;
            return _index < _list.Count;
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(MoveNext());
        }
    }
}
