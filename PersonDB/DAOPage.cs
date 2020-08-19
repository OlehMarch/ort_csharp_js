using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VisualDAO.Crud_Forms;

using PersonDB;

namespace VisualDAO
{
    public partial class DAOPage : Form
    {
        private PersonDAO_File data;

        public DAOPage()
        {
            InitializeComponent();
            SetComboBox();
        }

        private void SetComboBox()
        {
            CreateComboBoxControls(this.comboDB);
        }

        private void CreateComboBoxControls(ComboBox cb)
        {
            cb.Items.Clear();
            var names = PersonDAO_DynamicImplementation.GetDynamicDaoTypeNames();
            for (int i = 0; i < names.Length; i++)
            {
                cb.Items.Add(names[i]);
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        { 
            try
            {
                dataGrid.DataSource = data.Read();
                dataGrid.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Crud_Forms.GenericDialog form = null;
            try
            {
                form = new Crud_Forms.GenericDialog(DialogType.CREATE);
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    data.Create(form.GetPerson());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                form.Dispose();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            GenericDialog form = null;
            try
            {
                form = new Crud_Forms.GenericDialog(DialogType.UPDATE, GetSelectedPerson());
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    data.Update(form.GetPerson());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                form.Dispose();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            GenericDialog form = null;
            try
            {
                form = new Crud_Forms.GenericDialog(DialogType.DELETE, GetSelectedPerson());
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    data.Delete(form.GetPerson());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                form.Dispose();
            }
        }

        private void DB_chooseEventHandler(object sender, EventArgs e)
        {
            ComboBox obj = sender as ComboBox;
            try
            {
                data = new PersonDAO_File(obj.SelectedIndex);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            data.Update(GetSelectedPerson());
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

        private void SetDefaultRow()
        {
            var collection = (Person[])data.Read();
            var id = collection[collection.Length - 1].Id;
            var row = this.dataGrid.CurrentRow.Cells;
            row[3].Value = id + 1;
            row[0].Value = "";
            row[1].Value = "";
            row[2].Value = 0;
        }

        private void dataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            SetDefaultRow();
        }
    }
}
