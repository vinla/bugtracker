using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bugtracker.Core
{

    public interface IDataStore<TRecord> where TRecord : DataRecord
    {
        Task<string> GetNextId();
        Task Insert(TRecord bug);
        Task Update(string recordId, Action<TRecord> action);
        Task<IEnumerable<TRecord>> Get();        
        Task<TRecord> GetById(string recordId);
    }        
}
