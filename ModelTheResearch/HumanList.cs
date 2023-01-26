using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class HumanList: List<Human>
    {
        public HumanList() { }
        public HumanList(List<Human> list): base(list) { }
        public HumanList(IEnumerable<BaseEntity> list) : base(list.Cast<Human>().ToList()) { }
    }
}
