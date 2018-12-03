using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class CustomerList
    {
        [Display(Name="Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Display(Name="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public override string ToString() => FirstName;
    }
}
