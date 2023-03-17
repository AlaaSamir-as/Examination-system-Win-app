namespace FormProject
{
    partial class Assigant_student
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
            this.DGV_Asigned_STudent = new System.Windows.Forms.DataGridView();
            this.DGV_Students = new System.Windows.Forms.DataGridView();
            this.btn_add_student = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.ComboBoxExamIDs = new System.Windows.Forms.ComboBox();
            this.lblExamID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Asigned_STudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Students)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Asigned_STudent
            // 
            this.DGV_Asigned_STudent.AllowUserToAddRows = false;
            this.DGV_Asigned_STudent.AllowUserToDeleteRows = false;
            this.DGV_Asigned_STudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Asigned_STudent.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Asigned_STudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Asigned_STudent.Location = new System.Drawing.Point(497, 123);
            this.DGV_Asigned_STudent.Name = "DGV_Asigned_STudent";
            this.DGV_Asigned_STudent.ReadOnly = true;
            this.DGV_Asigned_STudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Asigned_STudent.Size = new System.Drawing.Size(264, 357);
            this.DGV_Asigned_STudent.TabIndex = 0;
            // 
            // DGV_Students
            // 
            this.DGV_Students.AllowUserToAddRows = false;
            this.DGV_Students.AllowUserToDeleteRows = false;
            this.DGV_Students.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Students.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Students.Location = new System.Drawing.Point(38, 123);
            this.DGV_Students.Name = "DGV_Students";
            this.DGV_Students.ReadOnly = true;
            this.DGV_Students.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Students.Size = new System.Drawing.Size(410, 357);
            this.DGV_Students.TabIndex = 4;
            // 
            // btn_add_student
            // 
            this.btn_add_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.btn_add_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_student.ForeColor = System.Drawing.Color.White;
            this.btn_add_student.Location = new System.Drawing.Point(72, 42);
            this.btn_add_student.Name = "btn_add_student";
            this.btn_add_student.Size = new System.Drawing.Size(136, 40);
            this.btn_add_student.TabIndex = 1;
            this.btn_add_student.Text = "ADD Student";
            this.btn_add_student.UseVisualStyleBackColor = false;
            this.btn_add_student.Click += new System.EventHandler(this.btn_add_student_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(248, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.btn_Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirm.ForeColor = System.Drawing.Color.White;
            this.btn_Confirm.Location = new System.Drawing.Point(625, 511);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(136, 40);
            this.btn_Confirm.TabIndex = 7;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = false;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // ComboBoxExamIDs
            // 
            this.ComboBoxExamIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxExamIDs.FormattingEnabled = true;
            this.ComboBoxExamIDs.Items.AddRange(new object[] {
            "moa",
            "ali",
            "ahmed"});
            this.ComboBoxExamIDs.Location = new System.Drawing.Point(583, 54);
            this.ComboBoxExamIDs.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxExamIDs.Name = "ComboBoxExamIDs";
            this.ComboBoxExamIDs.Size = new System.Drawing.Size(178, 21);
            this.ComboBoxExamIDs.TabIndex = 30;
            // 
            // lblExamID
            // 
            this.lblExamID.AutoSize = true;
            this.lblExamID.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.lblExamID.Location = new System.Drawing.Point(494, 57);
            this.lblExamID.Name = "lblExamID";
            this.lblExamID.Size = new System.Drawing.Size(66, 18);
            this.lblExamID.TabIndex = 31;
            this.lblExamID.Text = "ExamID";
            this.lblExamID.Click += new System.EventHandler(this.lblExamID_Click);
            // 
            // Assigant_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 566);
            this.Controls.Add(this.lblExamID);
            this.Controls.Add(this.ComboBoxExamIDs);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGV_Students);
            this.Controls.Add(this.btn_add_student);
            this.Controls.Add(this.DGV_Asigned_STudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Assigant_student";
            this.Text = "Assigant_student";
            this.Load += new System.EventHandler(this.Assigant_student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Asigned_STudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Students)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Asigned_STudent;
        private System.Windows.Forms.DataGridView DGV_Students;
        private System.Windows.Forms.Button btn_add_student;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.ComboBox ComboBoxExamIDs;
        private System.Windows.Forms.Label lblExamID;
    }
}