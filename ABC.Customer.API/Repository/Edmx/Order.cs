using System;
using System.Collections.Generic;

#nullable disable

namespace ABC.Customer.API.Repository.Edmx
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string ProductVariation { get; set; }
        public string DeliveryAddress { get; set; }
        public string MailingAddress { get; set; }
        public string PaymentType { get; set; }
    }
}
