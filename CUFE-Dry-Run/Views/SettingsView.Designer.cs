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
            panelMainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainLayout
            // 
            panelMainLayout.Controls.Add(label1);
            panelMainLayout.Controls.Add(cbHighlight);
            panelMainLayout.Controls.Add(cbCodes);
            panelMainLayout.Controls.Add(cbOpen);
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
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelMainLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbHighlight;
        private System.Windows.Forms.CheckBox cbCodes;
        private System.Windows.Forms.CheckBox cbOpen;
    }
}
