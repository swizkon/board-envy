
namespace BoardEnvy.Domain.Interfaces
{
    using System.Collections.Generic;
    
    public interface IRepository<T> where T : class
    {
        IList<T> All(string partitionKey);

        T Get(string partitionKey, string entityKey);
    }
}
