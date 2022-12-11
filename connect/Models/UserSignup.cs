using System.ComponentModel.DataAnnotations;

namespace connect.Models
{
    public class UserSignup
    {
        [Required(ErrorMessage = "login")]
        [MinLength(4,ErrorMessage ="Min Lenght 4")]
        [MaxLength(24, ErrorMessage = "Max Lenght 24")]
        public string UserLogin { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password")]
        [MinLength(4, ErrorMessage = "Min Lenght 4")]
        [MaxLength(24, ErrorMessage = "Max Lenght 24")]
        public string UserPassword { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password")]
        [Compare(otherProperty:"password",ErrorMessage = "different passwords")]
        [MinLength(4, ErrorMessage = "Min Lenght 4")]
        [MaxLength(24, ErrorMessage = "Max Lenght 24")]
        public string UserConfirmPassword { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "email")]
        public string UserEmail { get; set; }
    }
}
