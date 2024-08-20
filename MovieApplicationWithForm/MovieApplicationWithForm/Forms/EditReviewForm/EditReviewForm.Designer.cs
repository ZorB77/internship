namespace MovieApplicationWithForm.Forms.EditReviewForm
{
    partial class EditReviewForm
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
            label2 = new Label();
            label3 = new Label();
            buttonUpdateReview = new Button();
            buttonDeleteReview = new Button();
            textBoxComment = new TextBox();
            comboBoxMovies = new ComboBox();
            numericUpDownRating = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 62);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Movie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 264);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 1;
            label2.Text = "Rating:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 168);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Comment:";
            // 
            // buttonUpdateReview
            // 
            buttonUpdateReview.Location = new Point(41, 361);
            buttonUpdateReview.Name = "buttonUpdateReview";
            buttonUpdateReview.Size = new Size(118, 29);
            buttonUpdateReview.TabIndex = 3;
            buttonUpdateReview.Text = "Update Review";
            buttonUpdateReview.UseVisualStyleBackColor = true;
            buttonUpdateReview.Click += buttonUpdateReview_Click_1;
            // 
            // buttonDeleteReview
            // 
            buttonDeleteReview.Location = new Point(181, 361);
            buttonDeleteReview.Name = "buttonDeleteReview";
            buttonDeleteReview.Size = new Size(118, 29);
            buttonDeleteReview.TabIndex = 4;
            buttonDeleteReview.Text = "Delete Review";
            buttonDeleteReview.UseVisualStyleBackColor = true;
            buttonDeleteReview.Click += buttonDeleteReview_Click_1;
            // 
            // textBoxComment
            // 
            textBoxComment.Location = new Point(100, 191);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(151, 27);
            textBoxComment.TabIndex = 5;
            // 
            // comboBoxMovies
            // 
            comboBoxMovies.FormattingEnabled = true;
            comboBoxMovies.Location = new Point(100, 85);
            comboBoxMovies.Name = "comboBoxMovies";
            comboBoxMovies.Size = new Size(151, 28);
            comboBoxMovies.TabIndex = 6;
            // 
            // numericUpDownRating
            // 
            numericUpDownRating.Location = new Point(100, 287);
            numericUpDownRating.Name = "numericUpDownRating";
            numericUpDownRating.Size = new Size(151, 27);
            numericUpDownRating.TabIndex = 7;
            // 
            // EditReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(394, 450);
            Controls.Add(numericUpDownRating);
            Controls.Add(comboBoxMovies);
            Controls.Add(textBoxComment);
            Controls.Add(buttonDeleteReview);
            Controls.Add(buttonUpdateReview);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditReviewForm";
            Text = "Edit Review";
            Load += EditReviewForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonUpdateReview;
        private Button buttonDeleteReview;
        private TextBox textBoxComment;
        private ComboBox comboBoxMovies;
        private NumericUpDown numericUpDownRating;
    }
}