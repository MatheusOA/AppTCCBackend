using System.ComponentModel.DataAnnotations;

namespace EyeTractorAPI.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
