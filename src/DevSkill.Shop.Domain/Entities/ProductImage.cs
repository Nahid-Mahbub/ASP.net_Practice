using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Image name cannot exceed 255 characters.")]
        public string ImageName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a product.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Serial is required.")]
        [Range(1, 1000, ErrorMessage = "Serial must be between 1 and 1000.")]
        public int Serial { get; set; }

        public Product? Product { get; set; }
    }
}