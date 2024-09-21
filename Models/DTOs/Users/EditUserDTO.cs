using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Models.DTOs.Users
{
    public class EditUserDTO
    {
        public string Id { get; set; } = default!;
        [Required]
        public string Login { get; set; } = default;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default;
        [Display(Name = "Date of birthday")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
