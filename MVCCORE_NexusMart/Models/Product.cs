using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCORE_NexusMart.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Product_Name { get; set; }


        [DataType(DataType.Currency)]
        public decimal Product_Price { get; set; }

        public string Product_Image { get; set; }

        [StringLength(500)]
        public string Product_Description { get; set; }
        // FOREIGN KEY (by convention: NavigationPropertyName + "Id")
        public int Category_Id { get; set; }


        //navigation property

        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
    }
}
