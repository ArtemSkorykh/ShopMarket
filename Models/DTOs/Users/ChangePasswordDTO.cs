using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models.DTOs.Users
{
    public class ChangePasswordDTO
    {
        public string Id { get; set; } = default!;
     
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default;
        [Required]
        [Display(Name = "Old password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = default;
        [Required]
        [Display(Name = "New password")]
        [DataType(DataType.Password)]       
        public string NewPassword { get; set; } = default;
    }
}
