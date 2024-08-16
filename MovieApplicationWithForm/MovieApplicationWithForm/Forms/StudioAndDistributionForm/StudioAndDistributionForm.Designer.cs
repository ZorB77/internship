namespace MovieApplicationWithForm.Forms.StudioAndDistributionForm
{
    partial class StudioAndDistributionForm
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
            components = new System.ComponentModel.Container();
            dataGridViewStudio = new DataGridView();
            studioBindingSource = new BindingSource(components);
            dataGridViewDistribution = new DataGridView();
            movieStudioDistributionBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            id = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            establishmentYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            movieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            studioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            distributionDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detailsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movieStudioDistributionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudio
            // 
            dataGridViewStudio.AutoGenerateColumns = false;
            dataGridViewStudio.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewStudio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudio.Columns.AddRange(new DataGridViewColumn[] { id, nameDataGridViewTextBoxColumn, establishmentYearDataGridViewTextBoxColumn, locationDataGridViewTextBoxColumn });
            dataGridViewStudio.DataSource = studioBindingSource;
            dataGridViewStudio.Location = new Point(69, 50);
            dataGridViewStudio.Name = "dataGridViewStudio";
            dataGridViewStudio.RowHeadersWidth = 51;
            dataGridViewStudio.Size = new Size(553, 237);
            dataGridViewStudio.TabIndex = 0;
            dataGridViewStudio.CellContentClick += dataGridViewStudio_CellContentClick;
            // 
            // studioBindingSource
            // 
            studioBindingSource.DataSource = typeof(Studio);
            // 
            // dataGridViewDistribution
            // 
            dataGridViewDistribution.AutoGenerateColumns = false;
            dataGridViewDistribution.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewDistribution.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDistribution.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, movieDataGridViewTextBoxColumn, studioDataGridViewTextBoxColumn, distributionDateDataGridViewTextBoxColumn, detailsDataGridViewTextBoxColumn });
            dataGridViewDistribution.DataSource = movieStudioDistributionBindingSource;
            dataGridViewDistribution.Location = new Point(69, 341);
            dataGridViewDistribution.Name = "dataGridViewDistribution";
            dataGridViewDistribution.RowHeadersWidth = 51;
            dataGridViewDistribution.Size = new Size(678, 246);
            dataGridViewDistribution.TabIndex = 1;
            // 
            // movieStudioDistributionBindingSource
            // 
            movieStudioDistributionBindingSource.DataSource = typeof(MovieStudioDistribution);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 27);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 2;
            label1.Text = "Studios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 318);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 3;
            label2.Text = "Distributions";
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.HeaderText = "name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // establishmentYearDataGridViewTextBoxColumn
            // 
            establishmentYearDataGridViewTextBoxColumn.DataPropertyName = "establishmentYear";
            establishmentYearDataGridViewTextBoxColumn.HeaderText = "establishmentYear";
            establishmentYearDataGridViewTextBoxColumn.MinimumWidth = 6;
            establishmentYearDataGridViewTextBoxColumn.Name = "establishmentYearDataGridViewTextBoxColumn";
            establishmentYearDataGridViewTextBoxColumn.Width = 125;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            locationDataGridViewTextBoxColumn.DataPropertyName = "location";
            locationDataGridViewTextBoxColumn.HeaderText = "location";
            locationDataGridViewTextBoxColumn.MinimumWidth = 6;
            locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            locationDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "id";
            dataGridViewTextBoxColumn1.HeaderText = "id";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // movieDataGridViewTextBoxColumn
            // 
            movieDataGridViewTextBoxColumn.DataPropertyName = "movie";
            movieDataGridViewTextBoxColumn.HeaderText = "movie";
            movieDataGridViewTextBoxColumn.MinimumWidth = 6;
            movieDataGridViewTextBoxColumn.Name = "movieDataGridViewTextBoxColumn";
            movieDataGridViewTextBoxColumn.Width = 125;
            // 
            // studioDataGridViewTextBoxColumn
            // 
            studioDataGridViewTextBoxColumn.DataPropertyName = "studio";
            studioDataGridViewTextBoxColumn.HeaderText = "studio";
            studioDataGridViewTextBoxColumn.MinimumWidth = 6;
            studioDataGridViewTextBoxColumn.Name = "studioDataGridViewTextBoxColumn";
            studioDataGridViewTextBoxColumn.Width = 125;
            // 
            // distributionDateDataGridViewTextBoxColumn
            // 
            distributionDateDataGridViewTextBoxColumn.DataPropertyName = "distributionDate";
            distributionDateDataGridViewTextBoxColumn.HeaderText = "distributionDate";
            distributionDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            distributionDateDataGridViewTextBoxColumn.Name = "distributionDateDataGridViewTextBoxColumn";
            distributionDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // detailsDataGridViewTextBoxColumn
            // 
            detailsDataGridViewTextBoxColumn.DataPropertyName = "details";
            detailsDataGridViewTextBoxColumn.HeaderText = "details";
            detailsDataGridViewTextBoxColumn.MinimumWidth = 6;
            detailsDataGridViewTextBoxColumn.Name = "detailsDataGridViewTextBoxColumn";
            detailsDataGridViewTextBoxColumn.Width = 125;
            // 
            // StudioAndDistributionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1057, 647);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewDistribution);
            Controls.Add(dataGridViewStudio);
            Name = "StudioAndDistributionForm";
            Text = "StudioAndDistributionForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudio).EndInit();
            ((System.ComponentModel.ISupportInitialize)studioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)movieStudioDistributionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudio;
        private DataGridViewTextBoxColumn studioIDDataGridViewTextBoxColumn;
        private BindingSource studioBindingSource;
        private DataGridView dataGridViewDistribution;
        private DataGridViewTextBoxColumn distributionIDDataGridViewTextBoxColumn;
        private BindingSource movieStudioDistributionBindingSource;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn establishmentYearDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn movieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn studioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn distributionDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
    }
}