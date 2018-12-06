using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class TransactionDetail
    {
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }
        public LoadoutDesig Designation { get; set; }
        [Display(Name = "Issuer: ")]
        public string IssuerName { get; set; }
        [Display(Name = "Transaction Date: ")]
        public DateTime TransactionDate { get; set; }

        //From CUSTOMER
        [Display(Name = "Receiver's Last Name: ")]
        public string LastName { get; set; }
        //From PRODUCT
        [Display(Name = "Weapon/Item: ")]
        public string Name { get; set; }
        [Display(Name = "Serial: ")]
        public string Serial { get; set; }

        public override string ToString() => $"[{TransactionId}] {IssuerName}";
    }
}
