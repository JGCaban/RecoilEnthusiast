using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Data
{
    public enum ItemType { Firearm = 1, Knives, Ammo, Clothing, Target }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public ItemType TypeOfItem { get; set; }
        [Required]
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