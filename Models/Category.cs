using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMarket.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category name")]
        [Required]
        public string CategoryName { get; set; } = default!;
        [Display(Name = "Parent Category")]
        public int? ParentCategoryId { get; set; }
        [ForeignKey(nameof(ParentCategoryId))]
        public Category? ParentCategory { get; set; }
        public ICollection<Category>? ChildCategories { get; set;}
        public ICollection<Product>? Products { get; set;}
    }
}
