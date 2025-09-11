using System.ComponentModel.DataAnnotations;

namespace MVCCORE_NexusMart.Models
{
    public class Admin
    {
        [Key]
        [Display(Name = "Admin ID")]
        public int Admin_Id { get; set; }

        [Display(Name = "Name")]
        public string Admin_Name { get; set; }

        [Display(Name = "Email")]
        public string Admin_Email { get; set; }

        [Display(Name = "Password")]

        public string Admin_Password { get; set; }

        [Display(Name = "Image")]
        public string Admin_Image { get; set; }
    }
}
