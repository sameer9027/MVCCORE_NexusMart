using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    // PSEUDOCODE PLAN:
    // 1. For each public property that represents a customer field, add a [Display(Name="...")] attribute.
    // 2. Keep existing validation attributes intact.
    // 3. Use clear, user-friendly names (e.g., "Customer ID", "Email", "Country").
    // 4. Do not alter property types or existing validation rules.
    // 5. Leave optional (nullable) properties as they are.

    public class Customer
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int Customer_Id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters")]
        [Display(Name = "Name")]
        public string Customer_Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(25, ErrorMessage = "Phone number cannot exceed 25 characters")]
        [Display(Name = "Phone")]
        public string Customer_Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
        [Display(Name = "Email")]
        public string Customer_Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        [Display(Name = "Password")]
        public string Customer_Password { get; set; } = string.Empty;

        [Display(Name = "Country")]
        public string? Customer_Country { get; set; }

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        [Display(Name = "City")]
        public string? Customer_City { get; set; } = string.Empty;

        [Display(Name = "Address")]
        public string? Customer_Address { get; set; }

        [Display(Name = "Gender")]
        public string? Customer_Gender { get; set; }

        [Display(Name = "Image")]
        public string? Customer_Image { get; set; }
    }
}
