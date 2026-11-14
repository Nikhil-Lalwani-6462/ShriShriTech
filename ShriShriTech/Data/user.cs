using System.ComponentModel.DataAnnotations;

namespace ShriShriTech.Data
{
    public class user
    {

        [Required(ErrorMessage = "FirstName Required")]
        [RegularExpression(@"^[a-zA-Z\s]$",ErrorMessage ="Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required")]
        [RegularExpression(@"^[a-zA-Z\s]$", ErrorMessage = "Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Contact No Required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Only numbers are allowed to add")]
        public int ContactNo { get; set; }

        [Required(ErrorMessage = "StoreName Required")]
        [RegularExpression(@"^[a-zA-Z\s]$", ErrorMessage = "Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "Designation Required")]
        [RegularExpression(@"^[a-zA-Z\s]$", ErrorMessage = "Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? Designation { get; set; }

        [Required(ErrorMessage = "StoreAddress Required")]
        [RegularExpression(@"^[a-zA-Z\s]$", ErrorMessage = "Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? Store_Address { get; set; }
        public string? City { get; set; }

        [Required(ErrorMessage = "Pincode No Required")]
        [RegularExpression(@"^[0-9]$", ErrorMessage = "Only numbers are allowed to add")]
        public int Pincode { get; set; }

        [Required(ErrorMessage = "District Required")]
        [RegularExpression(@"^[a-zA-Z\s]$", ErrorMessage = "Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? District { get; set; }

        [Required(ErrorMessage = "State Required")]
        [RegularExpression(@"^[a-zA-Z\s]$", ErrorMessage = "Only Characters[a-zA-Z] and spaces are allowed to add")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string? Pass { get; set; }

        [Required(ErrorMessage ="Confirm Password Required")]
        [Compare("Pass",ErrorMessage ="Confirm Password must be same as Password")]
        public string? ConfirmPass { get; set; }

    }
}
