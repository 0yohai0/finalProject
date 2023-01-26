using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewModelTheResearch
{
    public class HumanDB : BaseEntityDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Human human = entity as Human;
            human.Id = (int)reader["Id"];
            human.name = (string)reader["HumanName"];
            human.email = (string)reader["email"];
            human.password = (string)reader["password"];
            human.birthDate = (DateTime)reader["birthDate"];

            AuthLevel authLevel = new AuthLevel();
            authLevel.name = (string)reader["authName"];
            //authLevel.Id = (int)reader["IDAuth"];

            human.authLevel=authLevel;

            return human;
        }
        protected override BaseEntity newEntity()
        {
            return new Human() as BaseEntity;
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            Human human=entity as Human;
            if(human!=null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", human.Id));
                cmd.CommandText = "delete from tbHumans where IdHuman=@id";
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            Human human = entity as Human;
            if (human != null)
            {
                cmd.Parameters.Add(new SqlParameter("@Name", human.name));
                cmd.Parameters.Add(new SqlParameter("@Email", human.email));
                cmd.Parameters.Add(new SqlParameter("@Password", human.password));
                cmd.Parameters.Add(new SqlParameter("@BirthDate", human.birthDate));
                cmd.Parameters.Add(new SqlParameter("@IdAuthLevel", human.authLevel.Id));

                cmd.CommandText ="insert into tbHumans (name,birthDate,email,password,IdAuthLevel) values(@Name,@BirthDate,@Email,@Password,@IdAuthLevel)";
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            Human human = entity as Human;
            if (human != null)
            {

                cmd.Parameters.Add(new SqlParameter("@Id", human.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", human.name));
                cmd.Parameters.Add(new SqlParameter("@Email", human.email));
                cmd.Parameters.Add(new SqlParameter("@Password", human.password));
                cmd.Parameters.Add(new SqlParameter("@BirthDate", human.birthDate));
                cmd.Parameters.Add(new SqlParameter("@IdAuthLevel", human.authLevel.Id));
                cmd.CommandText = "update tbHumans set name=@Name, email=@Email, password=@Password,birthDate=@BirthDate, IdAuthLevel=@IdAuthLevel where IdHuman=@Id";
            }
        }

    }
}
