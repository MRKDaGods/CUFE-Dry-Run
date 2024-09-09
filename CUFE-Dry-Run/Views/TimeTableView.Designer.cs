namespace MRK.Views
{
    partial class TimeTableView
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
            lCourseList = new System.Windows.Forms.Label();
            cbOpen = new System.Windows.Forms.CheckBox();
            lLoading = new System.Windows.Forms.Label();
            courseCont = new System.Windows.Forms.Panel();
            coursePrefab = new System.Windows.Forms.Button();
            dayPrefab = new System.Windows.Forms.Label();
            timePrefab = new System.Windows.Forms.Label();
            courseCont.SuspendLayout();
            SuspendLayout();
            // 
            // lCourseList
            // 
            lCourseList.AutoSize = true;
            lCourseList.BackColor = System.Drawing.Color.Transparent;
            lCourseList.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            lCourseList.ForeColor = System.Drawing.Color.White;
            lCourseList.Location = new System.Drawing.Point(951, 582);
            lCourseList.Name = "lCourseList";
            lCourseList.Size = new System.Drawing.Size(142, 19);
            lCourseList.TabIndex = 8;
            lCourseList.Text = "xyzzzzzzzzzzzzzzzzz";
            lCourseList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbOpen
            // 
            cbOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbOpen.BackColor = System.Drawing.Color.Transparent;
            cbOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            cbOpen.ForeColor = System.Drawing.Color.White;
            cbOpen.Location = new System.Drawing.Point(1339, -29);
            cbOpen.Name = "cbOpen";
            cbOpen.Size = new System.Drawing.Size(150, 23);
            cbOpen.TabIndex = 11;
            cbOpen.Text = "SHOW OPEN ONLY";
            cbOpen.UseVisualStyleBackColor = false;
            // 
            // lLoading
            // 
            lLoading.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lLoading.BackColor = System.Drawing.Color.Transparent;
            lLoading.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            lLoading.ForeColor = System.Drawing.Color.White;
            lLoading.Location = new System.Drawing.Point(318, 146);
            lLoading.Name = "lLoading";
            lLoading.Size = new System.Drawing.Size(489, 444);
            lLoading.TabIndex = 9;
            lLoading.Text = "Loading courses...";
            lLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseCont
            // 
            courseCont.AutoScroll = true;
            courseCont.AutoScrollMargin = new System.Drawing.Size(10, 10);
            courseCont.BackColor = System.Drawing.Color.Transparent;
            courseCont.Controls.Add(coursePrefab);
            courseCont.Controls.Add(dayPrefab);
            courseCont.Controls.Add(lLoading);
            courseCont.Controls.Add(timePrefab);
            courseCont.Dock = System.Windows.Forms.DockStyle.Fill;
            courseCont.ForeColor = System.Drawing.Color.White;
            courseCont.Location = new System.Drawing.Point(0, 0);
            courseCont.Name = "courseCont";
            courseCont.Size = new System.Drawing.Size(1275, 684);
            courseCont.TabIndex = 10;
            // 
            // coursePrefab
            // 
            coursePrefab.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            coursePrefab.FlatAppearance.BorderColor = System.Drawing.Color.White;
            coursePrefab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            coursePrefab.Font = new System.Drawing.Font("Segoe UI", 9F);
            coursePrefab.ForeColor = System.Drawing.Color.White;
            coursePrefab.Location = new System.Drawing.Point(3, 69);
            coursePrefab.Name = "coursePrefab";
            coursePrefab.Size = new System.Drawing.Size(95, 57);
            coursePrefab.TabIndex = 3;
            coursePrefab.Text = "MTHN102\r\nLEC G5";
            coursePrefab.UseVisualStyleBackColor = false;
            // 
            // dayPrefab
            // 
            dayPrefab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dayPrefab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
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
            timePrefab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            timePrefab.ForeColor = System.Drawing.Color.White;
            timePrefab.Location = new System.Drawing.Point(3, 23);
            timePrefab.Name = "timePrefab";
            timePrefab.Size = new System.Drawing.Size(95, 43);
            timePrefab.TabIndex = 2;
            timePrefab.Text = "8:00\r\n8:50";
            timePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeTableView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(lCourseList);
            Controls.Add(cbOpen);
            Controls.Add(courseCont);
            Name = "TimeTableView";
            Size = new System.Drawing.Size(1275, 684);
            courseCont.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lCourseList;
        private System.Windows.Forms.CheckBox cbOpen;
        private System.Windows.Forms.Label lLoading;
        private System.Windows.Forms.Panel courseCont;
        private System.Windows.Forms.Button coursePrefab;
        private System.Windows.Forms.Label dayPrefab;
        private System.Windows.Forms.Label timePrefab;
    }
}
