using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    class CustomerCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool HasFelony { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}