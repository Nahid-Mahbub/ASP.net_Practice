using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a product.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, 100000, ErrorMessage = "Quantity must be 0 or greater.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Low stock quantity is required.")]
        [Range(0, 100000, ErrorMessage = "Low stock quantity must be 0 or greater.")]
        public int LowStockQuantity { get; set; }

        public Product? Product { get; set; }
    }
}