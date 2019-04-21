using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
namespace RecipeBox3._0.ViewModels
{
    public class IngredientViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
