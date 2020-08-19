using MultichatVisual.UI.Lobby;
using MultichatVisual.UI.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultichatVisual.API;

using ChatForm = MultichatVisual.UI.Chat.Chat;
using MultichatVisual.UI.Moderate;

namespace MultichatVisual
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();

            UserName = "";
            chat = new ChatForm();
            moderate = new ModerateForm();
            client = new ClientApi(new EventHandler(BroadcastRefresh), chat, moderate);
            Commander.Cmd = new RequestCommand(client.SayBridge);
        }


        private ClientApi client;
        private ChatForm chat;
        private ModerateForm moderate;
        private string UserName;

        private void BroadcastRefresh(object sender, EventArgs e)
        {
            var roomList = (sender as string).Split(',');
            if (LB_ChatRooms.InvokeRequired)
            {
                LB_ChatRooms.Invoke(new Action(() => {
                    LB_ChatRooms.Items.Clear();
                    LB_ChatRooms.Items.AddRange(roomList);
                }));
            }
        }


        private void B_Create_Click(object sender, EventArgs e)
        {
            if (UserName != "Admin")
            {
                CreateChatRoomDialog dlg = new CreateChatRoomDialog();
                var result = dlg.ShowDialog();
                string chatRoomName = String.Empty;
                if (result == DialogResult.OK)
                {
                    chatRoomName = dlg.chatRoomName;
                    chat.SetName(chatRoomName);
                    Commander.Cmd.Create(chatRoomName);
                }
                dlg.Dispose();
            }
        }

        private void B_ConnectToServer_Click(object sender, EventArgs e)
        {
            Auth dlg = new Auth();
            var result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                UserName = dlg.nickname;
                Commander.Cmd.LoginClient(UserName);
            }
            else if (result == DialogResult.Yes)
            {
                this.B_Moderate.Visible = true;
                UserName = "Admin";
                Commander.Cmd.LoginAdmin();
            }
            this.Text += ": " + UserName;

            dlg.Dispose();
            client.ThreadStart();
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                string chatRoomName = LB_ChatRooms.SelectedItem.ToString();
                chat.SetName(chatRoomName);
                Commander.Cmd.Connect(chatRoomName);
            }
            catch { }
        }

        private void B_Moderate_Click(object sender, EventArgs e)
        {
            moderate.ShowDialog();
        }
    }
}
