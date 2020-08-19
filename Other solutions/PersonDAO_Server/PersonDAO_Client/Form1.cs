using PersonDAO;
using PersonDAO_Client.Api;
using PersonDAO_Client.Crud_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonDAO_Client
{
    public partial class Form1 : Form
    {
        private Client client;
        private PacketMaster packetMaster; 

        public Form1()
        {
            InitializeComponent();
            packetMaster = new PacketMaster();
        }

        private void buttonCRUD_Click(object sender, EventArgs e)
        {
            Button obj = sender as Button;
            GenericDialog dialog = GetDialog(obj.Text);
            try
            {
                DoCrud(obj.Text, dialog);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                if (dialog != null) dialog.Dispose();
            }
        }

        private void DoCrud(string type, GenericDialog dialog)
        {
            switch (type)
            {
                case "Insert":
                    {
                        var result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string message = packetMaster.CreatePacket("CREATE", dialog.GetPerson());
                            client.Send(message);
                        }
                        break;
                    }
                case "Read":
                    {
                        string message = packetMaster.CreatePacket("READ", null);
                        client.Send(message);
                        string incomeMessage = client.ListenReply();
                        PersonPacket packet = packetMaster.DecodePacket(incomeMessage);
                        dataGrid.DataSource = packet.Persons;
                        dataGrid.Update();
                        break;
                    }
                case "Update":
                    {
                        var result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string message = packetMaster.CreatePacket("UPDATE", dialog.GetPerson());
                            client.Send(message);
                        }
                        break;
                    }
                case "Delete":
                    {
                        var result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string message = packetMaster.CreatePacket("DELETE", dialog.GetPerson());
                            client.Send(message);
                        }
                        break;
                    }
            }
        }

        private GenericDialog GetDialog(string type)
        {
            GenericDialog result = null;
            switch (type)
            {
                case "Insert":
                    {
                        result = new GenericDialog(DialogType.CREATE);
                        break;
                    }
                case "Update":
                    {
                        result = new GenericDialog(DialogType.UPDATE, GetSelectedPerson());
                        break;
                    }
                case "Delete":
                    {
                        result = new GenericDialog(DialogType.DELETE, GetSelectedPerson());
                        break;
                    }
            }
            return result;
        }
        
        private Person GetSelectedPerson()
        {
            var row = this.dataGrid.CurrentRow.Cells;
            object[] rowValues = new object[row.Count];
            for (int i = 0; i < rowValues.Length; i++)
            {
                rowValues[i] = row[i].Value;
            }
            return new Person(rowValues);
        }

        private void buttonCreateConnection_Click(object sender, EventArgs e)
        {
            client = new Client();
        }
    }
}
