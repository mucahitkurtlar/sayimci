using System.ComponentModel.DataAnnotations;

namespace Stock.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? CodeName { get; set; }

        public string? Explanation { get; set; }

        public float Cost { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
