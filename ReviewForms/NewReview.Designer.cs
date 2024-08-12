namespace MovieWinForms.ReviewForms
{
    partial class NewReview
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
            addReviewBtn = new Button();
            label1 = new Label();
            reviewCommentBox = new TextBox();
            movieNameLabel = new Label();
            label2 = new Label();
            ratingInputValue = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)ratingInputValue).BeginInit();
            SuspendLayout();
            // 
            // addReviewBtn
            // 
            addReviewBtn.Location = new Point(7, 288);
            addReviewBtn.Name = "addReviewBtn";
            addReviewBtn.Size = new Size(143, 58);
            addReviewBtn.TabIndex = 26;
            addReviewBtn.Text = "Add review";
            addReviewBtn.UseVisualStyleBackColor = true;
            addReviewBtn.Click += addReviewBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(295, 29);
            label1.TabIndex = 25;
            label1.Text = "Thoughts about the movie...";
            // 
            // reviewCommentBox
            // 
            reviewCommentBox.Location = new Point(12, 73);
            reviewCommentBox.Multiline = true;
            reviewCommentBox.Name = "reviewCommentBox";
            reviewCommentBox.Size = new Size(374, 172);
            reviewCommentBox.TabIndex = 24;
            // 
            // movieNameLabel
            // 
            movieNameLabel.AutoSize = true;
            movieNameLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            movieNameLabel.ForeColor = Color.Coral;
            movieNameLabel.Location = new Point(163, 9);
            movieNameLabel.Name = "movieNameLabel";
            movieNameLabel.Size = new Size(132, 29);
            movieNameLabel.TabIndex = 23;
            movieNameLabel.Text = "Movie Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 9);
            label2.Name = "label2";
            label2.Size = new Size(163, 29);
            label2.TabIndex = 22;
            label2.Text = "Add review for";
            // 
            // ratingInputValue
            // 
            ratingInputValue.DecimalPlaces = 1;
            ratingInputValue.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            ratingInputValue.Location = new Point(91, 255);
            ratingInputValue.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ratingInputValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ratingInputValue.Name = "ratingInputValue";
            ratingInputValue.Size = new Size(79, 27);
            ratingInputValue.TabIndex = 27;
            ratingInputValue.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 253);
            label3.Name = "label3";
            label3.Size = new Size(73, 29);
            label3.TabIndex = 28;
            label3.Text = "Rating";
            // 
            // NewReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 359);
            Controls.Add(label3);
            Controls.Add(ratingInputValue);
            Controls.Add(addReviewBtn);
            Controls.Add(label1);
            Controls.Add(reviewCommentBox);
            Controls.Add(movieNameLabel);
            Controls.Add(label2);
            Name = "NewReview";
            Text = "NewReview";
            Load += NewReview_Load;
            ((System.ComponentModel.ISupportInitialize)ratingInputValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addReviewBtn;
        private Label label1;
        private TextBox reviewCommentBox;
        private Label movieNameLabel;
        private Label label2;
        private NumericUpDown ratingInputValue;
        private Label label3;
    }
}