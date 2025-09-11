using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    public class Cart
    {
        [Key]
        public int Cart_Id { get; set; }

        public int Cust_Id { get; set; }
        public int Quantity { get; set; }
        public int Prod_ID { get; set; }

        public int Cart_Status { get; set; }

    }
}
