using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(100, ErrorMessage = "Brand cannot exceed 100 characters.")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "SKU is required.")]
        [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters.")]
        public string Sku { get; set; } = string.Empty;

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(50, ErrorMessage = "Color cannot exceed 50 characters.")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "Weight is required.")]
        [Range(0.01, 100000, ErrorMessage = "Weight must be greater than 0.")]
        public double Weight { get; set; }

        public Category? Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public Stock? Stock { get; set; }
    }
}