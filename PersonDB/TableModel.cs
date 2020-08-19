using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public class TableModel
    {
        private IPersonDAO dbActive = null;

        public void SetDB(int type)
        {
            dbActive = PersonDAO_Implementation.GetInstance(type);
        }

        #region CRUD
        public void Create(Person p)
        {
            dbActive.Create(p);
        }

        public DataTable Read()
        {
            DataTable dt = new DataTable();
            var persons = dbActive.Read();

            dt.Columns.Add("Id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Age");

            foreach (var i in persons)
            {
                DataRow dtRow = dt.NewRow();
                dtRow["Id"] = i.Id;
                dtRow["FirstName"] = i.FirstName;
                dtRow["LastName"] = i.LastName;
                dtRow["Age"] = i.Age;
                dt.Rows.Add(dtRow);
            }

            return dt;
        }

        public void Update(Person p)
        {
            dbActive.Update(p);
        }

        public void Delete(Person p)
        {
            dbActive.Delete(p);
        }
        #endregion

    }
}
