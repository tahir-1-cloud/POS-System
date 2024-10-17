using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.EFCore.Repository.Edmx
{
    public class CartDetailValidate
    {
    }
    [MetadataType(typeof(CartDetailValidate))]
    public partial class CartDetail
    {

        [NotMapped]
        public Product ProductObj { get; set; }
    }
}
