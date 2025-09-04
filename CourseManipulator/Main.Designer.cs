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
            tbRawXml = new TextBox();
            label1 = new Label();
            bParse = new Button();
            dgvCourses = new DataGridView();
            bAddRow = new Button();
            bCloneRow = new Button();
            bDeleteRow = new Button();
            bEditCourse = new Button();
            toolTip = new ToolTip(components);
            tbSearch = new TextBox();
            bClearSearch = new Button();
            bExport = new Button();
            lblSearch = new Label();
            bOpen = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // tbRawXml
            // 
            tbRawXml.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbRawXml.Location = new Point(12, 25);
            tbRawXml.MaxLength = int.MaxValue;
            tbRawXml.Multiline = true;
            tbRawXml.Name = "tbRawXml";
            tbRawXml.Size = new Size(776, 101);
            tbRawXml.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Raw xml";
            // 
            // bParse
            // 
            bParse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bParse.Location = new Point(713, 132);
            bParse.Name = "bParse";
            bParse.Size = new Size(75, 31);
            bParse.TabIndex = 2;
            bParse.Text = "Parse";
            toolTip.SetToolTip(bParse, "Parse the XML data and populate the course grid");
            bParse.UseVisualStyleBackColor = true;
            // 
            // dgvCourses
            // 
            dgvCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(12, 230);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(776, 399);
            dgvCourses.TabIndex = 3;
            // 
            // bAddRow
            // 
            bAddRow.Location = new Point(12, 169);
            bAddRow.Name = "bAddRow";
            bAddRow.Size = new Size(75, 25);
            bAddRow.TabIndex = 4;
            bAddRow.Text = "Add Row";
            toolTip.SetToolTip(bAddRow, "Add a new course record (Ctrl+N)");
            bAddRow.UseVisualStyleBackColor = true;
            // 
            // bCloneRow
            // 
            bCloneRow.Location = new Point(93, 169);
            bCloneRow.Name = "bCloneRow";
            bCloneRow.Size = new Size(75, 25);
            bCloneRow.TabIndex = 5;
            bCloneRow.Text = "Clone Row";
            toolTip.SetToolTip(bCloneRow, "Clone the selected row (Ctrl+D)");
            bCloneRow.UseVisualStyleBackColor = true;
            // 
            // bDeleteRow
            // 
            bDeleteRow.Location = new Point(174, 169);
            bDeleteRow.Name = "bDeleteRow";
            bDeleteRow.Size = new Size(75, 25);
            bDeleteRow.TabIndex = 6;
            bDeleteRow.Text = "Delete Row";
            toolTip.SetToolTip(bDeleteRow, "Delete the selected row (Delete key)");
            bDeleteRow.UseVisualStyleBackColor = true;
            // 
            // bEditCourse
            // 
            bEditCourse.Location = new Point(255, 169);
            bEditCourse.Name = "bEditCourse";
            bEditCourse.Size = new Size(75, 25);
            bEditCourse.TabIndex = 7;
            bEditCourse.Text = "Edit Course";
            toolTip.SetToolTip(bEditCourse, "Edit course information (Ctrl+E)");
            bEditCourse.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(60, 201);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Enter course code...";
            tbSearch.Size = new Size(200, 23);
            tbSearch.TabIndex = 9;
            toolTip.SetToolTip(tbSearch, "Search courses by code (supports partial matching)");
            // 
            // bClearSearch
            // 
            bClearSearch.Location = new Point(266, 200);
            bClearSearch.Name = "bClearSearch";
            bClearSearch.Size = new Size(50, 25);
            bClearSearch.TabIndex = 11;
            bClearSearch.Text = "Clear";
            toolTip.SetToolTip(bClearSearch, "Clear search filter");
            bClearSearch.UseVisualStyleBackColor = true;
            // 
            // bExport
            // 
            bExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bExport.Location = new Point(713, 169);
            bExport.Name = "bExport";
            bExport.Size = new Size(75, 25);
            bExport.TabIndex = 8;
            bExport.Text = "Export";
            bExport.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 204);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 10;
            lblSearch.Text = "Search:";
            // 
            // bOpen
            // 
            bOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bOpen.Location = new Point(632, 132);
            bOpen.Name = "bOpen";
            bOpen.Size = new Size(75, 31);
            bOpen.TabIndex = 2;
            bOpen.Text = "Open";
            bOpen.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 641);
            Controls.Add(bClearSearch);
            Controls.Add(lblSearch);
            Controls.Add(tbSearch);
            Controls.Add(bExport);
            Controls.Add(bEditCourse);
            Controls.Add(bDeleteRow);
            Controls.Add(bCloneRow);
            Controls.Add(bAddRow);
            Controls.Add(dgvCourses);
            Controls.Add(bOpen);
            Controls.Add(bParse);
            Controls.Add(label1);
            Controls.Add(tbRawXml);
            Name = "Main";
            Text = "Course Manipulator";
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbRawXml;
        private Label label1;
        private Button bParse;
        private DataGridView dgvCourses;
        private Button bAddRow;
        private Button bCloneRow;
        private Button bDeleteRow;
        private Button bEditCourse;
        private ToolTip toolTip;
        private Button bExport;
        private TextBox tbSearch;
        private Label lblSearch;
        private Button bClearSearch;
        private Button bOpen;
    }
}
