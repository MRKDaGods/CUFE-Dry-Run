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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dayPrefab = new Label();
            timePrefab = new Label();
            bExit = new Button();
            bPref = new Button();
            courseCont = new Panel();
            coursePrefab = new Button();
            lLoading = new Label();
            tooltip = new ToolTip(components);
            lCourseList = new Label();
            panel1 = new Panel();
            cbOpen = new CheckBox();
            lHoveredCourse = new Label();
            lLastUpdated = new Label();
            cbHighlight = new CheckBox();
            cbCode = new CheckBox();
            bScreenshot = new Button();
            panelToolbar = new Panel();
            label2 = new Label();
            courseCont.SuspendLayout();
            panel1.SuspendLayout();
            panelToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Yu Gothic UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(41, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(156, 32);
            label1.TabIndex = 0;
            label1.Text = "CUFE Dry Run";
            // 
            // dayPrefab
            // 
            dayPrefab.BorderStyle = BorderStyle.FixedSingle;
            dayPrefab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dayPrefab.ForeColor = System.Drawing.Color.White;
            dayPrefab.Location = new System.Drawing.Point(3, 0);
            dayPrefab.Name = "dayPrefab";
            dayPrefab.Size = new System.Drawing.Size(158, 23);
            dayPrefab.TabIndex = 1;
            dayPrefab.Text = "Saturday";
            dayPrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timePrefab
            // 
            timePrefab.BorderStyle = BorderStyle.FixedSingle;
            timePrefab.ForeColor = System.Drawing.Color.White;
            timePrefab.Location = new System.Drawing.Point(3, 23);
            timePrefab.Name = "timePrefab";
            timePrefab.Size = new System.Drawing.Size(95, 43);
            timePrefab.TabIndex = 2;
            timePrefab.Text = "8:00\r\n8:50";
            timePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bExit
            // 
            bExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bExit.FlatAppearance.BorderSize = 0;
            bExit.FlatStyle = FlatStyle.Flat;
            bExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            bExit.ForeColor = System.Drawing.Color.White;
            bExit.Location = new System.Drawing.Point(1224, 12);
            bExit.Name = "bExit";
            bExit.Size = new System.Drawing.Size(47, 34);
            bExit.TabIndex = 3;
            bExit.Text = "X";
            bExit.UseVisualStyleBackColor = true;
            // 
            // bPref
            // 
            bPref.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bPref.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bPref.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bPref.FlatAppearance.BorderSize = 0;
            bPref.FlatStyle = FlatStyle.Flat;
            bPref.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bPref.ForeColor = System.Drawing.Color.White;
            bPref.Location = new System.Drawing.Point(1150, 688);
            bPref.Name = "bPref";
            bPref.Size = new System.Drawing.Size(121, 43);
            bPref.TabIndex = 4;
            bPref.Text = "Courses";
            bPref.UseVisualStyleBackColor = false;
            // 
            // courseCont
            // 
            courseCont.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            courseCont.AutoScroll = true;
            courseCont.AutoScrollMargin = new System.Drawing.Size(10, 10);
            courseCont.Controls.Add(coursePrefab);
            courseCont.Controls.Add(dayPrefab);
            courseCont.Controls.Add(timePrefab);
            courseCont.ForeColor = System.Drawing.Color.White;
            courseCont.Location = new System.Drawing.Point(41, 106);
            courseCont.Name = "courseCont";
            courseCont.Size = new System.Drawing.Size(1203, 566);
            courseCont.TabIndex = 5;
            // 
            // coursePrefab
            // 
            coursePrefab.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            coursePrefab.FlatAppearance.BorderColor = System.Drawing.Color.White;
            coursePrefab.FlatStyle = FlatStyle.Flat;
            coursePrefab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            coursePrefab.ForeColor = System.Drawing.Color.White;
            coursePrefab.Location = new System.Drawing.Point(3, 69);
            coursePrefab.Name = "coursePrefab";
            coursePrefab.Size = new System.Drawing.Size(95, 57);
            coursePrefab.TabIndex = 3;
            coursePrefab.Text = "MTHN102\r\nLEC G5";
            coursePrefab.UseVisualStyleBackColor = false;
            // 
            // lLoading
            // 
            lLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lLoading.Font = new System.Drawing.Font("Yu Gothic UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lLoading.ForeColor = System.Drawing.Color.White;
            lLoading.Location = new System.Drawing.Point(41, 106);
            lLoading.Name = "lLoading";
            lLoading.Size = new System.Drawing.Size(1200, 566);
            lLoading.TabIndex = 0;
            lLoading.Text = "Loading courses...";
            lLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCourseList
            // 
            lCourseList.BackColor = System.Drawing.Color.FromArgb(8, 8, 8);
            lCourseList.Dock = DockStyle.Fill;
            lCourseList.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lCourseList.ForeColor = System.Drawing.Color.White;
            lCourseList.Location = new System.Drawing.Point(0, 0);
            lCourseList.Name = "lCourseList";
            lCourseList.Size = new System.Drawing.Size(1100, 43);
            lCourseList.TabIndex = 0;
            lCourseList.Text = "-";
            lCourseList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tooltip.SetToolTip(lCourseList, "Selected courses");
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(lCourseList);
            panel1.Location = new System.Drawing.Point(44, 688);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1100, 43);
            panel1.TabIndex = 6;
            // 
            // cbOpen
            // 
            cbOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbOpen.ForeColor = System.Drawing.Color.White;
            cbOpen.Location = new System.Drawing.Point(1085, 77);
            cbOpen.Name = "cbOpen";
            cbOpen.Size = new System.Drawing.Size(150, 23);
            cbOpen.TabIndex = 7;
            cbOpen.Text = "SHOW OPEN ONLY";
            cbOpen.UseVisualStyleBackColor = true;
            // 
            // lHoveredCourse
            // 
            lHoveredCourse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lHoveredCourse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lHoveredCourse.ForeColor = System.Drawing.Color.White;
            lHoveredCourse.Location = new System.Drawing.Point(208, 57);
            lHoveredCourse.Name = "lHoveredCourse";
            lHoveredCourse.Size = new System.Drawing.Size(871, 32);
            lHoveredCourse.TabIndex = 8;
            lHoveredCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lLastUpdated
            // 
            lLastUpdated.AutoSize = true;
            lLastUpdated.Font = new System.Drawing.Font("Yu Gothic UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lLastUpdated.ForeColor = System.Drawing.Color.White;
            lLastUpdated.Location = new System.Drawing.Point(12, 12);
            lLastUpdated.Name = "lLastUpdated";
            lLastUpdated.Size = new System.Drawing.Size(36, 15);
            lLastUpdated.TabIndex = 9;
            lLastUpdated.Text = "TERM";
            // 
            // cbHighlight
            // 
            cbHighlight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbHighlight.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbHighlight.ForeColor = System.Drawing.Color.White;
            cbHighlight.Location = new System.Drawing.Point(1085, 50);
            cbHighlight.Name = "cbHighlight";
            cbHighlight.Size = new System.Drawing.Size(150, 23);
            cbHighlight.TabIndex = 10;
            cbHighlight.Text = "HIGHLIGHT";
            cbHighlight.UseVisualStyleBackColor = true;
            // 
            // cbCode
            // 
            cbCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbCode.ForeColor = System.Drawing.Color.White;
            cbCode.Location = new System.Drawing.Point(1085, 23);
            cbCode.Name = "cbCode";
            cbCode.Size = new System.Drawing.Size(101, 23);
            cbCode.TabIndex = 11;
            cbCode.Text = "SHOW CODE";
            cbCode.UseVisualStyleBackColor = true;
            // 
            // bScreenshot
            // 
            bScreenshot.Anchor = AnchorStyles.None;
            bScreenshot.AutoSize = true;
            bScreenshot.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bScreenshot.FlatAppearance.BorderSize = 0;
            bScreenshot.FlatStyle = FlatStyle.Flat;
            bScreenshot.ForeColor = System.Drawing.Color.White;
            bScreenshot.Location = new System.Drawing.Point(0, 0);
            bScreenshot.Name = "bScreenshot";
            bScreenshot.Size = new System.Drawing.Size(75, 25);
            bScreenshot.TabIndex = 12;
            bScreenshot.Text = "Screenshot";
            bScreenshot.UseVisualStyleBackColor = true;
            // 
            // panelToolbar
            // 
            panelToolbar.Anchor = AnchorStyles.Top;
            panelToolbar.AutoSize = true;
            panelToolbar.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            panelToolbar.Controls.Add(bScreenshot);
            panelToolbar.Location = new System.Drawing.Point(462, 0);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new System.Drawing.Size(102, 28);
            panelToolbar.TabIndex = 13;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Yu Gothic UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(933, 13);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 15);
            label2.TabIndex = 9;
            label2.Text = "BETA - NewFormat";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(8, 8, 8);
            ClientSize = new System.Drawing.Size(1283, 743);
            Controls.Add(panelToolbar);
            Controls.Add(cbCode);
            Controls.Add(cbHighlight);
            Controls.Add(label2);
            Controls.Add(lLastUpdated);
            Controls.Add(lHoveredCourse);
            Controls.Add(cbOpen);
            Controls.Add(lLoading);
            Controls.Add(panel1);
            Controls.Add(courseCont);
            Controls.Add(bPref);
            Controls.Add(bExit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Main";
            Text = "CUFE Dry Run";
            courseCont.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label2;
    }
}