using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace XMLInterpreter.WPF
{
    internal static class SAX_Parser
    {
        static SAX_Parser()
        {
            ElementStart += SAX_Parser_ElementStart;
            ElementContext += SAX_Parser_ElementContext;
            ElementEnd += SAX_Parser_ElementEnd;
            CurrentControl = new List<FrameworkElement>();
            CurrentControl.Add(null);
            depthLevel = 0;
        }


        public static event EventHandler<string> ElementStart;
        public static event EventHandler<string> ElementContext;
        public static event EventHandler<string> ElementEnd;
        internal static List<FrameworkElement> CurrentControl;
        internal static int depthLevel;


        #region Event Hendlers
        internal static void SAX_Parser_ElementStart(object sender, string e)
        {
            string line = e.Replace("<", "").Replace(">", "");

            if (line == "list")
            {
                depthLevel++;
                CurrentControl.Add(null);
            }

            // fill log
        }

        internal static void SAX_Parser_ElementContext(object sender, string e)
        {
            string tag = e.Remove(e.IndexOf(">")).Replace("<", "");
            string innerText = e.Remove(0, e.IndexOf(">") + 1);
            innerText = innerText.Remove(innerText.IndexOf("</"));

            if (tag == "")
            {
                return;
            }
            else if (tag == "type")
            {
                CurrentControl[depthLevel] = ControlSelector.ControlCreation(innerText);
            }
            else
            {
                ControlDataHandler.InsertData(tag, innerText);
            }

            // fill log
        }

        internal static void SAX_Parser_ElementEnd(object sender, string e)
        {
            string line = e.Replace("</", "").Replace(">", "");

            if (line == "velement" && depthLevel == 0)
            {
                ControlHolder.Container = CurrentControl[0];
                CurrentControl = null;
            }
            else if (line == "velement")
            {
                CurrentControl[depthLevel].HorizontalAlignment = HorizontalAlignment.Left;
                CurrentControl[depthLevel].VerticalAlignment = VerticalAlignment.Top;
                ControlHierarchyHandler.AddControlToHierarchy();
                CurrentControl[depthLevel] = null;
            }
            else if (line == "list")
            {
                depthLevel--;
            }

            // fill log
        }
        #endregion

    }
}
