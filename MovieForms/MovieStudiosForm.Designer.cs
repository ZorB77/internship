namespace MovieWinForms.MovieForms
{
    partial class MovieStudiosForm
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
            allStudios = new ListBox();
            label1 = new Label();
            movieNameLabel = new Label();
            addStudioBtn = new Button();
            studiosForMovie = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // allStudios
            // 
            allStudios.FormattingEnabled = true;
            allStudios.Location = new Point(12, 79);
            allStudios.Name = "allStudios";
            allStudios.Size = new Size(275, 304);
            allStudios.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(125, 29);
            label1.TabIndex = 1;
            label1.Text = "Studios for";
            // 
            // movieNameLabel
            // 
            movieNameLabel.AutoSize = true;
            movieNameLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            movieNameLabel.ForeColor = Color.Coral;
            movieNameLabel.Location = new Point(12, 38);
            movieNameLabel.Name = "movieNameLabel";
            movieNameLabel.Size = new Size(132, 29);
            movieNameLabel.TabIndex = 11;
            movieNameLabel.Text = "Movie Name";
            // 
            // addStudioBtn
            // 
            addStudioBtn.Location = new Point(13, 389);
            addStudioBtn.Name = "addStudioBtn";
            addStudioBtn.Size = new Size(131, 51);
            addStudioBtn.TabIndex = 20;
            addStudioBtn.Text = "Add Studio";
            addStudioBtn.UseVisualStyleBackColor = true;
            addStudioBtn.Click += addStudioBtn_Click;
            // 
            // studiosForMovie
            // 
            studiosForMovie.FormattingEnabled = true;
            studiosForMovie.Location = new Point(328, 79);
            studiosForMovie.Name = "studiosForMovie";
            studiosForMovie.Size = new Size(280, 304);
            studiosForMovie.TabIndex = 21;
            // 
            // button1
            // 
            button1.Location = new Point(328, 389);
            button1.Name = "button1";
            button1.Size = new Size(131, 51);
            button1.TabIndex = 22;
            button1.Text = "Remove Studio";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MovieStudiosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 482);
            Controls.Add(button1);
            Controls.Add(studiosForMovie);
            Controls.Add(addStudioBtn);
            Controls.Add(movieNameLabel);
            Controls.Add(label1);
            Controls.Add(allStudios);
            Name = "MovieStudiosForm";
            Text = "MovieStudiosList";
            Load += MovieStudiosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox allStudios;
        private Label label1;
        private Label movieNameLabel;
        private Button addStudioBtn;
        private ListBox studiosForMovie;
        private Button button1;
    }
}