using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class TransactionCreate
    {
        [Required]
        public LoadoutDesig Designation { get; set; }
        [Required]
        [Display(Name = "Last name of recepient: ")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Weapon/Item being issued: ")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Name of Issuer: ")]
        public string IssuerName { get; set; }
        [Required]
        [Display(Name = "Transaction Date: ")]
        public DateTime TransactionDate { get; set; }

        public override string ToString() => IssuerName;
    }
}
