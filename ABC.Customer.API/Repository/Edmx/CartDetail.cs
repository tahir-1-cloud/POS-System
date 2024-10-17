using System;
using System.Collections.Generic;

#nullable disable

namespace ABC.Customer.API.Repository.Edmx
{
    public partial class CartDetail
    {
        public int CartId { get; set; }
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string UnitCharge { get; set; }
        public string Retail { get; set; }
        public string Total { get; set; }
        public int? Quantity { get; set; }
        public int? Count { get; set; }
        public bool? PendingForApproval { get; set; }
        public bool? IsDelivered { get; set; }
        public string TicketId { get; set; }
        public string Tax { get; set; }
        public string TotalTaxes { get; set; }
        public string InvoiceNumber { get; set; }
    }
}
