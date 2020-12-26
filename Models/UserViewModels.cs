using System.ComponentModel.DataAnnotations;

namespace PartsCatalog.Models
{
    public class CreateModel
    {
    
        [Required]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        
    }
}