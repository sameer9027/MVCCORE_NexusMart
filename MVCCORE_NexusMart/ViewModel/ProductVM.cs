// Models/VMProduct.cs
using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    public class ProductVM
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [DataType(DataType.Currency)]
        public decimal Product_Price { get; set; }

        [Required(ErrorMessage = "Please select a product image")]
        public IFormFile ProductImageFile { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Product_Description { get; set; }

        [Required(ErrorMessage = "Please enter a category ID")]

        public int Category_Id { get; set; }

    }
}