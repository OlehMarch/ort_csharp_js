using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultichatVisual.UI.Auth
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        public string nickname;

        private void B_OK_Click(object sender, EventArgs e)
        {
            if (TB_Name.Text != String.Empty)
            {
                nickname = TB_Name.Text;
            }
            DialogResult = DialogResult.OK;
        }

        private void B_Admin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
