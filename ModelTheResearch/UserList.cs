using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class UserList : List<User>
    {
        private List<BaseEntity> baseEntities;

        public UserList() { }
        public UserList(IEnumerable<User> list) : base(list) { }
        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }

    }
}
