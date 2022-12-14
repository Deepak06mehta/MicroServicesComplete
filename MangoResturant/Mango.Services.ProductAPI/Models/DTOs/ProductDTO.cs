using System;

namespace Mango.Services.ProductAPI.Models.DTOs
{
    public class ProductDTO
    {
        public ProductDTO()
        {
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}

