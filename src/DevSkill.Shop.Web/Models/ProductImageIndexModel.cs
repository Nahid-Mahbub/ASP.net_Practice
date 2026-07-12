using Microsoft.AspNetCore.Mvc.Rendering;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Web.Models
{
    public class ProductImageIndexModel
    {
        public int SelectedProductId { get; set; }


        public IEnumerable<SelectListItem> Products { get; set; }
            = new List<SelectListItem>();


        public IEnumerable<ProductImage> Images { get; set; }
            = new List<ProductImage>();
    }
}