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
    public class UserNewsInteractionDB : BaseEntityDB
    {
        protected override BaseEntity newEntity()
        {
            return new UserNewsInteraction() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            UserNewsInteraction userNewsInteraction = entity as UserNewsInteraction;
            User user = new User();
            user.Id = (int)reader["userId"];
            News news = new News();
            news.Id = (int)reader["newsId"];
            news.headLine = (string)reader["HeadLine"];
            news.secondaryTitle = (string)reader["seconderyTitle"];
            news.imagePath = (string)reader["imagePath"];
            news.dateTimePublished = (DateTime)reader["newsDateTimePublished"];

            userNewsInteraction.Id = (int)reader["userNewsInteractionId"];
            userNewsInteraction.user = user;
            userNewsInteraction.news= news;
            userNewsInteraction.dateTimeAdded = (DateTime)reader["dateTimeAdded"];

            return userNewsInteraction;

        }
        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            UserNewsInteraction userNewsInteraction = entity as UserNewsInteraction;
            if (userNewsInteraction != null)
            {
                cmd.Parameters.Add(new SqlParameter("@idUser", userNewsInteraction.user.Id));
                cmd.Parameters.Add(new SqlParameter("@idNews", userNewsInteraction.news.Id));
                cmd.Parameters.Add(new SqlParameter("@dateTimeAdded", userNewsInteraction.dateTimeAdded));
                cmd.CommandText = "insert into tbUserNewsInteraction (IdUser,IdNews,dateTimeAdded) values(@idUser,@idNews,@dateTimeAdded)";
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            UserNewsInteraction userNewsInteraction = entity as UserNewsInteraction;
            if( userNewsInteraction != null )
            {
                cmd.Parameters.Add(new SqlParameter("@Id", userNewsInteraction.Id));
                cmd.CommandText = "delete from tbUserInteraction where IdUserInteraction=@Id";
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
