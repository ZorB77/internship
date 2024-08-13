namespace MovieWinForms.PersonForms
{
    partial class PeopleForm
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
            peopleListBox = new ListBox();
            addPersonBtn = new Button();
            editPersonBtn = new Button();
            deletePersonBtn = new Button();
            genreSubmit = new Button();
            genreDropdown = new ComboBox();
            label9 = new Label();
            numberOfRolesInput = new NumericUpDown();
            label1 = new Label();
            numberOfRolesSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)numberOfRolesInput).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(107, 29);
            label2.TabIndex = 10;
            label2.Text = "All people";
            // 
            // peopleListBox
            // 
            peopleListBox.FormattingEnabled = true;
            peopleListBox.Location = new Point(12, 41);
            peopleListBox.Name = "peopleListBox";
            peopleListBox.Size = new Size(324, 224);
            peopleListBox.TabIndex = 11;
            // 
            // addPersonBtn
            // 
            addPersonBtn.Location = new Point(12, 271);
            addPersonBtn.Name = "addPersonBtn";
            addPersonBtn.Size = new Size(104, 56);
            addPersonBtn.TabIndex = 19;
            addPersonBtn.Text = "Add person";
            addPersonBtn.UseVisualStyleBackColor = true;
            addPersonBtn.Click += addPersonBtn_Click;
            // 
            // editPersonBtn
            // 
            editPersonBtn.Location = new Point(122, 271);
            editPersonBtn.Name = "editPersonBtn";
            editPersonBtn.Size = new Size(104, 56);
            editPersonBtn.TabIndex = 20;
            editPersonBtn.Text = "Edit person";
            editPersonBtn.UseVisualStyleBackColor = true;
            editPersonBtn.Click += editPersonBtn_Click;
            // 
            // deletePersonBtn
            // 
            deletePersonBtn.Location = new Point(232, 271);
            deletePersonBtn.Name = "deletePersonBtn";
            deletePersonBtn.Size = new Size(104, 56);
            deletePersonBtn.TabIndex = 21;
            deletePersonBtn.Text = "Delete person";
            deletePersonBtn.UseVisualStyleBackColor = true;
            deletePersonBtn.Click += deletePersonBtn_Click;
            // 
            // genreSubmit
            // 
            genreSubmit.Location = new Point(343, 77);
            genreSubmit.Name = "genreSubmit";
            genreSubmit.Size = new Size(94, 29);
            genreSubmit.TabIndex = 34;
            genreSubmit.Text = "Submit";
            genreSubmit.UseVisualStyleBackColor = true;
            genreSubmit.Click += genreSubmit_Click;
            // 
            // genreDropdown
            // 
            genreDropdown.FormattingEnabled = true;
            genreDropdown.Location = new Point(343, 43);
            genreDropdown.Name = "genreDropdown";
            genreDropdown.Size = new Size(151, 28);
            genreDropdown.TabIndex = 33;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
            label9.Location = new Point(343, 13);
            label9.Name = "label9";
            label9.Size = new Size(140, 25);
            label9.TabIndex = 32;
            label9.Text = "Filter by Genre";
            // 
            // numberOfRolesInput
            // 
            numberOfRolesInput.Location = new Point(342, 162);
            numberOfRolesInput.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numberOfRolesInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberOfRolesInput.Name = "numberOfRolesInput";
            numberOfRolesInput.Size = new Size(150, 27);
            numberOfRolesInput.TabIndex = 35;
            numberOfRolesInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
            label1.Location = new Point(342, 109);
            label1.Name = "label1";
            label1.Size = new Size(160, 50);
            label1.TabIndex = 36;
            label1.Text = "Filter by Minimum\r\nNumber of Roles";
            // 
            // numberOfRolesSubmit
            // 
            numberOfRolesSubmit.Location = new Point(342, 195);
            numberOfRolesSubmit.Name = "numberOfRolesSubmit";
            numberOfRolesSubmit.Size = new Size(94, 29);
            numberOfRolesSubmit.TabIndex = 37;
            numberOfRolesSubmit.Text = "Submit";
            numberOfRolesSubmit.UseVisualStyleBackColor = true;
            numberOfRolesSubmit.Click += numberOfRolesSubmit_Click;
            // 
            // PeopleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 338);
            Controls.Add(numberOfRolesSubmit);
            Controls.Add(label1);
            Controls.Add(numberOfRolesInput);
            Controls.Add(genreSubmit);
            Controls.Add(genreDropdown);
            Controls.Add(label9);
            Controls.Add(deletePersonBtn);
            Controls.Add(editPersonBtn);
            Controls.Add(addPersonBtn);
            Controls.Add(peopleListBox);
            Controls.Add(label2);
            Name = "PeopleForm";
            Text = "PeopleForm";
            Load += PeopleForm_Load;
            ((System.ComponentModel.ISupportInitialize)numberOfRolesInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ListBox peopleListBox;
        private Button addPersonBtn;
        private Button editPersonBtn;
        private Button deletePersonBtn;
        private Button genreSubmit;
        private ComboBox genreDropdown;
        private Label label9;
        private NumericUpDown numberOfRolesInput;
        private Label label1;
        private Button numberOfRolesSubmit;
    }
}