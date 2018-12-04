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
        public string IssuerName { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }

        public override string ToString() => IssuerName;
    }
}
