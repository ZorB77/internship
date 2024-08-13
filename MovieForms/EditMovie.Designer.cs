namespace MovieWinForms
{
    partial class EditMovie
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
            genreInput = new TextBox();
            descriptionInput = new TextBox();
            dateInput = new MonthCalendar();
            titleInput = new TextBox();
            label2 = new Label();
            saveChangesBtn = new Button();
            SuspendLayout();
            // 
            // genreInput
            // 
            genreInput.Location = new Point(12, 74);
            genreInput.Name = "genreInput";
            genreInput.PlaceholderText = "Genre";
            genreInput.Size = new Size(125, 27);
            genreInput.TabIndex = 18;
            genreInput.Validating += genreInput_Validating;
            // 
            // descriptionInput
            // 
            descriptionInput.Location = new Point(307, 113);
            descriptionInput.Multiline = true;
            descriptionInput.Name = "descriptionInput";
            descriptionInput.PlaceholderText = "Enter description...";
            descriptionInput.Size = new Size(319, 205);
            descriptionInput.TabIndex = 17;
            descriptionInput.Validating += descriptionInput_Validating;
            // 
            // dateInput
            // 
            dateInput.Location = new Point(12, 113);
            dateInput.MaxSelectionCount = 1;
            dateInput.Name = "dateInput";
            dateInput.TabIndex = 16;
            dateInput.Validating += dateInput_Validating;
            // 
            // titleInput
            // 
            titleInput.Location = new Point(12, 41);
            titleInput.Name = "titleInput";
            titleInput.PlaceholderText = "Title";
            titleInput.Size = new Size(262, 27);
            titleInput.TabIndex = 15;
            titleInput.Validating += titleInput_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(115, 29);
            label2.TabIndex = 14;
            label2.Text = "Edit movie";
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(12, 332);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(143, 58);
            saveChangesBtn.TabIndex = 20;
            saveChangesBtn.Text = "Save changes";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // EditMovie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 401);
            Controls.Add(saveChangesBtn);
            Controls.Add(genreInput);
            Controls.Add(descriptionInput);
            Controls.Add(dateInput);
            Controls.Add(titleInput);
            Controls.Add(label2);
            Name = "EditMovie";
            Text = "EditMovie";
            Load += EditMovie_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox genreInput;
        private TextBox descriptionInput;
        private MonthCalendar dateInput;
        private TextBox titleInput;
        private Label label2;
        private Button saveChangesBtn;
    }
}