using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBox3._0.Models
{
    // JH - Removed unmapped struct from models folder and changed the "FileType"
    // To string, Enum not needed for so little options use a List<SelectListItem> instead
    // Removed Data Anotations for troubleshooting purposes
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string ImageName { get; set;}
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string FileType { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
