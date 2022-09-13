using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DojoSurvey.Models
{
    public class Survey
    {
        [Display(Name="Full Name")]
        [Required]
        [MinLength(4, ErrorMessage = "Name must contain at least 4 characters")]
        public string YourName {get; set;}

        [Display(Name = "Dojo Location")]
        [Required]
        public string Location {get; set;}


        [Display(Name = "Favorite Language")]
        [Required]
        public string Language {get; set;}

        [Display(Name = "Comment")]
        [Required]
        [MinLength(5, ErrorMessage = "Comment must be 5 characters.")]
        public string Comment {get; set;}
    }
}