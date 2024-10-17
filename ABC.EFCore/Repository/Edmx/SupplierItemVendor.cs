using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.EFCore.Repository.Edmx
{
    public class SupplierItemVendor
    {
        public SupplierItemNumber supplierItemNumber { get; set; }
        public PurchaseOrder purchaseOrder { get; set; }
    }

    [MetadataType(typeof(SupplierItemVendor))]
    public partial class Vendor
    {
        [NotMapped]
        public SupplierItemNumber supplierItemNumber { get; set; }
        [NotMapped]
        public PurchaseOrder purchaseOrder { get; set; }
    }
}
