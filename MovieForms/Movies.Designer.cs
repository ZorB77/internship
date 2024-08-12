namespace MovieWinForms
{
    partial class Movies
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
            label1 = new Label();
            movieList = new ListBox();
            titleLabel = new Label();
            label3 = new Label();
            movieTitleLabel = new Label();
            releaseDateLabel = new Label();
            label6 = new Label();
            genreLabel = new Label();
            label4 = new Label();
            descriptionBox = new TextBox();
            addMovieButton = new Button();
            editSelectedMovie = new Button();
            viewReviewsBtn = new Button();
            viewRolesBtn = new Button();
            label2 = new Label();
            averageRatingLabel = new Label();
            startDatePick = new DateTimePicker();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            endDatePick = new DateTimePicker();
            filterBtn = new Button();
            label9 = new Label();
            genreDropdown = new ComboBox();
            genreSubmit = new Button();
            sortByBoxInput = new ComboBox();
            sortSubmitBtn = new Button();
            deleteMovieBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(79, 29);
            label1.TabIndex = 0;
            label1.Text = "Movies";
            // 
            // movieList
            // 
            movieList.FormattingEnabled = true;
            movieList.Location = new Point(12, 41);
            movieList.Name = "movieList";
            movieList.Size = new Size(198, 124);
            movieList.TabIndex = 1;
            movieList.SelectedIndexChanged += movieList_SelectedIndexChanged;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            titleLabel.Location = new Point(216, 41);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(90, 21);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Movie Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label3.Location = new Point(216, 70);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 9;
            label3.Text = "Release Date";
            // 
            // movieTitleLabel
            // 
            movieTitleLabel.AutoSize = true;
            movieTitleLabel.Font = new Font("Comic Sans MS", 9F);
            movieTitleLabel.Location = new Point(322, 41);
            movieTitleLabel.Name = "movieTitleLabel";
            movieTitleLabel.Size = new Size(86, 20);
            movieTitleLabel.TabIndex = 10;
            movieTitleLabel.Text = "Movie Title";
            // 
            // releaseDateLabel
            // 
            releaseDateLabel.AutoSize = true;
            releaseDateLabel.Font = new Font("Comic Sans MS", 9F);
            releaseDateLabel.Location = new Point(322, 70);
            releaseDateLabel.Name = "releaseDateLabel";
            releaseDateLabel.Size = new Size(99, 20);
            releaseDateLabel.TabIndex = 11;
            releaseDateLabel.Text = "Release Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label6.Location = new Point(216, 99);
            label6.Name = "label6";
            label6.Size = new Size(51, 21);
            label6.TabIndex = 12;
            label6.Text = "Genre";
            // 
            // genreLabel
            // 
            genreLabel.AutoSize = true;
            genreLabel.Font = new Font("Comic Sans MS", 9F);
            genreLabel.Location = new Point(322, 99);
            genreLabel.Name = "genreLabel";
            genreLabel.Size = new Size(50, 20);
            genreLabel.TabIndex = 13;
            genreLabel.Text = "Genre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label4.Location = new Point(450, 41);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 14;
            label4.Text = "Description";
            // 
            // descriptionBox
            // 
            descriptionBox.Location = new Point(450, 67);
            descriptionBox.Multiline = true;
            descriptionBox.Name = "descriptionBox";
            descriptionBox.ReadOnly = true;
            descriptionBox.Size = new Size(335, 160);
            descriptionBox.TabIndex = 15;
            // 
            // addMovieButton
            // 
            addMovieButton.Location = new Point(12, 171);
            addMovieButton.Name = "addMovieButton";
            addMovieButton.Size = new Size(131, 51);
            addMovieButton.TabIndex = 16;
            addMovieButton.Text = "Add new movie";
            addMovieButton.UseVisualStyleBackColor = true;
            addMovieButton.Click += addMovieButton_Click;
            // 
            // editSelectedMovie
            // 
            editSelectedMovie.Location = new Point(149, 171);
            editSelectedMovie.Name = "editSelectedMovie";
            editSelectedMovie.Size = new Size(131, 51);
            editSelectedMovie.TabIndex = 17;
            editSelectedMovie.Text = "Edit selected movie";
            editSelectedMovie.UseVisualStyleBackColor = true;
            editSelectedMovie.Click += editSelectedMovie_Click;
            // 
            // viewReviewsBtn
            // 
            viewReviewsBtn.Location = new Point(12, 228);
            viewReviewsBtn.Name = "viewReviewsBtn";
            viewReviewsBtn.Size = new Size(131, 51);
            viewReviewsBtn.TabIndex = 18;
            viewReviewsBtn.Text = "View reviews";
            viewReviewsBtn.UseVisualStyleBackColor = true;
            viewReviewsBtn.Click += viewReviewsBtn_Click;
            // 
            // viewRolesBtn
            // 
            viewRolesBtn.Location = new Point(149, 228);
            viewRolesBtn.Name = "viewRolesBtn";
            viewRolesBtn.Size = new Size(131, 51);
            viewRolesBtn.TabIndex = 19;
            viewRolesBtn.Text = "View roles";
            viewRolesBtn.UseVisualStyleBackColor = true;
            viewRolesBtn.Click += viewRolesBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label2.Location = new Point(216, 125);
            label2.Name = "label2";
            label2.Size = new Size(74, 42);
            label2.TabIndex = 20;
            label2.Text = "Average \r\nrating";
            // 
            // averageRatingLabel
            // 
            averageRatingLabel.AutoSize = true;
            averageRatingLabel.Font = new Font("Comic Sans MS", 9F);
            averageRatingLabel.Location = new Point(322, 126);
            averageRatingLabel.Name = "averageRatingLabel";
            averageRatingLabel.Size = new Size(53, 20);
            averageRatingLabel.TabIndex = 21;
            averageRatingLabel.Text = "Rating";
            // 
            // startDatePick
            // 
            startDatePick.Location = new Point(69, 323);
            startDatePick.Name = "startDatePick";
            startDatePick.Size = new Size(250, 27);
            startDatePick.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
            label5.Location = new Point(12, 295);
            label5.Name = "label5";
            label5.Size = new Size(180, 25);
            label5.TabIndex = 24;
            label5.Text = "Filter by date range";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 327);
            label7.Name = "label7";
            label7.Size = new Size(49, 21);
            label7.TabIndex = 25;
            label7.Text = "Start";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label8.Location = new Point(25, 360);
            label8.Name = "label8";
            label8.Size = new Size(36, 21);
            label8.TabIndex = 27;
            label8.Text = "End";
            // 
            // endDatePick
            // 
            endDatePick.Location = new Point(69, 356);
            endDatePick.Name = "endDatePick";
            endDatePick.Size = new Size(250, 27);
            endDatePick.TabIndex = 26;
            // 
            // filterBtn
            // 
            filterBtn.Location = new Point(69, 389);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(94, 29);
            filterBtn.TabIndex = 28;
            filterBtn.Text = "Submit";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Click += filterBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
            label9.Location = new Point(336, 295);
            label9.Name = "label9";
            label9.Size = new Size(140, 25);
            label9.TabIndex = 29;
            label9.Text = "Filter by Genre";
            // 
            // genreDropdown
            // 
            genreDropdown.FormattingEnabled = true;
            genreDropdown.Location = new Point(336, 325);
            genreDropdown.Name = "genreDropdown";
            genreDropdown.Size = new Size(151, 28);
            genreDropdown.TabIndex = 30;
            // 
            // genreSubmit
            // 
            genreSubmit.Location = new Point(336, 359);
            genreSubmit.Name = "genreSubmit";
            genreSubmit.Size = new Size(94, 29);
            genreSubmit.TabIndex = 31;
            genreSubmit.Text = "Submit";
            genreSubmit.UseVisualStyleBackColor = true;
            genreSubmit.Click += genreSubmit_Click;
            // 
            // sortByBoxInput
            // 
            sortByBoxInput.FormattingEnabled = true;
            sortByBoxInput.Items.AddRange(new object[] { "Name", "Release Date" });
            sortByBoxInput.Location = new Point(88, 12);
            sortByBoxInput.Name = "sortByBoxInput";
            sortByBoxInput.Size = new Size(122, 28);
            sortByBoxInput.TabIndex = 32;
            sortByBoxInput.Text = "Sort by";
            // 
            // sortSubmitBtn
            // 
            sortSubmitBtn.Location = new Point(216, 11);
            sortSubmitBtn.Name = "sortSubmitBtn";
            sortSubmitBtn.Size = new Size(94, 29);
            sortSubmitBtn.TabIndex = 33;
            sortSubmitBtn.Text = "Sort";
            sortSubmitBtn.UseVisualStyleBackColor = true;
            sortSubmitBtn.Click += sortSubmitBtn_Click;
            // 
            // deleteMovieBtn
            // 
            deleteMovieBtn.ForeColor = Color.Black;
            deleteMovieBtn.Location = new Point(286, 171);
            deleteMovieBtn.Name = "deleteMovieBtn";
            deleteMovieBtn.Size = new Size(131, 51);
            deleteMovieBtn.TabIndex = 34;
            deleteMovieBtn.Text = "Delete selected movie";
            deleteMovieBtn.UseVisualStyleBackColor = true;
            deleteMovieBtn.Click += deleteMovieBtn_Click;
            // 
            // Movies
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteMovieBtn);
            Controls.Add(sortSubmitBtn);
            Controls.Add(sortByBoxInput);
            Controls.Add(genreSubmit);
            Controls.Add(genreDropdown);
            Controls.Add(label9);
            Controls.Add(filterBtn);
            Controls.Add(label8);
            Controls.Add(endDatePick);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(startDatePick);
            Controls.Add(averageRatingLabel);
            Controls.Add(label2);
            Controls.Add(viewRolesBtn);
            Controls.Add(viewReviewsBtn);
            Controls.Add(editSelectedMovie);
            Controls.Add(addMovieButton);
            Controls.Add(descriptionBox);
            Controls.Add(label4);
            Controls.Add(genreLabel);
            Controls.Add(label6);
            Controls.Add(releaseDateLabel);
            Controls.Add(movieTitleLabel);
            Controls.Add(label3);
            Controls.Add(titleLabel);
            Controls.Add(movieList);
            Controls.Add(label1);
            Name = "Movies";
            Text = "Movies";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox movieList;
        private Label titleLabel;
        private Label label3;
        private Label movieTitleLabel;
        private Label releaseDateLabel;
        private Label label6;
        private Label genreLabel;
        private Label label4;
        private TextBox descriptionBox;
        private Button addMovieButton;
        private Button editSelectedMovie;
        private Button viewReviewsBtn;
        private Button viewRolesBtn;
        private Label label2;
        private Label averageRatingLabel;
        private DateTimePicker startDatePick;
        private Label label5;
        private Label label7;
        private Label label8;
        private DateTimePicker endDatePick;
        private Button filterBtn;
        private Label label9;
        private ComboBox genreDropdown;
        private Button genreSubmit;
        private ComboBox sortByBoxInput;
        private Button sortSubmitBtn;
        private Button deleteMovieBtn;
    }
}