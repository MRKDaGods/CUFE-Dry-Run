using System.Windows.Forms;

namespace MRK
{
    partial class Preferences
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lTitle = new Label();
            bExit = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            courseCont = new Panel();
            coursePrefab = new Panel();
            extraPrefab = new Label();
            namePrefab = new Label();
            codePrefab = new Label();
            cbPrefab = new CheckBox();
            tbSearch = new TextBox();
            bSearch = new Button();
            bCmp = new Button();
            bMth = new Button();
            bGen = new Button();
            bClr = new Button();
            bEecs = new Button();
            bUpdate = new Button();
            panel1.SuspendLayout();
            courseCont.SuspendLayout();
            coursePrefab.SuspendLayout();
            SuspendLayout();
            // 
            // lTitle
            // 
            lTitle.AutoSize = true;
            lTitle.Font = new System.Drawing.Font("Yu Gothic UI Light", 18F);
            lTitle.ForeColor = System.Drawing.Color.White;
            lTitle.Location = new System.Drawing.Point(41, 41);
            lTitle.Name = "lTitle";
            lTitle.Size = new System.Drawing.Size(208, 32);
            lTitle.TabIndex = 0;
            lTitle.Text = "Course Preferences";
            // 
            // bExit
            // 
            bExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bExit.FlatAppearance.BorderSize = 0;
            bExit.FlatStyle = FlatStyle.Flat;
            bExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            bExit.ForeColor = System.Drawing.Color.White;
            bExit.Location = new System.Drawing.Point(636, 12);
            bExit.Name = "bExit";
            bExit.Size = new System.Drawing.Size(47, 34);
            bExit.TabIndex = 3;
            bExit.Text = "X";
            bExit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new System.Drawing.Point(41, 133);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(618, 32);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(40, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(122, 29);
            label2.TabIndex = 5;
            label2.Text = "CODE";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(168, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(122, 29);
            label3.TabIndex = 5;
            label3.Text = "NAME";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseCont
            // 
            courseCont.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            courseCont.AutoScroll = true;
            courseCont.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            courseCont.Controls.Add(coursePrefab);
            courseCont.Location = new System.Drawing.Point(41, 168);
            courseCont.Name = "courseCont";
            courseCont.Size = new System.Drawing.Size(618, 652);
            courseCont.TabIndex = 5;
            // 
            // coursePrefab
            // 
            coursePrefab.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            coursePrefab.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            coursePrefab.Controls.Add(extraPrefab);
            coursePrefab.Controls.Add(namePrefab);
            coursePrefab.Controls.Add(codePrefab);
            coursePrefab.Controls.Add(cbPrefab);
            coursePrefab.Location = new System.Drawing.Point(0, 3);
            coursePrefab.Name = "coursePrefab";
            coursePrefab.Size = new System.Drawing.Size(618, 58);
            coursePrefab.TabIndex = 0;
            // 
            // extraPrefab
            // 
            extraPrefab.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            extraPrefab.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            extraPrefab.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            extraPrefab.ForeColor = System.Drawing.Color.White;
            extraPrefab.Location = new System.Drawing.Point(168, 35);
            extraPrefab.Name = "extraPrefab";
            extraPrefab.Size = new System.Drawing.Size(447, 23);
            extraPrefab.TabIndex = 6;
            extraPrefab.Text = "LEC (3)";
            extraPrefab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // namePrefab
            // 
            namePrefab.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            namePrefab.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            namePrefab.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            namePrefab.ForeColor = System.Drawing.Color.White;
            namePrefab.Location = new System.Drawing.Point(165, 6);
            namePrefab.Name = "namePrefab";
            namePrefab.Size = new System.Drawing.Size(436, 29);
            namePrefab.TabIndex = 5;
            namePrefab.Text = "Probability, Calc, etc";
            namePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codePrefab
            // 
            codePrefab.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            codePrefab.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            codePrefab.ForeColor = System.Drawing.Color.White;
            codePrefab.Location = new System.Drawing.Point(39, 6);
            codePrefab.Name = "codePrefab";
            codePrefab.Size = new System.Drawing.Size(120, 29);
            codePrefab.TabIndex = 5;
            codePrefab.Text = "MTHN100";
            codePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPrefab
            // 
            cbPrefab.Location = new System.Drawing.Point(12, 14);
            cbPrefab.Name = "cbPrefab";
            cbPrefab.Size = new System.Drawing.Size(21, 14);
            cbPrefab.TabIndex = 0;
            cbPrefab.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSearch.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            tbSearch.BorderStyle = BorderStyle.FixedSingle;
            tbSearch.ForeColor = System.Drawing.Color.White;
            tbSearch.Location = new System.Drawing.Point(41, 104);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search by code";
            tbSearch.Size = new System.Drawing.Size(551, 23);
            tbSearch.TabIndex = 6;
            // 
            // bSearch
            // 
            bSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bSearch.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bSearch.FlatAppearance.BorderSize = 0;
            bSearch.FlatStyle = FlatStyle.Flat;
            bSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bSearch.ForeColor = System.Drawing.Color.White;
            bSearch.Location = new System.Drawing.Point(598, 104);
            bSearch.Name = "bSearch";
            bSearch.Size = new System.Drawing.Size(62, 23);
            bSearch.TabIndex = 7;
            bSearch.Text = "Search";
            bSearch.UseVisualStyleBackColor = false;
            // 
            // bCmp
            // 
            bCmp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bCmp.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bCmp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bCmp.FlatAppearance.BorderSize = 0;
            bCmp.FlatStyle = FlatStyle.Flat;
            bCmp.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bCmp.ForeColor = System.Drawing.Color.White;
            bCmp.Location = new System.Drawing.Point(245, 826);
            bCmp.Name = "bCmp";
            bCmp.Size = new System.Drawing.Size(62, 23);
            bCmp.TabIndex = 7;
            bCmp.Text = "CMPS";
            bCmp.UseVisualStyleBackColor = false;
            // 
            // bMth
            // 
            bMth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bMth.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bMth.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bMth.FlatAppearance.BorderSize = 0;
            bMth.FlatStyle = FlatStyle.Flat;
            bMth.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bMth.ForeColor = System.Drawing.Color.White;
            bMth.Location = new System.Drawing.Point(177, 826);
            bMth.Name = "bMth";
            bMth.Size = new System.Drawing.Size(62, 23);
            bMth.TabIndex = 7;
            bMth.Text = "MTHS";
            bMth.UseVisualStyleBackColor = false;
            // 
            // bGen
            // 
            bGen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bGen.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bGen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bGen.FlatAppearance.BorderSize = 0;
            bGen.FlatStyle = FlatStyle.Flat;
            bGen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bGen.ForeColor = System.Drawing.Color.White;
            bGen.Location = new System.Drawing.Point(109, 826);
            bGen.Name = "bGen";
            bGen.Size = new System.Drawing.Size(62, 23);
            bGen.TabIndex = 7;
            bGen.Text = "GENS";
            bGen.UseVisualStyleBackColor = false;
            // 
            // bClr
            // 
            bClr.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bClr.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bClr.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bClr.FlatAppearance.BorderSize = 0;
            bClr.FlatStyle = FlatStyle.Flat;
            bClr.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bClr.ForeColor = System.Drawing.Color.White;
            bClr.Location = new System.Drawing.Point(41, 826);
            bClr.Name = "bClr";
            bClr.Size = new System.Drawing.Size(62, 23);
            bClr.TabIndex = 7;
            bClr.Text = "Clear";
            bClr.UseVisualStyleBackColor = false;
            // 
            // bEecs
            // 
            bEecs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bEecs.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bEecs.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bEecs.FlatAppearance.BorderSize = 0;
            bEecs.FlatStyle = FlatStyle.Flat;
            bEecs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bEecs.ForeColor = System.Drawing.Color.White;
            bEecs.Location = new System.Drawing.Point(313, 826);
            bEecs.Name = "bEecs";
            bEecs.Size = new System.Drawing.Size(62, 23);
            bEecs.TabIndex = 8;
            bEecs.Text = "EECS";
            bEecs.UseVisualStyleBackColor = false;
            // 
            // bUpdate
            // 
            bUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bUpdate.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            bUpdate.FlatAppearance.BorderSize = 0;
            bUpdate.FlatStyle = FlatStyle.Flat;
            bUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            bUpdate.ForeColor = System.Drawing.Color.White;
            bUpdate.Location = new System.Drawing.Point(584, 826);
            bUpdate.Name = "bUpdate";
            bUpdate.Size = new System.Drawing.Size(76, 23);
            bUpdate.TabIndex = 9;
            bUpdate.Text = "Update";
            bUpdate.UseVisualStyleBackColor = false;
            // 
            // Preferences
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            ClientSize = new System.Drawing.Size(695, 869);
            Controls.Add(bUpdate);
            Controls.Add(bEecs);
            Controls.Add(bClr);
            Controls.Add(bGen);
            Controls.Add(bMth);
            Controls.Add(bCmp);
            Controls.Add(bSearch);
            Controls.Add(tbSearch);
            Controls.Add(courseCont);
            Controls.Add(panel1);
            Controls.Add(bExit);
            Controls.Add(lTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Preferences";
            Text = "CUFE Dry Run";
            panel1.ResumeLayout(false);
            courseCont.ResumeLayout(false);
            coursePrefab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lTitle;
        private Button bExit;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Panel courseCont;
        private Panel coursePrefab;
        private CheckBox cbPrefab;
        private Label namePrefab;
        private Label codePrefab;
        private TextBox tbSearch;
        private Button bSearch;
        private Button bCmp;
        private Button bMth;
        private Button bGen;
        private Button bClr;
        private Button bEecs;
        private Label extraPrefab;
        private Button bUpdate;
    }
}