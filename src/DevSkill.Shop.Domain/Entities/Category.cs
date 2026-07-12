using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        [StringLength(255)]
        public string? ImageName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}