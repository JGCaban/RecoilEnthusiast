using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Data
{
    public enum ItemType { [Display(Name ="Firearms")]Firearm = 1, [Display(Name = "Knives")]Knives, [Display(Name = "Ammunition")] Ammo, [Display(Name = "Clothing")] Clothing, [Display(Name = "Items")]Item }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public ItemType TypeOfItem { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Serial { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}