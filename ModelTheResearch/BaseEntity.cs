using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public delegate void CreateSql(BaseEntity entity, SqlCommand cmd);
    public class BaseEntity
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
