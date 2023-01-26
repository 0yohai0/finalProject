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
    public class FavoriteDB:UserNewsInteractionDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Favorite favorite = entity as Favorite;
            base.CreateModel(favorite);
            return favorite;
        }
        protected override BaseEntity newEntity()
        {
            return new Favorite() as BaseEntity;
        }
        public FavoriteList SelectAll()
        {
            //command.CommandText = "select tbUserNewsInteraction.IdUserNewsInteraction as userNewsInteractionId,tbUserNewsInteraction.dateTimeAdded as dateTimeAdded, tbUsers.IdUser as userId, tbNews.IdNews as newsId, tbNews.HeadLine as headLine, tbNews.seconderyTitle as seconderyTitle, tbNews.imagePath as imagePath, tbNews.dateTimePublished as newsDateTimePublished from tbUserNewsInteraction join tbUsers on tbUserNewsInteraction.IdUser = tbUsers.IdUser join tbHumans on tbHumans.IdHuman = tbUsers.IdHuman join tbNews on tbUserNewsInteraction.IdNews = tbNews.IdNews";
            command.CommandText = "select tbUserNewsInteraction.IdUserNewsInteraction as userNewsInteractionId,tbUserNewsInteraction.dateTimeAdded as dateTimeAdded, tbUserNewsInteraction.IdUser as userId,tbNews.IdNews as newsId, tbNews.HeadLine as headLine, tbNews.seconderyTitle as seconderyTitle, tbNews.imagePath as imagePath, tbNews.dateTimePublished as newsDateTimePublished \r\nfrom tbUserNewsInteraction full join tbUsers on tbUserNewsInteraction.IdUser = tbUsers.IdUser\r\nfull join tbHumans on tbHumans.IdHuman = tbUsers.IdHuman \r\njoin tbNews on tbUserNewsInteraction.IdNews = tbNews.IdNews";
            FavoriteList favorites = new FavoriteList(base.Select());
            return favorites;
        }

        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {         
            cmd.Parameters.Add(new SqlParameter("@id", entity.Id));
            cmd.CommandText = "insert into tbFavorites (IdUserNewsInteraction) values(@id)";
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@id", entity.Id));
            cmd.CommandText = "delete from tbFavorits where IdUserInteraction=@id";
        }
        public override void Insert(BaseEntity entity)
        {
            Favorite favorite = entity as Favorite;
            if (favorite != null)
            {
                action.Add(new ChangeEntity(base.CreateInsertSQL, entity, true));
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity, false));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            Favorite favorite = entity as Favorite;
            if (favorite != null)
            {
                action.Add(new ChangeEntity(this.CreateDeleteSQL, entity, false));
                action.Add(new ChangeEntity(base.CreateDeleteSQL, entity, false));
            }
        }

    }
}
