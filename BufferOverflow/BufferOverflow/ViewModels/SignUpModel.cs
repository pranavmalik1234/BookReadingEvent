using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BufferOverflow.ViewModels
{
    public class SignUpModel
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Display(Name = "UpLoad Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 8)]
        [RegularExpression("^(?=.*?[A-Za-z])(?=.*?[@$!% *#?&])[A-Za-z0-9@$!%*#?&]{5,}$", ErrorMessage = "Must be at least 8 characters & contain at least one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}