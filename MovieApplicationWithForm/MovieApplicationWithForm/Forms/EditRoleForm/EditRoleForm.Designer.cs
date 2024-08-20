namespace MovieApplicationWithForm.Forms.EditRoleForm
{
    partial class EditRoleForm
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
            buttonUpdateRole = new Button();
            buttonDeleteRole = new Button();
            comboBoxMovies = new ComboBox();
            comboBoxPersons = new ComboBox();
            textBoxDescription = new TextBox();
            textBoxName = new TextBox();
            textBoxSalary = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // buttonUpdateRole
            // 
            buttonUpdateRole.Location = new Point(390, 290);
            buttonUpdateRole.Name = "buttonUpdateRole";
            buttonUpdateRole.Size = new Size(100, 29);
            buttonUpdateRole.TabIndex = 0;
            buttonUpdateRole.Text = "Update Role";
            buttonUpdateRole.UseVisualStyleBackColor = true;
            buttonUpdateRole.Click += buttonUpdateRole_Click;
            // 
            // buttonDeleteRole
            // 
            buttonDeleteRole.Location = new Point(512, 290);
            buttonDeleteRole.Name = "buttonDeleteRole";
            buttonDeleteRole.Size = new Size(100, 29);
            buttonDeleteRole.TabIndex = 1;
            buttonDeleteRole.Text = "Delete Role";
            buttonDeleteRole.UseVisualStyleBackColor = true;
            buttonDeleteRole.Click += buttonDeleteRole_Click;
            // 
            // comboBoxMovies
            // 
            comboBoxMovies.FormattingEnabled = true;
            comboBoxMovies.Location = new Point(71, 76);
            comboBoxMovies.Name = "comboBoxMovies";
            comboBoxMovies.Size = new Size(151, 28);
            comboBoxMovies.TabIndex = 2;
            // 
            // comboBoxPersons
            // 
            comboBoxPersons.FormattingEnabled = true;
            comboBoxPersons.Location = new Point(71, 183);
            comboBoxPersons.Name = "comboBoxPersons";
            comboBoxPersons.Size = new Size(151, 28);
            comboBoxPersons.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(402, 76);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(151, 27);
            textBoxDescription.TabIndex = 4;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(71, 292);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(151, 27);
            textBoxName.TabIndex = 5;
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(402, 183);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(151, 27);
            textBoxSalary.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 53);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 7;
            label1.Text = "Movie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 160);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 8;
            label2.Text = "Person:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 269);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 9;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(402, 53);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 10;
            label4.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(402, 160);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 11;
            label5.Text = "Salary:";
            // 
            // EditRoleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(718, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxSalary);
            Controls.Add(textBoxName);
            Controls.Add(textBoxDescription);
            Controls.Add(comboBoxPersons);
            Controls.Add(comboBoxMovies);
            Controls.Add(buttonDeleteRole);
            Controls.Add(buttonUpdateRole);
            Name = "EditRoleForm";
            Text = "Edit Role";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUpdateRole;
        private Button buttonDeleteRole;
        private ComboBox comboBoxMovies;
        private ComboBox comboBoxPersons;
        private TextBox textBoxDescription;
        private TextBox textBoxName;
        private TextBox textBoxSalary;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}