using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public int ProfileID { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}
