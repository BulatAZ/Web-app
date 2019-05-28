namespace RequestAccounting3.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The string length must be between 6 and 20 characters")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "No more than 25 characters")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "No more than 25 characters")]
        public string lastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Сonfirm password")]
        public string PasswordConfirm { get; set; }
    }
}
