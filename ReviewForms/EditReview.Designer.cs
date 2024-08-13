namespace MovieWinForms.ReviewForms
{
    partial class EditReview
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
            label3 = new Label();
            ratingInputValue = new NumericUpDown();
            saveChangesBtn = new Button();
            label1 = new Label();
            reviewCommentBox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)ratingInputValue).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 253);
            label3.Name = "label3";
            label3.Size = new Size(73, 29);
            label3.TabIndex = 35;
            label3.Text = "Rating";
            // 
            // ratingInputValue
            // 
            ratingInputValue.DecimalPlaces = 1;
            ratingInputValue.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            ratingInputValue.Location = new Point(96, 255);
            ratingInputValue.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ratingInputValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ratingInputValue.Name = "ratingInputValue";
            ratingInputValue.Size = new Size(79, 27);
            ratingInputValue.TabIndex = 34;
            ratingInputValue.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // saveChangesBtn
            // 
            saveChangesBtn.Location = new Point(12, 288);
            saveChangesBtn.Name = "saveChangesBtn";
            saveChangesBtn.Size = new Size(143, 58);
            saveChangesBtn.TabIndex = 33;
            saveChangesBtn.Text = "Save changes";
            saveChangesBtn.UseVisualStyleBackColor = true;
            saveChangesBtn.Click += saveChangesBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 41);
            label1.Name = "label1";
            label1.Size = new Size(295, 29);
            label1.TabIndex = 32;
            label1.Text = "Thoughts about the movie...";
            // 
            // reviewCommentBox
            // 
            reviewCommentBox.Location = new Point(17, 73);
            reviewCommentBox.Multiline = true;
            reviewCommentBox.Name = "reviewCommentBox";
            reviewCommentBox.Size = new Size(374, 172);
            reviewCommentBox.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 9);
            label2.Name = "label2";
            label2.Size = new Size(123, 29);
            label2.TabIndex = 29;
            label2.Text = "Edit review";
            // 
            // EditReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 355);
            Controls.Add(label3);
            Controls.Add(ratingInputValue);
            Controls.Add(saveChangesBtn);
            Controls.Add(label1);
            Controls.Add(reviewCommentBox);
            Controls.Add(label2);
            Name = "EditReview";
            Text = "EditReview";
            Load += EditReview_Load;
            ((System.ComponentModel.ISupportInitialize)ratingInputValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private NumericUpDown ratingInputValue;
        private Button saveChangesBtn;
        private Label label1;
        private TextBox reviewCommentBox;
        private Label label2;
    }
}