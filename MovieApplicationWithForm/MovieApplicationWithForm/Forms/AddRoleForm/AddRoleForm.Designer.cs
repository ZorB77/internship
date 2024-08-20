namespace MovieApplicationWithForm
{
    partial class AddRoleForm
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
            comboBoxAddRoleMovie = new ComboBox();
            comboBoxAddRolePerson = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBoxAddRoleName = new TextBox();
            label3 = new Label();
            buttonAddRole = new Button();
            numericUpDownSalary = new NumericUpDown();
            textBoxAddRoleDescription = new TextBox();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSalary).BeginInit();
            SuspendLayout();
            // 
            // comboBoxAddRoleMovie
            // 
            comboBoxAddRoleMovie.FormattingEnabled = true;
            comboBoxAddRoleMovie.Location = new Point(33, 68);
            comboBoxAddRoleMovie.Name = "comboBoxAddRoleMovie";
            comboBoxAddRoleMovie.Size = new Size(151, 28);
            comboBoxAddRoleMovie.TabIndex = 0;
            // 
            // comboBoxAddRolePerson
            // 
            comboBoxAddRolePerson.FormattingEnabled = true;
            comboBoxAddRolePerson.Location = new Point(33, 172);
            comboBoxAddRolePerson.Name = "comboBoxAddRolePerson";
            comboBoxAddRolePerson.Size = new Size(151, 28);
            comboBoxAddRolePerson.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 45);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 2;
            label1.Text = "Select the movie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 149);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 3;
            label2.Text = "Select the person:";
            // 
            // textBoxAddRoleName
            // 
            textBoxAddRoleName.Location = new Point(33, 277);
            textBoxAddRoleName.Name = "textBoxAddRoleName";
            textBoxAddRoleName.Size = new Size(151, 27);
            textBoxAddRoleName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 254);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 5;
            label3.Text = "Name of the role:";
            // 
            // buttonAddRole
            // 
            buttonAddRole.Location = new Point(33, 359);
            buttonAddRole.Name = "buttonAddRole";
            buttonAddRole.Size = new Size(94, 29);
            buttonAddRole.TabIndex = 6;
            buttonAddRole.Text = "Add Role";
            buttonAddRole.UseVisualStyleBackColor = true;
            buttonAddRole.Click += buttonAddRole_Click;
            // 
            // numericUpDownSalary
            // 
            numericUpDownSalary.Location = new Point(483, 68);
            numericUpDownSalary.Name = "numericUpDownSalary";
            numericUpDownSalary.Size = new Size(151, 27);
            numericUpDownSalary.TabIndex = 7;
            // 
            // textBoxAddRoleDescription
            // 
            textBoxAddRoleDescription.Location = new Point(483, 172);
            textBoxAddRoleDescription.Name = "textBoxAddRoleDescription";
            textBoxAddRoleDescription.Size = new Size(151, 27);
            textBoxAddRoleDescription.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 45);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 9;
            label4.Text = "Salary:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(483, 149);
            label5.Name = "label5";
            label5.Size = new Size(161, 20);
            label5.TabIndex = 10;
            label5.Text = "Description of the role:";
            // 
            // AddRoleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxAddRoleDescription);
            Controls.Add(numericUpDownSalary);
            Controls.Add(buttonAddRole);
            Controls.Add(label3);
            Controls.Add(textBoxAddRoleName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxAddRolePerson);
            Controls.Add(comboBoxAddRoleMovie);
            Name = "AddRoleForm";
            Text = "Add Role";
            ((System.ComponentModel.ISupportInitialize)numericUpDownSalary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxAddRoleMovie;
        private ComboBox comboBoxAddRolePerson;
        private Label label1;
        private Label label2;
        private TextBox textBoxAddRoleName;
        private Label label3;
        private Button buttonAddRole;
        private NumericUpDown numericUpDownSalary;
        private TextBox textBoxAddRoleDescription;
        private Label label4;
        private Label label5;
    }
}