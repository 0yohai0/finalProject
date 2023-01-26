using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class News: BaseEntity
    {
        public string headLine { get; set; }
        public string secondaryTitle { get; set; }
        public DateTime dateTimePublished { get; set; }
        public UserList stuff { get;  set; }
        public string imagePath { get; set; }
        public string content { get; set; }
        public AuthLevel AuthLevel { get; set; }
    }
}
