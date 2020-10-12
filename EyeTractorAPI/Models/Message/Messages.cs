using System;
using System.Collections.Generic;

namespace EyeTractorAPI.Models
{
    public partial class Messages
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public DateTime? CreationDateTime { get; set; }
    }
}
