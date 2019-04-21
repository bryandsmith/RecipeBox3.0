using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Domain.Abstract
{
    public interface ICrudRepository<T>
    {
        IQueryable<T> Recipes { get; }
        Task<T> FindAsync(int? Id);
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
