using PersonDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonDAO_Client.Crud_forms
{
    public partial class GenericDialog : Form
    {
        public GenericDialog()
        {
            InitializeComponent();
        }

        public GenericDialog(DialogType type, Person persona = null)
            : this()
        {
            FillPersonaFields(type, persona ?? new Person(0, "", "", 0));
        }

        private void FillPersonaFields(DialogType type, Person persona)
        {
            switch (type)
            {
                case DialogType.DELETE:
                    {
                        SetPerson(persona);
                        this.textID.ReadOnly = true;
                        this.textFN.ReadOnly = true;
                        this.textLN.ReadOnly = true;
                        this.textAge.ReadOnly = true;
                        break;
                    }
                case DialogType.UPDATE:
                    {
                        SetPerson(persona);
                        this.textID.ReadOnly = true;
                        break;
                    }
                default: break;
            }
        }

        public void SetPerson(Person persona)
        {
            this.textID.Text = persona.Id.ToString();
            this.textFN.Text = persona.FirstName.ToString();
            this.textLN.Text = persona.LastName.ToString();
            this.textAge.Text = persona.Age.ToString();
        }

        public Person GetPerson()
        {
            var id = Convert.ToUInt32(textID.Text);
            var fName = textFN.Text;
            var lName = textLN.Text;
            var age = Convert.ToUInt32(textAge.Text);
            return new Person(id, fName, lName, age);
        }

        private void anyButton_Click(object sender, EventArgs e)
        {
            Button obj = sender as Button;
            if (obj.Equals(buttonOK))
            {
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
