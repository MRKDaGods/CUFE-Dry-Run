using MRK.Models;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace MRK
{
    public partial class Main : Form
    {
        private BindingList<CourseRecord> courseRecords = new();
        private BindingList<CourseRecord> filteredCourseRecords = new();

        public Main()
        {
            InitializeComponent();

            bParse.Click += OnParseClick;
            bAddRow.Click += OnAddRowClick;
            bCloneRow.Click += OnCloneRowClick;
            bDeleteRow.Click += OnDeleteRowClick;
            bEditCourse.Click += OnEditCourseClick;
            bExport.Click += OnExportClick;
            bOpen.Click += OnOpenClick;

            // Search functionality
            tbSearch.TextChanged += OnSearchTextChanged;
            bClearSearch.Click += OnClearSearchClick;

            // Set up DataGridView with filtered data source
            dgvCourses.DataSource = filteredCourseRecords;
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.KeyDown += OnDataGridViewKeyDown;
            dgvCourses.SelectionChanged += OnSelectionChanged;
            dgvCourses.AutoGenerateColumns = true;
            dgvCourses.ReadOnly = false;
            dgvCourses.CellEndEdit += OnCellEndEdit;
            dgvCourses.CellDoubleClick += OnCellDoubleClick;

            // Configure column display after data is bound
            ConfigureColumns();

            // Initially disable clone/delete buttons since no rows are selected
            UpdateButtonStates();
        }

        private void OnOpenClick(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog()
            {
                Title = "Open Course XML File",
                Filter = "All Files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileContent = File.ReadAllText(ofd.FileName);
                    tbRawXml.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to read file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnSearchTextChanged(object? sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void OnClearSearchClick(object? sender, EventArgs e)
        {
            tbSearch.Clear();
            ApplySearchFilter();
        }

        private void ApplySearchFilter()
        {
            var searchText = tbSearch.Text.Trim().ToUpperInvariant();
            
            filteredCourseRecords.Clear();
            
            if (string.IsNullOrEmpty(searchText))
            {
                // Show all records when search is empty
                foreach (var record in courseRecords)
                {
                    filteredCourseRecords.Add(record);
                }
            }
            else
            {
                // Filter records by course code (case-insensitive, partial matching)
                foreach (var record in courseRecords)
                {
                    if (record.Course.Code.ToUpperInvariant().Contains(searchText))
                    {
                        filteredCourseRecords.Add(record);
                    }
                }
            }
            
            UpdateButtonStates();
        }

        private void OnExportClick(object? sender, EventArgs e)
        {
            var sb = new StringBuilder();

            int courseId = 1;
            foreach (var record in courseRecords)
            {
                sb.Append($"<tr>\",\"<td>{courseId++}</td><td>__{record.Course.Code}__</td><td>{record.Course.Name}</td><td>{record.Group}</td><td>{record.Type}</td><td>{record.Day}</td><td>{record.From.ToString(@"h\:mm")}</td><td>{record.To.ToString(@"h\:mm")}</td><td>{record.ClassSize}</td><td>{record.Enrolled}</td><td>{record.Waiting}</td><td>{record.Status}</td><td>{record.Location}</td><td>8/27/2025 7:00:00 PM</td>\",\"</tr>");
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Copied to clipboard!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfigureColumns()
        {
            if (dgvCourses.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvCourses.Columns)
                {
                    switch (column.Name)
                    {
                        case "Course":
                            column.HeaderText = "Course (Double-click to edit)";
                            column.Width = 250;
                            column.ReadOnly = true;
                            break;
                        case "Group":
                            column.HeaderText = "Group";
                            column.Width = 60;
                            break;
                        case "Type":
                            column.HeaderText = "Type";
                            column.Width = 80;
                            break;
                        case "Day":
                            column.HeaderText = "Day";
                            column.Width = 80;
                            break;
                        case "From":
                            column.HeaderText = "From";
                            column.Width = 80;
                            break;
                        case "To":
                            column.HeaderText = "To";
                            column.Width = 80;
                            break;
                        case "ClassSize":
                            column.HeaderText = "Class Size";
                            column.Width = 80;
                            break;
                        case "Enrolled":
                            column.HeaderText = "Enrolled";
                            column.Width = 80;
                            break;
                        case "Waiting":
                            column.HeaderText = "Waiting";
                            column.Width = 80;
                            break;
                        case "Status":
                            column.HeaderText = "Status";
                            column.Width = 80;
                            break;
                        case "Location":
                            column.HeaderText = "Location";
                            column.Width = 150;
                            break;
                        case "Selected":
                            column.HeaderText = "Selected";
                            column.Width = 70;
                            break;
                        case "IsOpen":
                            column.HeaderText = "Is Open";
                            column.Width = 70;
                            column.ReadOnly = true;
                            break;
                        case "ParseFormat":
                        case "MultipleLectureIndex":
                        case "MultipleTutorialIndex":
                            // Hide technical columns
                            column.Visible = false;
                            break;
                    }
                }
            }
        }

        private void OnCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Handle double-click on Course column to edit course information
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < filteredCourseRecords.Count)
            {
                var column = dgvCourses.Columns[e.ColumnIndex];
                if (column.Name == "Course")
                {
                    EditCourseInformation(e.RowIndex);
                }
            }
        }

        private void EditCourseInformation(int rowIndex)
        {
            var record = filteredCourseRecords[rowIndex];
            var originalCourse = record.Course;

            // Create a simple dialog for editing course information
            using var form = new Form()
            {
                Text = "Edit Course Information",
                Size = new Size(400, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblCode = new Label() { Text = "Course Code:", Location = new Point(10, 20), Size = new Size(100, 23) };
            var txtCode = new TextBox() { Text = originalCourse.Code, Location = new Point(120, 20), Size = new Size(200, 23), ReadOnly = true };

            var lblName = new Label() { Text = "Course Name:", Location = new Point(10, 50), Size = new Size(100, 23) };
            var txtName = new TextBox() { Text = originalCourse.Name, Location = new Point(120, 50), Size = new Size(200, 23) };

            var btnOK = new Button() { Text = "OK", Location = new Point(165, 100), Size = new Size(75, 30), DialogResult = DialogResult.OK };
            var btnCancel = new Button() { Text = "Cancel", Location = new Point(245, 100), Size = new Size(75, 30), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange([lblCode, txtCode, lblName, txtName, btnOK, btnCancel]);
            form.AcceptButton = btnOK;
            form.CancelButton = btnCancel;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var newName = txtName.Text.Trim();

                if (string.IsNullOrEmpty(newName))
                {
                    MessageBox.Show("Course name cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update the course name directly (now possible since Name property has a setter)
                originalCourse.Name = newName;

                // Refresh the grid to show the updated name
                dgvCourses.InvalidateRow(rowIndex);
                dgvCourses.Refresh();

                MessageBox.Show("Course name updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnCellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            // Handle any post-edit validation or updates if needed
            if (e.RowIndex >= 0 && e.RowIndex < filteredCourseRecords.Count)
            {
                var record = filteredCourseRecords[e.RowIndex];
                
                // Refresh the row to ensure proper display
                dgvCourses.InvalidateRow(e.RowIndex);
            }
        }

        private void OnParseClick(object? sender, EventArgs e)
        {
            var standardCourseParser = CourseRegistry.GetOrCreateParser<StandardCourseParser>();
            standardCourseParser.Parse(tbRawXml.Text);

            // Clear the existing records and add the parsed ones
            courseRecords.Clear();
            foreach (var record in standardCourseParser.CourseRecords)
            {
                courseRecords.Add(record);
            }

            // Apply search filter to update the filtered view
            ApplySearchFilter();

            // Configure columns after data is loaded
            ConfigureColumns();
            UpdateButtonStates();
        }

        private void OnAddRowClick(object? sender, EventArgs e)
        {
            // Get a unique course code
            var newCourseCode = GetNextAvailableCourseCode();
            
            // Use CourseRegistry.GetOrCreateCourse for consistency
            var defaultCourse = CourseRegistry.GetOrCreateCourse(newCourseCode, "New Course");
            var newRecord = new CourseRecord(
                course: defaultCourse,
                group: 1,
                type: CourseRecordType.Lecture,
                day: CourseRecordDay.Sunday,
                from: TimeSpan.FromHours(8),
                to: TimeSpan.FromHours(10),
                classSize: 30,
                enrolled: 0,
                waiting: 0,
                status: "Opened",
                location: "TBA",
                parseFormat: CourseParseFormat.Regular
            );

            courseRecords.Add(newRecord);
            
            // Apply search filter to update the filtered view
            ApplySearchFilter();
            
            // Configure columns if this is the first row
            if (courseRecords.Count == 1)
            {
                ConfigureColumns();
            }
            
            // Select the newly added row if it's visible in filtered results
            var newRowIndex = filteredCourseRecords.IndexOf(newRecord);
            if (newRowIndex >= 0 && dgvCourses.Rows.Count > newRowIndex)
            {
                dgvCourses.ClearSelection();
                dgvCourses.Rows[newRowIndex].Selected = true;
                dgvCourses.CurrentCell = dgvCourses.Rows[newRowIndex].Cells[0];
            }
        }

        private void OnCloneRowClick(object? sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to clone.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedIndex = dgvCourses.SelectedRows[0].Index;
            if (selectedIndex >= 0 && selectedIndex < filteredCourseRecords.Count)
            {
                var originalRecord = filteredCourseRecords[selectedIndex];
                
                // Create a clone with a modified group number to avoid conflicts
                var clonedRecord = new CourseRecord(
                    course: originalRecord.Course,
                    group: GetNextAvailableGroup(originalRecord.Course, originalRecord.Type),
                    type: originalRecord.Type,
                    day: originalRecord.Day,
                    from: originalRecord.From,
                    to: originalRecord.To,
                    classSize: originalRecord.ClassSize,
                    enrolled: originalRecord.Enrolled,
                    waiting: originalRecord.Waiting,
                    status: originalRecord.Status,
                    location: originalRecord.Location,
                    parseFormat: originalRecord.ParseFormat
                );

                courseRecords.Add(clonedRecord);
                
                // Apply search filter to update the filtered view
                ApplySearchFilter();

                // Select the newly cloned row if it's visible in filtered results
                var newRowIndex = filteredCourseRecords.IndexOf(clonedRecord);
                if (newRowIndex >= 0 && dgvCourses.Rows.Count > newRowIndex)
                {
                    dgvCourses.ClearSelection();
                    dgvCourses.Rows[newRowIndex].Selected = true;
                    dgvCourses.CurrentCell = dgvCourses.Rows[newRowIndex].Cells[0];
                }
            }
        }

        private void OnDeleteRowClick(object? sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedIndex = dgvCourses.SelectedRows[0].Index;
            if (selectedIndex >= 0 && selectedIndex < filteredCourseRecords.Count)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected row?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    var recordToDelete = filteredCourseRecords[selectedIndex];
                    courseRecords.Remove(recordToDelete);
                    
                    // Apply search filter to update the filtered view
                    ApplySearchFilter();
                }
            }
        }

        private void OnDataGridViewKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N: // Ctrl+N for Add
                        OnAddRowClick(sender, e);
                        e.Handled = true;
                        break;
                    case Keys.D: // Ctrl+D for Clone
                        OnCloneRowClick(sender, e);
                        e.Handled = true;
                        break;
                    case Keys.E: // Ctrl+E for Edit Course
                        if (dgvCourses.SelectedRows.Count > 0)
                        {
                            EditCourseInformation(dgvCourses.SelectedRows[0].Index);
                        }
                        e.Handled = true;
                        break;
                    case Keys.F: // Ctrl+F for Search
                        tbSearch.Focus();
                        e.Handled = true;
                        break;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                OnDeleteRowClick(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape && tbSearch.Focused)
            {
                // Clear search when Escape is pressed in search box
                tbSearch.Clear();
                dgvCourses.Focus();
                e.Handled = true;
            }
        }

        private void OnSelectionChanged(object? sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvCourses.SelectedRows.Count > 0;
            bCloneRow.Enabled = hasSelection;
            bDeleteRow.Enabled = hasSelection;
            bEditCourse.Enabled = hasSelection;
        }

        private int GetNextAvailableGroup(Course course, CourseRecordType type)
        {
            var existingGroups = courseRecords
                .Where(r => r.Course.Code == course.Code && r.Type == type)
                .Select(r => r.Group)
                .ToHashSet();

            int group = 1;
            while (existingGroups.Contains(group))
            {
                group++;
            }

            return group;
        }

        private string GetNextAvailableCourseCode()
        {
            var existingCodes = courseRecords
                .Select(r => r.Course.Code)
                .ToHashSet();

            int counter = 1;
            string newCode;
            do
            {
                newCode = $"NEW{counter:000}";
                counter++;
            } while (existingCodes.Contains(newCode));

            return newCode;
        }

        private void OnEditCourseClick(object? sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit the course information.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedIndex = dgvCourses.SelectedRows[0].Index;
            if (selectedIndex >= 0 && selectedIndex < filteredCourseRecords.Count)
            {
                EditCourseInformation(selectedIndex);
            }
        }
    }
}
