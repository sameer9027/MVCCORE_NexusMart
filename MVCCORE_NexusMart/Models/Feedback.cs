using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    public class Feedback
    {
        [Key]
        public int Feedback_Id { get; set; }
        public string Feedback_Username { get; set; }
        public string Feed_msg { get; set; }



    }
}
