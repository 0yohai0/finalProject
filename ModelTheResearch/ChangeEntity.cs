using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class ChangeEntity
    {
        private CreateSql createSql;
        private BaseEntity entity;
        private bool isNeededID;

        public CreateSql CreateSql
        {
            get { return createSql; }
        }
        public BaseEntity Entity
        {
            get { return entity; }
        }
        public ChangeEntity(CreateSql createSql, BaseEntity entity)
        {
            this.createSql = createSql;
            this.entity = entity;
        }
        public bool IsNeededID
        {
            get { return isNeededID; }
        }
        public ChangeEntity(CreateSql createSql, BaseEntity entity, bool isNeededID)
        {
            this.isNeededID = isNeededID;
            this.createSql = createSql;
            this.entity = entity;
        }
    }
}
