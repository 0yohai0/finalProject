using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class CommentList:List<Comment>
    {
        public CommentList() { }
        public CommentList(IEnumerable<Comment>list):base(list) { }
        public CommentList(IEnumerable<BaseEntity> list) : base(list.Cast<Comment>().ToList()) { }
    }
}
