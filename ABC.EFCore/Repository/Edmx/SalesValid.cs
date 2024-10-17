﻿using ABC.EFCore.Repository.Edmx;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.EFCore.Repository.Edmx
{
    public class SalesValid
    {
        public Supervisor Supervisor { get; set; }
        public SalesManager SalesManager { get; set; }
    }
    [MetadataType(typeof(SalesValid))]
    public partial class PosSale
    {
        [NotMapped]
        public Supervisor Supervisor { get; set; }
        [NotMapped]
        public SalesManager SalesManager { get; set; }
        [NotMapped]

        public string InvDate { get; set; }

    }
}
