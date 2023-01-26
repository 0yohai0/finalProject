using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewModelTheResearch
{
    public class WorkerDB:HumanDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Worker worker = entity as Worker;
            worker.salary = (double)reader["salary"];
            base.CreateModel(worker);
            return worker;
        }
        protected override BaseEntity newEntity()
        {
            return new Worker() as BaseEntity;
        }
        public WorkerList SelectAll()
        {
            command.CommandText = "select tbWorkers.IdHuman as Id,tbHumans.name as humanName, email, password, birthDate, salary, tbAuths.name as AuthName from tbHumans join tbWorkers on tbWorkers.IdHuman = tbHumans.IdHuman join tbAuths on tbHumans.IdAuthLevel = tbAuths.IdAuthLevel  ";
            WorkerList workers = new WorkerList(base.Select());
            return workers;
        }
        protected override void CreateInsertSQL(BaseEntity entity, SqlCommand cmd)
        {
            Worker worker = entity as Worker;
            if(worker != null)
            {
              cmd.Parameters.Add(new SqlParameter("@id", worker.Id));
              cmd.Parameters.Add(new SqlParameter("@salary",worker.salary));
              cmd.CommandText = "insert into tbWorkers (IdHuman) values(@id)";
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, SqlCommand cmd)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
               cmd.Parameters.Add(new SqlParameter("@id", worker.Id));
               cmd.CommandText = "update tbWorkers set salary=@salary";
            }
        }
        protected override void CreateDeleteSQL(BaseEntity entity, SqlCommand cmd)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                cmd.Parameters.Add(new SqlParameter("@id", worker.Id));
                cmd.CommandText = "delete from tbWorkers where IdHuman =@id";
            }
        }

        public override void Insert(BaseEntity entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                action.Add(new ChangeEntity(base.CreateInsertSQL, entity, true));
                action.Add(new ChangeEntity(this.CreateInsertSQL, entity, false));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                action.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
                action.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                action.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
    }
}
