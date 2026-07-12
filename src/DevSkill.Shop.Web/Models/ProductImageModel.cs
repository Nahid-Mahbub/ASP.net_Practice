using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DevSkill.Shop.Web.Models
{
    public class ProductImageModel
    {

        [Required(ErrorMessage = "Please select a product.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }



        [Required(ErrorMessage = "Please select an image.")]
        public IFormFile ImageFile { get; set; } = null!;



        [Required(ErrorMessage = "Serial is required.")]
        [Range(1, 1000, ErrorMessage = "Serial must be between 1 and 1000.")]
        public int Serial { get; set; }



        // For dropdown list
        public IEnumerable<SelectListItem>? Products { get; set; }

    }
}