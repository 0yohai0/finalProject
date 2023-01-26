using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class UserNewsInteractionList:List<UserNewsInteraction>
    {
        public UserNewsInteractionList() { }
        public UserNewsInteractionList(IEnumerable<UserNewsInteraction> list):base(list) { }
        public UserNewsInteractionList(IEnumerable<BaseEntity> list) : base(list.Cast<UserNewsInteraction>().ToList()) { }

    }
}
