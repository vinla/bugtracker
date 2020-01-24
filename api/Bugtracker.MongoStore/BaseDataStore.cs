using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bugtracker.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bugtracker.MongoStore
{
    public abstract class BaseDataStore<TRecord> where TRecord : DataRecord
    {
        private readonly MongoOptions _options;
        private readonly Lazy<IMongoCollection<TRecord>> _getCollection;        

        protected BaseDataStore(IOptions<MongoOptions> options)
        {
            _options = options.Value;
            _getCollection = new Lazy<IMongoCollection<TRecord>>(() => 
            {
                return GetDatabase().GetCollection<TRecord>(CollectionName);
            });
        }        

        public async Task<IEnumerable<TRecord>> Get()
        {
            return (await Collection.FindAsync(FilterDefinition<TRecord>.Empty)).ToList();
        }

        public async Task<TRecord> GetById(string recordId)
        {
            var results = await Collection.FindAsync(CreateFilter(b => b.Id == recordId));
            return results.SingleOrDefault();            
        }

        public Task Insert(TRecord record)
        {
            return Collection.InsertOneAsync(record);
        }

        public Task Update(TRecord record)
        {
            return Collection.ReplaceOneAsync(CreateFilter(b => b.Id == record.Id), record);
        }

        public async Task Update(string recordId, Action<TRecord> action)
        {
            var record = await GetById(recordId);
            if(record == null)
                throw new InvalidOperationException("Unable to find specified record");
            action(record);
            await Update(record);
        }
        
        private IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(_options.ConnectionString);
            return client.GetDatabase(_options.DatabaseName);
        }

        private FilterDefinition<TRecord> CreateFilter(Expression<Func<TRecord, bool>> predicate)
        {
            return Builders<TRecord>.Filter.Where(predicate);
        }

        protected virtual IMongoCollection<TRecord> Collection => _getCollection.Value;

        protected abstract string CollectionName { get; }
    }

    public class MongoOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set;}        
    }
}
