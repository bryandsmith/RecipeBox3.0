using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBox3._0.Models;
using System.Text;

namespace RecipeBox3._0.Models.Abstract
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
