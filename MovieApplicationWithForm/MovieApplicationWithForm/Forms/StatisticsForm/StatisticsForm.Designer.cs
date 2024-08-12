namespace MovieApplicationWithForm
{
    partial class StatisticsForm
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
            listViewTopMovies = new ListView();
            label1 = new Label();
            comboBoxStatisticsMovie = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            labelAverageRating = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // listViewTopMovies
            // 
            listViewTopMovies.Location = new Point(360, 71);
            listViewTopMovies.Name = "listViewTopMovies";
            listViewTopMovies.Size = new Size(404, 324);
            listViewTopMovies.TabIndex = 0;
            listViewTopMovies.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 1;
            label1.Text = "Average Rating For Movie";
            // 
            // comboBoxStatisticsMovie
            // 
            comboBoxStatisticsMovie.FormattingEnabled = true;
            comboBoxStatisticsMovie.Location = new Point(12, 109);
            comboBoxStatisticsMovie.Name = "comboBoxStatisticsMovie";
            comboBoxStatisticsMovie.Size = new Size(181, 28);
            comboBoxStatisticsMovie.TabIndex = 2;
            comboBoxStatisticsMovie.SelectedIndexChanged += comboBoxStatisticsMovie_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 3;
            label2.Text = "Select movie:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 140);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 4;
            label3.Text = "The average rating is:";
            // 
            // labelAverageRating
            // 
            labelAverageRating.AutoSize = true;
            labelAverageRating.Location = new Point(59, 169);
            labelAverageRating.Name = "labelAverageRating";
            labelAverageRating.Size = new Size(60, 20);
            labelAverageRating.TabIndex = 5;
            labelAverageRating.Text = "-rating-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(469, 48);
            label4.Name = "label4";
            label4.Size = new Size(202, 20);
            label4.TabIndex = 6;
            label4.Text = "Best Movies Based On Rating";
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(791, 450);
            Controls.Add(label4);
            Controls.Add(labelAverageRating);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxStatisticsMovie);
            Controls.Add(label1);
            Controls.Add(listViewTopMovies);
            Name = "StatisticsForm";
            Text = "Statistics";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewTopMovies;
        private Label label1;
        private ComboBox comboBoxStatisticsMovie;
        private Label label2;
        private Label label3;
        private Label labelAverageRating;
        private Label label4;
    }
}