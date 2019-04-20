using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RecipeBox3._0.Models;
using RecipeBox3._0.Models.Abstract;
using RecipeBox3._0.Data;

namespace RecipeBox3._0.Models.Concrete
{
    public class CrudRepository : ICrudRepository<Recipe>
    {
        private readonly RecipeDbContext _context;
        public IQueryable<Recipe> Recipes { get { return _context.Recipes; } }
        public IEnumerable<Instructions> Instructions { get { return _context.Instructions; } }
        public IEnumerable<Ingredient> Ingredients { get { return _context.Ingredient; } }
        public CrudRepository(RecipeDbContext Context)
        {
            _context = Context;
        }
        public async Task<Recipe> FindAsync(int? Id)
        {
            return await _context.Recipes.FindAsync(Id);
        }
        public void Add(Recipe recipe)
        {
            _context.Add(recipe);
            _context.SaveChanges();
        }
        public void Update(Recipe recipe)
        {
            _context.Update(recipe);
            _context.SaveChanges();
        }
        public void Remove(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }
    }
}
