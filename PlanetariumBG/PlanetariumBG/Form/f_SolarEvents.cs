/*
    MIT License
    
    Copyright (c) [2019] [Daniel Denev and Orlin Dimitrov]
    
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

using SpaceObjects.Data;
using SpaceObjects.SolarSystem;
using System;
using System.Collections;
using System.Drawing;
using System.Threading;

namespace Planetarium
{
    /// <summary>
    /// Summary description for f_SolarEvents.
    /// </summary>
    public class f_SolarEvents : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pB_Space;
        private System.Windows.Forms.Panel p_mainPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton r_SolarEclipse;
        private System.Windows.Forms.RadioButton r_MercuryTranzit;
        private System.Windows.Forms.RadioButton r_VenusTranzit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nUD_From;
        private System.Windows.Forms.NumericUpDown nUD_To;
        private System.Windows.Forms.ListBox lB_Result;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button b_Watch;
        private System.Windows.Forms.Label l_Progress;
        private System.Windows.Forms.Button b_Search;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label l_labelProg;
        private System.Windows.Forms.RadioButton r_LunarEclipse;
        private System.ComponentModel.IContainer components;

        public f_SolarEvents()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(f_SolarEvents));
            this.pB_Space = new System.Windows.Forms.PictureBox();
            this.p_mainPanel = new System.Windows.Forms.Panel();
            this.l_labelProg = new System.Windows.Forms.Label();
            this.l_Progress = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nUD_To = new System.Windows.Forms.NumericUpDown();
            this.nUD_From = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.r_LunarEclipse = new System.Windows.Forms.RadioButton();
            this.r_VenusTranzit = new System.Windows.Forms.RadioButton();
            this.r_MercuryTranzit = new System.Windows.Forms.RadioButton();
            this.r_SolarEclipse = new System.Windows.Forms.RadioButton();
            this.b_Search = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lB_Result = new System.Windows.Forms.ListBox();
            this.b_Watch = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.p_mainPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_To)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_From)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pB_Space
            // 
            this.pB_Space.BackColor = System.Drawing.Color.Black;
            this.pB_Space.Dock = System.Windows.Forms.DockStyle.Right;
            this.pB_Space.Location = new System.Drawing.Point(362, 0);
            this.pB_Space.Name = "pB_Space";
            this.pB_Space.Size = new System.Drawing.Size(376, 736);
            this.pB_Space.TabIndex = 0;
            this.pB_Space.TabStop = false;
            this.pB_Space.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Space_Paint);
            // 
            // p_mainPanel
            // 
            this.p_mainPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.p_mainPanel.Controls.Add(this.l_labelProg);
            this.p_mainPanel.Controls.Add(this.l_Progress);
            this.p_mainPanel.Controls.Add(this.groupBox2);
            this.p_mainPanel.Controls.Add(this.groupBox1);
            this.p_mainPanel.Controls.Add(this.b_Search);
            this.p_mainPanel.Controls.Add(this.groupBox4);
            this.p_mainPanel.Location = new System.Drawing.Point(10, 10);
            this.p_mainPanel.Name = "p_mainPanel";
            this.p_mainPanel.Size = new System.Drawing.Size(186, 526);
            this.p_mainPanel.TabIndex = 1;
            // 
            // l_labelProg
            // 
            this.l_labelProg.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.l_labelProg.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.l_labelProg.Location = new System.Drawing.Point(13, 285);
            this.l_labelProg.Name = "l_labelProg";
            this.l_labelProg.Size = new System.Drawing.Size(55, 19);
            this.l_labelProg.TabIndex = 6;
            this.l_labelProg.Text = "Progress :";
            this.l_labelProg.Visible = false;
            // 
            // l_Progress
            // 
            this.l_Progress.BackColor = System.Drawing.Color.White;
            this.l_Progress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.l_Progress.Location = new System.Drawing.Point(75, 280);
            this.l_Progress.Name = "l_Progress";
            this.l_Progress.TabIndex = 5;
            this.l_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Progress.Paint += new System.Windows.Forms.PaintEventHandler(this.l_Progress_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nUD_To);
            this.groupBox2.Controls.Add(this.nUD_From);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(8, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 88);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Span";
            // 
            // nUD_To
            // 
            this.nUD_To.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.nUD_To.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUD_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.nUD_To.Location = new System.Drawing.Point(88, 57);
            this.nUD_To.Maximum = new System.Decimal(new int[] {
                                                                   2100,
                                                                   0,
                                                                   0,
                                                                   0});
            this.nUD_To.Minimum = new System.Decimal(new int[] {
                                                                   1901,
                                                                   0,
                                                                   0,
                                                                   0});
            this.nUD_To.Name = "nUD_To";
            this.nUD_To.Size = new System.Drawing.Size(58, 13);
            this.nUD_To.TabIndex = 4;
            this.nUD_To.Value = new System.Decimal(new int[] {
                                                                 2001,
                                                                 0,
                                                                 0,
                                                                 0});
            this.nUD_To.ValueChanged += new System.EventHandler(this.nUD_To_ValueChanged);
            // 
            // nUD_From
            // 
            this.nUD_From.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.nUD_From.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUD_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.nUD_From.Location = new System.Drawing.Point(88, 28);
            this.nUD_From.Maximum = new System.Decimal(new int[] {
                                                                     2099,
                                                                     0,
                                                                     0,
                                                                     0});
            this.nUD_From.Minimum = new System.Decimal(new int[] {
                                                                     1900,
                                                                     0,
                                                                     0,
                                                                     0});
            this.nUD_From.Name = "nUD_From";
            this.nUD_From.Size = new System.Drawing.Size(57, 13);
            this.nUD_From.TabIndex = 3;
            this.nUD_From.Value = new System.Decimal(new int[] {
                                                                   2000,
                                                                   0,
                                                                   0,
                                                                   0});
            this.nUD_From.ValueChanged += new System.EventHandler(this.nUD_From_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "From :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "To :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.r_LunarEclipse);
            this.groupBox1.Controls.Add(this.r_VenusTranzit);
            this.groupBox1.Controls.Add(this.r_MercuryTranzit);
            this.groupBox1.Controls.Add(this.r_SolarEclipse);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solar Event";
            // 
            // r_LunarEclipse
            // 
            this.r_LunarEclipse.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.r_LunarEclipse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.r_LunarEclipse.Location = new System.Drawing.Point(24, 56);
            this.r_LunarEclipse.Name = "r_LunarEclipse";
            this.r_LunarEclipse.TabIndex = 3;
            this.r_LunarEclipse.Text = "Lunar eclipse";
            // 
            // r_VenusTranzit
            // 
            this.r_VenusTranzit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.r_VenusTranzit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.r_VenusTranzit.Location = new System.Drawing.Point(24, 120);
            this.r_VenusTranzit.Name = "r_VenusTranzit";
            this.r_VenusTranzit.TabIndex = 2;
            this.r_VenusTranzit.Text = "Venus Tranzit";
            this.r_VenusTranzit.CheckedChanged += new System.EventHandler(this.r_VenusTranzit_CheckedChanged);
            // 
            // r_MercuryTranzit
            // 
            this.r_MercuryTranzit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.r_MercuryTranzit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.r_MercuryTranzit.Location = new System.Drawing.Point(24, 88);
            this.r_MercuryTranzit.Name = "r_MercuryTranzit";
            this.r_MercuryTranzit.Size = new System.Drawing.Size(112, 24);
            this.r_MercuryTranzit.TabIndex = 1;
            this.r_MercuryTranzit.Text = "Mercury Tranzit";
            this.r_MercuryTranzit.CheckedChanged += new System.EventHandler(this.r_MercuryTranzit_CheckedChanged);
            // 
            // r_SolarEclipse
            // 
            this.r_SolarEclipse.Checked = true;
            this.r_SolarEclipse.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.r_SolarEclipse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.r_SolarEclipse.Location = new System.Drawing.Point(24, 24);
            this.r_SolarEclipse.Name = "r_SolarEclipse";
            this.r_SolarEclipse.TabIndex = 0;
            this.r_SolarEclipse.TabStop = true;
            this.r_SolarEclipse.Text = "Solar Eclipse";
            this.r_SolarEclipse.CheckedChanged += new System.EventHandler(this.r_SolarEclipse_CheckedChanged);
            // 
            // b_Search
            // 
            this.b_Search.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.b_Search.Location = new System.Drawing.Point(10, 281);
            this.b_Search.Name = "b_Search";
            this.b_Search.Size = new System.Drawing.Size(56, 23);
            this.b_Search.TabIndex = 2;
            this.b_Search.Text = "Search";
            this.b_Search.Click += new System.EventHandler(this.b_Search_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lB_Result);
            this.groupBox4.Controls.Add(this.b_Watch);
            this.groupBox4.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(8, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 200);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search Result";
            // 
            // lB_Result
            // 
            this.lB_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.lB_Result.Location = new System.Drawing.Point(8, 24);
            this.lB_Result.Name = "lB_Result";
            this.lB_Result.Size = new System.Drawing.Size(150, 134);
            this.lB_Result.TabIndex = 4;
            this.lB_Result.SelectedIndexChanged += new System.EventHandler(this.lB_Result_SelectedIndexChanged);
            // 
            // b_Watch
            // 
            this.b_Watch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Watch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.b_Watch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_Watch.Location = new System.Drawing.Point(56, 167);
            this.b_Watch.Name = "b_Watch";
            this.b_Watch.Size = new System.Drawing.Size(56, 23);
            this.b_Watch.TabIndex = 7;
            this.b_Watch.Text = "Watch";
            this.b_Watch.Click += new System.EventHandler(this.b_Watch_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // f_SolarEvents
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
            this.ClientSize = new System.Drawing.Size(738, 736);
            this.Controls.Add(this.p_mainPanel);
            this.Controls.Add(this.pB_Space);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_SolarEvents";
            this.Text = "Solar Events";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.f_SolarEvents_Closing);
            this.Load += new System.EventHandler(this.f_SolarEvents_Load);
            this.p_mainPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_To)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_From)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void f_SolarEvents_Load(object sender, System.EventArgs e)
        {
            pB_Space.Width = this.ClientSize.Width - (p_mainPanel.Location.X + p_mainPanel.Width + 10);
            b_Watch.Visible = false;
            searchThread = new Thread(new ThreadStart(SearchFunc));
        }

        private void nUD_From_ValueChanged(object sender, System.EventArgs e)
        {
            if (nUD_From.Value >= nUD_To.Value)
                nUD_To.Value = nUD_From.Value + 1;
        }

        private void nUD_To_ValueChanged(object sender, System.EventArgs e)
        {
            if (nUD_From.Value >= nUD_To.Value)
                nUD_To.Value = nUD_From.Value + 1;
        }

        private void AddTime(string timeStep, double n)
        {
            switch (timeStep)
            {
                case "day":
                    location.MainDateTime = location.MainDateTime.AddDays(n);
                    break;
                case "hour":
                    location.MainDateTime = location.MainDateTime.AddHours(n);
                    break;
                case "minute":
                    location.MainDateTime = location.MainDateTime.AddMinutes(n);
                    break;
            }
        }

        private void SearchFunc()
        {

            if (r_SolarEclipse.Checked == true)
            {
                lB_Result.Items.Clear();
                dateList.Clear();
                NoEcl = 0;
                location.MainDateTime = new DateTime((int)nUD_From.Value, 1, 1);
                location.MainDateTime = location.MainDateTime.AddDays(-1);
                planetData.PlanetPositions();
                oldElong = planetData.SolarSystemObjects.GetObjectByName("Moon").elong;
                step = "day";
                while (location.MainDateTime.Year < (int)nUD_To.Value + 1)
                {
                    prog = ((location.MainDateTime.Year - (int)nUD_From.Value) * 100) / ((int)nUD_To.Value - (int)nUD_From.Value);
                    l_Progress.Invalidate();
                    AddTime(step, 1);
                    planetData.PlanetPositions();
                    newElong = planetData.SolarSystemObjects.GetObjectByName("Moon").elong;
                    if (newElong < 15 && newElong > 1) step = "hour";
                    if (newElong < 1) step = "minute";
                    if (step == "hour" && newElong > oldElong)
                    {
                        step = "day";
                        AddTime(step, 20);
                    }
                    if (step == "minute" && newElong > oldElong)
                    {
                        if (oldElong < (planetData.SolarSystemObjects.GetObjectByName("Moon").diam / 7200 + planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200))
                        {
                            AddTime(step, -1);
                            ++NoEcl;
                            lB_Result.Items.Add(NoEcl + ".   " + location.MainDateTime);
                            DateTime tempTime = new DateTime();
                            tempTime = location.MainDateTime;
                            dateList.Add(tempTime);
                            step = "day";
                            AddTime(step, 20);
                        }
                        else
                        {
                            step = "day";
                            AddTime(step, 20);
                        }
                    }
                    oldElong = newElong;
                }
                prog = 100;
                l_Progress.Invalidate();
                b_Search.Visible = true;
                l_labelProg.Visible = false;
                nUD_From.Enabled = true;
                nUD_To.Enabled = true;
                searchThread.Abort();
            }
            if (r_LunarEclipse.Checked == true)
            {
                lB_Result.Items.Clear();
                dateList.Clear();
                NoEcl = 0;
                location.MainDateTime = new DateTime((int)nUD_From.Value, 1, 1);
                location.MainDateTime = location.MainDateTime.AddDays(-1);
                planetData.PlanetPositions();
                oldElong = planetData.SolarSystemObjects.GetObjectByName("Moon").elong;
                step = "day";
                while (location.MainDateTime.Year < (int)nUD_To.Value + 1)
                {
                    prog = ((location.MainDateTime.Year - (int)nUD_From.Value) * 100) / ((int)nUD_To.Value - (int)nUD_From.Value);
                    l_Progress.Invalidate();
                    AddTime(step, 1);
                    planetData.PlanetPositions();
                    newElong = planetData.SolarSystemObjects.GetObjectByName("Moon").elong;
                    if (newElong > 165 && newElong < 179) step = "hour";
                    if (newElong > 179) step = "minute";
                    if (step == "hour" && newElong < oldElong)
                    {
                        step = "day";
                        AddTime(step, 20);
                    }
                    if (step == "minute" && newElong < oldElong)
                    {
                        double RZ = 6378.140;
                        double RS = 696000;
                        double dS = planetData.SolarSystemObjects.GetObjectByName("Sun").dist * 1.49597870E8;
                        double dM = planetData.SolarSystemObjects.GetObjectByName("Moon").dist * 1.49597870E8;
                        double RES = (RZ + RS) * (dS + dM) / dS - RS;
                        planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam = 7200 * Math.Atan(RES / dM) * 180 / Math.PI;

                        if (oldElong > 180 - (planetData.SolarSystemObjects.GetObjectByName("Moon").diam / 7200 + planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam / 7200))
                        {
                            AddTime(step, -1);
                            ++NoEcl;
                            lB_Result.Items.Add(NoEcl + ".   " + location.MainDateTime);
                            DateTime tempTime = new DateTime();
                            tempTime = location.MainDateTime;
                            dateList.Add(tempTime);
                            step = "day";
                            AddTime(step, 20);
                        }
                        else
                        {
                            step = "day";
                            AddTime(step, 20);
                        }
                    }
                    oldElong = newElong;
                }
                prog = 100;
                l_Progress.Invalidate();
                b_Search.Visible = true;
                l_labelProg.Visible = false;
                nUD_From.Enabled = true;
                nUD_To.Enabled = true;
                searchThread.Abort();
            }
            if (r_MercuryTranzit.Checked == true)
            {
                lB_Result.Items.Clear();
                dateList.Clear();
                NoEcl = 0;
                location.MainDateTime = new DateTime((int)nUD_From.Value, 1, 1);
                location.MainDateTime = location.MainDateTime.AddDays(-1);
                planetData.PlanetPositions();
                oldElong = planetData.SolarSystemObjects.GetObjectByName("Mercury").elong;
                step = "day";
                while (location.MainDateTime.Year < (int)nUD_To.Value + 1)
                {
                    prog = ((location.MainDateTime.Year - (int)nUD_From.Value) * 100) / ((int)nUD_To.Value - (int)nUD_From.Value);
                    l_Progress.Invalidate();
                    AddTime(step, 1);
                    planetData.PlanetPositions();
                    newElong = planetData.SolarSystemObjects.GetObjectByName("Mercury").elong;
                    if (newElong < 2) step = "hour";
                    if (newElong < 0.4) step = "minute";
                    if (step == "hour" && newElong > oldElong)
                    {
                        step = "day";
                        AddTime(step, 20);
                    }
                    if (step == "minute" && newElong > oldElong)
                    {
                        if (oldElong < (planetData.SolarSystemObjects.GetObjectByName("Mercury").diam / 7200 + planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200))
                        {
                            if (planetData.SolarSystemObjects.GetObjectByName("Mercury").dist < planetData.SolarSystemObjects.GetObjectByName("Sun").dist)
                            {
                                AddTime(step, -1);
                                ++NoEcl;
                                lB_Result.Items.Add(NoEcl + ".  " + location.MainDateTime);
                                DateTime tempTime = new DateTime();
                                tempTime = location.MainDateTime;
                                dateList.Add(tempTime);
                            }
                            step = "day";
                            AddTime(step, 90);
                        }
                        else
                        {
                            step = "day";
                            AddTime(step, 90);
                        }
                    }
                    oldElong = newElong;
                }
                prog = 100;
                l_Progress.Invalidate();
                b_Search.Visible = true;
                l_labelProg.Visible = false;
                nUD_From.Enabled = true;
                nUD_To.Enabled = true;
                searchThread.Abort();
            }
            if (r_VenusTranzit.Checked == true)
            {
                lB_Result.Items.Clear();
                dateList.Clear();
                NoEcl = 0;
                location.MainDateTime = new DateTime((int)nUD_From.Value, 1, 1);
                location.MainDateTime = location.MainDateTime.AddDays(-1);
                planetData.PlanetPositions();
                oldElong = planetData.SolarSystemObjects.GetObjectByName("Venus").elong;
                step = "day";
                while (location.MainDateTime.Year < (int)nUD_To.Value + 1)
                {
                    prog = ((location.MainDateTime.Year - (int)nUD_From.Value) * 100) / ((int)nUD_To.Value - (int)nUD_From.Value);
                    l_Progress.Invalidate();
                    AddTime(step, 1);
                    planetData.PlanetPositions();
                    newElong = planetData.SolarSystemObjects.GetObjectByName("Venus").elong;
                    if (newElong < 2) step = "hour";
                    if (newElong < 0.4) step = "minute";
                    if (step == "hour" && newElong > oldElong)
                    {
                        step = "day";
                        AddTime(step, 20);
                    }
                    if (step == "minute" && newElong > oldElong)
                    {
                        if (oldElong < (planetData.SolarSystemObjects.GetObjectByName("Venus").diam / 7200 + planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200))
                        {
                            if (planetData.SolarSystemObjects.GetObjectByName("Venus").dist < planetData.SolarSystemObjects.GetObjectByName("Sun").dist)
                            {
                                AddTime(step, -1);
                                ++NoEcl;
                                lB_Result.Items.Add(NoEcl + ".  " + location.MainDateTime);
                                DateTime tempTime = new DateTime();
                                tempTime = location.MainDateTime;
                                dateList.Add(tempTime);
                            }
                            step = "day";
                            AddTime(step, 200);
                        }
                        else
                        {
                            step = "day";
                            AddTime(step, 200);
                        }
                    }
                    oldElong = newElong;
                }
                prog = 100;
                l_Progress.Invalidate();
                b_Search.Visible = true;
                l_labelProg.Visible = false;
                nUD_From.Enabled = true;
                nUD_To.Enabled = true;
                searchThread.Abort();
            }
        }

        private void b_Search_Click(object sender, System.EventArgs e)
        {
            nUD_From.Enabled = false;
            nUD_To.Enabled = false;
            timer1.Stop();
            prog = 0;
            b_Watch.Visible = false;
            b_Search.Visible = false;
            l_labelProg.Visible = true;
            searchThread = new Thread(new ThreadStart(SearchFunc));
            searchThread.Start();
        }

        private void lB_Result_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (prog == 100)
            {
                timer1.Stop();
                DateTime tempTime = new DateTime();
                tempTime = (DateTime)dateList[lB_Result.SelectedIndex];
                location.MainDateTime = tempTime;
                planetData.PlanetPositions();
                pB_Space.Invalidate();
                b_Watch.Visible = true;
            }
        }

        private void pB_Space_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (r_LunarEclipse.Checked == true)
            {
                planetData.SolarSystemObjects.GetObjectByName("Earth shadow").SkyPosition.eqToaA(location.SIDTIME, location.Latitude);
                if (planetData.SolarSystemObjects.GetObjectByName("Earth shadow").SkyPosition.a < 0)
                    g.DrawString("Not visible !", new Font("Arial", 12),
                        new SolidBrush(Color.Red), 10, 10);
                g.DrawString(location.MainDateTime.ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.White), 10, 30);
                g.DrawLine(new Pen(Color.DarkGray), pB_Space.Width / 2, 0, pB_Space.Width / 2, pB_Space.Height);
                g.DrawLine(new Pen(Color.DarkGray), 0, pB_Space.Height / 2, pB_Space.Width, pB_Space.Height / 2);

                double tempRA = planetData.SolarSystemObjects.GetObjectByName("Earth shadow").SkyPosition.Rectascence - planetData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Rectascence;
                if (tempRA > 300) tempRA -= 360;
                double dx = (tempRA * pB_Space.Width / 3) / (planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam / 7200);
                double dy = ((planetData.SolarSystemObjects.GetObjectByName("Earth shadow").SkyPosition.Decl - planetData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl) * pB_Space.Width / 3) / (planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam / 7200);
                double DMM = (((EarthShadow)planetData.SolarSystemObjects.GetObjectByName("Earth shadow")).DU * pB_Space.Width / 1.5) / ((EarthShadow)planetData.SolarSystemObjects.GetObjectByName("Earth shadow")).DP;
                double DM = (planetData.SolarSystemObjects.GetObjectByName("Moon").diam * pB_Space.Width / 1.5) / planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam;
                g.FillEllipse(new SolidBrush(Color.DarkSlateGray),
                    pB_Space.Width / 2 + (int)dx - (int)DM / 2, pB_Space.Height / 2 - (int)dy - (int)DM / 2, (int)DM, (int)DM);
                g.FillEllipse(new SolidBrush(Color.FromArgb(85, 50, 50, 50)),
                    pB_Space.Width / 2 - pB_Space.Width / 3, pB_Space.Height / 2 - pB_Space.Width / 3,
                    (float)(pB_Space.Width / 1.5), (float)(pB_Space.Width / 1.5));
                g.FillEllipse(new SolidBrush(Color.FromArgb(85, 80, 0, 0)),
                    (float)(pB_Space.Width / 2 - DMM / 2), (float)(pB_Space.Height / 2 - DMM / 2), (float)DMM, (float)DMM);

                g.DrawString("Rectascence : " + Math.Round(planetData.SolarSystemObjects.GetObjectByName("Earth shadow").SkyPosition.Rectascence, 3).ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.DarkGray), pB_Space.Width / 2 + 10, 30);
                g.DrawString("Decl : " + Math.Round(planetData.SolarSystemObjects.GetObjectByName("Earth shadow").SkyPosition.Decl, 3).ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.DarkGray), 15, pB_Space.Height / 2 + 15);
            }
            else
            {
                planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.eqToaA(location.SIDTIME, location.Latitude);
                if (planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.a < 0)
                    g.DrawString("Not visible !", new Font("Arial", 12),
                        new SolidBrush(Color.Red), 10, 10);
                g.DrawString(location.MainDateTime.ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.White), 10, 30);

                g.DrawLine(new Pen(Color.Yellow), pB_Space.Width / 2, 0, pB_Space.Width / 2, pB_Space.Height);
                g.DrawLine(new Pen(Color.Yellow), 0, pB_Space.Height / 2, pB_Space.Width, pB_Space.Height / 2);

                if (r_SolarEclipse.Checked == true)
                {
                    g.FillEllipse(new SolidBrush(Color.Yellow),
                        pB_Space.Width / 2 - pB_Space.Width / 8, pB_Space.Height / 2 - pB_Space.Width / 8,
                        pB_Space.Width / 4, pB_Space.Width / 4);

                    double tempRA = planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Rectascence - planetData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Rectascence;
                    if (tempRA > 300) tempRA -= 360;
                    double dx = (tempRA * pB_Space.Width / 8) /
                        (planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200);
                    double dy = ((planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Decl - planetData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl) * pB_Space.Width / 8) /
                        (planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200);
                    double DM = (planetData.SolarSystemObjects.GetObjectByName("Moon").diam * pB_Space.Width / 4) / planetData.SolarSystemObjects.GetObjectByName("Sun").diam;
                    g.FillEllipse(new SolidBrush(Color.DarkSlateGray),
                        pB_Space.Width / 2 + (int)dx - (int)DM / 2, pB_Space.Height / 2 - (int)dy - (int)DM / 2, (int)DM, (int)DM);
                }
                if (r_MercuryTranzit.Checked == true)
                {
                    g.FillEllipse(new SolidBrush(Color.Yellow),
                        pB_Space.Width / 2 - pB_Space.Width / 4, pB_Space.Height / 2 - pB_Space.Width / 4,
                        pB_Space.Width / 2, pB_Space.Width / 2);
                    g.DrawString("Mercury enlarged !", new Font("Arial", 12),
                        new SolidBrush(Color.Yellow), 12, pB_Space.Height - 50);

                    double tempRA = planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Rectascence - planetData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Rectascence;
                    if (tempRA > 300) tempRA -= 360;
                    double dx = (tempRA * pB_Space.Width / 4) /
                        (planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200);
                    double dy = ((planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Decl - planetData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl) * pB_Space.Width / 4) /
                        (planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200);
                    double DM = 6;
                    g.FillEllipse(new SolidBrush(Color.DarkSlateGray),
                        pB_Space.Width / 2 + (int)dx - (int)DM / 2, pB_Space.Height / 2 - (int)dy - (int)DM / 2, (int)DM, (int)DM);
                }
                if (r_VenusTranzit.Checked == true)
                {
                    g.FillEllipse(new SolidBrush(Color.Yellow),
                        pB_Space.Width / 2 - pB_Space.Width / 4, pB_Space.Height / 2 - pB_Space.Width / 4,
                        pB_Space.Width / 2, pB_Space.Width / 2);

                    double tempRA = planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Rectascence - planetData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Rectascence;
                    if (tempRA > 300) tempRA -= 360;
                    double dx = (tempRA * pB_Space.Width / 4) /
                        (planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200);
                    double dy = ((planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Decl - planetData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl) * pB_Space.Width / 4) /
                        (planetData.SolarSystemObjects.GetObjectByName("Sun").diam / 7200);
                    double DM = (planetData.SolarSystemObjects.GetObjectByName("Venus").diam * pB_Space.Width / 2) / planetData.SolarSystemObjects.GetObjectByName("Sun").diam;
                    g.FillEllipse(new SolidBrush(Color.DarkSlateGray),
                        pB_Space.Width / 2 + (int)dx - (int)DM / 2, pB_Space.Height / 2 - (int)dy - (int)DM / 2, (int)DM, (int)DM);
                }

                g.DrawString("Rectascence : " + Math.Round(planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Rectascence, 3).ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.Yellow), pB_Space.Width / 2 + 10, 30);
                g.DrawString("Decl : " + Math.Round(planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Decl, 3).ToString(), new Font("Arial", 10),
                    new SolidBrush(Color.Yellow), 15, pB_Space.Height / 2 + 15);
            }
        }

        private void b_Watch_Click(object sender, System.EventArgs e)
        {
            if (r_SolarEclipse.Checked == true)
                location.MainDateTime = ((DateTime)dateList[lB_Result.SelectedIndex]).AddMinutes(-90);
            if (r_LunarEclipse.Checked == true)
                location.MainDateTime = ((DateTime)dateList[lB_Result.SelectedIndex]).AddMinutes(-200);
            if (r_MercuryTranzit.Checked == true)
                location.MainDateTime = ((DateTime)dateList[lB_Result.SelectedIndex]).AddHours(-5);
            if (r_VenusTranzit.Checked == true)
                location.MainDateTime = ((DateTime)dateList[lB_Result.SelectedIndex]).AddHours(-5);
            n = 0;
            b_Watch.Visible = false;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (r_SolarEclipse.Checked == true)
            {
                if (++n > 180)
                {
                    timer1.Stop();
                    b_Watch.Visible = true;
                }
            }
            if (r_LunarEclipse.Checked == true)
            {
                if (++n > 400)
                {
                    timer1.Stop();
                    b_Watch.Visible = true;
                }
            }
            if (r_MercuryTranzit.Checked == true)
            {
                if (++n > 600)
                {
                    timer1.Stop();
                    b_Watch.Visible = true;
                }
            }
            if (r_VenusTranzit.Checked == true)
            {
                if (++n > 600)
                {
                    timer1.Stop();
                    b_Watch.Visible = true;
                }
            }
            location.MainDateTime = location.MainDateTime.AddMinutes(1);
            planetData.PlanetPositions();
            pB_Space.Invalidate();
        }

        private void r_SolarEclipse_CheckedChanged(object sender, System.EventArgs e)
        {
            if (searchThread.IsAlive == true)
                searchThread.Abort();
            b_Watch.Visible = false;
            dateList.Clear();
            lB_Result.Items.Clear();
            timer1.Stop();
            prog = 0;
            l_Progress.Invalidate();
            pB_Space.Invalidate();
            b_Search.Visible = true;
            l_labelProg.Visible = false;
            nUD_From.Enabled = true;
            nUD_To.Enabled = true;
        }

        private void r_MercuryTranzit_CheckedChanged(object sender, System.EventArgs e)
        {
            if (searchThread.IsAlive == true)
                searchThread.Abort();
            b_Watch.Visible = false;
            dateList.Clear();
            lB_Result.Items.Clear();
            timer1.Stop();
            prog = 0;
            l_Progress.Invalidate();
            pB_Space.Invalidate();
            b_Search.Visible = true;
            l_labelProg.Visible = false;
            nUD_From.Enabled = true;
            nUD_To.Enabled = true;
        }

        private void r_VenusTranzit_CheckedChanged(object sender, System.EventArgs e)
        {
            if (searchThread.IsAlive == true)
                searchThread.Abort();
            b_Watch.Visible = false;
            dateList.Clear();
            lB_Result.Items.Clear();
            timer1.Stop();
            prog = 0;
            l_Progress.Invalidate();
            pB_Space.Invalidate();
            b_Search.Visible = true;
            l_labelProg.Visible = false;
            nUD_From.Enabled = true;
            nUD_To.Enabled = true;
        }

        private void l_Progress_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.SteelBlue), 0, 0, prog, l_Progress.Height);
            e.Graphics.DrawString(prog.ToString() + " %", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), 35, 3);
        }

        private void f_SolarEvents_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (searchThread.IsAlive == true)
                searchThread.Abort();
        }

        private Thread searchThread;
        private LocationST location = LocationST.GetInstance();
        private SolarSystemData planetData = SolarSystemData.GetInstance();
        private double oldElong, newElong;
        private string step;
        private ArrayList dateList = new ArrayList();
        private int n, NoEcl;
        private int prog;
    }
}
