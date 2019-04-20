using RecipeBox3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBox3._0.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
