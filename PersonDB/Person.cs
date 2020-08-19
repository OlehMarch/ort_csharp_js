using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonDB
{
    [Serializable]
    public sealed class Person
    {
        #region Definitions
        [XmlElement("Id")]
        public uint Id { set; get; }
        [XmlElement("FirstName")]
        public string FirstName { set; get; }
        [XmlElement("LastName")]
        public string LastName { set; get; }
        [XmlElement("Age")]
        public uint Age { set; get; }
        #endregion

        #region Constructors
        public Person()
        {
            this.FirstName = null;
            this.LastName = null;
            Id = default(uint);
            Age = default(uint);
        }

        public Person(uint id, string firstName, string lastName, uint age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            Id = id;
            Age = age;
        }

        public Person(Person p)
        {
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            Id = p.Id;
            Age = p.Age;
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

        public Person(uint id) : base()
        {
            this.Id = id;
        }
        #endregion

        public override string ToString()
        {
            string str = "[";
            str += Id + ", ";
            str += FirstName + ", ";
            str += LastName + ", ";
            str += Age + "]";

            return str;
        }

        public override bool Equals(object obj)
        {
            Person comp = (Person)obj;
            if (Id != comp.Id)
            {
                return false;
            }
            if (!String.Equals(comp.FirstName, FirstName))
            {
                return false;
            }
            if (!String.Equals(comp.LastName, LastName))
            {
                return false;
            }
            if (Age != comp.Age)
            {
                return false;
            }
            return true;
        }

    }

    [Serializable]
    [XmlRoot("persons")]
    public class PersonCollection
    {
        [XmlArrayItem("person", typeof(Person))]
        public Person[] persons;
    }
}
