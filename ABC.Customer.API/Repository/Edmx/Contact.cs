using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ABC.Customer.API.Repository.Edmx
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
