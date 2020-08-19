using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativePortable
{
    public interface IPersonDAO
    {
        void Create(Person person);
        IEnumerable<Person> ReadAll();
        Person Read(int id);
        void Update(Person person);
        void Delete(Person person);
    }
}
