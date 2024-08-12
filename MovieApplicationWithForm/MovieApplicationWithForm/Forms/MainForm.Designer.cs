namespace MovieApplicationWithForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            movieBindingSource = new BindingSource(components);
            personBindingSource = new BindingSource(components);
            buttonSave = new Button();
            roleBindingSource = new BindingSource(components);
            reviewBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridViewRoles = new DataGridView();
            roleIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            movieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            personDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewMovies = new DataGridView();
            movieIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            releaseDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            genreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewPersons = new DataGridView();
            personIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            birthdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewReviews = new DataGridView();
            reviewIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ratingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            commentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            movieDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            buttonFilter = new Button();
            linkLabelRoles = new LinkLabel();
            linkLabelReviews = new LinkLabel();
            linkLabel1 = new LinkLabel();
            linkLabelMovies = new LinkLabel();
            linkLabel3 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)movieBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roleBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reviewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPersons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviews).BeginInit();
            SuspendLayout();
            // 
            // movieBindingSource
            // 
            movieBindingSource.DataSource = typeof(Movie);
            // 
            // personBindingSource
            // 
            personBindingSource.DataSource = typeof(Person);
            // 
            // buttonSave
            // 
            buttonSave.AccessibleDescription = "Save";
            buttonSave.AccessibleName = "Save";
            buttonSave.Location = new Point(12, 560);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save Changes";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // roleBindingSource
            // 
            roleBindingSource.DataSource = typeof(Role);
            // 
            // reviewBindingSource
            // 
            reviewBindingSource.DataSource = typeof(Review);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 5;
            label1.Text = "Movies";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 298);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 6;
            label2.Text = "Roles";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(663, 298);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 7;
            label3.Text = "Reviews";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(663, 7);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 8;
            label4.Text = "Persons";
            // 
            // dataGridViewRoles
            // 
            dataGridViewRoles.AutoGenerateColumns = false;
            dataGridViewRoles.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoles.Columns.AddRange(new DataGridViewColumn[] { roleIDDataGridViewTextBoxColumn, movieDataGridViewTextBoxColumn, personDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn1 });
            dataGridViewRoles.DataSource = roleBindingSource;
            dataGridViewRoles.Location = new Point(12, 321);
            dataGridViewRoles.Name = "dataGridViewRoles";
            dataGridViewRoles.RowHeadersWidth = 51;
            dataGridViewRoles.Size = new Size(553, 223);
            dataGridViewRoles.TabIndex = 3;
            // 
            // roleIDDataGridViewTextBoxColumn
            // 
            roleIDDataGridViewTextBoxColumn.DataPropertyName = "roleID";
            roleIDDataGridViewTextBoxColumn.HeaderText = "roleID";
            roleIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            roleIDDataGridViewTextBoxColumn.Name = "roleIDDataGridViewTextBoxColumn";
            roleIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // movieDataGridViewTextBoxColumn
            // 
            movieDataGridViewTextBoxColumn.DataPropertyName = "movie";
            movieDataGridViewTextBoxColumn.HeaderText = "movie";
            movieDataGridViewTextBoxColumn.MinimumWidth = 6;
            movieDataGridViewTextBoxColumn.Name = "movieDataGridViewTextBoxColumn";
            movieDataGridViewTextBoxColumn.Width = 125;
            // 
            // personDataGridViewTextBoxColumn
            // 
            personDataGridViewTextBoxColumn.DataPropertyName = "person";
            personDataGridViewTextBoxColumn.HeaderText = "person";
            personDataGridViewTextBoxColumn.MinimumWidth = 6;
            personDataGridViewTextBoxColumn.Name = "personDataGridViewTextBoxColumn";
            personDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn1.HeaderText = "name";
            nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewMovies
            // 
            dataGridViewMovies.AutoGenerateColumns = false;
            dataGridViewMovies.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovies.Columns.AddRange(new DataGridViewColumn[] { movieIDDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, releaseDateDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, genreDataGridViewTextBoxColumn });
            dataGridViewMovies.DataSource = movieBindingSource;
            dataGridViewMovies.Location = new Point(12, 30);
            dataGridViewMovies.Name = "dataGridViewMovies";
            dataGridViewMovies.RowHeadersWidth = 51;
            dataGridViewMovies.Size = new Size(553, 253);
            dataGridViewMovies.TabIndex = 5;
            // 
            // movieIDDataGridViewTextBoxColumn
            // 
            movieIDDataGridViewTextBoxColumn.DataPropertyName = "movieID";
            movieIDDataGridViewTextBoxColumn.HeaderText = "movieID";
            movieIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            movieIDDataGridViewTextBoxColumn.Name = "movieIDDataGridViewTextBoxColumn";
            movieIDDataGridViewTextBoxColumn.ReadOnly = true;
            movieIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.HeaderText = "name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // releaseDateDataGridViewTextBoxColumn
            // 
            releaseDateDataGridViewTextBoxColumn.DataPropertyName = "releaseDate";
            releaseDateDataGridViewTextBoxColumn.HeaderText = "releaseDate";
            releaseDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            releaseDateDataGridViewTextBoxColumn.Name = "releaseDateDataGridViewTextBoxColumn";
            releaseDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // genreDataGridViewTextBoxColumn
            // 
            genreDataGridViewTextBoxColumn.DataPropertyName = "genre";
            genreDataGridViewTextBoxColumn.HeaderText = "genre";
            genreDataGridViewTextBoxColumn.MinimumWidth = 6;
            genreDataGridViewTextBoxColumn.Name = "genreDataGridViewTextBoxColumn";
            genreDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridViewPersons
            // 
            dataGridViewPersons.AutoGenerateColumns = false;
            dataGridViewPersons.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPersons.Columns.AddRange(new DataGridViewColumn[] { personIDDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, birthdateDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn });
            dataGridViewPersons.DataSource = personBindingSource;
            dataGridViewPersons.Location = new Point(663, 30);
            dataGridViewPersons.Name = "dataGridViewPersons";
            dataGridViewPersons.RowHeadersWidth = 51;
            dataGridViewPersons.Size = new Size(553, 253);
            dataGridViewPersons.TabIndex = 7;
            // 
            // personIDDataGridViewTextBoxColumn
            // 
            personIDDataGridViewTextBoxColumn.DataPropertyName = "personID";
            personIDDataGridViewTextBoxColumn.HeaderText = "personID";
            personIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            personIDDataGridViewTextBoxColumn.Name = "personIDDataGridViewTextBoxColumn";
            personIDDataGridViewTextBoxColumn.ReadOnly = true;
            personIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "firstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "firstName";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "lastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "lastName";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // birthdateDataGridViewTextBoxColumn
            // 
            birthdateDataGridViewTextBoxColumn.DataPropertyName = "birthdate";
            birthdateDataGridViewTextBoxColumn.HeaderText = "birthdate";
            birthdateDataGridViewTextBoxColumn.MinimumWidth = 6;
            birthdateDataGridViewTextBoxColumn.Name = "birthdateDataGridViewTextBoxColumn";
            birthdateDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            emailDataGridViewTextBoxColumn.HeaderText = "email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridViewReviews
            // 
            dataGridViewReviews.AllowUserToDeleteRows = false;
            dataGridViewReviews.AutoGenerateColumns = false;
            dataGridViewReviews.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReviews.Columns.AddRange(new DataGridViewColumn[] { reviewIDDataGridViewTextBoxColumn, ratingDataGridViewTextBoxColumn, commentDataGridViewTextBoxColumn, movieDataGridViewTextBoxColumn1 });
            dataGridViewReviews.DataSource = reviewBindingSource;
            dataGridViewReviews.Location = new Point(663, 321);
            dataGridViewReviews.Name = "dataGridViewReviews";
            dataGridViewReviews.RowHeadersWidth = 51;
            dataGridViewReviews.Size = new Size(553, 223);
            dataGridViewReviews.TabIndex = 8;
            // 
            // reviewIDDataGridViewTextBoxColumn
            // 
            reviewIDDataGridViewTextBoxColumn.DataPropertyName = "reviewID";
            reviewIDDataGridViewTextBoxColumn.HeaderText = "reviewID";
            reviewIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            reviewIDDataGridViewTextBoxColumn.Name = "reviewIDDataGridViewTextBoxColumn";
            reviewIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // ratingDataGridViewTextBoxColumn
            // 
            ratingDataGridViewTextBoxColumn.DataPropertyName = "rating";
            ratingDataGridViewTextBoxColumn.HeaderText = "rating";
            ratingDataGridViewTextBoxColumn.MinimumWidth = 6;
            ratingDataGridViewTextBoxColumn.Name = "ratingDataGridViewTextBoxColumn";
            ratingDataGridViewTextBoxColumn.Width = 125;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            commentDataGridViewTextBoxColumn.DataPropertyName = "comment";
            commentDataGridViewTextBoxColumn.HeaderText = "comment";
            commentDataGridViewTextBoxColumn.MinimumWidth = 6;
            commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            commentDataGridViewTextBoxColumn.Width = 125;
            // 
            // movieDataGridViewTextBoxColumn1
            // 
            movieDataGridViewTextBoxColumn1.DataPropertyName = "movie";
            movieDataGridViewTextBoxColumn1.HeaderText = "movie";
            movieDataGridViewTextBoxColumn1.MinimumWidth = 6;
            movieDataGridViewTextBoxColumn1.Name = "movieDataGridViewTextBoxColumn1";
            movieDataGridViewTextBoxColumn1.Width = 125;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(112, 560);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(94, 29);
            buttonFilter.TabIndex = 9;
            buttonFilter.Text = "Filter";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // linkLabelRoles
            // 
            linkLabelRoles.AutoSize = true;
            linkLabelRoles.LinkColor = Color.Black;
            linkLabelRoles.Location = new Point(466, 298);
            linkLabelRoles.Name = "linkLabelRoles";
            linkLabelRoles.Size = new Size(99, 20);
            linkLabelRoles.TabIndex = 10;
            linkLabelRoles.TabStop = true;
            linkLabelRoles.Text = "Add a role ->";
            linkLabelRoles.LinkClicked += linkLabelRoles_LinkClicked;
            // 
            // linkLabelReviews
            // 
            linkLabelReviews.AutoSize = true;
            linkLabelReviews.LinkColor = Color.Black;
            linkLabelReviews.Location = new Point(1100, 298);
            linkLabelReviews.Name = "linkLabelReviews";
            linkLabelReviews.Size = new Size(116, 20);
            linkLabelReviews.TabIndex = 11;
            linkLabelReviews.TabStop = true;
            linkLabelReviews.Text = "Add a review ->";
            linkLabelReviews.VisitedLinkColor = SystemColors.GradientActiveCaption;
            linkLabelReviews.LinkClicked += linkLabelReviews_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(1122, 560);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(87, 20);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Statistics ->";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabelMovies
            // 
            linkLabelMovies.AutoSize = true;
            linkLabelMovies.LinkColor = Color.Black;
            linkLabelMovies.Location = new Point(451, 7);
            linkLabelMovies.Name = "linkLabelMovies";
            linkLabelMovies.Size = new Size(114, 20);
            linkLabelMovies.TabIndex = 13;
            linkLabelMovies.TabStop = true;
            linkLabelMovies.Text = "Add a movie ->";
            linkLabelMovies.LinkClicked += linkLabelMovies_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(1098, 7);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(118, 20);
            linkLabel3.TabIndex = 14;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Add a person ->";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1221, 597);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabelMovies);
            Controls.Add(linkLabel1);
            Controls.Add(linkLabelReviews);
            Controls.Add(linkLabelRoles);
            Controls.Add(buttonFilter);
            Controls.Add(dataGridViewMovies);
            Controls.Add(dataGridViewReviews);
            Controls.Add(dataGridViewPersons);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridViewRoles);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Name = "MainForm";
            Text = "Movie Application";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)movieBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)roleBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)reviewBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovies).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPersons).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonSave;
        private BindingSource movieBindingSource;
        private BindingSource personBindingSource;
        private BindingSource roleBindingSource;
        private BindingSource reviewBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridViewRoles;
        private DataGridViewTextBoxColumn roleIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn movieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn personDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridView dataGridViewMovies;
        private DataGridViewTextBoxColumn movieIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn releaseDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genreDataGridViewTextBoxColumn;
        private DataGridView dataGridViewPersons;
        private DataGridViewTextBoxColumn personIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn birthdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridView dataGridViewReviews;
        private DataGridViewTextBoxColumn reviewIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ratingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn movieDataGridViewTextBoxColumn1;
        private Button buttonFilter;
        private LinkLabel linkLabelRoles;
        private LinkLabel linkLabelReviews;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabelMovies;
        private LinkLabel linkLabel3;
    }
}
