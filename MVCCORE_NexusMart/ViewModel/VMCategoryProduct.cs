using MVCCORE_NexusMart.Models;
namespace MVCCORE_NexusMart.ViewModel


{
    public class VMCategoryProduct
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Category> Categories { get; set; } = new List<Category>();
        public int SelectedCatagoryId { get; set; }
    }
}
