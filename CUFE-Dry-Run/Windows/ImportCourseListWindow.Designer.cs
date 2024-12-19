namespace MRK
{
    partial class ImportCourseListWindow
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
            label1 = new System.Windows.Forms.Label();
            tbList = new System.Windows.Forms.TextBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            bCancel = new System.Windows.Forms.Button();
            bImport = new System.Windows.Forms.Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = Utils.GetFontFallbacked("Segoe UI Variable Display Semib", 21F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(40, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(256, 37);
            label1.TabIndex = 1;
            label1.Text = "Import Course List";
            // 
            // tbList
            // 
            tbList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbList.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            tbList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tbList.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            tbList.Font = new System.Drawing.Font("Segoe UI", 12F);
            tbList.ForeColor = System.Drawing.Color.White;
            tbList.Location = new System.Drawing.Point(70, 122);
            tbList.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            tbList.Multiline = true;
            tbList.Name = "tbList";
            tbList.PlaceholderText = "Computer Networks-1 (1/1) - Image Processing and Computer Vision (2/1) - Control..";
            tbList.Size = new System.Drawing.Size(671, 279);
            tbList.TabIndex = 3;
            tbList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(bCancel);
            flowLayoutPanel1.Controls.Add(bImport);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(532, 425);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(267, 35);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // bCancel
            // 
            bCancel.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            bCancel.FlatAppearance.BorderSize = 0;
            bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bCancel.ForeColor = System.Drawing.Color.White;
            bCancel.Location = new System.Drawing.Point(147, 0);
            bCancel.Margin = new System.Windows.Forms.Padding(0);
            bCancel.Name = "bCancel";
            bCancel.Size = new System.Drawing.Size(120, 35);
            bCancel.TabIndex = 4;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = false;
            // 
            // bImport
            // 
            bImport.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            bImport.FlatAppearance.BorderSize = 0;
            bImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bImport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bImport.ForeColor = System.Drawing.Color.White;
            bImport.Location = new System.Drawing.Point(11, 0);
            bImport.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            bImport.Name = "bImport";
            bImport.Size = new System.Drawing.Size(120, 35);
            bImport.TabIndex = 4;
            bImport.Text = "Import";
            bImport.UseVisualStyleBackColor = false;
            // 
            // ImportCourseListWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(811, 474);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tbList);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Location = new System.Drawing.Point(0, 0);
            Name = "ImportCourseListWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ImportCourseListWindow";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bImport;
    }
}