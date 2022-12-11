using System.ComponentModel.DataAnnotations;

namespace connect.Models
{
    public class UserSignin
    {
        [Required(ErrorMessage = "login")]
        [MinLength(4, ErrorMessage = "Min Lenght 4")]
        [MaxLength(24, ErrorMessage = "Max Lenght 24")]
        public string UserLogin { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password")]
        [MinLength(4, ErrorMessage = "Min Lenght 4")]
        [MaxLength(24, ErrorMessage = "Max Lenght 24")]
        public string UserPassword { get; set; }


    }
}
