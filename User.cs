using System.ComponentModel.DataAnnotations;

namespace Lab2_NguyenTruongGiang_CSE422.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")][StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters")] 
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")][EmailAddress(ErrorMessage = "Invalid Email Address")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")][Phone(ErrorMessage = "Invalid Phone Number")] 
        public string PhoneNumber { get; set; }
    }
}
