using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualDAO;

namespace PersonDB
{
    static class Program
    {
        #region Selections
        public static void SelectArmyAge(List<Person> list)
        {
            foreach (var person in list)
            {
                if (person.Age >= 18 && person.Age <= 27)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        public static void SelectNameEndWithOV(List<Person> list)
        {
            foreach (var person in list)
            {
                if (person.LastName.EndsWith("ов"))
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        public static void SelectNameLengthEq4(List<Person> list)
        {
            foreach (var person in list)
            {
                if (person.LastName.Length == 4)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        public static void SelectAllPersons(List<Person> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void SelectAllPersonsLowCase(List<Person> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.FirstName.ToLower() + "  " + item.LastName.ToLower());
            }
        }

        public static void SelectAgeMultiplicity5(List<Person> list)
        {
            foreach (var person in list)
            {
                if (person.Age % 5 == 0)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        public static void SelectNameWithXwithin(List<Person> list)
        {
            foreach (var person in list)
            {
                if (person.FirstName[person.FirstName.Length / 2] == 'х')
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        public static void SelectAgeEqualWithID(List<Person> list)
        {
            foreach (var person in list)
            {
                if (person.Age == person.Id)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #region Old
            /*
            PersonDAO_Redis dao = new PersonDAO_Redis();
            dao.Create(new Person(4, "Name2", "Surname2", 26));
            dao.Update(new Person(5, "Name3", "Surname3", 27));
            dao.Update(new Person(3, "Name4", "Surname4", 28));
            dao.Delete(new Person(5, "Name3", "Surname3", 27));
            List<Person> personList = (List<Person>)dao.Read();

            SelectAllPersons(personList);

            Console.ReadKey();
            */
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DAOPage());
        }

    }
}
