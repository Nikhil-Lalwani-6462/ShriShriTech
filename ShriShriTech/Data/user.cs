using System.ComponentModel.DataAnnotations;

namespace ShriShriTech.Data
{
    public class user
    {
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Contact No is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a 10-digit mobile number")]
        [Display(Name = "Contact No")]
        public string? ContactNo { get; set; }

        [Required(ErrorMessage = "Store Name is required")]
        [Display(Name = "Store Name")]
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed")]
        public string? Designation { get; set; }

        [Required(ErrorMessage = "Store Address is required")]
        [StringLength(250)]
        [Display(Name = "Store Address")]
        public string? Store_Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Enter a 6-digit pincode")]
        public string? Pincode { get; set; }

        [Required(ErrorMessage = "District is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed")]
        public string? District { get; set; }

        [Required(ErrorMessage = "State is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [Display(Name = "Password")]
        public string? Pass { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Pass", ErrorMessage = "Confirm Password must match Password")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPass { get; set; }
    }
}