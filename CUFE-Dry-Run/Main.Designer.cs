using System.Windows.Forms;

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
            this.lLoading = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lCourseList = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbOpen = new System.Windows.Forms.CheckBox();
            this.lHoveredCourse = new System.Windows.Forms.Label();
            this.lLastUpdated = new System.Windows.Forms.Label();
            this.cbHighlight = new System.Windows.Forms.CheckBox();
            this.cbCode = new System.Windows.Forms.CheckBox();
            this.bScreenshot = new System.Windows.Forms.Button();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.courseCont.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelToolbar.SuspendLayout();
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
            this.bExit.Location = new System.Drawing.Point(1224, 12);
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
            this.bPref.Location = new System.Drawing.Point(1150, 688);
            this.bPref.Name = "bPref";
            this.bPref.Size = new System.Drawing.Size(121, 43);
            this.bPref.TabIndex = 4;
            this.bPref.Text = "Courses";
            this.bPref.UseVisualStyleBackColor = false;
            // 
            // courseCont
            // 
            this.courseCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courseCont.AutoScroll = true;
            this.courseCont.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.courseCont.Controls.Add(this.coursePrefab);
            this.courseCont.Controls.Add(this.dayPrefab);
            this.courseCont.Controls.Add(this.timePrefab);
            this.courseCont.ForeColor = System.Drawing.Color.White;
            this.courseCont.Location = new System.Drawing.Point(41, 106);
            this.courseCont.Name = "courseCont";
            this.courseCont.Size = new System.Drawing.Size(1203, 566);
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
            // lLoading
            // 
            this.lLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lLoading.Font = new System.Drawing.Font("Yu Gothic UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lLoading.ForeColor = System.Drawing.Color.White;
            this.lLoading.Location = new System.Drawing.Point(41, 106);
            this.lLoading.Name = "lLoading";
            this.lLoading.Size = new System.Drawing.Size(1200, 566);
            this.lLoading.TabIndex = 0;
            this.lLoading.Text = "Loading courses...";
            this.lLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCourseList
            // 
            this.lCourseList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.lCourseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCourseList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCourseList.ForeColor = System.Drawing.Color.White;
            this.lCourseList.Location = new System.Drawing.Point(0, 0);
            this.lCourseList.Name = "lCourseList";
            this.lCourseList.Size = new System.Drawing.Size(1100, 43);
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
            this.panel1.Location = new System.Drawing.Point(44, 688);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 43);
            this.panel1.TabIndex = 6;
            // 
            // cbOpen
            // 
            this.cbOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOpen.ForeColor = System.Drawing.Color.White;
            this.cbOpen.Location = new System.Drawing.Point(1085, 77);
            this.cbOpen.Name = "cbOpen";
            this.cbOpen.Size = new System.Drawing.Size(150, 23);
            this.cbOpen.TabIndex = 7;
            this.cbOpen.Text = "SHOW OPEN ONLY";
            this.cbOpen.UseVisualStyleBackColor = true;
            // 
            // lHoveredCourse
            // 
            this.lHoveredCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lHoveredCourse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lHoveredCourse.ForeColor = System.Drawing.Color.White;
            this.lHoveredCourse.Location = new System.Drawing.Point(208, 57);
            this.lHoveredCourse.Name = "lHoveredCourse";
            this.lHoveredCourse.Size = new System.Drawing.Size(871, 32);
            this.lHoveredCourse.TabIndex = 8;
            this.lHoveredCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lLastUpdated
            // 
            this.lLastUpdated.AutoSize = true;
            this.lLastUpdated.Font = new System.Drawing.Font("Yu Gothic UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lLastUpdated.ForeColor = System.Drawing.Color.White;
            this.lLastUpdated.Location = new System.Drawing.Point(12, 12);
            this.lLastUpdated.Name = "lLastUpdated";
            this.lLastUpdated.Size = new System.Drawing.Size(163, 15);
            this.lLastUpdated.TabIndex = 9;
            this.lLastUpdated.Text = "FALL 2023 14/09/2023 10:21 PM\r\n";
            // 
            // cbHighlight
            // 
            this.cbHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHighlight.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbHighlight.ForeColor = System.Drawing.Color.White;
            this.cbHighlight.Location = new System.Drawing.Point(1085, 50);
            this.cbHighlight.Name = "cbHighlight";
            this.cbHighlight.Size = new System.Drawing.Size(150, 23);
            this.cbHighlight.TabIndex = 10;
            this.cbHighlight.Text = "HIGHLIGHT";
            this.cbHighlight.UseVisualStyleBackColor = true;
            // 
            // cbCode
            // 
            this.cbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCode.ForeColor = System.Drawing.Color.White;
            this.cbCode.Location = new System.Drawing.Point(1085, 23);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(101, 23);
            this.cbCode.TabIndex = 11;
            this.cbCode.Text = "SHOW CODE";
            this.cbCode.UseVisualStyleBackColor = true;
            // 
            // bScreenshot
            // 
            this.bScreenshot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bScreenshot.AutoSize = true;
            this.bScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bScreenshot.FlatAppearance.BorderSize = 0;
            this.bScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bScreenshot.ForeColor = System.Drawing.Color.White;
            this.bScreenshot.Location = new System.Drawing.Point(0, 0);
            this.bScreenshot.Name = "bScreenshot";
            this.bScreenshot.Size = new System.Drawing.Size(75, 25);
            this.bScreenshot.TabIndex = 12;
            this.bScreenshot.Text = "Screenshot";
            this.bScreenshot.UseVisualStyleBackColor = true;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelToolbar.AutoSize = true;
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panelToolbar.Controls.Add(this.bScreenshot);
            this.panelToolbar.Location = new System.Drawing.Point(462, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(102, 28);
            this.panelToolbar.TabIndex = 13;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.ClientSize = new System.Drawing.Size(1283, 743);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.cbCode);
            this.Controls.Add(this.cbHighlight);
            this.Controls.Add(this.lLastUpdated);
            this.Controls.Add(this.lHoveredCourse);
            this.Controls.Add(this.cbOpen);
            this.Controls.Add(this.lLoading);
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
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
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
        private CheckBox cbOpen;
        private Label lLoading;
        private Label lHoveredCourse;
        private Label lLastUpdated;
        private CheckBox cbHighlight;
        private CheckBox cbCode;
        private Button bScreenshot;
        private Panel panelToolbar;
    }
}