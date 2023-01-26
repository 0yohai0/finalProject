using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class NewsList:List<News>
    {
        public NewsList() { }
        public NewsList(IEnumerable<News> list) : base(list) { }
        public NewsList(IEnumerable<BaseEntity> list) : base(list.Cast<News>().ToList()) { }

    }
}
