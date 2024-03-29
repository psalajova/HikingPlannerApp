﻿using System.ComponentModel.DataAnnotations;

namespace Application.Models.UserModels
{
    public class UserCreateModel : BaseModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Maximum length for username is 40 characters")]
        public string Name            { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address")]
        [StringLength(50, ErrorMessage = "Maximum length for email is 50 characters")]
        public string MailAddress     { get; set; }
        [Required]
        public string Password        { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
