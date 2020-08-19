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

namespace MultichatVisual.UI.Chat
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            isLogout = false;
        }


        private string roomName;
        private bool isLogout;


        public string GetName()
        {
            return roomName;
        }

        public void SetName(string roomName)
        {
            if (roomName.Contains("("))
            {
                roomName = roomName.Remove(roomName.IndexOf("(")).Trim();
            }
            this.roomName = roomName;
            this.Text += ": " + this.roomName;
        }

        public void SetMessages(string messages)
        {
            LB_Messages.Items.Clear();
            LB_Messages.Items.AddRange(messages.Split(','));
        }

        public void SetUsers(string users)
        {
            if (LB_UserList.InvokeRequired)
            {
                LB_UserList.Invoke(new Action(() => {
                    LB_UserList.Items.Clear();
                    LB_UserList.Items.AddRange(users.Split(','));
                }));
            }
        }

        public void Say(string message)
        {
            if (LB_Messages.InvokeRequired)
            {
                LB_Messages.Invoke(new Action(() => {
                    LB_Messages.Items.Add(message);
                }));
            }
        }


        private void B_Send_Click(object sender, EventArgs e)
        {
            Commander.Cmd.Message(roomName, TB_Message.Text);
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearChat();
            if (!isLogout)
            {
                Commander.Cmd.Exit(roomName);
            }
        }

        private void ClearChat()
        {
            if (LB_Messages.InvokeRequired)
            {
                LB_Messages.Invoke(new Action(() => {
                    TB_Message.Text = String.Empty;
                    LB_Messages.Items.Clear();
                }));
            }
            else
            {
                TB_Message.Text = String.Empty;
                LB_Messages.Items.Clear();
            }
        }

        private void MainMenu_Logout_Click(object sender, EventArgs e)
        {
            Commander.Cmd.Logout(roomName);
            isLogout = true;
            this.Close();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            isLogout = false;
            Commander.Cmd.Logout(roomName);
            Commander.Cmd.PrivateRefresh();

        }

        private void B_PrivateMessage_Click(object sender, EventArgs e)
        {
            if (LB_UserList.SelectedItem != null)
            {
                Commander.Cmd.PrivateMessage(LB_UserList.SelectedItem.ToString(), TB_Message.Text);
            }
        }

    }
}
