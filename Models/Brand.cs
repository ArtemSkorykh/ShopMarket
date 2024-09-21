using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Brand name")]
        [Required]
        public string BrandName { get; set; } = default!;
        [Required]
        public string? Country { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
