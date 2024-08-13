namespace MovieWinForms.StudioForms
{
    partial class StudiosForm
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
            studiosList = new ListBox();
            label1 = new Label();
            studioLocationLabel = new Label();
            label6 = new Label();
            foundedDateLabel = new Label();
            studioNameLabel = new Label();
            label3 = new Label();
            studioLabel = new Label();
            addStudioBtn = new Button();
            edtiStudioBtn = new Button();
            deleteStudioBtn = new Button();
            SuspendLayout();
            // 
            // studiosList
            // 
            studiosList.FormattingEnabled = true;
            studiosList.Location = new Point(12, 41);
            studiosList.Name = "studiosList";
            studiosList.Size = new Size(198, 224);
            studiosList.TabIndex = 3;
            studiosList.SelectedIndexChanged += studiosList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 29);
            label1.TabIndex = 2;
            label1.Text = "Studios";
            // 
            // studioLocationLabel
            // 
            studioLocationLabel.AutoSize = true;
            studioLocationLabel.Font = new Font("Comic Sans MS", 9F);
            studioLocationLabel.Location = new Point(322, 64);
            studioLocationLabel.Name = "studioLocationLabel";
            studioLocationLabel.Size = new Size(68, 20);
            studioLocationLabel.TabIndex = 19;
            studioLocationLabel.Text = "Location";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label6.Location = new Point(216, 64);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 18;
            label6.Text = "Location";
            // 
            // foundedDateLabel
            // 
            foundedDateLabel.AutoSize = true;
            foundedDateLabel.Font = new Font("Comic Sans MS", 9F);
            foundedDateLabel.Location = new Point(322, 88);
            foundedDateLabel.Name = "foundedDateLabel";
            foundedDateLabel.Size = new Size(106, 20);
            foundedDateLabel.TabIndex = 17;
            foundedDateLabel.Text = "Founded Date";
            // 
            // studioNameLabel
            // 
            studioNameLabel.AutoSize = true;
            studioNameLabel.Font = new Font("Comic Sans MS", 9F);
            studioNameLabel.Location = new Point(322, 41);
            studioNameLabel.Name = "studioNameLabel";
            studioNameLabel.Size = new Size(98, 20);
            studioNameLabel.TabIndex = 16;
            studioNameLabel.Text = "Studio Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label3.Location = new Point(216, 88);
            label3.Name = "label3";
            label3.Size = new Size(110, 21);
            label3.TabIndex = 15;
            label3.Text = "Founded Date";
            // 
            // studioLabel
            // 
            studioLabel.AutoSize = true;
            studioLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            studioLabel.Location = new Point(216, 41);
            studioLabel.Name = "studioLabel";
            studioLabel.Size = new Size(103, 21);
            studioLabel.TabIndex = 14;
            studioLabel.Text = "Studio Name";
            // 
            // addStudioBtn
            // 
            addStudioBtn.Location = new Point(12, 271);
            addStudioBtn.Name = "addStudioBtn";
            addStudioBtn.Size = new Size(131, 51);
            addStudioBtn.TabIndex = 20;
            addStudioBtn.Text = "Add new studio";
            addStudioBtn.UseVisualStyleBackColor = true;
            addStudioBtn.Click += addStudioBtn_Click;
            // 
            // edtiStudioBtn
            // 
            edtiStudioBtn.Location = new Point(154, 271);
            edtiStudioBtn.Name = "edtiStudioBtn";
            edtiStudioBtn.Size = new Size(131, 51);
            edtiStudioBtn.TabIndex = 21;
            edtiStudioBtn.Text = "Edit studio";
            edtiStudioBtn.UseVisualStyleBackColor = true;
            edtiStudioBtn.Click += edtiStudioBtn_Click;
            // 
            // deleteStudioBtn
            // 
            deleteStudioBtn.Location = new Point(297, 271);
            deleteStudioBtn.Name = "deleteStudioBtn";
            deleteStudioBtn.Size = new Size(131, 51);
            deleteStudioBtn.TabIndex = 22;
            deleteStudioBtn.Text = "Delete studio";
            deleteStudioBtn.UseVisualStyleBackColor = true;
            deleteStudioBtn.Click += deleteStudioBtn_Click;
            // 
            // StudiosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 331);
            Controls.Add(deleteStudioBtn);
            Controls.Add(edtiStudioBtn);
            Controls.Add(addStudioBtn);
            Controls.Add(studioLocationLabel);
            Controls.Add(label6);
            Controls.Add(foundedDateLabel);
            Controls.Add(studioNameLabel);
            Controls.Add(label3);
            Controls.Add(studioLabel);
            Controls.Add(studiosList);
            Controls.Add(label1);
            Name = "StudiosForm";
            Text = "StudiosForm";
            Load += StudiosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox studiosList;
        private Label label1;
        private Label studioLocationLabel;
        private Label label6;
        private Label foundedDateLabel;
        private Label studioNameLabel;
        private Label label3;
        private Label studioLabel;
        private Button addStudioBtn;
        private Button edtiStudioBtn;
        private Button deleteStudioBtn;
    }
}