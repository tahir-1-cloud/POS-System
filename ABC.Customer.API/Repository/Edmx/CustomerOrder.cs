using System;
using System.Collections.Generic;

#nullable disable

namespace ABC.Customer.API.Repository.Edmx
{
    public partial class CustomerOrder
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public string TicketId { get; set; }
        public string CustomerName { get; set; }
        public string BillingAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public bool? AdminStatus { get; set; }
        public bool? Delivered { get; set; }
        public string OrderAmount { get; set; }
        public string TaxAmount { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
