namespace MovieApplicationWithForm.Forms
{
    partial class AddPersonForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxLastName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxFirstName = new TextBox();
            dateTimePickerBirthdate = new DateTimePicker();
            buttonAddPerson = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 52);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 126);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 208);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Birthdate:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 288);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(48, 149);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(170, 27);
            textBoxLastName.TabIndex = 4;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(48, 311);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(170, 27);
            textBoxEmail.TabIndex = 5;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(48, 75);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(170, 27);
            textBoxFirstName.TabIndex = 6;
            textBoxFirstName.TextChanged += textBox3_TextChanged;
            // 
            // dateTimePickerBirthdate
            // 
            dateTimePickerBirthdate.Location = new Point(48, 231);
            dateTimePickerBirthdate.Name = "dateTimePickerBirthdate";
            dateTimePickerBirthdate.Size = new Size(170, 27);
            dateTimePickerBirthdate.TabIndex = 7;
            // 
            // buttonAddPerson
            // 
            buttonAddPerson.Location = new Point(48, 367);
            buttonAddPerson.Name = "buttonAddPerson";
            buttonAddPerson.Size = new Size(94, 29);
            buttonAddPerson.TabIndex = 8;
            buttonAddPerson.Text = "Add Person";
            buttonAddPerson.UseVisualStyleBackColor = true;
            buttonAddPerson.Click += buttonAddPerson_Click;
            // 
            // AddPersonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAddPerson);
            Controls.Add(dateTimePickerBirthdate);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxLastName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddPersonForm";
            Text = "Add Person";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxLastName;
        private TextBox textBoxEmail;
        private TextBox textBoxFirstName;
        private DateTimePicker dateTimePickerBirthdate;
        private Button buttonAddPerson;
    }
}