﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public bool IsPublic { get; set; }
        public virtual ICollection<RecipeIngredients> Ingredients { get; set; }
        public virtual ICollection<Instructions> Instructions { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
