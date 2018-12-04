using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class ProductDetail
    {
        [Display(Name = "Item ID")]
        public int ProductId { get; set; }
        [Display(Name = "Category")]
        public ItemType TypeOfItem { get; set; }
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Serial Number")]
        public string Serial { get; set; }
        [Display(Name = "Notes")]
        public string Notes { get; set; }
        public override string ToString() => $"[{ProductId}] {Name}";
    }
}
