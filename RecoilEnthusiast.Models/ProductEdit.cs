using RecoilEnthusiast.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoilEnthusiast.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public ItemType TypeOfItem { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string Notes { get; set; }
    }
}
