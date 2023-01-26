using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class AuthLevelList:List<AuthLevel>
    {
        public AuthLevelList() { }
        public AuthLevelList(IEnumerable<AuthLevel> list) : base(list) { }
        public AuthLevelList(IEnumerable<BaseEntity> list) : base(list.Cast<AuthLevel>().ToList()) { }

    }
}
