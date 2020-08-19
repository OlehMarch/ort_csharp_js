using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PersonDB
{
    public static class PersonDAO_DynamicImplementation
    {
        private static List<IPersonDAO> DAOHandler { set; get; }

        static PersonDAO_DynamicImplementation()
        {
            DAOHandler = (List<IPersonDAO>)GetDynamicDAOTypeInstancies();
        }

        public static IPersonDAO GetDynamicInstance(int index)
        {
            return DAOHandler[index];
        }

        public static string[] GetDynamicDaoTypeNames()
        {
            string[] names = new string[DAOHandler.Count];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = DAOHandler[i].GetType().Name;
            }
            return names;
        }

        private static IEnumerable<IPersonDAO> GetDynamicDAOTypeInstancies()
        {
            List<IPersonDAO> necessaryTypes = new List<IPersonDAO>();
            var currentAssembly = Assembly.GetExecutingAssembly();
            Type[] allTypes = currentAssembly.GetTypes();
            Array.ForEach<Type>(allTypes, (type) =>
            {
                if (type.GetInterface("IPersonDao", true) != null && !type.IsAbstract)
                    necessaryTypes.Add((IPersonDAO)Activator.CreateInstance(type));
                object a = new object();
            });
            return necessaryTypes;
        }
    }
}
