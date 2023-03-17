namespace ExaminationSystem
{
    partial class ManageCourse
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteStud = new System.Windows.Forms.Button();
            this.btnUpdateStud = new System.Windows.Forms.Button();
            this.btnAddStud = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.crsMaxDeg = new System.Windows.Forms.NumericUpDown();
            this.crsMinDeg = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxInstructors = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crsMaxDeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crsMinDeg)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label5.Location = new System.Drawing.Point(11, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 24);
            this.label5.TabIndex = 24;
            this.label5.Text = "Courses:";
            // 
            // btnDeleteStud
            // 
            this.btnDeleteStud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.btnDeleteStud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStud.ForeColor = System.Drawing.Color.White;
            this.btnDeleteStud.Location = new System.Drawing.Point(661, 160);
            this.btnDeleteStud.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteStud.Name = "btnDeleteStud";
            this.btnDeleteStud.Size = new System.Drawing.Size(128, 28);
            this.btnDeleteStud.TabIndex = 23;
            this.btnDeleteStud.Text = "Delete";
            this.btnDeleteStud.UseVisualStyleBackColor = false;
            this.btnDeleteStud.Click += new System.EventHandler(this.btnDeleteStud_Click);
            // 
            // btnUpdateStud
            // 
            this.btnUpdateStud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.btnUpdateStud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStud.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStud.Location = new System.Drawing.Point(661, 118);
            this.btnUpdateStud.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateStud.Name = "btnUpdateStud";
            this.btnUpdateStud.Size = new System.Drawing.Size(129, 28);
            this.btnUpdateStud.TabIndex = 22;
            this.btnUpdateStud.Text = "Update";
            this.btnUpdateStud.UseVisualStyleBackColor = false;
            this.btnUpdateStud.Click += new System.EventHandler(this.btnUpdateStud_Click);
            // 
            // btnAddStud
            // 
            this.btnAddStud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.btnAddStud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStud.ForeColor = System.Drawing.Color.White;
            this.btnAddStud.Location = new System.Drawing.Point(661, 75);
            this.btnAddStud.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddStud.Name = "btnAddStud";
            this.btnAddStud.Size = new System.Drawing.Size(129, 28);
            this.btnAddStud.TabIndex = 21;
            this.btnAddStud.Text = "Add";
            this.btnAddStud.UseVisualStyleBackColor = false;
            this.btnAddStud.Click += new System.EventHandler(this.btnAddStud_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label4.Location = new System.Drawing.Point(304, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Manage Courses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label3.Location = new System.Drawing.Point(327, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Course Instructor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label2.Location = new System.Drawing.Point(17, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Max Degree:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label1.Location = new System.Drawing.Point(17, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Course Name:";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseName.Location = new System.Drawing.Point(143, 78);
            this.txtCourseName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(166, 26);
            this.txtCourseName.TabIndex = 14;
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.AllowUserToAddRows = false;
            this.dataGridViewCourses.AllowUserToDeleteRows = false;
            this.dataGridViewCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCourses.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Location = new System.Drawing.Point(9, 202);
            this.dataGridViewCourses.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.ReadOnly = true;
            this.dataGridViewCourses.RowHeadersWidth = 51;
            this.dataGridViewCourses.RowTemplate.Height = 24;
            this.dataGridViewCourses.Size = new System.Drawing.Size(780, 368);
            this.dataGridViewCourses.TabIndex = 13;
            this.dataGridViewCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCourses_CellContentClick);
            this.dataGridViewCourses.SelectionChanged += new System.EventHandler(this.dataGridViewCourses_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label6.Location = new System.Drawing.Point(349, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Min Degree:";
            // 
            // crsMaxDeg
            // 
            this.crsMaxDeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsMaxDeg.Location = new System.Drawing.Point(144, 129);
            this.crsMaxDeg.Margin = new System.Windows.Forms.Padding(2);
            this.crsMaxDeg.Name = "crsMaxDeg";
            this.crsMaxDeg.Size = new System.Drawing.Size(165, 26);
            this.crsMaxDeg.TabIndex = 27;
            // 
            // crsMinDeg
            // 
            this.crsMinDeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsMinDeg.Location = new System.Drawing.Point(478, 131);
            this.crsMinDeg.Margin = new System.Windows.Forms.Padding(2);
            this.crsMinDeg.Name = "crsMinDeg";
            this.crsMinDeg.Size = new System.Drawing.Size(146, 26);
            this.crsMinDeg.TabIndex = 28;
            // 
            // ComboBoxInstructors
            // 
            this.ComboBoxInstructors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxInstructors.FormattingEnabled = true;
            this.ComboBoxInstructors.Items.AddRange(new object[] {
            "moa",
            "ali",
            "ahmed"});
            this.ComboBoxInstructors.Location = new System.Drawing.Point(478, 81);
            this.ComboBoxInstructors.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxInstructors.Name = "ComboBoxInstructors";
            this.ComboBoxInstructors.Size = new System.Drawing.Size(146, 21);
            this.ComboBoxInstructors.TabIndex = 29;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(130, 23);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 30;
            this.lblID.Visible = false;
            // 
            // ManageCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 583);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.ComboBoxInstructors);
            this.Controls.Add(this.crsMinDeg);
            this.Controls.Add(this.crsMaxDeg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteStud);
            this.Controls.Add(this.btnUpdateStud);
            this.Controls.Add(this.btnAddStud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.dataGridViewCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageCourse";
            this.Text = "ManageCourse";
            this.Load += new System.EventHandler(this.ManageCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crsMaxDeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crsMinDeg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteStud;
        private System.Windows.Forms.Button btnUpdateStud;
        private System.Windows.Forms.Button btnAddStud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown crsMaxDeg;
        private System.Windows.Forms.NumericUpDown crsMinDeg;
        private System.Windows.Forms.ComboBox ComboBoxInstructors;
        private System.Windows.Forms.Label lblID;
    }
}