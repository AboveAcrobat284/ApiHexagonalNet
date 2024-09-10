using System;
using System.Collections.Generic;

namespace ApiHexagonalNet.Domain.Models
{
    public class Order
    {
        public string Id { get; set; } = string.Empty; // Asignar valor predeterminado
        public string CustomerName { get; set; } = string.Empty; // Asignar valor predeterminado
        public string CustomerEmail { get; set; } = string.Empty; // Asignar valor predeterminado
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderItem
    {
        public string FlowerId { get; set; } = string.Empty; // Asignar valor predeterminado
        public int Quantity { get; set; }
    }
}
