namespace MovieWinForms
{
    partial class MainForm
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
            topTenMoviesList = new ListBox();
            label1 = new Label();
            viewMoviesBtn = new Button();
            viewPeopleBtn = new Button();
            viewStudiosBtn = new Button();
            SuspendLayout();
            // 
            // topTenMoviesList
            // 
            topTenMoviesList.FormattingEnabled = true;
            topTenMoviesList.Location = new Point(12, 41);
            topTenMoviesList.Name = "topTenMoviesList";
            topTenMoviesList.Size = new Size(263, 204);
            topTenMoviesList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(263, 29);
            label1.TabIndex = 1;
            label1.Text = "Top 10 movies by ratings";
            // 
            // viewMoviesBtn
            // 
            viewMoviesBtn.Location = new Point(12, 251);
            viewMoviesBtn.Name = "viewMoviesBtn";
            viewMoviesBtn.Size = new Size(126, 56);
            viewMoviesBtn.TabIndex = 19;
            viewMoviesBtn.Text = "View Movies";
            viewMoviesBtn.UseVisualStyleBackColor = true;
            viewMoviesBtn.Click += viewMoviesBtn_Click;
            // 
            // viewPeopleBtn
            // 
            viewPeopleBtn.Location = new Point(149, 251);
            viewPeopleBtn.Name = "viewPeopleBtn";
            viewPeopleBtn.Size = new Size(126, 56);
            viewPeopleBtn.TabIndex = 20;
            viewPeopleBtn.Text = "View People";
            viewPeopleBtn.UseVisualStyleBackColor = true;
            viewPeopleBtn.Click += viewPeopleBtn_Click;
            // 
            // viewStudiosBtn
            // 
            viewStudiosBtn.Location = new Point(12, 313);
            viewStudiosBtn.Name = "viewStudiosBtn";
            viewStudiosBtn.Size = new Size(126, 56);
            viewStudiosBtn.TabIndex = 21;
            viewStudiosBtn.Text = "View Studios";
            viewStudiosBtn.UseVisualStyleBackColor = true;
            viewStudiosBtn.Click += viewStudiosBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 385);
            Controls.Add(viewStudiosBtn);
            Controls.Add(viewPeopleBtn);
            Controls.Add(viewMoviesBtn);
            Controls.Add(label1);
            Controls.Add(topTenMoviesList);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox topTenMoviesList;
        private Label label1;
        private Button viewMoviesBtn;
        private Button viewPeopleBtn;
        private Button viewStudiosBtn;
    }
}