﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace RecipeBox3._0.ViewModels
{
    public class InstructionsViewModel
    {
        [Required]
        public string Instructions { get; set; }

    }
}
