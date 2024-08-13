namespace MovieWinForms.RoleForms
{
    partial class EditRole
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
            label1 = new Label();
            roleNameInput = new TextBox();
            saveChangesBtn = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(98, 29);
            label2.TabIndex = 27;
            label2.Text = "Edit role";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 35;
            label1.Text = "Role name";
            // 
            // roleNameInput
            // 
            roleNameInput.Location = new Point(12, 65);
            roleNameInput.Name = "roleNameInput";
            roleNameInput.Size = new Size(190, 27);
            roleNameInput.TabIndex = 36;
            roleNameInput.Validating += roleNameInput_Validating;
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(12, 98);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(116, 43);
            saveChangesBtn.TabIndex = 37;
            saveChangesBtn.Text = "Save changes";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // EditRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 152);
            Controls.Add(saveChangesBtn);
            Controls.Add(roleNameInput);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "EditRole";
            Text = "EditRole";
            Load += EditRole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox roleNameInput;
        private Button saveChangesBtn;
    }
}