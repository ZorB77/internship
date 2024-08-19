namespace MovieApplicationWithForm
{
    partial class FilterForm
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
            comboBoxTable = new ComboBox();
            textBoxFilterCriteria = new TextBox();
            buttonApplyFilter = new Button();
            dataGridViewResults = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            comboBoxColumn = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // comboBoxTable
            // 
            comboBoxTable.FormattingEnabled = true;
            comboBoxTable.Location = new Point(28, 45);
            comboBoxTable.Name = "comboBoxTable";
            comboBoxTable.Size = new Size(151, 28);
            comboBoxTable.TabIndex = 0;
            comboBoxTable.SelectedIndexChanged += comboBoxTable_SelectedIndexChanged;
            // 
            // textBoxFilterCriteria
            // 
            textBoxFilterCriteria.Location = new Point(28, 302);
            textBoxFilterCriteria.Name = "textBoxFilterCriteria";
            textBoxFilterCriteria.Size = new Size(151, 27);
            textBoxFilterCriteria.TabIndex = 1;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Location = new Point(28, 335);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(94, 29);
            buttonApplyFilter.TabIndex = 2;
            buttonApplyFilter.Text = "Filter";
            buttonApplyFilter.UseVisualStyleBackColor = true;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(259, 45);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.Size = new Size(478, 319);
            dataGridViewResults.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 22);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 4;
            label1.Text = "Choose table:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 103);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 5;
            label2.Text = "Choose criteria:";
            // 
            // comboBoxColumn
            // 
            comboBoxColumn.FormattingEnabled = true;
            comboBoxColumn.Location = new Point(28, 126);
            comboBoxColumn.Name = "comboBoxColumn";
            comboBoxColumn.Size = new Size(151, 28);
            comboBoxColumn.TabIndex = 6;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxColumn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonApplyFilter);
            Controls.Add(textBoxFilterCriteria);
            Controls.Add(comboBoxTable);
            Name = "FilterForm";
            Text = "Filter";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTable;
        private TextBox textBoxFilterCriteria;
        private Button buttonApplyFilter;
        private DataGridView dataGridViewResults;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxColumn;
    }
}