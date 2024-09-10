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
            panel2 = new System.Windows.Forms.Panel();
            bUpdateAction = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            cbChannel = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            lUpdateStatus = new System.Windows.Forms.Label();
            pbarUpdate = new System.Windows.Forms.ProgressBar();
            panelMainLayout.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainLayout
            // 
            panelMainLayout.Controls.Add(label1);
            panelMainLayout.Controls.Add(cbHighlight);
            panelMainLayout.Controls.Add(cbCodes);
            panelMainLayout.Controls.Add(cbOpen);
            panelMainLayout.Controls.Add(panel2);
            panelMainLayout.Controls.Add(panel1);
            panelMainLayout.Controls.Add(lUpdateStatus);
            panelMainLayout.Controls.Add(pbarUpdate);
            panelMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            panelMainLayout.Location = new System.Drawing.Point(0, 0);
            panelMainLayout.Name = "panelMainLayout";
            panelMainLayout.Size = new System.Drawing.Size(749, 587);
            panelMainLayout.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 16F);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(212, 30);
            label1.TabIndex = 0;
            label1.Text = "Time Table Settings";
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
            // panel2
            // 
            panel2.Controls.Add(bUpdateAction);
            panel2.Controls.Add(label3);
            panel2.Location = new System.Drawing.Point(0, 201);
            panel2.Margin = new System.Windows.Forms.Padding(0, 32, 3, 24);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(514, 38);
            panel2.TabIndex = 8;
            // 
            // bUpdateAction
            // 
            bUpdateAction.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            bUpdateAction.FlatAppearance.BorderSize = 0;
            bUpdateAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            panel1.Location = new System.Drawing.Point(0, 266);
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
            lUpdateStatus.Location = new System.Drawing.Point(3, 309);
            lUpdateStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            lUpdateStatus.Name = "lUpdateStatus";
            lUpdateStatus.Size = new System.Drawing.Size(190, 21);
            lUpdateStatus.TabIndex = 6;
            lUpdateStatus.Text = "A new update is available!";
            // 
            // pbarUpdate
            // 
            pbarUpdate.Location = new System.Drawing.Point(3, 347);
            pbarUpdate.MarqueeAnimationSpeed = 30;
            pbarUpdate.Name = "pbarUpdate";
            pbarUpdate.Size = new System.Drawing.Size(508, 22);
            pbarUpdate.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            pbarUpdate.TabIndex = 7;
            pbarUpdate.Value = 50;
            // 
            // SettingsView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(panelMainLayout);
            Name = "SettingsView";
            Size = new System.Drawing.Size(749, 587);
            panelMainLayout.ResumeLayout(false);
            panelMainLayout.PerformLayout();
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
    }
}
