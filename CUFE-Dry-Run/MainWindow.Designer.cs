using System.Windows.Forms;

namespace MRK
{
    partial class MainWindow
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
            tooltip = new ToolTip(components);
            lStatusBar = new Label();
            lTitle = new Label();
            panelMenuItems = new FlowLayoutPanel();
            bNavTimeTable = new Button();
            bNavCourses = new Button();
            panelFooterItems = new FlowLayoutPanel();
            bNavSettings = new Button();
            bScreenshot = new Button();
            bToggleTransparency = new Button();
            panelViewContainer = new Panel();
            lFooterBar = new Label();
            panelLegend = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            label2 = new Label();
            button2 = new Button();
            panel3 = new Panel();
            label3 = new Label();
            button3 = new Button();
            panel4 = new Panel();
            label4 = new Label();
            button4 = new Button();
            panel5 = new Panel();
            label5 = new Label();
            button5 = new Button();
            panelMenuItems.SuspendLayout();
            panelFooterItems.SuspendLayout();
            panelLegend.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
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
            // lStatusBar
            // 
            lStatusBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lStatusBar.BackColor = System.Drawing.Color.Transparent;
            lStatusBar.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.75F);
            lStatusBar.ForeColor = System.Drawing.Color.White;
            lStatusBar.Location = new System.Drawing.Point(826, 59);
            lStatusBar.Name = "lStatusBar";
            lStatusBar.Size = new System.Drawing.Size(434, 32);
            lStatusBar.TabIndex = 8;
            lStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTitle
            // 
            lTitle.AutoSize = true;
            lTitle.BackColor = System.Drawing.Color.Transparent;
            lTitle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F);
            lTitle.ForeColor = System.Drawing.Color.White;
            lTitle.Location = new System.Drawing.Point(12, 16);
            lTitle.Name = "lTitle";
            lTitle.Size = new System.Drawing.Size(34, 16);
            lTitle.TabIndex = 9;
            lTitle.Text = "Cryn";
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
            panelMenuItems.Size = new System.Drawing.Size(220, 38);
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
            panelFooterItems.Controls.Add(bNavSettings);
            panelFooterItems.Controls.Add(bScreenshot);
            panelFooterItems.Controls.Add(bToggleTransparency);
            panelFooterItems.FlowDirection = FlowDirection.RightToLeft;
            panelFooterItems.Location = new System.Drawing.Point(950, 719);
            panelFooterItems.Name = "panelFooterItems";
            panelFooterItems.Size = new System.Drawing.Size(350, 38);
            panelFooterItems.TabIndex = 15;
            // 
            // bNavSettings
            // 
            bNavSettings.AutoEllipsis = true;
            bNavSettings.BackColor = System.Drawing.Color.Transparent;
            bNavSettings.Cursor = Cursors.Hand;
            bNavSettings.FlatAppearance.BorderSize = 0;
            bNavSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            bNavSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            bNavSettings.FlatStyle = FlatStyle.Flat;
            bNavSettings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bNavSettings.ForeColor = System.Drawing.Color.White;
            bNavSettings.Location = new System.Drawing.Point(240, 0);
            bNavSettings.Margin = new Padding(0);
            bNavSettings.Name = "bNavSettings";
            bNavSettings.Size = new System.Drawing.Size(110, 35);
            bNavSettings.TabIndex = 0;
            bNavSettings.Text = "  Settings";
            bNavSettings.UseVisualStyleBackColor = false;
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
            bScreenshot.Location = new System.Drawing.Point(130, 0);
            bScreenshot.Margin = new Padding(0);
            bScreenshot.Name = "bScreenshot";
            bScreenshot.Size = new System.Drawing.Size(110, 35);
            bScreenshot.TabIndex = 1;
            bScreenshot.Text = "  Screenshot";
            bScreenshot.UseVisualStyleBackColor = false;
            // 
            // bToggleTransparency
            // 
            bToggleTransparency.BackColor = System.Drawing.Color.Transparent;
            bToggleTransparency.Cursor = Cursors.Hand;
            bToggleTransparency.FlatAppearance.BorderSize = 0;
            bToggleTransparency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            bToggleTransparency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            bToggleTransparency.FlatStyle = FlatStyle.Flat;
            bToggleTransparency.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            bToggleTransparency.ForeColor = System.Drawing.Color.White;
            bToggleTransparency.Location = new System.Drawing.Point(0, 0);
            bToggleTransparency.Margin = new Padding(0);
            bToggleTransparency.Name = "bToggleTransparency";
            bToggleTransparency.Size = new System.Drawing.Size(130, 35);
            bToggleTransparency.TabIndex = 2;
            bToggleTransparency.Text = "  Transparency";
            bToggleTransparency.UseVisualStyleBackColor = false;
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
            // lFooterBar
            // 
            lFooterBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lFooterBar.BackColor = System.Drawing.Color.Transparent;
            lFooterBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            lFooterBar.ForeColor = System.Drawing.Color.White;
            lFooterBar.Location = new System.Drawing.Point(238, 716);
            lFooterBar.Name = "lFooterBar";
            lFooterBar.Size = new System.Drawing.Size(697, 41);
            lFooterBar.TabIndex = 8;
            lFooterBar.Text = "footer";
            lFooterBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLegend
            // 
            panelLegend.Anchor = AnchorStyles.Top;
            panelLegend.BackColor = System.Drawing.Color.Transparent;
            panelLegend.Controls.Add(panel1);
            panelLegend.Controls.Add(panel2);
            panelLegend.Controls.Add(panel3);
            panelLegend.Controls.Add(panel4);
            panelLegend.Controls.Add(panel5);
            panelLegend.Location = new System.Drawing.Point(370, 59);
            panelLegend.Name = "panelLegend";
            panelLegend.Size = new System.Drawing.Size(450, 41);
            panelLegend.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(81, 38);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(31, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 1;
            label1.Text = "Lecture";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new System.Drawing.Point(3, 9);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(22, 19);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(button2);
            panel2.Location = new System.Drawing.Point(81, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(81, 38);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(31, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 1;
            label2.Text = "Tutorial";
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(44, 120, 115);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new System.Drawing.Point(3, 9);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(22, 19);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(button3);
            panel3.Location = new System.Drawing.Point(162, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(105, 38);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(31, 12);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 13);
            label3.TabIndex = 1;
            label3.Text = "Same group";
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.DarkGoldenrod;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new System.Drawing.Point(3, 9);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(22, 19);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(button4);
            panel4.Location = new System.Drawing.Point(267, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(95, 38);
            panel4.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(31, 12);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 13);
            label4.TabIndex = 1;
            label4.Text = "Diff group";
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.DarkOliveGreen;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new System.Drawing.Point(3, 9);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(22, 19);
            button4.TabIndex = 0;
            button4.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(label5);
            panel5.Controls.Add(button5);
            panel5.Location = new System.Drawing.Point(362, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(84, 38);
            panel5.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(31, 12);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(50, 13);
            label5.TabIndex = 1;
            label5.Text = "Selected";
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.FromArgb(211, 84, 0);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new System.Drawing.Point(3, 9);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(22, 19);
            button5.TabIndex = 0;
            button5.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1300, 760);
            Controls.Add(panelLegend);
            Controls.Add(lFooterBar);
            Controls.Add(panelViewContainer);
            Controls.Add(panelFooterItems);
            Controls.Add(panelMenuItems);
            Controls.Add(lTitle);
            Controls.Add(lStatusBar);
            Controls.Add(bExit);
            Controls.Add(lViewTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Location = new System.Drawing.Point(0, 0);
            Name = "MainWindow";
            Text = "CUFE Dry Run";
            panelMenuItems.ResumeLayout(false);
            panelFooterItems.ResumeLayout(false);
            panelLegend.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lViewTitle;
        private Button bExit;
        private ToolTip tooltip;
        private Label lStatusBar;
        private Label lTitle;
        private FlowLayoutPanel panelMenuItems;
        private Button bNavTimeTable;
        private Button bNavCourses;
        private FlowLayoutPanel panelFooterItems;
        private Button bNavSettings;
        private Button bScreenshot;
        private Panel panelViewContainer;
        private Button bToggleTransparency;
        private Label lFooterBar;
        private FlowLayoutPanel panelLegend;
        private Panel panel1;
        private Label label1;
        private Button button1;
        private Panel panel2;
        private Label label2;
        private Button button2;
        private Panel panel3;
        private Label label3;
        private Button button3;
        private Panel panel4;
        private Label label4;
        private Button button4;
        private Panel panel5;
        private Label label5;
        private Button button5;
    }
}