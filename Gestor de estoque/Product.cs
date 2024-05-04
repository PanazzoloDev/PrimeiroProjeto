using System;

namespace Gestor
{
    public class Product 
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Author { get; set; }
        public long Quantity { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public decimal? Freight { get; set; }
    }
}
