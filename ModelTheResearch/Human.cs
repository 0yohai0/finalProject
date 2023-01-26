using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public  class Human:BaseEntity
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public AuthLevel authLevel { get; set; } 
    }
}
