using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models.DTOs.Users
{
    public class CreateUserDTO
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
    }
}
