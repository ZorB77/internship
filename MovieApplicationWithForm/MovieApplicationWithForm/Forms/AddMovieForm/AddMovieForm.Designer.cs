namespace MovieApplicationWithForm.Forms
{
    partial class AddMovieForm
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
            textBoxName = new TextBox();
            textBoxGenre = new TextBox();
            textBoxDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(48, 60);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(176, 27);
            textBoxName.TabIndex = 0;
            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new Point(48, 151);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.Size = new Size(176, 27);
            textBoxGenre.TabIndex = 1;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(48, 245);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(176, 27);
            textBoxDescription.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 37);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 4;
            label1.Text = "Name of the movie:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 128);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 5;
            label2.Text = "Genre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 222);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 6;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 324);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 7;
            label4.Text = "Release date:";
            // 
            // button1
            // 
            button1.Location = new Point(48, 395);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Add Movie";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(48, 347);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 9;
            // 
            // AddMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxGenre);
            Controls.Add(textBoxName);
            Name = "AddMovieForm";
            Text = "Add Movie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxGenre;
        private TextBox textBoxDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private DateTimePicker dateTimePicker1;
    }
}