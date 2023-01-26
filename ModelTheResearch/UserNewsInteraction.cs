using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class UserNewsInteraction:BaseEntity
    {
        public User user { get; set; }
        public News news { get; set; }
        public DateTime dateTimeAdded { get; set; }
    }
}
