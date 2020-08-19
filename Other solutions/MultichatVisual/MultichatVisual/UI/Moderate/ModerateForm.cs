using MultichatVisual.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultichatVisual.UI.Moderate
{
    public partial class ModerateForm : Form
    {
        public ModerateForm()
        {
            InitializeComponent();
        }


        public void UpdateUserList(string[] names)
        {
            if (LB_UserList.InvokeRequired)
            {
                LB_UserList.Invoke(new Action(() =>
                {
                    LB_UserList.Items.Clear();
                    LB_UserList.Items.AddRange(names);
                }));
            }
        }

        private void B_Ban_Click(object sender, EventArgs e)
        {
            if (LB_UserList.SelectedItem != null)
            {
                string name = LB_UserList.SelectedItem.ToString();
                if (name.Contains("("))
                {
                    name = name.Remove(name.IndexOf("(")).Trim();
                }
                int banTime = (int)NUD_BanTime.Value;
                Commander.Cmd.AdminBan(name, banTime);
                Commander.Cmd.AdminRefresh();
            }
        }

        private void B_Unban_Click(object sender, EventArgs e)
        {
            if (LB_UserList.SelectedItem != null)
            {
                string name = LB_UserList.SelectedItem.ToString();
                if (name.Contains("("))
                {
                    name = name.Remove(name.IndexOf("(")).Trim();
                }
                Commander.Cmd.AdminUnban(name);
                Commander.Cmd.AdminRefresh();
            }
        }

        private void ModerateForm_Load(object sender, EventArgs e)
        {
            Commander.Cmd.AdminRefresh();
        }
    }
}
