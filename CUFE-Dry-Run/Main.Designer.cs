namespace MRK
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dayPrefab = new System.Windows.Forms.Label();
            this.timePrefab = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.bPref = new System.Windows.Forms.Button();
            this.courseCont = new System.Windows.Forms.Panel();
            this.coursePrefab = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lCourseList = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.courseCont.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUFE Dry Run";
            // 
            // dayPrefab
            // 
            this.dayPrefab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dayPrefab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dayPrefab.ForeColor = System.Drawing.Color.White;
            this.dayPrefab.Location = new System.Drawing.Point(3, 0);
            this.dayPrefab.Name = "dayPrefab";
            this.dayPrefab.Size = new System.Drawing.Size(158, 23);
            this.dayPrefab.TabIndex = 1;
            this.dayPrefab.Text = "Saturday";
            this.dayPrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timePrefab
            // 
            this.timePrefab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timePrefab.ForeColor = System.Drawing.Color.White;
            this.timePrefab.Location = new System.Drawing.Point(3, 23);
            this.timePrefab.Name = "timePrefab";
            this.timePrefab.Size = new System.Drawing.Size(95, 43);
            this.timePrefab.TabIndex = 2;
            this.timePrefab.Text = "8:00\r\n8:50";
            this.timePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bExit.ForeColor = System.Drawing.Color.White;
            this.bExit.Location = new System.Drawing.Point(1053, 12);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(47, 34);
            this.bExit.TabIndex = 3;
            this.bExit.Text = "X";
            this.bExit.UseVisualStyleBackColor = true;
            // 
            // bPref
            // 
            this.bPref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bPref.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bPref.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPref.FlatAppearance.BorderSize = 0;
            this.bPref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPref.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bPref.ForeColor = System.Drawing.Color.White;
            this.bPref.Location = new System.Drawing.Point(979, 824);
            this.bPref.Name = "bPref";
            this.bPref.Size = new System.Drawing.Size(121, 43);
            this.bPref.TabIndex = 4;
            this.bPref.Text = "Preferences";
            this.bPref.UseVisualStyleBackColor = false;
            // 
            // courseCont
            // 
            this.courseCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courseCont.AutoScroll = true;
            this.courseCont.Controls.Add(this.coursePrefab);
            this.courseCont.Controls.Add(this.dayPrefab);
            this.courseCont.Controls.Add(this.timePrefab);
            this.courseCont.ForeColor = System.Drawing.Color.White;
            this.courseCont.Location = new System.Drawing.Point(41, 106);
            this.courseCont.Name = "courseCont";
            this.courseCont.Size = new System.Drawing.Size(1032, 702);
            this.courseCont.TabIndex = 5;
            // 
            // coursePrefab
            // 
            this.coursePrefab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.coursePrefab.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.coursePrefab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coursePrefab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.coursePrefab.ForeColor = System.Drawing.Color.White;
            this.coursePrefab.Location = new System.Drawing.Point(3, 69);
            this.coursePrefab.Name = "coursePrefab";
            this.coursePrefab.Size = new System.Drawing.Size(95, 57);
            this.coursePrefab.TabIndex = 3;
            this.coursePrefab.Text = "MTHN102\r\nLEC G5";
            this.coursePrefab.UseVisualStyleBackColor = false;
            // 
            // lCourseList
            // 
            this.lCourseList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.lCourseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCourseList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCourseList.ForeColor = System.Drawing.Color.White;
            this.lCourseList.Location = new System.Drawing.Point(0, 0);
            this.lCourseList.Name = "lCourseList";
            this.lCourseList.Size = new System.Drawing.Size(929, 43);
            this.lCourseList.TabIndex = 0;
            this.lCourseList.Text = "-";
            this.lCourseList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tooltip.SetToolTip(this.lCourseList, "Selected courses");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lCourseList);
            this.panel1.Location = new System.Drawing.Point(44, 824);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 43);
            this.panel1.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.ClientSize = new System.Drawing.Size(1112, 879);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.courseCont);
            this.Controls.Add(this.bPref);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "CUFE Dry Run";
            this.courseCont.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label dayPrefab;
        private Label timePrefab;
        private Button bExit;
        private Button bPref;
        private Panel courseCont;
        private Button coursePrefab;
        private ToolTip tooltip;
        private Label lCourseList;
        private Panel panel1;
    }
}