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
            components = new System.ComponentModel.Container();
            lLoading = new System.Windows.Forms.Label();
            courseCont = new System.Windows.Forms.FlowLayoutPanel();
            containerPrefab = new System.Windows.Forms.Panel();
            dayPrefab = new System.Windows.Forms.Label();
            timePrefab = new System.Windows.Forms.Label();
            coursePrefab = new System.Windows.Forms.Button();
            tooltip = new System.Windows.Forms.ToolTip(components);
            courseCont.SuspendLayout();
            containerPrefab.SuspendLayout();
            SuspendLayout();
            // 
            // lLoading
            // 
            lLoading.BackColor = System.Drawing.Color.Transparent;
            lLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            lLoading.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 18F);
            lLoading.ForeColor = System.Drawing.Color.White;
            lLoading.Location = new System.Drawing.Point(0, 0);
            lLoading.Name = "lLoading";
            lLoading.Size = new System.Drawing.Size(1275, 684);
            lLoading.TabIndex = 9;
            lLoading.Text = "Loading courses...";
            lLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseCont
            // 
            courseCont.AutoScroll = true;
            courseCont.AutoScrollMargin = new System.Drawing.Size(10, 10);
            courseCont.BackColor = System.Drawing.Color.Transparent;
            courseCont.Controls.Add(containerPrefab);
            courseCont.Dock = System.Windows.Forms.DockStyle.Fill;
            courseCont.ForeColor = System.Drawing.Color.White;
            courseCont.Location = new System.Drawing.Point(0, 0);
            courseCont.Name = "courseCont";
            courseCont.Size = new System.Drawing.Size(1275, 684);
            courseCont.TabIndex = 10;
            // 
            // containerPrefab
            // 
            containerPrefab.Controls.Add(dayPrefab);
            containerPrefab.Controls.Add(timePrefab);
            containerPrefab.Controls.Add(coursePrefab);
            containerPrefab.Location = new System.Drawing.Point(3, 0);
            containerPrefab.Margin = new System.Windows.Forms.Padding(3, 0, 3, 24);
            containerPrefab.Name = "containerPrefab";
            containerPrefab.Size = new System.Drawing.Size(268, 170);
            containerPrefab.TabIndex = 10;
            // 
            // dayPrefab
            // 
            dayPrefab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dayPrefab.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dayPrefab.ForeColor = System.Drawing.Color.White;
            dayPrefab.Location = new System.Drawing.Point(3, 0);
            dayPrefab.Name = "dayPrefab";
            dayPrefab.Size = new System.Drawing.Size(158, 42);
            dayPrefab.TabIndex = 1;
            dayPrefab.Text = "Saturday";
            dayPrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timePrefab
            // 
            timePrefab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            timePrefab.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F);
            timePrefab.ForeColor = System.Drawing.Color.White;
            timePrefab.Location = new System.Drawing.Point(3, 42);
            timePrefab.Name = "timePrefab";
            timePrefab.Size = new System.Drawing.Size(95, 43);
            timePrefab.TabIndex = 2;
            timePrefab.Text = "8:00\r\n8:50";
            timePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coursePrefab
            // 
            coursePrefab.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            coursePrefab.FlatAppearance.BorderColor = System.Drawing.Color.White;
            coursePrefab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            coursePrefab.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F);
            coursePrefab.ForeColor = System.Drawing.Color.White;
            coursePrefab.Location = new System.Drawing.Point(3, 88);
            coursePrefab.Name = "coursePrefab";
            coursePrefab.Size = new System.Drawing.Size(95, 65);
            coursePrefab.TabIndex = 3;
            coursePrefab.Text = "MTHN102\r\nLEC G5";
            coursePrefab.UseVisualStyleBackColor = false;
            // 
            // TimeTableView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(lLoading);
            Controls.Add(courseCont);
            Name = "TimeTableView";
            Size = new System.Drawing.Size(1275, 684);
            courseCont.ResumeLayout(false);
            containerPrefab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lLoading;
        private System.Windows.Forms.FlowLayoutPanel courseCont;
        private System.Windows.Forms.Button coursePrefab;
        private System.Windows.Forms.Label dayPrefab;
        private System.Windows.Forms.Label timePrefab;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Panel containerPrefab;
    }
}
