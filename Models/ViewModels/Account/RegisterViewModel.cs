using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
       
        [Required]
        public string Login { get; set; } = default;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default;
        [Display(Name = "Date of birthday")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default;
        [Required]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Passwordsn should match!")]
        public string ConfirmPassword { get; set; } = default;

    }
}
