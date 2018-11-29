using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class TransactionList
    {
        [Display(Name="Transaction ID")]
        public int TransactionId { get; set; }
        [Display(Name="Customer ID")]
        public Guid OwnerId { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Display(Name="Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name="Paid")]
        public decimal PayAmmount { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
