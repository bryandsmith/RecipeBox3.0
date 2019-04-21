using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Domain.Entities;
using Domain.Abstract;
using Domain.DataContexts;

namespace Domain.Concrete
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
