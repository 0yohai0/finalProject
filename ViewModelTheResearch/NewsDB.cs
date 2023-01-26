using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewModelTheResearch
{
    public class NewsDB : BaseEntityDB
    {
        public NewsList SelectAll()
        {
            command.CommandText = "select IdNews, HeadLine, seconderyTitle, dateTimePublished, content, IdAuthLevelNeeded, imagePath from tbNews";
            NewsList news = new NewsList(base.Select());
            return news;
        }
        protected override BaseEntity newEntity()
        {
            return new News() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            News news = entity as News;
            news.Id = (int)reader["IdNews"];
            news.headLine = (string)reader["HeadLine"];
            news.secondaryTitle = (string)reader["seconderyTitle"];
            news.content = (string)reader["content"];
            news.imagePath = (string)reader["imagePath"];
            news.dateTimePublished = (DateTime)reader["dateTimePublished"];

            AuthLevel authLevel = new AuthLevel();
            authLevel.Id = (int)reader["IdAuthLevelNeeded"];
            news.AuthLevel = authLevel;

            return news;
        }
        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            News news = entity as News;
            if (news != null)
            {
                cmd.Parameters.Add(new SqlParameter("@headLine", news.headLine));
                cmd.Parameters.Add(new SqlParameter("@seconderyTitle", news.secondaryTitle));
                cmd.Parameters.Add(new SqlParameter("@content", news.content));
                cmd.Parameters.Add(new SqlParameter("@dateTimePublished", news.dateTimePublished));
                cmd.Parameters.Add(new SqlParameter("@IdAuthLevel", news.AuthLevel.Id));
                cmd.Parameters.Add(new SqlParameter("@imagePath", news.imagePath));
                cmd.CommandText = $"insert into tbNews (HeadLine,seconderyTitle,dateTimePublished,content,IdAuthLevel,imagePath) values(@headLine,@seconderyTitle,@dateTimePublished,@content,@IdAuthLevel,@imagePath)";
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            News news = entity as News;
            if (news != null)
            {
                cmd.Parameters.Add(new SqlParameter("@headLine", news.headLine));
                cmd.Parameters.Add(new SqlParameter("@seconderyTitle", news.secondaryTitle));
                cmd.Parameters.Add(new SqlParameter("@content", news.content));
                cmd.Parameters.Add(new SqlParameter("@dateTimePublished", news.dateTimePublished));
                cmd.Parameters.Add(new SqlParameter("@IdAuthLevel", news.AuthLevel.Id));
                cmd.Parameters.Add(new SqlParameter("@imagePath", news.imagePath));
                cmd.CommandText = $"update tbNews set HeadLine=@headLine, seconderyTitle=@seconderyTitle, content=@content, dateTimePublished=@dateTimePublished, IdAuthLevel=@IdAuthLevel imagePath=@imagePath ";
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override void Insert(BaseEntity entity)
        {
            News news = entity as News;
            if (news != null)
            {
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity, false));
            }
        }
        public override void Update(BaseEntity entity)
        {
            News news = entity as News;
            if (news != null)
            {
                action.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

    }
}
