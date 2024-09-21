using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models
{
    public class ShopUser : IdentityUser
    {
        [Display(Name = "Date of birthday")]
        public DateTime DateOfBirth { get; set; }
    }
}
