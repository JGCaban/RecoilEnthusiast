using RecoilEnthusiast.Data;
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
        public int TransactionId { get; set; }
        public LoadoutDesig Designation { get; set; }
        public string IssuerName { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public override string ToString() => IssuerName;
    }
}
