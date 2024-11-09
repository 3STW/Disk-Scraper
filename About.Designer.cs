namespace Disk_Scraper
{
    partial class About
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
            label3 = new Label();
            guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(735, 52);
            label3.TabIndex = 10;
            label3.Text = "This app is created for the purpose of cleaning your PC from junk log files, \r\ntemp files, and other unnecessary files!";
            // 
            // guna2Separator2
            // 
            guna2Separator2.FillColor = Color.White;
            guna2Separator2.FillThickness = 4;
            guna2Separator2.Location = new Point(-18, 50);
            guna2Separator2.Name = "guna2Separator2";
            guna2Separator2.Size = new Size(851, 10);
            guna2Separator2.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(325, 21);
            label1.Name = "label1";
            label1.Size = new Size(98, 26);
            label1.TabIndex = 8;
            label1.Text = "About us";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(442, 78);
            label2.TabIndex = 11;
            label2.Text = "This project will be continuously updated to \r\ngive you its full potential and will stop when\r\n no further modifications are needed.";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 390);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(guna2Separator2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "About";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Label label1;
        private Label label2;
    }
}