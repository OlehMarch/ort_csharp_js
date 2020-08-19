using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDAO
{
    public sealed class Person
    {
        #region Definitions

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public uint Age { set; get; }
        public uint Id { set; get; }

        #endregion

        #region Constructors

        public Person()
        {
            this.FirstName = null;
            this.LastName = null;
            this.Age = default(uint);
            this.Id = default(uint);
        }

        public Person(Person persona)
        {
            this.FirstName = persona.FirstName;
            this.LastName = persona.LastName;
            this.Age = persona.Age;
            this.Id = persona.Id;
        }

        public Person(uint id, string firstName, string lastName, uint Age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = Age;
            this.Id = id;
        }

        public Person(object[] propValues)
        {
            var type = this.GetType();
            var properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (propValues[i].GetType() == typeof(uint))
                {
                    properties[i].SetValue(this, (uint)propValues[i]);
                }
                else if (propValues[i].GetType() == typeof(string))
                {
                    properties[i].SetValue(this, (string)propValues[i]);
                }
            }
        }

        public Person(uint id)
            : base()
        {
            this.Id = id;
        }

        #endregion

        public override string ToString()
        {
            string result = null;
            result = ("ID : " + Id.ToString() + ", " + LastName + " " + FirstName + " , age : " + Age.ToString());
            return result;
        }
    }
}
