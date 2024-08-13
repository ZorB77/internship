namespace MovieWinForms.RoleForms
{
    partial class AddRole
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
            movieNameLabel = new Label();
            label2 = new Label();
            personList = new ListBox();
            label1 = new Label();
            selectPersonLabel = new Label();
            roleNameInput = new TextBox();
            addRoleBtn = new Button();
            SuspendLayout();
            // 
            // movieNameLabel
            // 
            movieNameLabel.AutoSize = true;
            movieNameLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            movieNameLabel.ForeColor = Color.Coral;
            movieNameLabel.Location = new Point(144, 4);
            movieNameLabel.Name = "movieNameLabel";
            movieNameLabel.Size = new Size(132, 29);
            movieNameLabel.TabIndex = 30;
            movieNameLabel.Text = "Movie Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 4);
            label2.Name = "label2";
            label2.Size = new Size(138, 29);
            label2.TabIndex = 29;
            label2.Text = "Add role for";
            // 
            // personList
            // 
            personList.FormattingEnabled = true;
            personList.Location = new Point(12, 65);
            personList.Name = "personList";
            personList.Size = new Size(150, 204);
            personList.TabIndex = 28;
            personList.SelectedIndexChanged += personList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 35;
            label1.Text = "Select Person";
            // 
            // selectPersonLabel
            // 
            selectPersonLabel.AutoSize = true;
            selectPersonLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectPersonLabel.Location = new Point(168, 41);
            selectPersonLabel.Name = "selectPersonLabel";
            selectPersonLabel.Size = new Size(87, 21);
            selectPersonLabel.TabIndex = 36;
            selectPersonLabel.Text = "Role Name";
            // 
            // roleNameInput
            // 
            roleNameInput.Location = new Point(168, 65);
            roleNameInput.Name = "roleNameInput";
            roleNameInput.Size = new Size(175, 27);
            roleNameInput.TabIndex = 37;
            roleNameInput.Validating += roleNameInput_Validating;
            // 
            // addRoleBtn
            // 
            addRoleBtn.Location = new Point(168, 98);
            addRoleBtn.Name = "addRoleBtn";
            addRoleBtn.Size = new Size(143, 58);
            addRoleBtn.TabIndex = 38;
            addRoleBtn.Text = "Add role";
            addRoleBtn.UseVisualStyleBackColor = true;
            addRoleBtn.Click += addRoleBtn_Click;
            // 
            // AddRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 280);
            Controls.Add(addRoleBtn);
            Controls.Add(roleNameInput);
            Controls.Add(selectPersonLabel);
            Controls.Add(label1);
            Controls.Add(movieNameLabel);
            Controls.Add(label2);
            Controls.Add(personList);
            Name = "AddRole";
            Text = "AddRole";
            Load += AddRole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label movieNameLabel;
        private Label label2;
        private ListBox personList;
        private Label label1;
        private Label selectPersonLabel;
        private TextBox roleNameInput;
        private Button addRoleBtn;
    }
}