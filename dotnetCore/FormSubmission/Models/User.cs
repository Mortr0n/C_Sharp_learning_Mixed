using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Display(Name="First Name")]
        [Required]
        [MinLength(4, ErrorMessage = "First name must be at least 4 characters long")]
        public string FirstName {get; set;}

        [Display(Name="Last Name")]
        [Required]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 characters long")]
        public string LastName {get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only Positive numbers allowed.")]
        public int Age {get; set;}

        [Display(Name="Email Address")]
        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime FutureDate {get; set;}
    }
}