using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDB
{
    public sealed class PersonDAO_XMLSAX : APersonDao
    {
        static class Element
        {
            public static List<string> TagName;
            public static List<string> InnerText;
            //public static List<string[]> TagProperty;
            public static int iterator;

            static Element()
            {
                TagName = new List<string>();
                InnerText = new List<string>();
                //TagProperty = new List<string[]>();
                iterator = -1;
            }

            public static List<string> GetInnerTextByTagName(string tagName)
            {
                List<string> list = new List<string>();

                for (int i = 0; i < TagName.Count; ++i)
                {
                    if (TagName[i] == tagName)
                    {
                        list.Add(InnerText[i]);
                    }
                }

                return list;
            }

            public static void Clear()
            {
                TagName = new List<string>();
                InnerText = new List<string>();
                iterator = -1;
            }
        }

        public override string ConnectionString { get; set; }
        private event EventHandler<string> ElementStart;
        private event EventHandler<string> TextNode;
        private event EventHandler<string> ElementEnd;

        public PersonDAO_XMLSAX()
        {
            ConnectionString = Environment.CurrentDirectory + "\\PersonDB\\" + "personDB.xml";
            ElementStart += PersonDAO_XMLSAX_ElementStart;
            ElementEnd += PersonDAO_XMLSAX_ElementEnd;
            TextNode += PersonDAO_XMLSAX_TextNode;
        }

        
        #region SAX Events
        private void PersonDAO_XMLSAX_ElementStart(object sender, string arg)
        {
            if (arg != null || arg != "")
            {
                Element.TagName.Add(arg.Trim().Replace("<", "").TrimStart());
                Element.InnerText.Add(null);
                Element.iterator++;
            }
        }

        private void PersonDAO_XMLSAX_ElementEnd(object sender, string arg)
        {

        }

        private void PersonDAO_XMLSAX_TextNode(object sender, string arg)
        {
            Element.InnerText[Element.iterator] = arg;
        }
        #endregion

        private void SAX_XMLParse()
        {
            Element.Clear();

            StreamReader fs = new StreamReader(ConnectionString);

            while (!fs.EndOfStream)
            {
                string currLine = fs.ReadLine();

                if (currLine.TrimStart().StartsWith("</"))
                {
                    PersonDAO_XMLSAX_ElementEnd(fs, currLine);
                    continue;
                }
                if (currLine.TrimStart().StartsWith("<"))
                {
                    PersonDAO_XMLSAX_ElementStart(fs, currLine.Remove(currLine.IndexOf('>')));
                }
                if (currLine.Contains("</"))
                {
                    string tmp = currLine.Remove(0, currLine.IndexOf('>') + 1);
                    tmp = tmp.Remove(tmp.IndexOf("</"));
                    PersonDAO_XMLSAX_TextNode(fs, tmp);
                    continue;
                }
            }

            fs.Dispose();
        }

        private List<Person> FillPersonList()
        {
            List<Person> personList = new List<Person>();

            string[] id = Element.GetInnerTextByTagName("id").ToArray();
            string[] firstName = Element.GetInnerTextByTagName("firstName").ToArray();
            string[] lastName = Element.GetInnerTextByTagName("lastName").ToArray();
            string[] age = Element.GetInnerTextByTagName("age").ToArray();

            for (int i = 0; i < id.Length; ++i)
            {
                personList.Add(
                    new Person(
                        Convert.ToUInt32(id[i]), 
                        firstName[i], 
                        lastName[i], 
                        Convert.ToUInt32(age[i])
                    )
                );
            }

            return personList;
        }

        public override List<Person> Reader()
        {
            SAX_XMLParse();
            
            return FillPersonList();
        }

        public override void Writer(List<Person> personList)
        {
            string persons = "<Persons>" + Environment.NewLine;
            for (int i = 0; i < personList.Count; ++i)
            {
                persons += "  <Person>" + Environment.NewLine;
                persons += String.Format("    <id>{0}</id>", personList[i].Id) + Environment.NewLine;
                persons += String.Format("    <firstName>{0}</firstName>", personList[i].FirstName) + Environment.NewLine;
                persons += String.Format("    <lastName>{0}</lastName>", personList[i].LastName) + Environment.NewLine;
                persons += String.Format("    <age>{0}</age>", personList[i].Age) + Environment.NewLine;
                persons += "  </Person>" + Environment.NewLine;
            }
            persons += "</Persons>";

            StreamWriter fs = new StreamWriter(ConnectionString);
            fs.WriteLine(persons);
            fs.Dispose();
        }

    }
}
