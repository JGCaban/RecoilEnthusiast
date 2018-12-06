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
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public LoadoutDesig Designation { get; set; }
        [Display(Name = "Issuer: ")]
        public string IssuerName { get; set; }
        [Display(Name = "Transaction Date: ")]
        public DateTime TransactionDate { get; set; }

        //From CUSTOMER
        public virtual Customer Customer { get; set; }
        [Display(Name = "Receiver's Last Name: ")]
        public string LastName { get; set; }

        //From PRODUCT
        public virtual Product Product { get; set; }
        [Display(Name = "Weapon/Item: ")]
        public string Name { get; set; }
        [Display(Name = "Serial: ")]
        public string Serial { get; set; }

        public override string ToString() => IssuerName;
    }
}
