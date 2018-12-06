using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Data
{
    public enum LoadoutDesig { [Display(Name="Longarm")]Longarm=1, [Display(Name="Sidearm")]Sidearm, [Display(Name="Accessory")]Accessory, [Display(Name="Item")]Item }
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public LoadoutDesig Designation { get; set; }
        [Required]
        public string IssuerName { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
