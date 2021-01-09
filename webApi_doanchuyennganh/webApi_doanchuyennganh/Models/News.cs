using System;
using System.Collections.Generic;

#nullable disable

namespace webApi_doanchuyennganh.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
