﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Ingredient
    {
        //public Ingredient()
        //{
          //  this.Recipes = new HashSet<RecipeIngredients>();
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
       
        
       public virtual ICollection<RecipeIngredients> Recipes { get; set; }
      
        //public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
     
        
    }
}
