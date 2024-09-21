using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models.ViewModels.Account
{
    public class LoginViewModel
    {        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default;        
      
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default;
        [Display(Name="Remember me?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
