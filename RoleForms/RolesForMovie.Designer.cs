namespace MovieWinForms.RoleForms
{
    partial class RolesForMovie
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
            goBackBtn = new Button();
            button2 = new Button();
            saveChangesBtn = new Button();
            movieNameLabel = new Label();
            label2 = new Label();
            rolesList = new ListBox();
            label1 = new Label();
            label3 = new Label();
            roleNameLabel = new Label();
            actorNameLabel = new Label();
            editRoleBtn = new Button();
            SuspendLayout();
            // 
            // goBackBtn
            // 
            goBackBtn.Location = new Point(12, 315);
            goBackBtn.Name = "goBackBtn";
            goBackBtn.Size = new Size(143, 58);
            goBackBtn.TabIndex = 33;
            goBackBtn.Text = "Go back to movies";
            goBackBtn.UseVisualStyleBackColor = true;
            goBackBtn.Click += goBackBtn_Click;
            // 
            // button2
            // 
            button2.Location = new Point(310, 251);
            button2.Name = "button2";
            button2.Size = new Size(143, 58);
            button2.TabIndex = 32;
            button2.Text = "Delete role";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(12, 251);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(143, 58);
            saveChangesBtn.TabIndex = 30;
            saveChangesBtn.Text = "Add role";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // movieNameLabel
            // 
            movieNameLabel.AutoSize = true;
            movieNameLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            movieNameLabel.ForeColor = Color.Coral;
            movieNameLabel.Location = new Point(108, 9);
            movieNameLabel.Name = "movieNameLabel";
            movieNameLabel.Size = new Size(132, 29);
            movieNameLabel.TabIndex = 27;
            movieNameLabel.Text = "Movie Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(103, 29);
            label2.TabIndex = 26;
            label2.Text = "Roles for";
            // 
            // rolesList
            // 
            rolesList.FormattingEnabled = true;
            rolesList.Location = new Point(12, 41);
            rolesList.Name = "rolesList";
            rolesList.Size = new Size(150, 204);
            rolesList.TabIndex = 25;
            rolesList.SelectedIndexChanged += rolesList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(168, 41);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 34;
            label1.Text = "Role name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(168, 61);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 35;
            label3.Text = "Actor name";
            // 
            // roleNameLabel
            // 
            roleNameLabel.AutoSize = true;
            roleNameLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roleNameLabel.Location = new Point(263, 41);
            roleNameLabel.Name = "roleNameLabel";
            roleNameLabel.Size = new Size(77, 20);
            roleNameLabel.TabIndex = 36;
            roleNameLabel.Text = "Role name";
            // 
            // actorNameLabel
            // 
            actorNameLabel.AutoSize = true;
            actorNameLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            actorNameLabel.Location = new Point(263, 61);
            actorNameLabel.Name = "actorNameLabel";
            actorNameLabel.Size = new Size(89, 20);
            actorNameLabel.TabIndex = 37;
            actorNameLabel.Text = "Actor name";
            // 
            // editRoleBtn
            // 
            editRoleBtn.Location = new Point(161, 251);
            editRoleBtn.Name = "editRoleBtn";
            editRoleBtn.Size = new Size(143, 58);
            editRoleBtn.TabIndex = 39;
            editRoleBtn.Text = "Edit role";
            editRoleBtn.UseVisualStyleBackColor = true;
            editRoleBtn.Click += editRoleBtn_Click;
            // 
            // RolesForMovie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 381);
            Controls.Add(editRoleBtn);
            Controls.Add(actorNameLabel);
            Controls.Add(roleNameLabel);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(goBackBtn);
            Controls.Add(button2);
            Controls.Add(saveChangesBtn);
            Controls.Add(movieNameLabel);
            Controls.Add(label2);
            Controls.Add(rolesList);
            Name = "RolesForMovie";
            Text = "RolesForMovie";
            Load += RolesForMovie_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button goBackBtn;
        private Button button2;
        private Button saveChangesBtn;
        private Label movieNameLabel;
        private Label label2;
        private ListBox rolesList;
        private Label label1;
        private Label label3;
        private Label roleNameLabel;
        private Label actorNameLabel;
        private Button editRoleBtn;
    }
}