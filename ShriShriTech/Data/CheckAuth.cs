using System.ComponentModel.DataAnnotations;

namespace ShriShriTech.Data
{
    public class CheckAuth
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Please add an valid mail address")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [MinLength(8)]
        [Display(Name ="Password")]
        public string?  Pass { get; set; }

    }
}
