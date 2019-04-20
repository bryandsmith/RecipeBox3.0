using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecipeBox3._0.Models;
namespace RecipeBox3._0.ViewModels
{
    public class RecipeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
      
        public List<Ingredient> Ingredients { get; set; }

        public List<Instructions> Instructions { get; set; }
    }
}
