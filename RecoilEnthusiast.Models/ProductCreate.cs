using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class ProductCreate
    {
        [Required]
        [Display(Name="Category")]
        public ItemType TypeOfItem { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string Model { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string Serial { get; set; }
        [MaxLength(5000)]
        public string Notes { get; set; }

        public override string ToString() => Name;
    }
}
