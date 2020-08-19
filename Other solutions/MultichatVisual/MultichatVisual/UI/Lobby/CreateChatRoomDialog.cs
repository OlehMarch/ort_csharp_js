using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultichatVisual.UI.Lobby
{
    public partial class CreateChatRoomDialog : Form
    {
        public CreateChatRoomDialog()
        {
            InitializeComponent();
        }

        public string chatRoomName;

        private void B_OK_Click(object sender, EventArgs e)
        {
            if (TB_ChatRoomName.Text != String.Empty)
            {
                chatRoomName = TB_ChatRoomName.Text;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
