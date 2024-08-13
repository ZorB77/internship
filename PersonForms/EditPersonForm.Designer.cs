namespace MovieWinForms.PersonForms
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
            saveChangesBtn = new Button();
            label4 = new Label();
            birthDateInput = new MonthCalendar();
            label3 = new Label();
            label1 = new Label();
            lastNameInput = new TextBox();
            firstNameInput = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(262, 338);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(104, 56);
            saveChangesBtn.TabIndex = 28;
            saveChangesBtn.Text = "Save changes";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 119);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 25;
            label4.Text = "Birthdate";
            // 
            // birthDateInput
            // 
            birthDateInput.Location = new Point(104, 119);
            birthDateInput.MaxSelectionCount = 1;
            birthDateInput.Name = "birthDateInput";
            birthDateInput.TabIndex = 24;
            birthDateInput.Validating += dateInput_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 83);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 23;
            label3.Text = "Last Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 48);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 22;
            label1.Text = "First Name";
            // 
            // lastNameInput
            // 
            lastNameInput.Location = new Point(104, 80);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.Size = new Size(262, 27);
            lastNameInput.TabIndex = 21;
            lastNameInput.Validating += lastNameInput_Validating;
            // 
            // firstNameInput
            // 
            firstNameInput.Location = new Point(104, 45);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.Size = new Size(262, 27);
            firstNameInput.TabIndex = 20;
            firstNameInput.Validating += firstNameInput_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(124, 29);
            label2.TabIndex = 19;
            label2.Text = "Edit person";
            // 
            // EditPersonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 406);
            Controls.Add(saveChangesBtn);
            Controls.Add(label4);
            Controls.Add(birthDateInput);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lastNameInput);
            Controls.Add(firstNameInput);
            Controls.Add(label2);
            Name = "EditPersonForm";
            Text = "EditPersonForm";
            Load += EditPersonForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveChangesBtn;
        private Label label4;
        private MonthCalendar birthDateInput;
        private Label label3;
        private Label label1;
        private TextBox lastNameInput;
        private TextBox firstNameInput;
        private Label label2;
    }
}