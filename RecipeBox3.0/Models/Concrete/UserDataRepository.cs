using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RecipeBox3._0.Models.Abstract;
using RecipeBox3._0.Data;
using Domain.Abstract;

namespace RecipeBox3._0.Models.Concrete
{
    public class UserDataRepository :  IUserRepository
    {
        private readonly RecipeDbContext _context;
        public UserDataRepository(RecipeDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Recipe> GetUserRecipes(string OwnerId)
        {
            return _context.Recipes.Where(r => r.Owner == OwnerId);
        }
        public IEnumerable<Ingredient> GetIngredients(int RecipeId)
        {
            return _context.Ingredient.Where(i => i.IngredientId == RecipeId);
        }
        public IEnumerable<Instructions> GetInstructions(int RecipeId)
        {
            return _context.Instructions.Where(i => i.InstrutionsId == RecipeId);
        }
    }
}
