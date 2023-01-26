using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewModelTheResearch
{
    public abstract class BaseEntityDB
    {
        protected string connectionString = "";
        protected SqlConnection connection;
        protected SqlDataReader reader;
        protected SqlCommand command;

        protected List<ChangeEntity> action = new List<ChangeEntity>();

        protected abstract void CreateInsertSQL(BaseEntity entity, SqlCommand cmd);
        protected abstract void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd);
        protected abstract void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd);


        protected abstract BaseEntity newEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);

        public BaseEntityDB()
        {
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\projects\\Project2022-2023\\FinalProject\\ViewModelTheResearch\\dbTheResarch.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
        }
        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BaseEntity baseEntity = newEntity();
                    list.Add(CreateModel(baseEntity));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return list;

        }
        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && reqEntity.GetType() == entity.GetType())
            {
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && reqEntity.GetType() == entity.GetType())
            {
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && reqEntity.GetType() == entity.GetType())
            {
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public int saveChanges()
        {
            SqlCommand command = new SqlCommand();
            int rowEffected = 0;
            try
            {
                command.Connection = this.connection;
                connection.Open();

                foreach (var item in action)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    rowEffected += command.ExecuteNonQuery();

                    if (item.IsNeededID)
                    {
                        command.CommandText = "select @@Identity";
                        int.TryParse(command.ExecuteScalar().ToString(), out int id);
                        item.Entity.Id = id;

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                action.Clear();

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return rowEffected;
        }

    }
}
