namespace MovieWinForms.PersonForms
{
    partial class NewPerson
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
            label2 = new Label();
            firstNameInput = new TextBox();
            lastNameInput = new TextBox();
            label1 = new Label();
            label3 = new Label();
            birthDateInput = new MonthCalendar();
            label4 = new Label();
            label5 = new Label();
            emailInput = new TextBox();
            addPersonBtn = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(168, 29);
            label2.TabIndex = 9;
            label2.Text = "Add new person";
            // 
            // firstNameInput
            // 
            firstNameInput.Location = new Point(104, 45);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.Size = new Size(262, 27);
            firstNameInput.TabIndex = 10;
            // 
            // lastNameInput
            // 
            lastNameInput.Location = new Point(104, 80);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.Size = new Size(262, 27);
            lastNameInput.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 48);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 12;
            label1.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 83);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 13;
            label3.Text = "Last Name";
            // 
            // birthDateInput
            // 
            birthDateInput.Location = new Point(104, 119);
            birthDateInput.MaxSelectionCount = 1;
            birthDateInput.Name = "birthDateInput";
            birthDateInput.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 119);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 15;
            label4.Text = "Birthdate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 341);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 17;
            label5.Text = "Email";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(104, 338);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(262, 27);
            emailInput.TabIndex = 16;
            // 
            // addPersonBtn
            // 
            addPersonBtn.Location = new Point(262, 371);
            addPersonBtn.Name = "addPersonBtn";
            addPersonBtn.Size = new Size(104, 56);
            addPersonBtn.TabIndex = 18;
            addPersonBtn.Text = "Add person";
            addPersonBtn.UseVisualStyleBackColor = true;
            addPersonBtn.Click += addPersonBtn_Click;
            // 
            // NewPerson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 450);
            Controls.Add(addPersonBtn);
            Controls.Add(label5);
            Controls.Add(emailInput);
            Controls.Add(label4);
            Controls.Add(birthDateInput);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lastNameInput);
            Controls.Add(firstNameInput);
            Controls.Add(label2);
            Name = "NewPerson";
            Text = "NewPerson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox firstNameInput;
        private TextBox lastNameInput;
        private Label label1;
        private Label label3;
        private MonthCalendar birthDateInput;
        private Label label4;
        private Label label5;
        private TextBox emailInput;
        private Button addPersonBtn;
    }
}