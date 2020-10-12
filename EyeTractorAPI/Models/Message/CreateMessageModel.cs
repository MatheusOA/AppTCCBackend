using System.ComponentModel.DataAnnotations;

namespace EyeTractorAPI.Models
{
    public class CreateMessageModel
    {
        [Required]
        public string Message { get; set; }
    }
}
