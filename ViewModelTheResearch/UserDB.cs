using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viewModelTheResearch;

namespace ViewModelTheResearch
{
    public class UserDB:HumanDB
    {
        protected override BaseEntity newEntity()
        {
            return new User() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity baseEntity)
        {
            User user = baseEntity as User;
            user.IdUser = (int)reader["IdUser"];
            user.userName = (string)reader["userName"];
            base.CreateModel(user);
            return user;
        }
        public UserList SelectAll()
        {
            command.CommandText = "select tbUsers.IdUser as IdUser, tbUsers.userName as userName, tbHumans.name as humanName,tbUsers.IdHuman as Id,birthDate,email,password,tbAuths.name as AuthName from tbHumans join tbUsers on tbUsers.IdHuman = tbHumans.IdHuman join tbAuths on tbHumans.IdAuthLevel = tbAuths.IdAuthLevel ";
            UserList users = new UserList(base.Select());
            return users;
        }
        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            User user = entity as User;
            if(user != null)
            {
               cmd.Parameters.Add(new SqlParameter("@id", user.Id));
               cmd.Parameters.Add(new SqlParameter("@userName", user.userName));
               cmd.CommandText = "insert into tbUsers (IdHuman,userName) values(@id,@userName)";
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            User user = entity as User;
            if (user != null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", user.IdUser));
                cmd.Parameters.Add(new SqlParameter("@userName", user.userName));
                cmd.CommandText = "update tbUsers set userName=@userName where IdUser=@id";
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            User user = entity as User;
            if (user != null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                cmd.CommandText = "delete from tbUsers where IdHuman=@id";
            }
        }
        public override void Insert(BaseEntity entity)
        {
            User user = entity as User;
            if (user != null)
            {
                action.Add(new ChangeEntity(base.CreateInsertSQL, entity, true));
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity, false));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            User user = entity as User;
            if (user != null)
            {
                action.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
                action.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            User user = entity as User;
            if (user != null)
            {
                action.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                action.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
    }
}
