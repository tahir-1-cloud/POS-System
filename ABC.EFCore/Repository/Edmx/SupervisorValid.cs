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
    public class SupervisorValid
    {
        public AspNetUser AspNetUser { get; set; }
    }
    [MetadataType(typeof(SupervisorValid))]
    public partial class Supervisor
    {
        [NotMapped]
        public AspNetUser AspNetUser { get; set; }


    }
}
