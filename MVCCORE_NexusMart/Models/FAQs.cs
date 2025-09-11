using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    public class FAQs
    {
        [Key]
        public int FAQ_Id { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }

    }
}
