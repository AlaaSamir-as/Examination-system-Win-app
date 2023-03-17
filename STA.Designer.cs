namespace ExaminationSytem
{
    partial class STA
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartSt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxInstructors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartSt)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSt
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSt.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSt.Legends.Add(legend1);
            this.chartSt.Location = new System.Drawing.Point(177, 145);
            this.chartSt.Name = "chartSt";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Student";
            this.chartSt.Series.Add(series1);
            this.chartSt.Size = new System.Drawing.Size(421, 320);
            this.chartSt.TabIndex = 1;
            this.chartSt.Text = "chart2";
            title1.Name = "Title1";
            title1.Text = "Best Students";
            this.chartSt.Titles.Add(title1);
            this.chartSt.Click += new System.EventHandler(this.chart2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label5.Location = new System.Drawing.Point(618, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "Exam ID";
            // 
            // ComboBoxInstructors
            // 
            this.ComboBoxInstructors.FormattingEnabled = true;
            this.ComboBoxInstructors.Items.AddRange(new object[] {
            "moa",
            "ali",
            "ahmed"});
            this.ComboBoxInstructors.Location = new System.Drawing.Point(622, 66);
            this.ComboBoxInstructors.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxInstructors.Name = "ComboBoxInstructors";
            this.ComboBoxInstructors.Size = new System.Drawing.Size(85, 21);
            this.ComboBoxInstructors.TabIndex = 30;
            this.ComboBoxInstructors.SelectedIndexChanged += new System.EventHandler(this.ComboBoxInstructors_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.label1.Location = new System.Drawing.Point(238, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 29);
            this.label1.TabIndex = 31;
            this.label1.Text = "Best Students Score";
            // 
            // STA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxInstructors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chartSt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "STA";
            this.Text = "STA";
            this.Load += new System.EventHandler(this.STA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxInstructors;
        private System.Windows.Forms.Label label1;
    }
}