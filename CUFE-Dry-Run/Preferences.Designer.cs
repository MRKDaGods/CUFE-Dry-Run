﻿using System.Windows.Forms;

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
            this.lTitle = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.courseCont = new System.Windows.Forms.Panel();
            this.coursePrefab = new System.Windows.Forms.Panel();
            this.extraPrefab = new System.Windows.Forms.Label();
            this.namePrefab = new System.Windows.Forms.Label();
            this.codePrefab = new System.Windows.Forms.Label();
            this.cbPrefab = new System.Windows.Forms.CheckBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.bCmp = new System.Windows.Forms.Button();
            this.bMth = new System.Windows.Forms.Button();
            this.bGen = new System.Windows.Forms.Button();
            this.bClr = new System.Windows.Forms.Button();
            this.bEecs = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.courseCont.SuspendLayout();
            this.coursePrefab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Yu Gothic UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(41, 41);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(208, 32);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Course Preferences";
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bExit.ForeColor = System.Drawing.Color.White;
            this.bExit.Location = new System.Drawing.Point(636, 12);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(47, 34);
            this.bExit.TabIndex = 3;
            this.bExit.Text = "X";
            this.bExit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(41, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 32);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "CODE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(168, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "NAME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseCont
            // 
            this.courseCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courseCont.AutoScroll = true;
            this.courseCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.courseCont.Controls.Add(this.coursePrefab);
            this.courseCont.Location = new System.Drawing.Point(41, 168);
            this.courseCont.Name = "courseCont";
            this.courseCont.Size = new System.Drawing.Size(618, 652);
            this.courseCont.TabIndex = 5;
            // 
            // coursePrefab
            // 
            this.coursePrefab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coursePrefab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.coursePrefab.Controls.Add(this.extraPrefab);
            this.coursePrefab.Controls.Add(this.namePrefab);
            this.coursePrefab.Controls.Add(this.codePrefab);
            this.coursePrefab.Controls.Add(this.cbPrefab);
            this.coursePrefab.Location = new System.Drawing.Point(0, 3);
            this.coursePrefab.Name = "coursePrefab";
            this.coursePrefab.Size = new System.Drawing.Size(618, 58);
            this.coursePrefab.TabIndex = 0;
            // 
            // extraPrefab
            // 
            this.extraPrefab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extraPrefab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.extraPrefab.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.extraPrefab.ForeColor = System.Drawing.Color.White;
            this.extraPrefab.Location = new System.Drawing.Point(168, 35);
            this.extraPrefab.Name = "extraPrefab";
            this.extraPrefab.Size = new System.Drawing.Size(447, 23);
            this.extraPrefab.TabIndex = 6;
            this.extraPrefab.Text = "LEC (3)";
            this.extraPrefab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // namePrefab
            // 
            this.namePrefab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.namePrefab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.namePrefab.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.namePrefab.ForeColor = System.Drawing.Color.White;
            this.namePrefab.Location = new System.Drawing.Point(165, 6);
            this.namePrefab.Name = "namePrefab";
            this.namePrefab.Size = new System.Drawing.Size(436, 29);
            this.namePrefab.TabIndex = 5;
            this.namePrefab.Text = "Probability, Calc, etc";
            this.namePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // codePrefab
            // 
            this.codePrefab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.codePrefab.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.codePrefab.ForeColor = System.Drawing.Color.White;
            this.codePrefab.Location = new System.Drawing.Point(39, 6);
            this.codePrefab.Name = "codePrefab";
            this.codePrefab.Size = new System.Drawing.Size(120, 29);
            this.codePrefab.TabIndex = 5;
            this.codePrefab.Text = "MTHN100";
            this.codePrefab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPrefab
            // 
            this.cbPrefab.Location = new System.Drawing.Point(12, 14);
            this.cbPrefab.Name = "cbPrefab";
            this.cbPrefab.Size = new System.Drawing.Size(21, 14);
            this.cbPrefab.TabIndex = 0;
            this.cbPrefab.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.ForeColor = System.Drawing.Color.White;
            this.tbSearch.Location = new System.Drawing.Point(41, 104);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderText = "Search by code";
            this.tbSearch.Size = new System.Drawing.Size(551, 23);
            this.tbSearch.TabIndex = 6;
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSearch.FlatAppearance.BorderSize = 0;
            this.bSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bSearch.ForeColor = System.Drawing.Color.White;
            this.bSearch.Location = new System.Drawing.Point(598, 104);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(62, 23);
            this.bSearch.TabIndex = 7;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = false;
            // 
            // bCmp
            // 
            this.bCmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bCmp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bCmp.FlatAppearance.BorderSize = 0;
            this.bCmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCmp.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bCmp.ForeColor = System.Drawing.Color.White;
            this.bCmp.Location = new System.Drawing.Point(245, 826);
            this.bCmp.Name = "bCmp";
            this.bCmp.Size = new System.Drawing.Size(62, 23);
            this.bCmp.TabIndex = 7;
            this.bCmp.Text = "CMPS";
            this.bCmp.UseVisualStyleBackColor = false;
            // 
            // bMth
            // 
            this.bMth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bMth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bMth.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bMth.FlatAppearance.BorderSize = 0;
            this.bMth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMth.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bMth.ForeColor = System.Drawing.Color.White;
            this.bMth.Location = new System.Drawing.Point(177, 826);
            this.bMth.Name = "bMth";
            this.bMth.Size = new System.Drawing.Size(62, 23);
            this.bMth.TabIndex = 7;
            this.bMth.Text = "MTHS";
            this.bMth.UseVisualStyleBackColor = false;
            // 
            // bGen
            // 
            this.bGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bGen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bGen.FlatAppearance.BorderSize = 0;
            this.bGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bGen.ForeColor = System.Drawing.Color.White;
            this.bGen.Location = new System.Drawing.Point(109, 826);
            this.bGen.Name = "bGen";
            this.bGen.Size = new System.Drawing.Size(62, 23);
            this.bGen.TabIndex = 7;
            this.bGen.Text = "GENS";
            this.bGen.UseVisualStyleBackColor = false;
            // 
            // bClr
            // 
            this.bClr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bClr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bClr.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClr.FlatAppearance.BorderSize = 0;
            this.bClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClr.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bClr.ForeColor = System.Drawing.Color.White;
            this.bClr.Location = new System.Drawing.Point(41, 826);
            this.bClr.Name = "bClr";
            this.bClr.Size = new System.Drawing.Size(62, 23);
            this.bClr.TabIndex = 7;
            this.bClr.Text = "Clear";
            this.bClr.UseVisualStyleBackColor = false;
            // 
            // bEecs
            // 
            this.bEecs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEecs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bEecs.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bEecs.FlatAppearance.BorderSize = 0;
            this.bEecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEecs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bEecs.ForeColor = System.Drawing.Color.White;
            this.bEecs.Location = new System.Drawing.Point(313, 826);
            this.bEecs.Name = "bEecs";
            this.bEecs.Size = new System.Drawing.Size(62, 23);
            this.bEecs.TabIndex = 8;
            this.bEecs.Text = "EECS";
            this.bEecs.UseVisualStyleBackColor = false;
            // 
            // bUpdate
            // 
            this.bUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdate.FlatAppearance.BorderSize = 0;
            this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bUpdate.ForeColor = System.Drawing.Color.White;
            this.bUpdate.Location = new System.Drawing.Point(584, 826);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(76, 23);
            this.bUpdate.TabIndex = 9;
            this.bUpdate.Text = "Update";
            this.bUpdate.UseVisualStyleBackColor = false;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.ClientSize = new System.Drawing.Size(695, 869);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bEecs);
            this.Controls.Add(this.bClr);
            this.Controls.Add(this.bGen);
            this.Controls.Add(this.bMth);
            this.Controls.Add(this.bCmp);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.courseCont);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.lTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Preferences";
            this.Text = "CUFE Dry Run";
            this.panel1.ResumeLayout(false);
            this.courseCont.ResumeLayout(false);
            this.coursePrefab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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