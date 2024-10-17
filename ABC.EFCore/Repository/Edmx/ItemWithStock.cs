using ABC.EFCore.Repository.Edmx;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.EFCore.Repository.Edmx
{
    public class ItemWithStock
    {
        [NotMapped]
        public Sttax stTax { get; set; }
    }
    [MetadataType(typeof(ItemWithStock))]
    public partial class Product
    {
        public InventoryStock Stock { get; set; }
        [NotMapped]
        public Financial Financial { get; set; }
        [NotMapped]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        [NotMapped]
        public virtual ICollection<PosSale> SaleOrders { get; set; }

        [NotMapped]
        public virtual ICollection<Vendor> Vendors { get; set; }
        [NotMapped]
        public Sttax stTax { get; set; }
    }
}
