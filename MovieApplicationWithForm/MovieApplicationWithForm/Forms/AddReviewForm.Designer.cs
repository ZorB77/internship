namespace MovieApplicationWithForm
{
    partial class AddReviewForm
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
            comboBoxAddReviewMovie = new ComboBox();
            label1 = new Label();
            numericUpDownRating = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            textBoxAddReviewComment = new TextBox();
            buttonAddReview = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).BeginInit();
            SuspendLayout();
            // 
            // comboBoxAddReviewMovie
            // 
            comboBoxAddReviewMovie.FormattingEnabled = true;
            comboBoxAddReviewMovie.Location = new Point(33, 71);
            comboBoxAddReviewMovie.Name = "comboBoxAddReviewMovie";
            comboBoxAddReviewMovie.Size = new Size(153, 28);
            comboBoxAddReviewMovie.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 48);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 1;
            label1.Text = "Select the movie:";
            // 
            // numericUpDownRating
            // 
            numericUpDownRating.Location = new Point(36, 172);
            numericUpDownRating.Name = "numericUpDownRating";
            numericUpDownRating.Size = new Size(150, 27);
            numericUpDownRating.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 149);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 3;
            label2.Text = "Select the rating:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 263);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 4;
            label3.Text = "Comment:";
            // 
            // textBoxAddReviewComment
            // 
            textBoxAddReviewComment.Location = new Point(36, 286);
            textBoxAddReviewComment.Name = "textBoxAddReviewComment";
            textBoxAddReviewComment.Size = new Size(143, 27);
            textBoxAddReviewComment.TabIndex = 5;
            // 
            // buttonAddReview
            // 
            buttonAddReview.Location = new Point(36, 361);
            buttonAddReview.Name = "buttonAddReview";
            buttonAddReview.Size = new Size(98, 29);
            buttonAddReview.TabIndex = 6;
            buttonAddReview.Text = "Add Review";
            buttonAddReview.UseVisualStyleBackColor = true;
            buttonAddReview.Click += buttonAddReview_Click;
            // 
            // AddReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAddReview);
            Controls.Add(textBoxAddReviewComment);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDownRating);
            Controls.Add(label1);
            Controls.Add(comboBoxAddReviewMovie);
            Name = "AddReviewForm";
            Text = "Add Review";
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxAddReviewMovie;
        private Label label1;
        private NumericUpDown numericUpDownRating;
        private Label label2;
        private Label label3;
        private TextBox textBoxAddReviewComment;
        private Button buttonAddReview;
    }
}