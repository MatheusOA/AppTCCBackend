using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTractorAPI.Models.Message
{
    public class UserMessage
    {
        public string Text { get; set; }
        public DateTime MessageDateTime { get; set; }
        public bool IsAuthor { get; set; } 
    }
}
