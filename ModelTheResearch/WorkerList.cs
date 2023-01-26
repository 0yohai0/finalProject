using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class WorkerList:List<Human>
    {
        public WorkerList() { }
        public WorkerList(IEnumerable<Human> list) : base(list) { }
        public WorkerList(IEnumerable<BaseEntity> list) : base(list.Cast<Worker>().ToList()) { }
    }
}
