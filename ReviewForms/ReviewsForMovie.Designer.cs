namespace MovieWinForms.ReviewForms
{
    partial class ReviewsForMovie
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
            reviewsBox = new ListBox();
            label2 = new Label();
            movieNameLabel = new Label();
            reviewCommentBox = new TextBox();
            label1 = new Label();
            saveChangesBtn = new Button();
            editReviewBtn = new Button();
            deleteReviewBtn = new Button();
            goBackBtn = new Button();
            SuspendLayout();
            // 
            // reviewsBox
            // 
            reviewsBox.FormattingEnabled = true;
            reviewsBox.Location = new Point(12, 41);
            reviewsBox.Name = "reviewsBox";
            reviewsBox.Size = new Size(150, 204);
            reviewsBox.TabIndex = 0;
            reviewsBox.SelectedIndexChanged += reviewsBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(128, 29);
            label2.TabIndex = 9;
            label2.Text = "Reviews for";
            // 
            // movieNameLabel
            // 
            movieNameLabel.AutoSize = true;
            movieNameLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            movieNameLabel.ForeColor = Color.Coral;
            movieNameLabel.Location = new Point(135, 9);
            movieNameLabel.Name = "movieNameLabel";
            movieNameLabel.Size = new Size(132, 29);
            movieNameLabel.TabIndex = 10;
            movieNameLabel.Text = "Movie Name";
            // 
            // reviewCommentBox
            // 
            reviewCommentBox.Location = new Point(168, 72);
            reviewCommentBox.Multiline = true;
            reviewCommentBox.Name = "reviewCommentBox";
            reviewCommentBox.ReadOnly = true;
            reviewCommentBox.Size = new Size(374, 172);
            reviewCommentBox.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(168, 40);
            label1.Name = "label1";
            label1.Size = new Size(98, 29);
            label1.TabIndex = 12;
            label1.Text = "Comment";
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(12, 251);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(143, 58);
            saveChangesBtn.TabIndex = 21;
            saveChangesBtn.Text = "Add review";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // editReviewBtn
            // 
            editReviewBtn.Location = new Point(161, 251);
            editReviewBtn.Name = "editReviewBtn";
            editReviewBtn.Size = new Size(143, 58);
            editReviewBtn.TabIndex = 22;
            editReviewBtn.Text = "Edit review";
            editReviewBtn.UseVisualStyleBackColor = true;
            editReviewBtn.Click += editReviewBtn_Click;
            // 
            // deleteReviewBtn
            // 
            deleteReviewBtn.Location = new Point(310, 250);
            deleteReviewBtn.Name = "deleteReviewBtn";
            deleteReviewBtn.Size = new Size(143, 58);
            deleteReviewBtn.TabIndex = 23;
            deleteReviewBtn.Text = "Delete review";
            deleteReviewBtn.UseVisualStyleBackColor = true;
            deleteReviewBtn.Click += deleteReviewBtn_Click;
            // 
            // goBackBtn
            // 
            goBackBtn.Location = new Point(12, 315);
            goBackBtn.Name = "goBackBtn";
            goBackBtn.Size = new Size(143, 58);
            goBackBtn.TabIndex = 24;
            goBackBtn.Text = "Go back to movies";
            goBackBtn.UseVisualStyleBackColor = true;
            goBackBtn.Click += goBackBtn_Click;
            // 
            // ReviewsForMovie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 380);
            Controls.Add(goBackBtn);
            Controls.Add(deleteReviewBtn);
            Controls.Add(editReviewBtn);
            Controls.Add(saveChangesBtn);
            Controls.Add(label1);
            Controls.Add(reviewCommentBox);
            Controls.Add(movieNameLabel);
            Controls.Add(label2);
            Controls.Add(reviewsBox);
            Name = "ReviewsForMovie";
            Text = "ReviewsForMovie";
            Load += ReviewsForMovie_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox reviewsBox;
        private Label label2;
        private Label movieNameLabel;
        private TextBox reviewCommentBox;
        private Label label1;
        private Button saveChangesBtn;
        private Button editReviewBtn;
        private Button deleteReviewBtn;
        private Button goBackBtn;
    }
}