using System.ComponentModel.DataAnnotations;

namespace CollectionApp.api.Dtos
{
    public class UserForRegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 8,
            ErrorMessage =
                "{0} cannot be shorter than {2} characters or longer than {1} characters. ")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(male|female|others)$",
            ErrorMessage = "Please Select from male, female, and others")]
        public string Gender { get; set; }
    }
}