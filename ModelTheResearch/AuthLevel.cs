using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class AuthLevel:BaseEntity
    {
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
