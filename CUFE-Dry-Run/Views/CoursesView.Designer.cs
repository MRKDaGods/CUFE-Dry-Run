namespace MRK.Views
{
    partial class CoursesView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMainLayout = new System.Windows.Forms.Panel();
            listViewCourses = new BrightIdeasSoftware.ObjectListView();
            panelSearchContainer = new System.Windows.Forms.Panel();
            panelShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            tbSearch = new System.Windows.Forms.TextBox();
            bSearch = new System.Windows.Forms.Button();
            codeHeader = new System.Windows.Forms.ColumnHeader();
            nameHeader = new System.Windows.Forms.ColumnHeader();
            lecsHeader = new System.Windows.Forms.ColumnHeader();
            tutsHeader = new System.Windows.Forms.ColumnHeader();
            flagsHeader = new System.Windows.Forms.ColumnHeader();
            panelMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listViewCourses).BeginInit();
            panelSearchContainer.SuspendLayout();
            panelShortcuts.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainLayout
            // 
            panelMainLayout.Controls.Add(listViewCourses);
            panelMainLayout.Controls.Add(panelSearchContainer);
            panelMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainLayout.Location = new System.Drawing.Point(0, 0);
            panelMainLayout.Name = "panelMainLayout";
            panelMainLayout.Size = new System.Drawing.Size(938, 600);
            panelMainLayout.TabIndex = 0;
            // 
            // listViewCourses
            // 
            listViewCourses.AlternateRowBackColor = System.Drawing.Color.FromArgb(42, 42, 42);
            listViewCourses.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listViewCourses.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            listViewCourses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listViewCourses.CellEditUseWholeCell = false;
            listViewCourses.CheckBoxes = true;
            listViewCourses.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            listViewCourses.ForeColor = System.Drawing.Color.White;
            listViewCourses.FullRowSelect = true;
            listViewCourses.Location = new System.Drawing.Point(0, 38);
            listViewCourses.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            listViewCourses.Name = "listViewCourses";
            listViewCourses.SelectedBackColor = System.Drawing.Color.White;
            listViewCourses.SelectedForeColor = System.Drawing.Color.Black;
            listViewCourses.ShowGroups = false;
            listViewCourses.Size = new System.Drawing.Size(938, 559);
            listViewCourses.TabIndex = 2;
            listViewCourses.UseAlternatingBackColors = true;
            listViewCourses.UseCompatibleStateImageBehavior = false;
            listViewCourses.View = System.Windows.Forms.View.Details;
            // 
            // panelSearchContainer
            // 
            panelSearchContainer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelSearchContainer.Controls.Add(panelShortcuts);
            panelSearchContainer.Controls.Add(tbSearch);
            panelSearchContainer.Controls.Add(bSearch);
            panelSearchContainer.Location = new System.Drawing.Point(0, 0);
            panelSearchContainer.Margin = new System.Windows.Forms.Padding(0);
            panelSearchContainer.Name = "panelSearchContainer";
            panelSearchContainer.Size = new System.Drawing.Size(938, 35);
            panelSearchContainer.TabIndex = 1;
            // 
            // panelShortcuts
            // 
            panelShortcuts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelShortcuts.Controls.Add(button2);
            panelShortcuts.Controls.Add(button1);
            panelShortcuts.Controls.Add(button5);
            panelShortcuts.Controls.Add(button3);
            panelShortcuts.Controls.Add(button4);
            panelShortcuts.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelShortcuts.Location = new System.Drawing.Point(416, 0);
            panelShortcuts.Name = "panelShortcuts";
            panelShortcuts.Size = new System.Drawing.Size(522, 35);
            panelShortcuts.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(422, 0);
            button2.Margin = new System.Windows.Forms.Padding(0);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(100, 25);
            button2.TabIndex = 4;
            button2.Text = "EECS";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(322, 0);
            button1.Margin = new System.Windows.Forms.Padding(0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(100, 25);
            button1.TabIndex = 4;
            button1.Text = "CMP";
            button1.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            button5.ForeColor = System.Drawing.Color.White;
            button5.Location = new System.Drawing.Point(222, 0);
            button5.Margin = new System.Windows.Forms.Padding(0);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(100, 25);
            button5.TabIndex = 5;
            button5.Text = "MTH";
            button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Location = new System.Drawing.Point(122, 0);
            button3.Margin = new System.Windows.Forms.Padding(0);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(100, 25);
            button3.TabIndex = 4;
            button3.Text = "GEN";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            button4.ForeColor = System.Drawing.Color.White;
            button4.Location = new System.Drawing.Point(22, 0);
            button4.Margin = new System.Windows.Forms.Padding(0);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(100, 25);
            button4.TabIndex = 4;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = false;
            // 
            // tbSearch
            // 
            tbSearch.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tbSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            tbSearch.ForeColor = System.Drawing.Color.White;
            tbSearch.Location = new System.Drawing.Point(0, 0);
            tbSearch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            tbSearch.Multiline = true;
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "   Search by code";
            tbSearch.Size = new System.Drawing.Size(291, 25);
            tbSearch.TabIndex = 2;
            // 
            // bSearch
            // 
            bSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bSearch.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            bSearch.FlatAppearance.BorderSize = 0;
            bSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bSearch.ForeColor = System.Drawing.Color.White;
            bSearch.Location = new System.Drawing.Point(294, 0);
            bSearch.Margin = new System.Windows.Forms.Padding(0);
            bSearch.Name = "bSearch";
            bSearch.Size = new System.Drawing.Size(100, 25);
            bSearch.TabIndex = 3;
            bSearch.Text = "Search";
            bSearch.UseVisualStyleBackColor = false;
            // 
            // codeHeader
            // 
            codeHeader.Text = "Code";
            codeHeader.Width = 100;
            // 
            // nameHeader
            // 
            nameHeader.Text = "Name";
            nameHeader.Width = 400;
            // 
            // lecsHeader
            // 
            lecsHeader.Text = "Lectures";
            lecsHeader.Width = 100;
            // 
            // tutsHeader
            // 
            tutsHeader.Text = "Tutorials";
            tutsHeader.Width = 100;
            // 
            // flagsHeader
            // 
            flagsHeader.Text = "Flags";
            flagsHeader.Width = 100;
            // 
            // CoursesView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(panelMainLayout);
            DoubleBuffered = true;
            Name = "CoursesView";
            Size = new System.Drawing.Size(938, 600);
            panelMainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listViewCourses).EndInit();
            panelSearchContainer.ResumeLayout(false);
            panelSearchContainer.PerformLayout();
            panelShortcuts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMainLayout;
        private System.Windows.Forms.Panel panelSearchContainer;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bSearch;
        private BrightIdeasSoftware.ObjectListView listViewCourses;
        private System.Windows.Forms.ColumnHeader codeHeader;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader lecsHeader;
        private System.Windows.Forms.ColumnHeader tutsHeader;
        private System.Windows.Forms.ColumnHeader flagsHeader;
        private System.Windows.Forms.FlowLayoutPanel panelShortcuts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
