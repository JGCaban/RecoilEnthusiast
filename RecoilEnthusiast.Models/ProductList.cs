using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    //public enum ItemType {[Display(Name = "Firearms")] Firearm = 1, [Display(Name = "Knives")] Knives, [Display(Name = "Ammunition")] Ammo, [Display(Name = "Clothing")] Clothing, [Display(Name = "Items")] Item }
    public class ProductList
    {
        [Display(Name="Item ID")]
        public int ProductId { get; set; }
        [Display(Name="Category")]
        public ItemType TypeOfItem { get; set; }
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public override string ToString() => Name;
    }
}
