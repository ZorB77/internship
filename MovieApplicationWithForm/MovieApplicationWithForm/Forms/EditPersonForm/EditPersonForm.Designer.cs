namespace MovieApplicationWithForm.Forms
{
    partial class EditPersonForm
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
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonUpdatePerson = new Button();
            buttonDeletePerson = new Button();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxPhone = new TextBox();
            textBoxCity = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 35);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(101, 160);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last name:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(101, 302);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(155, 27);
            dateTimePicker1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 279);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 3;
            label3.Text = "Birthdate:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(463, 35);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 4;
            label4.Text = "City:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(463, 160);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 5;
            label5.Text = "Phone:";
            // 
            // buttonUpdatePerson
            // 
            buttonUpdatePerson.Location = new Point(411, 300);
            buttonUpdatePerson.Name = "buttonUpdatePerson";
            buttonUpdatePerson.Size = new Size(115, 29);
            buttonUpdatePerson.TabIndex = 6;
            buttonUpdatePerson.Text = "Update Person";
            buttonUpdatePerson.UseVisualStyleBackColor = true;
            buttonUpdatePerson.Click += buttonUpdatePerson_Click_1;
            // 
            // buttonDeletePerson
            // 
            buttonDeletePerson.Location = new Point(532, 300);
            buttonDeletePerson.Name = "buttonDeletePerson";
            buttonDeletePerson.Size = new Size(115, 29);
            buttonDeletePerson.TabIndex = 7;
            buttonDeletePerson.Text = "Delete Person";
            buttonDeletePerson.UseVisualStyleBackColor = true;
            buttonDeletePerson.Click += buttonDeletePerson_Click_1;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(101, 58);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(155, 27);
            textBoxFirstName.TabIndex = 8;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(101, 183);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(155, 27);
            textBoxLastName.TabIndex = 9;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(463, 183);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(155, 27);
            textBoxPhone.TabIndex = 10;
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(463, 58);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(155, 27);
            textBoxCity.TabIndex = 11;
            // 
            // EditPersonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(buttonDeletePerson);
            Controls.Add(buttonUpdatePerson);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditPersonForm";
            Text = "Edit Person";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonUpdatePerson;
        private Button buttonDeletePerson;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxPhone;
        private TextBox textBoxCity;
    }
}