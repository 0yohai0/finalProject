using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class FavoriteList:List<Favorite>
    {
       public FavoriteList() { }
       public FavoriteList(IEnumerable<Favorite> list) : base(list) { }
       public FavoriteList(IEnumerable<BaseEntity> list) : base(list.Cast<Favorite>().ToList()) { }
    }
}
