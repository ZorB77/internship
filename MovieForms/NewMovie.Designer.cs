namespace MovieWinForms
{
    partial class NewMovie
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
            addMovieBtn = new Button();
            genreInput = new TextBox();
            descriptionInput = new TextBox();
            dateInput = new MonthCalendar();
            titleInput = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // addMovieBtn
            // 
            addMovieBtn.Location = new Point(12, 332);
            addMovieBtn.Name = "addMovieBtn";
            addMovieBtn.Size = new Size(143, 58);
            addMovieBtn.TabIndex = 13;
            addMovieBtn.Text = "Add Movie";
            addMovieBtn.UseVisualStyleBackColor = true;
            addMovieBtn.Click += addMovieBtn_Click;
            // 
            // genreInput
            // 
            genreInput.Location = new Point(12, 74);
            genreInput.Name = "genreInput";
            genreInput.PlaceholderText = "Genre";
            genreInput.Size = new Size(125, 27);
            genreInput.TabIndex = 12;
            genreInput.Validating += genreInput_Validating;
            // 
            // descriptionInput
            // 
            descriptionInput.Location = new Point(307, 113);
            descriptionInput.Multiline = true;
            descriptionInput.Name = "descriptionInput";
            descriptionInput.PlaceholderText = "Enter description...";
            descriptionInput.Size = new Size(319, 205);
            descriptionInput.TabIndex = 11;
            descriptionInput.Validating += descriptionInput_Validating;
            // 
            // dateInput
            // 
            dateInput.FirstDayOfWeek = Day.Monday;
            dateInput.Location = new Point(12, 113);
            dateInput.MaxSelectionCount = 1;
            dateInput.Name = "dateInput";
            dateInput.TabIndex = 10;
            dateInput.Validating += dateInput_Validating;
            // 
            // titleInput
            // 
            titleInput.Location = new Point(12, 41);
            titleInput.Name = "titleInput";
            titleInput.PlaceholderText = "Title";
            titleInput.Size = new Size(262, 27);
            titleInput.TabIndex = 9;
            titleInput.Validating += titleInput_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(159, 29);
            label2.TabIndex = 8;
            label2.Text = "Add new movie";
            // 
            // NewMovie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 410);
            Controls.Add(addMovieBtn);
            Controls.Add(genreInput);
            Controls.Add(descriptionInput);
            Controls.Add(dateInput);
            Controls.Add(titleInput);
            Controls.Add(label2);
            Name = "NewMovie";
            Text = "NewMovie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addMovieBtn;
        private TextBox genreInput;
        private TextBox descriptionInput;
        private MonthCalendar dateInput;
        private TextBox titleInput;
        private Label label2;
    }
}