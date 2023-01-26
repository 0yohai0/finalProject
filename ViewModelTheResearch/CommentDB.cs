using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelTheResearch
{
    public class CommentDB:UserNewsInteractionDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Comment comment = entity as Comment;
            comment.content = (string)reader["content"];
            base.CreateModel(comment);
            return comment;
        }
        protected override BaseEntity newEntity()
        {
            return new Comment() as BaseEntity;
        }

        public CommentList SelectAll()
        {
            command.CommandText = "select content, tbUserNewsInteraction.IdNews, tbUserNewsInteraction.IdUser from tbComments join tbUserNewsInteraction on tbComments.IdUserNewsInteraction = tbUserNewsInteraction.IdUserNewsInteraction ";
            CommentList comments = new CommentList(base.Select());
            return comments;
        }

        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            Comment comment = entity as Comment;
            if(comment != null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", comment.Id));
                cmd.Parameters.Add(new SqlParameter("@content", comment.content));
                cmd.CommandText = "insert into tbComments (IdUserNewsInteraction, content) values(@id,@content)";
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            Comment comment = entity as Comment;
            if (comment != null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", comment.Id));
                cmd.Parameters.Add(new SqlParameter("@content", comment.content));
                cmd.CommandText = " update tbComments set content=@content where IdUserNewsInteraction=@id";
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            Comment comment = entity as Comment;
            if (comment != null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", comment.Id));
                cmd.CommandText = "delete from tbComments where IdUserNewsInteraction=@id";
            }
        }

        public override void Insert(BaseEntity entity)
        {
            Comment comment = entity as Comment;
            if (comment != null)
            {
                action.Add(new ChangeEntity(base.CreateInsertSQL, entity, true));
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity, false));
            }
        }
        public override void Update(BaseEntity entity)
        {
            Comment comment = entity as Comment;
            if (comment != null)
            {
                action.Add(new ChangeEntity(this.CreateUpdateSQL, entity, false));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            Comment comment = entity as Comment;
            if (comment != null)
            {
                action.Add(new ChangeEntity(this.CreateDeleteSQL, entity, false));
                action.Add(new ChangeEntity(base.CreateDeleteSQL, entity, false));
            }
        }

    }
}
