using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewModelTheResearch
{
    public class AuthLevelDB : BaseEntityDB
    {
        protected override BaseEntity newEntity()
        {
            return new AuthLevel() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
           AuthLevel authLevel = entity as AuthLevel;
           authLevel.Id = (int)reader["IdAuthLevel"];
           authLevel.name= (string)reader["name"];
           return authLevel;

        }
        public AuthLevelList selectAll()
        {
            command.CommandText = "select IdAuthLevel, name from tbAuths";
            AuthLevelList auths = new AuthLevelList(base.Select());
            return auths;
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            AuthLevel authLevel = entity as AuthLevel;
            if(authLevel != null)
            {
               cmd.Parameters.Add(new SqlParameter("@name", authLevel.name));
               cmd.CommandText = "insert into tbAuths (name) values(@name)";
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            AuthLevel authLevel = entity as AuthLevel;
            if (authLevel != null)
            {
                cmd.Parameters.Add(new SqlParameter("@name", authLevel.name));
                cmd.CommandText = "update  tbAuths set name=@name";
            }
        }
        public override void Insert(BaseEntity entity)
        {
            AuthLevel authLevel = entity as AuthLevel;
            if (authLevel != null)
            {
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity, false));
            }
        }
        public override void Update(BaseEntity entity)
        {
            AuthLevel authLevel = entity as AuthLevel;
            if (authLevel != null)
            {
                action.Add(new ChangeEntity(this.CreateUpdateSQL, entity,false));
            }
        }

    }
}
