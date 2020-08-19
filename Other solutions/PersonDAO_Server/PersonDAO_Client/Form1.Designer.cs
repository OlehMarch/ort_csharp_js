namespace PersonDAO_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateConnection = new System.Windows.Forms.Button();
            this.comboDB = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateConnection
            // 
            this.buttonCreateConnection.Location = new System.Drawing.Point(487, 39);
            this.buttonCreateConnection.Name = "buttonCreateConnection";
            this.buttonCreateConnection.Size = new System.Drawing.Size(148, 23);
            this.buttonCreateConnection.TabIndex = 2;
            this.buttonCreateConnection.Text = "Create connection";
            this.buttonCreateConnection.UseVisualStyleBackColor = true;
            this.buttonCreateConnection.Click += new System.EventHandler(this.buttonCreateConnection_Click);
            // 
            // comboDB
            // 
            this.comboDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDB.FormattingEnabled = true;
            this.comboDB.Items.AddRange(new object[] {
            "Mock",
            "H2",
            "MsSQL",
            "MySQL",
            "Mongo",
            "Redis",
            "Neo4j",
            "CSV",
            "JSON",
            "XML",
            "YML",
            "CSV Extended",
            "YML Extended",
            "XML Extended",
            "JSON Extended",
            "Cassandra",
            "Entity",
            "NHibernate"});
            this.comboDB.Location = new System.Drawing.Point(487, 12);
            this.comboDB.Name = "comboDB";
            this.comboDB.Size = new System.Drawing.Size(148, 21);
            this.comboDB.TabIndex = 16;
            this.comboDB.Visible = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(396, 499);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonCRUD_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Location = new System.Drawing.Point(283, 498);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 14;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonCRUD_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.Location = new System.Drawing.Point(145, 499);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 22);
            this.buttonInsert.TabIndex = 13;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonCRUD_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRead.Location = new System.Drawing.Point(23, 499);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 12;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonCRUD_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(469, 460);
            this.dataGrid.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 541);
            this.Controls.Add(this.comboDB);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.buttonCreateConnection);
            this.Name = "Form1";
            this.Text = "CRUD client";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateConnection;
        private System.Windows.Forms.ComboBox comboDB;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}

