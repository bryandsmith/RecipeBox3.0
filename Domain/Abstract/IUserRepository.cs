using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;
using System.Text;

namespace Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<Recipe> GetUserRecipes(string ownerID);
        IEnumerable<Ingredient> GetIngredients(int recipeID);
        IEnumerable<Instructions> GetInstructions(int userID);
    }
}
