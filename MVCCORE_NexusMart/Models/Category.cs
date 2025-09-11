using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]

        public string Category_Name { get; set; }

        // NAVIGATION PROPERTY (One-to-Many Relationship)
        // 'virtual' enables lazy loading (entities are loaded from database when accessed)
        public virtual List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }


    }

}
