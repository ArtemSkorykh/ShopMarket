using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        public string? Description { get; set; }       
        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }=default!;
        
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = default!;
        public ICollection<Image>? Images { get; set; }
    }
}
