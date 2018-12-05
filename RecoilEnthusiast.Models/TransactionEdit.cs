using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class TransactionEdit
    {
        public int TransactionId { get; set; }
        public LoadoutDesig Designation { get; set; }
        [Display(Name="Name of Issuer: ")]
        public string IssuerName { get; set; }
        [Display(Name = "Transaction Date: ")]
        public DateTime TransactionDate { get; set; }
    }
}
