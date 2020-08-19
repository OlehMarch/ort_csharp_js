using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public interface IPersonDAO
    {
        string ConnectionString
        {
            set;
            get;
        }
        void Create(Person persona);
        IEnumerable<Person> Read();
        void Update(Person persona);
        void Delete(Person persona);
    }
}
