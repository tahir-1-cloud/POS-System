﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ABC.Customer.API.Repository.Edmx
{
    public partial class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public bool? TaxExempt { get; set; }
    }
}
