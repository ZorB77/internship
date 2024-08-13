namespace MovieWinForms.StudioForms
{
    partial class NewStudioForm
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
            label2 = new Label();
            studioNameInput = new TextBox();
            studioLocationInput = new TextBox();
            yearInput = new NumericUpDown();
            label3 = new Label();
            addStudioBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)yearInput).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(163, 29);
            label2.TabIndex = 9;
            label2.Text = "Add new studio";
            // 
            // studioNameInput
            // 
            studioNameInput.Location = new Point(12, 41);
            studioNameInput.Name = "studioNameInput";
            studioNameInput.PlaceholderText = "Studio Name";
            studioNameInput.Size = new Size(262, 27);
            studioNameInput.TabIndex = 10;
            // 
            // studioLocationInput
            // 
            studioLocationInput.Location = new Point(12, 74);
            studioLocationInput.Name = "studioLocationInput";
            studioLocationInput.PlaceholderText = "Location";
            studioLocationInput.Size = new Size(262, 27);
            studioLocationInput.TabIndex = 11;
            // 
            // yearInput
            // 
            yearInput.Location = new Point(124, 107);
            yearInput.Maximum = new decimal(new int[] { 2024, 0, 0, 0 });
            yearInput.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            yearInput.Name = "yearInput";
            yearInput.Size = new Size(150, 27);
            yearInput.TabIndex = 12;
            yearInput.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            label3.Location = new Point(8, 108);
            label3.Name = "label3";
            label3.Size = new Size(110, 21);
            label3.TabIndex = 16;
            label3.Text = "Founded Date";
            // 
            // addStudioBtn
            // 
            addStudioBtn.Location = new Point(8, 136);
            addStudioBtn.Name = "addStudioBtn";
            addStudioBtn.Size = new Size(131, 51);
            addStudioBtn.TabIndex = 21;
            addStudioBtn.Text = "Add new studio";
            addStudioBtn.UseVisualStyleBackColor = true;
            addStudioBtn.Click += addStudioBtn_Click;
            // 
            // NewStudioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 199);
            Controls.Add(addStudioBtn);
            Controls.Add(label3);
            Controls.Add(yearInput);
            Controls.Add(studioLocationInput);
            Controls.Add(studioNameInput);
            Controls.Add(label2);
            Name = "NewStudioForm";
            Text = "NewStudioForm";
            ((System.ComponentModel.ISupportInitialize)yearInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox studioNameInput;
        private TextBox studioLocationInput;
        private NumericUpDown yearInput;
        private Label label3;
        private Button addStudioBtn;
    }
}