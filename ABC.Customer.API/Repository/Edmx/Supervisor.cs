﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ABC.Customer.API.Repository.Edmx
{
    public partial class Supervisor
    {
        public int SupervisorId { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string AccessPin { get; set; }
        public string CreditLimit { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
