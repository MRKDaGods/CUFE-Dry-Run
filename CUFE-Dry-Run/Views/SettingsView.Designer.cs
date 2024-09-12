namespace MRK.Views
{
    partial class SettingsView
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
            panelMainLayout = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            cbHighlight = new System.Windows.Forms.CheckBox();
            cbCodes = new System.Windows.Forms.CheckBox();
            cbOpen = new System.Windows.Forms.CheckBox();
            cbWrap = new System.Windows.Forms.CheckBox();
            panel3 = new System.Windows.Forms.Panel();
            cbDaysPerRow = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            bUpdateAction = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            cbChannel = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            lUpdateStatus = new System.Windows.Forms.Label();
            pbarUpdate = new System.Windows.Forms.ProgressBar();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            panelMainLayout.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainLayout
            // 
            panelMainLayout.AutoScroll = true;
            panelMainLayout.Controls.Add(label1);
            panelMainLayout.Controls.Add(cbHighlight);
            panelMainLayout.Controls.Add(cbCodes);
            panelMainLayout.Controls.Add(cbOpen);
            panelMainLayout.Controls.Add(cbWrap);
            panelMainLayout.Controls.Add(panel3);
            panelMainLayout.Controls.Add(panel2);
            panelMainLayout.Controls.Add(panel1);
            panelMainLayout.Controls.Add(lUpdateStatus);
            panelMainLayout.Controls.Add(pbarUpdate);
            panelMainLayout.Controls.Add(label5);
            panelMainLayout.Controls.Add(label6);
            panelMainLayout.Controls.Add(label8);
            panelMainLayout.Controls.Add(label7);
            panelMainLayout.Controls.Add(label9);
            panelMainLayout.Controls.Add(label10);
            panelMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            panelMainLayout.Location = new System.Drawing.Point(0, 0);
            panelMainLayout.Name = "panelMainLayout";
            panelMainLayout.Size = new System.Drawing.Size(749, 705);
            panelMainLayout.TabIndex = 0;
            panelMainLayout.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 16F);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(123, 30);
            label1.TabIndex = 0;
            label1.Text = "Time Table";
            // 
            // cbHighlight
            // 
            cbHighlight.AutoSize = true;
            cbHighlight.Font = new System.Drawing.Font("Segoe UI", 12F);
            cbHighlight.ForeColor = System.Drawing.Color.White;
            cbHighlight.Location = new System.Drawing.Point(10, 46);
            cbHighlight.Margin = new System.Windows.Forms.Padding(10, 0, 3, 16);
            cbHighlight.Name = "cbHighlight";
            cbHighlight.Size = new System.Drawing.Size(216, 25);
            cbHighlight.TabIndex = 1;
            cbHighlight.Text = "Highlight courses on hover";
            cbHighlight.UseVisualStyleBackColor = true;
            // 
            // cbCodes
            // 
            cbCodes.AutoSize = true;
            cbCodes.Font = new System.Drawing.Font("Segoe UI", 12F);
            cbCodes.ForeColor = System.Drawing.Color.White;
            cbCodes.Location = new System.Drawing.Point(10, 87);
            cbCodes.Margin = new System.Windows.Forms.Padding(10, 0, 3, 16);
            cbCodes.Name = "cbCodes";
            cbCodes.Size = new System.Drawing.Size(296, 25);
            cbCodes.TabIndex = 2;
            cbCodes.Text = "Display course codes instead of names";
            cbCodes.UseVisualStyleBackColor = true;
            // 
            // cbOpen
            // 
            cbOpen.AutoSize = true;
            cbOpen.Font = new System.Drawing.Font("Segoe UI", 12F);
            cbOpen.ForeColor = System.Drawing.Color.White;
            cbOpen.Location = new System.Drawing.Point(10, 128);
            cbOpen.Margin = new System.Windows.Forms.Padding(10, 0, 3, 16);
            cbOpen.Name = "cbOpen";
            cbOpen.Size = new System.Drawing.Size(189, 25);
            cbOpen.TabIndex = 3;
            cbOpen.Text = "Display open slots only";
            cbOpen.UseVisualStyleBackColor = true;
            // 
            // cbWrap
            // 
            cbWrap.AutoSize = true;
            cbWrap.Font = new System.Drawing.Font("Segoe UI", 12F);
            cbWrap.ForeColor = System.Drawing.Color.White;
            cbWrap.Location = new System.Drawing.Point(10, 169);
            cbWrap.Margin = new System.Windows.Forms.Padding(10, 0, 3, 16);
            cbWrap.Name = "cbWrap";
            cbWrap.Size = new System.Drawing.Size(136, 25);
            cbWrap.TabIndex = 9;
            cbWrap.Text = "Wrap timetable";
            cbWrap.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(cbDaysPerRow);
            panel3.Controls.Add(label4);
            panel3.Location = new System.Drawing.Point(0, 210);
            panel3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(514, 27);
            panel3.TabIndex = 10;
            // 
            // cbDaysPerRow
            // 
            cbDaysPerRow.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            cbDaysPerRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDaysPerRow.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            cbDaysPerRow.ForeColor = System.Drawing.Color.White;
            cbDaysPerRow.FormattingEnabled = true;
            cbDaysPerRow.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cbDaysPerRow.Location = new System.Drawing.Point(380, 1);
            cbDaysPerRow.Name = "cbDaysPerRow";
            cbDaysPerRow.Size = new System.Drawing.Size(131, 25);
            cbDaysPerRow.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(5, 0);
            label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(102, 21);
            label4.TabIndex = 4;
            label4.Text = "Days per row";
            // 
            // panel2
            // 
            panel2.Controls.Add(bUpdateAction);
            panel2.Controls.Add(label3);
            panel2.Location = new System.Drawing.Point(0, 285);
            panel2.Margin = new System.Windows.Forms.Padding(0, 48, 3, 24);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(514, 38);
            panel2.TabIndex = 8;
            // 
            // bUpdateAction
            // 
            bUpdateAction.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            bUpdateAction.FlatAppearance.BorderSize = 0;
            bUpdateAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bUpdateAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bUpdateAction.ForeColor = System.Drawing.Color.White;
            bUpdateAction.Location = new System.Drawing.Point(380, 3);
            bUpdateAction.Name = "bUpdateAction";
            bUpdateAction.Size = new System.Drawing.Size(131, 33);
            bUpdateAction.TabIndex = 6;
            bUpdateAction.Text = "Check for updates";
            bUpdateAction.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 16F);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(3, 0);
            label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 30);
            label3.TabIndex = 4;
            label3.Text = "Update";
            // 
            // panel1
            // 
            panel1.Controls.Add(cbChannel);
            panel1.Controls.Add(label2);
            panel1.Location = new System.Drawing.Point(0, 350);
            panel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 16);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(514, 27);
            panel1.TabIndex = 5;
            // 
            // cbChannel
            // 
            cbChannel.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbChannel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            cbChannel.ForeColor = System.Drawing.Color.White;
            cbChannel.FormattingEnabled = true;
            cbChannel.Items.AddRange(new object[] { "main", "dev" });
            cbChannel.Location = new System.Drawing.Point(380, 1);
            cbChannel.Name = "cbChannel";
            cbChannel.Size = new System.Drawing.Size(131, 25);
            cbChannel.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(5, 0);
            label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 21);
            label2.TabIndex = 4;
            label2.Text = "Channel";
            // 
            // lUpdateStatus
            // 
            lUpdateStatus.AutoSize = true;
            lUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            lUpdateStatus.ForeColor = System.Drawing.Color.White;
            lUpdateStatus.Location = new System.Drawing.Point(5, 393);
            lUpdateStatus.Margin = new System.Windows.Forms.Padding(5, 0, 3, 14);
            lUpdateStatus.Name = "lUpdateStatus";
            lUpdateStatus.Size = new System.Drawing.Size(190, 21);
            lUpdateStatus.TabIndex = 6;
            lUpdateStatus.Text = "A new update is available!";
            // 
            // pbarUpdate
            // 
            pbarUpdate.Location = new System.Drawing.Point(3, 431);
            pbarUpdate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            pbarUpdate.MarqueeAnimationSpeed = 30;
            pbarUpdate.Name = "pbarUpdate";
            pbarUpdate.Size = new System.Drawing.Size(508, 22);
            pbarUpdate.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            pbarUpdate.TabIndex = 7;
            pbarUpdate.Value = 50;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 16F);
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(3, 501);
            label5.Margin = new System.Windows.Forms.Padding(3, 48, 3, 16);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 30);
            label5.TabIndex = 11;
            label5.Text = "Tips";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            label6.ForeColor = System.Drawing.Color.White;
            label6.Location = new System.Drawing.Point(5, 547);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 3, 10);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(467, 19);
            label6.TabIndex = 12;
            label6.Text = "Window can be maximized/minimized by double clicking on the title bar";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            label8.ForeColor = System.Drawing.Color.White;
            label8.Location = new System.Drawing.Point(5, 576);
            label8.Margin = new System.Windows.Forms.Padding(5, 0, 3, 10);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(453, 19);
            label8.TabIndex = 12;
            label8.Text = "Window resize handle can be found at the bottom right of the window";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(5, 605);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 3, 10);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(627, 19);
            label7.TabIndex = 13;
            label7.Text = "Double clicking the status bar in the timetable view will copy the selected courses to the clipboard";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            label9.ForeColor = System.Drawing.Color.White;
            label9.Location = new System.Drawing.Point(5, 634);
            label9.Margin = new System.Windows.Forms.Padding(5, 0, 3, 10);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(529, 19);
            label9.TabIndex = 13;
            label9.Text = "If transparency effect is enabled, controls may not look well on bright backgrounds";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            label10.ForeColor = System.Drawing.Color.White;
            label10.Location = new System.Drawing.Point(5, 663);
            label10.Margin = new System.Windows.Forms.Padding(5, 0, 3, 10);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(438, 19);
            label10.TabIndex = 14;
            label10.Text = "Winforms limit transparency support, tearing and lagging may occur";
            // 
            // SettingsView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(panelMainLayout);
            Name = "SettingsView";
            Size = new System.Drawing.Size(749, 705);
            panelMainLayout.ResumeLayout(false);
            panelMainLayout.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelMainLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbHighlight;
        private System.Windows.Forms.CheckBox cbCodes;
        private System.Windows.Forms.CheckBox cbOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lUpdateStatus;
        private System.Windows.Forms.ProgressBar pbarUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bUpdateAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbChannel;
        private System.Windows.Forms.CheckBox cbWrap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbDaysPerRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}
