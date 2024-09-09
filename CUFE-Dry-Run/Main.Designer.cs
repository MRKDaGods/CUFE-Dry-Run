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
            lViewTitle = new Label();
            bExit = new Button();
            bPref = new Button();
            tooltip = new ToolTip(components);
            lCourseList = new Label();
            cbOpen = new CheckBox();
            lHoveredCourse = new Label();
            lTitle = new Label();
            cbHighlight = new CheckBox();
            cbCode = new CheckBox();
            panelMenuItems = new FlowLayoutPanel();
            bNavTimeTable = new Button();
            bNavCourses = new Button();
            panelFooterItems = new FlowLayoutPanel();
            button3 = new Button();
            bScreenshot = new Button();
            panelViewContainer = new Panel();
            panelMenuItems.SuspendLayout();
            panelFooterItems.SuspendLayout();
            SuspendLayout();
            // 
            // lViewTitle
            // 
            lViewTitle.AutoSize = true;
            lViewTitle.BackColor = System.Drawing.Color.Transparent;
            lViewTitle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 21F);
            lViewTitle.ForeColor = System.Drawing.Color.White;
            lViewTitle.Location = new System.Drawing.Point(40, 50);
            lViewTitle.Name = "lViewTitle";
            lViewTitle.Size = new System.Drawing.Size(151, 37);
            lViewTitle.TabIndex = 0;
            lViewTitle.Text = "Time Table";
            // 
            // bExit
            // 
            bExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bExit.BackColor = System.Drawing.Color.Transparent;
            bExit.FlatAppearance.BorderSize = 0;
            bExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            bExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            bExit.FlatStyle = FlatStyle.Flat;
            bExit.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            bExit.ForeColor = System.Drawing.Color.White;
            bExit.Location = new System.Drawing.Point(1247, 0);
            bExit.Name = "bExit";
            bExit.Padding = new Padding(8, 0, 0, 0);
            bExit.Size = new System.Drawing.Size(53, 32);
            bExit.TabIndex = 3;
            bExit.Text = "";
            bExit.UseVisualStyleBackColor = false;
            // 
            // bPref
            // 
            bPref.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bPref.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bPref.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bPref.FlatAppearance.BorderSize = 0;
            bPref.FlatStyle = FlatStyle.Flat;
            bPref.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bPref.ForeColor = System.Drawing.Color.White;
            bPref.Location = new System.Drawing.Point(802, 716);
            bPref.Name = "bPref";
            bPref.Size = new System.Drawing.Size(121, 43);
            bPref.TabIndex = 4;
            bPref.Text = "Courses";
            bPref.UseVisualStyleBackColor = false;
            // 
            // lCourseList
            // 
            lCourseList.AutoSize = true;
            lCourseList.BackColor = System.Drawing.Color.Transparent;
            lCourseList.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            lCourseList.ForeColor = System.Drawing.Color.White;
            lCourseList.Location = new System.Drawing.Point(991, 688);
            lCourseList.Name = "lCourseList";
            lCourseList.Size = new System.Drawing.Size(142, 19);
            lCourseList.TabIndex = 0;
            lCourseList.Text = "xyzzzzzzzzzzzzzzzzz";
            lCourseList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tooltip.SetToolTip(lCourseList, "Selected courses");
            // 
            // cbOpen
            // 
            cbOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbOpen.BackColor = System.Drawing.Color.Transparent;
            cbOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            cbOpen.ForeColor = System.Drawing.Color.White;
            cbOpen.Location = new System.Drawing.Point(1102, 77);
            cbOpen.Name = "cbOpen";
            cbOpen.Size = new System.Drawing.Size(150, 23);
            cbOpen.TabIndex = 7;
            cbOpen.Text = "SHOW OPEN ONLY";
            cbOpen.UseVisualStyleBackColor = false;
            // 
            // lHoveredCourse
            // 
            lHoveredCourse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lHoveredCourse.BackColor = System.Drawing.Color.Transparent;
            lHoveredCourse.Font = new System.Drawing.Font("Segoe UI", 9F);
            lHoveredCourse.ForeColor = System.Drawing.Color.White;
            lHoveredCourse.Location = new System.Drawing.Point(240, 57);
            lHoveredCourse.Name = "lHoveredCourse";
            lHoveredCourse.Size = new System.Drawing.Size(839, 32);
            lHoveredCourse.TabIndex = 8;
            lHoveredCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTitle
            // 
            lTitle.AutoSize = true;
            lTitle.BackColor = System.Drawing.Color.Transparent;
            lTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lTitle.ForeColor = System.Drawing.Color.White;
            lTitle.Location = new System.Drawing.Point(12, 16);
            lTitle.Name = "lTitle";
            lTitle.Size = new System.Drawing.Size(32, 15);
            lTitle.TabIndex = 9;
            lTitle.Text = "Cryn";
            // 
            // cbHighlight
            // 
            cbHighlight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbHighlight.BackColor = System.Drawing.Color.Transparent;
            cbHighlight.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            cbHighlight.ForeColor = System.Drawing.Color.White;
            cbHighlight.Location = new System.Drawing.Point(1102, 50);
            cbHighlight.Name = "cbHighlight";
            cbHighlight.Size = new System.Drawing.Size(150, 23);
            cbHighlight.TabIndex = 10;
            cbHighlight.Text = "HIGHLIGHT";
            cbHighlight.UseVisualStyleBackColor = false;
            // 
            // cbCode
            // 
            cbCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbCode.BackColor = System.Drawing.Color.Transparent;
            cbCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            cbCode.ForeColor = System.Drawing.Color.White;
            cbCode.Location = new System.Drawing.Point(1102, 23);
            cbCode.Name = "cbCode";
            cbCode.Size = new System.Drawing.Size(101, 23);
            cbCode.TabIndex = 11;
            cbCode.Text = "SHOW CODE";
            cbCode.UseVisualStyleBackColor = false;
            // 
            // panelMenuItems
            // 
            panelMenuItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelMenuItems.AutoSize = true;
            panelMenuItems.BackColor = System.Drawing.Color.Transparent;
            panelMenuItems.Controls.Add(bNavTimeTable);
            panelMenuItems.Controls.Add(bNavCourses);
            panelMenuItems.Location = new System.Drawing.Point(12, 719);
            panelMenuItems.Name = "panelMenuItems";
            panelMenuItems.Size = new System.Drawing.Size(233, 38);
            panelMenuItems.TabIndex = 14;
            // 
            // bNavTimeTable
            // 
            bNavTimeTable.AutoEllipsis = true;
            bNavTimeTable.BackColor = System.Drawing.Color.Transparent;
            bNavTimeTable.Cursor = Cursors.Hand;
            bNavTimeTable.FlatAppearance.BorderSize = 0;
            bNavTimeTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            bNavTimeTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            bNavTimeTable.FlatStyle = FlatStyle.Flat;
            bNavTimeTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bNavTimeTable.ForeColor = System.Drawing.Color.White;
            bNavTimeTable.Location = new System.Drawing.Point(0, 0);
            bNavTimeTable.Margin = new Padding(0);
            bNavTimeTable.Name = "bNavTimeTable";
            bNavTimeTable.Size = new System.Drawing.Size(110, 35);
            bNavTimeTable.TabIndex = 0;
            bNavTimeTable.Text = "  Time Table";
            bNavTimeTable.UseVisualStyleBackColor = false;
            // 
            // bNavCourses
            // 
            bNavCourses.BackColor = System.Drawing.Color.Transparent;
            bNavCourses.Cursor = Cursors.Hand;
            bNavCourses.FlatAppearance.BorderSize = 0;
            bNavCourses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            bNavCourses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            bNavCourses.FlatStyle = FlatStyle.Flat;
            bNavCourses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bNavCourses.ForeColor = System.Drawing.Color.White;
            bNavCourses.Location = new System.Drawing.Point(110, 0);
            bNavCourses.Margin = new Padding(0);
            bNavCourses.Name = "bNavCourses";
            bNavCourses.Size = new System.Drawing.Size(110, 35);
            bNavCourses.TabIndex = 1;
            bNavCourses.Text = "  Courses";
            bNavCourses.UseVisualStyleBackColor = false;
            // 
            // panelFooterItems
            // 
            panelFooterItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelFooterItems.AutoSize = true;
            panelFooterItems.BackColor = System.Drawing.Color.Transparent;
            panelFooterItems.Controls.Add(button3);
            panelFooterItems.Controls.Add(bScreenshot);
            panelFooterItems.FlowDirection = FlowDirection.RightToLeft;
            panelFooterItems.Location = new System.Drawing.Point(1067, 719);
            panelFooterItems.Name = "panelFooterItems";
            panelFooterItems.Size = new System.Drawing.Size(233, 38);
            panelFooterItems.TabIndex = 15;
            // 
            // button3
            // 
            button3.AutoEllipsis = true;
            button3.BackColor = System.Drawing.Color.Transparent;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Location = new System.Drawing.Point(123, 0);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(110, 35);
            button3.TabIndex = 0;
            button3.Text = "  Settings";
            button3.UseVisualStyleBackColor = false;
            // 
            // bScreenshot
            // 
            bScreenshot.BackColor = System.Drawing.Color.Transparent;
            bScreenshot.Cursor = Cursors.Hand;
            bScreenshot.FlatAppearance.BorderSize = 0;
            bScreenshot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            bScreenshot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            bScreenshot.FlatStyle = FlatStyle.Flat;
            bScreenshot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bScreenshot.ForeColor = System.Drawing.Color.White;
            bScreenshot.Location = new System.Drawing.Point(13, 0);
            bScreenshot.Margin = new Padding(0);
            bScreenshot.Name = "bScreenshot";
            bScreenshot.Size = new System.Drawing.Size(110, 35);
            bScreenshot.TabIndex = 1;
            bScreenshot.Text = "  Screenshot";
            bScreenshot.UseVisualStyleBackColor = false;
            // 
            // panelViewContainer
            // 
            panelViewContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelViewContainer.AutoScroll = true;
            panelViewContainer.BackColor = System.Drawing.Color.Transparent;
            panelViewContainer.Location = new System.Drawing.Point(40, 110);
            panelViewContainer.Name = "panelViewContainer";
            panelViewContainer.Size = new System.Drawing.Size(1220, 603);
            panelViewContainer.TabIndex = 16;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1300, 760);
            Controls.Add(panelViewContainer);
            Controls.Add(panelFooterItems);
            Controls.Add(panelMenuItems);
            Controls.Add(lCourseList);
            Controls.Add(cbCode);
            Controls.Add(cbHighlight);
            Controls.Add(lTitle);
            Controls.Add(lHoveredCourse);
            Controls.Add(cbOpen);
            Controls.Add(bPref);
            Controls.Add(bExit);
            Controls.Add(lViewTitle);
            FormBorderStyle = FormBorderStyle.None;
            Location = new System.Drawing.Point(0, 0);
            Name = "Main";
            Text = "CUFE Dry Run";
            panelMenuItems.ResumeLayout(false);
            panelFooterItems.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lViewTitle;
        private Button bExit;
        private Button bPref;
        private ToolTip tooltip;
        private Label lCourseList;
        private CheckBox cbOpen;
        private Label lHoveredCourse;
        private Label lTitle;
        private CheckBox cbHighlight;
        private CheckBox cbCode;
        private FlowLayoutPanel panelMenuItems;
        private Button bNavTimeTable;
        private Button bNavCourses;
        private FlowLayoutPanel panelFooterItems;
        private Button button3;
        private Button bScreenshot;
        private Panel panelViewContainer;
    }
}