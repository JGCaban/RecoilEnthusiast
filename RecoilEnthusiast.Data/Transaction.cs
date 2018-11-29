using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string PayMethod { get; set; }
        [Required]
        public decimal PayAmmount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
