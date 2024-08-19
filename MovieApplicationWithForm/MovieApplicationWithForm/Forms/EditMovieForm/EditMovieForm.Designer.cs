namespace MovieApplicationWithForm.Forms.EditMovieForm
{
    partial class EditMovieForm
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
            label4 = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            textBoxGenre = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            buttonEditMovie = new Button();
            buttonDeleteMovie = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 20);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 109);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(188, 212);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 2;
            label3.Text = "Genre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 310);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 3;
            label4.Text = "Release date:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(188, 43);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(159, 27);
            textBoxName.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(188, 132);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(159, 27);
            textBoxDescription.TabIndex = 5;
            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new Point(188, 235);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.Size = new Size(159, 27);
            textBoxGenre.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(188, 333);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(159, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // buttonEditMovie
            // 
            buttonEditMovie.Location = new Point(146, 376);
            buttonEditMovie.Name = "buttonEditMovie";
            buttonEditMovie.Size = new Size(118, 29);
            buttonEditMovie.TabIndex = 8;
            buttonEditMovie.Text = "Update Movie";
            buttonEditMovie.UseVisualStyleBackColor = true;
            buttonEditMovie.Click += buttonEditMovie_Click;
            // 
            // buttonDeleteMovie
            // 
            buttonDeleteMovie.Location = new Point(270, 376);
            buttonDeleteMovie.Name = "buttonDeleteMovie";
            buttonDeleteMovie.Size = new Size(107, 29);
            buttonDeleteMovie.TabIndex = 9;
            buttonDeleteMovie.Text = "Delete Movie";
            buttonDeleteMovie.UseVisualStyleBackColor = true;
            buttonDeleteMovie.Click += buttonDeleteMovie_Click;
            // 
            // EditMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(568, 450);
            Controls.Add(buttonDeleteMovie);
            Controls.Add(buttonEditMovie);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBoxGenre);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditMovieForm";
            Text = "Edit Movie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxGenre;
        private DateTimePicker dateTimePicker1;
        private Button buttonEditMovie;
        private Button buttonDeleteMovie;
    }
}