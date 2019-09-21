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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Planetarium
{
    /// <summary>
    /// Summary description for f_SolarSystemView.
    /// </summary>
    public class f_SolarSystem : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button b_Step;
        private System.Windows.Forms.Button b_StartStop;
        private System.Windows.Forms.Button b_Now;
        private System.Windows.Forms.Button b_skipDe;
        private System.Windows.Forms.Button b_skipIn;
        private System.Windows.Forms.CheckBox c_Jupiter;
        private System.Windows.Forms.CheckBox c_Earth;
        private System.Windows.Forms.CheckBox c_Mars;
        private System.Windows.Forms.CheckBox c_Uranus;
        private System.Windows.Forms.CheckBox c_Mercury;
        private System.Windows.Forms.CheckBox c_Neptune;
        private System.Windows.Forms.CheckBox c_Saturn;
        private System.Windows.Forms.CheckBox c_Venus;
        private System.Windows.Forms.PictureBox pB_Space;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label l_skip;
        private System.Windows.Forms.CheckBox c_Pluto;
        private System.Windows.Forms.CheckBox c_Orbits;
        private System.Windows.Forms.Button b_tolDe;
        private System.Windows.Forms.Button b_tolIn;
        private System.Windows.Forms.Label l_deg;
        private System.Windows.Forms.Label l_TolNum;
        private System.Windows.Forms.CheckBox c_Moon;
        private System.ComponentModel.IContainer components;

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label l_Day;
        private System.Windows.Forms.Label l_Year;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button b_dtIn;
        private System.Windows.Forms.Button b_dtDe;
        private System.Windows.Forms.Label l_Month;
        private System.Windows.Forms.Label l_Min;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label l_Hour;
        private System.Windows.Forms.Label l_Sec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gB_tolerance;
        private System.Windows.Forms.Panel p_mainPanel;

        private LocationST location = LocationST.GetInstance();
        private SolarSystemData solarSystemData = SolarSystemData.GetInstance();
        private System.Windows.Forms.Button b_Apply;
        private System.Windows.Forms.TextBox t_Decoy;
        private System.Windows.Forms.Label label1;
        private AngularDistances anglDist = new AngularDistances();

        public f_SolarSystem()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public f_SolarSystem(string s)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.Text = "Conjunction Finder";
            isFor = s;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(f_SolarSystem));
            this.pB_Space = new System.Windows.Forms.PictureBox();
            this.b_Apply = new System.Windows.Forms.Button();
            this.b_Step = new System.Windows.Forms.Button();
            this.b_StartStop = new System.Windows.Forms.Button();
            this.l_deg = new System.Windows.Forms.Label();
            this.b_tolDe = new System.Windows.Forms.Button();
            this.b_tolIn = new System.Windows.Forms.Button();
            this.l_TolNum = new System.Windows.Forms.Label();
            this.c_Orbits = new System.Windows.Forms.CheckBox();
            this.b_Now = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.l_Year = new System.Windows.Forms.Label();
            this.l_Month = new System.Windows.Forms.Label();
            this.l_Day = new System.Windows.Forms.Label();
            this.b_dtDe = new System.Windows.Forms.Button();
            this.b_dtIn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.l_Sec = new System.Windows.Forms.Label();
            this.l_Min = new System.Windows.Forms.Label();
            this.l_Hour = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.b_skipDe = new System.Windows.Forms.Button();
            this.b_skipIn = new System.Windows.Forms.Button();
            this.l_skip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.p_mainPanel = new System.Windows.Forms.Panel();
            this.gB_tolerance = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_Moon = new System.Windows.Forms.CheckBox();
            this.c_Pluto = new System.Windows.Forms.CheckBox();
            this.c_Jupiter = new System.Windows.Forms.CheckBox();
            this.c_Earth = new System.Windows.Forms.CheckBox();
            this.c_Mars = new System.Windows.Forms.CheckBox();
            this.c_Uranus = new System.Windows.Forms.CheckBox();
            this.c_Mercury = new System.Windows.Forms.CheckBox();
            this.c_Neptune = new System.Windows.Forms.CheckBox();
            this.c_Saturn = new System.Windows.Forms.CheckBox();
            this.c_Venus = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.t_Decoy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.p_mainPanel.SuspendLayout();
            this.gB_tolerance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pB_Space
            // 
            this.pB_Space.BackColor = System.Drawing.SystemColors.ControlText;
            this.pB_Space.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pB_Space.Dock = System.Windows.Forms.DockStyle.Right;
            this.pB_Space.Location = new System.Drawing.Point(210, 0);
            this.pB_Space.Name = "pB_Space";
            this.pB_Space.Size = new System.Drawing.Size(528, 736);
            this.pB_Space.TabIndex = 0;
            this.pB_Space.TabStop = false;
            this.pB_Space.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Space_Paint);
            this.pB_Space.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_Space_MouseUp);
            this.pB_Space.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pB_Space_MouseMove);
            this.pB_Space.MouseLeave += new System.EventHandler(this.pB_Space_MouseLeave);
            this.pB_Space.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_Space_MouseDown);
            // 
            // b_Apply
            // 
            this.b_Apply.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.b_Apply.Location = new System.Drawing.Point(136, 368);
            this.b_Apply.Name = "b_Apply";
            this.b_Apply.Size = new System.Drawing.Size(59, 23);
            this.b_Apply.TabIndex = 26;
            this.b_Apply.Text = "Apply ";
            this.b_Apply.Visible = false;
            // 
            // b_Step
            // 
            this.b_Step.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.b_Step.Location = new System.Drawing.Point(69, 368);
            this.b_Step.Name = "b_Step";
            this.b_Step.Size = new System.Drawing.Size(48, 23);
            this.b_Step.TabIndex = 25;
            this.b_Step.Text = "Step";
            this.b_Step.Click += new System.EventHandler(this.b_Step_Click);
            // 
            // b_StartStop
            // 
            this.b_StartStop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_StartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.b_StartStop.Location = new System.Drawing.Point(12, 368);
            this.b_StartStop.Name = "b_StartStop";
            this.b_StartStop.Size = new System.Drawing.Size(48, 23);
            this.b_StartStop.TabIndex = 24;
            this.b_StartStop.Click += new System.EventHandler(this.b_StartStop_Click);
            // 
            // l_deg
            // 
            this.l_deg.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_deg.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.l_deg.Location = new System.Drawing.Point(24, 27);
            this.l_deg.Name = "l_deg";
            this.l_deg.Size = new System.Drawing.Size(48, 15);
            this.l_deg.TabIndex = 60;
            this.l_deg.Text = "Degrees";
            this.l_deg.Visible = false;
            // 
            // b_tolDe
            // 
            this.b_tolDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_tolDe.Location = new System.Drawing.Point(123, 33);
            this.b_tolDe.Name = "b_tolDe";
            this.b_tolDe.Size = new System.Drawing.Size(10, 11);
            this.b_tolDe.TabIndex = 59;
            this.b_tolDe.Visible = false;
            this.b_tolDe.Click += new System.EventHandler(this.b_tolDe_Click);
            // 
            // b_tolIn
            // 
            this.b_tolIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_tolIn.Location = new System.Drawing.Point(123, 22);
            this.b_tolIn.Name = "b_tolIn";
            this.b_tolIn.Size = new System.Drawing.Size(10, 11);
            this.b_tolIn.TabIndex = 58;
            this.b_tolIn.Visible = false;
            this.b_tolIn.Click += new System.EventHandler(this.b_tolIn_Click);
            // 
            // l_TolNum
            // 
            this.l_TolNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_TolNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_TolNum.Location = new System.Drawing.Point(80, 27);
            this.l_TolNum.Name = "l_TolNum";
            this.l_TolNum.Size = new System.Drawing.Size(32, 15);
            this.l_TolNum.TabIndex = 57;
            this.l_TolNum.Text = "360";
            this.l_TolNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_TolNum.Visible = false;
            // 
            // c_Orbits
            // 
            this.c_Orbits.Checked = true;
            this.c_Orbits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_Orbits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.c_Orbits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Orbits.Location = new System.Drawing.Point(27, 23);
            this.c_Orbits.Name = "c_Orbits";
            this.c_Orbits.Size = new System.Drawing.Size(120, 24);
            this.c_Orbits.TabIndex = 55;
            this.c_Orbits.Text = "Planetary Orbits";
            this.c_Orbits.CheckedChanged += new System.EventHandler(this.c_Orbits_CheckedChanged);
            // 
            // b_Now
            // 
            this.b_Now.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Now.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.b_Now.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_Now.Location = new System.Drawing.Point(120, 26);
            this.b_Now.Name = "b_Now";
            this.b_Now.Size = new System.Drawing.Size(38, 23);
            this.b_Now.TabIndex = 54;
            this.b_Now.Text = "Now ";
            this.b_Now.Click += new System.EventHandler(this.b_Now_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(48, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "/";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(24, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "/";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Year
            // 
            this.l_Year.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.l_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_Year.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Year.Location = new System.Drawing.Point(56, 40);
            this.l_Year.Name = "l_Year";
            this.l_Year.Size = new System.Drawing.Size(32, 13);
            this.l_Year.TabIndex = 49;
            this.l_Year.Text = "1978";
            this.l_Year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Year.Click += new System.EventHandler(this.l_Year_Click);
            // 
            // l_Month
            // 
            this.l_Month.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.l_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_Month.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Month.Location = new System.Drawing.Point(32, 40);
            this.l_Month.Name = "l_Month";
            this.l_Month.Size = new System.Drawing.Size(18, 13);
            this.l_Month.TabIndex = 48;
            this.l_Month.Text = "08";
            this.l_Month.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Month.Click += new System.EventHandler(this.l_Month_Click);
            // 
            // l_Day
            // 
            this.l_Day.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.l_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_Day.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Day.Location = new System.Drawing.Point(8, 40);
            this.l_Day.Name = "l_Day";
            this.l_Day.Size = new System.Drawing.Size(18, 13);
            this.l_Day.TabIndex = 47;
            this.l_Day.Text = "06";
            this.l_Day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Day.Click += new System.EventHandler(this.l_Day_Click);
            // 
            // b_dtDe
            // 
            this.b_dtDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_dtDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.b_dtDe.Location = new System.Drawing.Point(96, 38);
            this.b_dtDe.Name = "b_dtDe";
            this.b_dtDe.Size = new System.Drawing.Size(10, 11);
            this.b_dtDe.TabIndex = 46;
            this.b_dtDe.TabStop = false;
            this.b_dtDe.Visible = false;
            this.b_dtDe.Click += new System.EventHandler(this.b_dtDe_Click);
            // 
            // b_dtIn
            // 
            this.b_dtIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_dtIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.b_dtIn.Location = new System.Drawing.Point(96, 26);
            this.b_dtIn.Name = "b_dtIn";
            this.b_dtIn.Size = new System.Drawing.Size(10, 11);
            this.b_dtIn.TabIndex = 45;
            this.b_dtIn.TabStop = false;
            this.b_dtIn.Visible = false;
            this.b_dtIn.Click += new System.EventHandler(this.b_dtIn_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(48, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(7, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(24, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(7, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = ":";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Sec
            // 
            this.l_Sec.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.l_Sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_Sec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Sec.Location = new System.Drawing.Point(56, 24);
            this.l_Sec.Name = "l_Sec";
            this.l_Sec.Size = new System.Drawing.Size(18, 13);
            this.l_Sec.TabIndex = 42;
            this.l_Sec.Text = "29";
            this.l_Sec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Sec.Click += new System.EventHandler(this.l_Sec_Click);
            // 
            // l_Min
            // 
            this.l_Min.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.l_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_Min.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Min.Location = new System.Drawing.Point(32, 24);
            this.l_Min.Name = "l_Min";
            this.l_Min.Size = new System.Drawing.Size(18, 13);
            this.l_Min.TabIndex = 41;
            this.l_Min.Text = "59";
            this.l_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Min.Click += new System.EventHandler(this.l_Min_Click);
            // 
            // l_Hour
            // 
            this.l_Hour.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.l_Hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_Hour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Hour.Location = new System.Drawing.Point(8, 24);
            this.l_Hour.Name = "l_Hour";
            this.l_Hour.Size = new System.Drawing.Size(18, 13);
            this.l_Hour.TabIndex = 40;
            this.l_Hour.Text = "23";
            this.l_Hour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Hour.Click += new System.EventHandler(this.l_Hour_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(102, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "days";
            // 
            // b_skipDe
            // 
            this.b_skipDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_skipDe.Location = new System.Drawing.Point(134, 78);
            this.b_skipDe.Name = "b_skipDe";
            this.b_skipDe.Size = new System.Drawing.Size(10, 11);
            this.b_skipDe.TabIndex = 9;
            this.b_skipDe.Click += new System.EventHandler(this.b_skipDe_Click);
            // 
            // b_skipIn
            // 
            this.b_skipIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_skipIn.Location = new System.Drawing.Point(134, 66);
            this.b_skipIn.Name = "b_skipIn";
            this.b_skipIn.Size = new System.Drawing.Size(10, 11);
            this.b_skipIn.TabIndex = 8;
            this.b_skipIn.Click += new System.EventHandler(this.b_skipIn_Click);
            // 
            // l_skip
            // 
            this.l_skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.l_skip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_skip.Location = new System.Drawing.Point(70, 72);
            this.l_skip.Name = "l_skip";
            this.l_skip.Size = new System.Drawing.Size(32, 15);
            this.l_skip.TabIndex = 7;
            this.l_skip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(30, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Step :";
            // 
            // p_mainPanel
            // 
            this.p_mainPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.p_mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_mainPanel.Controls.Add(this.gB_tolerance);
            this.p_mainPanel.Controls.Add(this.groupBox2);
            this.p_mainPanel.Controls.Add(this.groupBox1);
            this.p_mainPanel.Location = new System.Drawing.Point(10, 10);
            this.p_mainPanel.Name = "p_mainPanel";
            this.p_mainPanel.Size = new System.Drawing.Size(186, 350);
            this.p_mainPanel.TabIndex = 21;
            // 
            // gB_tolerance
            // 
            this.gB_tolerance.Controls.Add(this.l_TolNum);
            this.gB_tolerance.Controls.Add(this.l_deg);
            this.gB_tolerance.Controls.Add(this.b_tolIn);
            this.gB_tolerance.Controls.Add(this.b_tolDe);
            this.gB_tolerance.Controls.Add(this.c_Orbits);
            this.gB_tolerance.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.gB_tolerance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gB_tolerance.Location = new System.Drawing.Point(8, 278);
            this.gB_tolerance.Name = "gB_tolerance";
            this.gB_tolerance.Size = new System.Drawing.Size(168, 59);
            this.gB_tolerance.TabIndex = 29;
            this.gB_tolerance.TabStop = false;
            this.gB_tolerance.Text = "View";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.b_dtIn);
            this.groupBox2.Controls.Add(this.b_dtDe);
            this.groupBox2.Controls.Add(this.l_Day);
            this.groupBox2.Controls.Add(this.l_Month);
            this.groupBox2.Controls.Add(this.l_Year);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.l_Hour);
            this.groupBox2.Controls.Add(this.l_Min);
            this.groupBox2.Controls.Add(this.l_Sec);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.b_Now);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.b_skipDe);
            this.groupBox2.Controls.Add(this.b_skipIn);
            this.groupBox2.Controls.Add(this.l_skip);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(8, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 96);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Date/Time";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c_Moon);
            this.groupBox1.Controls.Add(this.c_Pluto);
            this.groupBox1.Controls.Add(this.c_Jupiter);
            this.groupBox1.Controls.Add(this.c_Earth);
            this.groupBox1.Controls.Add(this.c_Mars);
            this.groupBox1.Controls.Add(this.c_Uranus);
            this.groupBox1.Controls.Add(this.c_Mercury);
            this.groupBox1.Controls.Add(this.c_Neptune);
            this.groupBox1.Controls.Add(this.c_Saturn);
            this.groupBox1.Controls.Add(this.c_Venus);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 160);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Planets";
            // 
            // c_Moon
            // 
            this.c_Moon.Enabled = false;
            this.c_Moon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Moon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Moon.Location = new System.Drawing.Point(15, 25);
            this.c_Moon.Name = "c_Moon";
            this.c_Moon.Size = new System.Drawing.Size(72, 24);
            this.c_Moon.TabIndex = 26;
            this.c_Moon.Text = "Moon";
            this.c_Moon.Visible = false;
            this.c_Moon.CheckedChanged += new System.EventHandler(this.c_Moon_CheckedChanged);
            // 
            // c_Pluto
            // 
            this.c_Pluto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Pluto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Pluto.Location = new System.Drawing.Point(94, 125);
            this.c_Pluto.Name = "c_Pluto";
            this.c_Pluto.Size = new System.Drawing.Size(72, 24);
            this.c_Pluto.TabIndex = 25;
            this.c_Pluto.Text = "Pluto";
            this.c_Pluto.CheckedChanged += new System.EventHandler(this.c_Pluto_CheckedChanged);
            // 
            // c_Jupiter
            // 
            this.c_Jupiter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Jupiter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Jupiter.Location = new System.Drawing.Point(94, 24);
            this.c_Jupiter.Name = "c_Jupiter";
            this.c_Jupiter.Size = new System.Drawing.Size(72, 24);
            this.c_Jupiter.TabIndex = 16;
            this.c_Jupiter.Text = "Jupiter";
            this.c_Jupiter.CheckedChanged += new System.EventHandler(this.c_Jupiter_CheckedChanged);
            // 
            // c_Earth
            // 
            this.c_Earth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Earth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Earth.Location = new System.Drawing.Point(15, 104);
            this.c_Earth.Name = "c_Earth";
            this.c_Earth.Size = new System.Drawing.Size(72, 16);
            this.c_Earth.TabIndex = 14;
            this.c_Earth.Text = "Earth";
            this.c_Earth.CheckedChanged += new System.EventHandler(this.c_Earth_CheckedChanged);
            // 
            // c_Mars
            // 
            this.c_Mars.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Mars.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Mars.Location = new System.Drawing.Point(15, 125);
            this.c_Mars.Name = "c_Mars";
            this.c_Mars.Size = new System.Drawing.Size(72, 24);
            this.c_Mars.TabIndex = 15;
            this.c_Mars.Text = "Mars";
            this.c_Mars.CheckedChanged += new System.EventHandler(this.c_Mars_CheckedChanged);
            // 
            // c_Uranus
            // 
            this.c_Uranus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Uranus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Uranus.Location = new System.Drawing.Point(94, 74);
            this.c_Uranus.Name = "c_Uranus";
            this.c_Uranus.Size = new System.Drawing.Size(72, 24);
            this.c_Uranus.TabIndex = 18;
            this.c_Uranus.Text = "Uranus";
            this.c_Uranus.CheckedChanged += new System.EventHandler(this.c_Uranus_CheckedChanged);
            // 
            // c_Mercury
            // 
            this.c_Mercury.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Mercury.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Mercury.Location = new System.Drawing.Point(15, 50);
            this.c_Mercury.Name = "c_Mercury";
            this.c_Mercury.Size = new System.Drawing.Size(72, 24);
            this.c_Mercury.TabIndex = 12;
            this.c_Mercury.Text = "Mercury";
            this.c_Mercury.CheckedChanged += new System.EventHandler(this.c_Mercury_CheckedChanged);
            // 
            // c_Neptune
            // 
            this.c_Neptune.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Neptune.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Neptune.Location = new System.Drawing.Point(94, 99);
            this.c_Neptune.Name = "c_Neptune";
            this.c_Neptune.Size = new System.Drawing.Size(72, 24);
            this.c_Neptune.TabIndex = 19;
            this.c_Neptune.Text = "Neptune";
            this.c_Neptune.CheckedChanged += new System.EventHandler(this.c_Neptune_CheckedChanged);
            // 
            // c_Saturn
            // 
            this.c_Saturn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Saturn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Saturn.Location = new System.Drawing.Point(94, 48);
            this.c_Saturn.Name = "c_Saturn";
            this.c_Saturn.Size = new System.Drawing.Size(72, 24);
            this.c_Saturn.TabIndex = 17;
            this.c_Saturn.Text = "Saturn";
            this.c_Saturn.CheckedChanged += new System.EventHandler(this.c_Saturn_CheckedChanged);
            // 
            // c_Venus
            // 
            this.c_Venus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.c_Venus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c_Venus.Location = new System.Drawing.Point(15, 75);
            this.c_Venus.Name = "c_Venus";
            this.c_Venus.Size = new System.Drawing.Size(72, 24);
            this.c_Venus.TabIndex = 13;
            this.c_Venus.Text = "Venus";
            this.c_Venus.CheckedChanged += new System.EventHandler(this.c_Venus_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // t_Decoy
            // 
            this.t_Decoy.Location = new System.Drawing.Point(64, 416);
            this.t_Decoy.Name = "t_Decoy";
            this.t_Decoy.Size = new System.Drawing.Size(8, 20);
            this.t_Decoy.TabIndex = 27;
            this.t_Decoy.Text = "";
            this.t_Decoy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_Decoy_KeyDown);
            this.t_Decoy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.t_Decoy_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 416);
            this.label1.Name = "label1";
            this.label1.TabIndex = 28;
            // 
            // f_SolarSystem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
            this.ClientSize = new System.Drawing.Size(738, 736);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_Decoy);
            this.Controls.Add(this.pB_Space);
            this.Controls.Add(this.p_mainPanel);
            this.Controls.Add(this.b_StartStop);
            this.Controls.Add(this.b_Step);
            this.Controls.Add(this.b_Apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_SolarSystem";
            this.Text = "Solar System View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.f_SolarSystemView_Load);
            this.Deactivate += new System.EventHandler(this.f_SolarSystem_Deactivate);
            this.p_mainPanel.ResumeLayout(false);
            this.gB_tolerance.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void f_SolarSystemView_Load(object sender, System.EventArgs e)
        {
            UpdateLabel();
            pB_Space.Width = this.ClientSize.Width - (p_mainPanel.Location.X + p_mainPanel.Width + 10);
            clg = pB_Space.CreateGraphics();
            originTop.X = pB_Space.Size.Width / 2;
            originTop.Y = pB_Space.Size.Height / 2;
            b_StartStop.Text = "Start";
            this.solarSystemData.PlanetPositions();
            this.solarSystemData.PlanetOrb();
            this.solarSystemData.RotateOrbit(angle_X, angle_Z);

            if (isFor == "cf")
            {
                gB_tolerance.Text = "Tolerance";
                c_Orbits.Visible = false;
                l_TolNum.Visible = true;
                l_deg.Visible = true;
                b_tolIn.Visible = true;
                b_tolDe.Visible = true;
                b_StartStop.Visible = false;
                b_Step.Visible = false;
                c_Earth.Checked = true;
                c_Earth.Enabled = false;
                c_Moon.Visible = true;
                originTop.X = pB_Space.Size.Width / 2;
                originTop.Y = pB_Space.Size.Height * 2 / 5;

                xg = 30;
                yg = pB_Space.Height * 4 / 5;
                wg = pB_Space.Width - xg - 10;
                hg = pB_Space.Height * 1 / 6;
                top = wg - 1;
                graf = new Double[top];
            }
        }

        private void NormalizeLabel()
        {
            switch (selected)
            {
                case "l_Hour":
                    {
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Hour.BackColor = Color.FromArgb(175, 175, 100);
                        l_Hour.ForeColor = Color.Black;
                        break;
                    }
                case "l_Min":
                    {
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Min.BackColor = Color.FromArgb(175, 175, 100);
                        l_Min.ForeColor = Color.Black;
                        break;
                    }
                case "l_Sec":
                    {
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Sec.BackColor = Color.FromArgb(175, 175, 100);
                        l_Sec.ForeColor = Color.Black;
                        break;
                    }
                case "l_Day":
                    {
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Day.BackColor = Color.FromArgb(175, 175, 100);
                        l_Day.ForeColor = Color.Black;
                        break;
                    }
                case "l_Month":
                    {
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Month.BackColor = Color.FromArgb(175, 175, 100);
                        l_Month.ForeColor = Color.Black;
                        break;
                    }
                case "l_Year":
                    {
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Year.BackColor = Color.FromArgb(175, 175, 100);
                        l_Year.ForeColor = Color.Black;
                        break;
                    }
            }
        }

        private void UpdateLabel()
        {
            l_Hour.Text = location.MainDateTime.Hour.ToString();
            l_Min.Text = location.MainDateTime.Minute.ToString();
            l_Sec.Text = location.MainDateTime.Second.ToString();
            l_Day.Text = location.MainDateTime.Day.ToString();
            l_Month.Text = location.MainDateTime.Month.ToString();
            l_Year.Text = location.MainDateTime.Year.ToString();
            l_skip.Text = step.ToString();
            l_TolNum.Text = tolerance.ToString();
        }

        private void ChangeTime(double n)
        {
            switch (selected)
            {
                case "l_Sec":
                    {
                        location.MainDateTime = location.MainDateTime.AddSeconds(n);
                        UpdateLabel(); break;
                    }
                case "l_Min":
                    {
                        location.MainDateTime = location.MainDateTime.AddMinutes(n);
                        UpdateLabel(); break;
                    }
                case "l_Hour":
                    {
                        location.MainDateTime = location.MainDateTime.AddHours(n);
                        UpdateLabel(); break;
                    }
                case "l_Day":
                    {
                        location.MainDateTime = location.MainDateTime.AddDays(n);
                        UpdateLabel(); break;
                    }
                case "l_Month":
                    {
                        location.MainDateTime = location.MainDateTime.AddMonths((int)n);
                        UpdateLabel(); break;
                    }
                case "l_Year":
                    {
                        location.MainDateTime = location.MainDateTime.AddYears((int)n);
                        UpdateLabel(); break;
                    }
            }
            if (location.MainDateTime < location.dtMin)
            {
                timer1.Stop();
                location.MainDateTime = location.dtMin;
                UpdateLabel();
            }
            if (location.MainDateTime > location.dtMax)
            {
                timer1.Stop();
                location.MainDateTime = location.dtMax;
                UpdateLabel();
            }
        }

        private void b_dtIn_Click(object sender, System.EventArgs e)
        {
            ChangeTime(1);
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            if (isFor == "cf") TestConjunction();
            pB_Space.Invalidate();
        }

        private void b_dtDe_Click(object sender, System.EventArgs e)
        {
            ChangeTime(-1);
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            if (isFor == "cf") TestConjunction();
            pB_Space.Invalidate();
        }

        private void l_Hour_Click(object sender, System.EventArgs e)
        {
            NormalizeLabel();
            selected = "l_Hour";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Hour.BackColor = Color.Brown;
            l_Hour.ForeColor = Color.White;
            t_Decoy.Select();
        }

        private void l_Min_Click(object sender, System.EventArgs e)
        {
            NormalizeLabel();
            selected = "l_Min";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Min.BackColor = Color.Brown;
            l_Min.ForeColor = Color.White;
            t_Decoy.Select();
        }

        private void l_Sec_Click(object sender, System.EventArgs e)
        {
            NormalizeLabel();
            selected = "l_Sec";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Sec.BackColor = Color.Brown;
            l_Sec.ForeColor = Color.White;
            t_Decoy.Select();
        }

        private void l_Day_Click(object sender, System.EventArgs e)
        {
            NormalizeLabel();
            selected = "l_Day";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Day.BackColor = Color.Brown;
            l_Day.ForeColor = Color.White;
            t_Decoy.Select();
        }

        private void l_Month_Click(object sender, System.EventArgs e)
        {
            NormalizeLabel();
            selected = "l_Month";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Month.BackColor = Color.Brown;
            l_Month.ForeColor = Color.White;
            t_Decoy.Select();
        }

        private void l_Year_Click(object sender, System.EventArgs e)
        {
            NormalizeLabel();
            selected = "l_Year";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Year.BackColor = Color.Brown;
            l_Year.ForeColor = Color.White;
            t_Decoy.Select();
        }

        private void b_Now_Click(object sender, System.EventArgs e)
        {
            location.TimeNow();
            UpdateLabel();
            NormalizeLabel();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            if (isFor == "cf") TestConjunction();
            pB_Space.Invalidate();
        }

        private void DrawSS(Graphics g, string name, Color color)
        {
            if (mag == 0) mag = (short)((originTop.Y - 10) / this.solarSystemData.SolarSystemObjects.GetObjectByName(name).d);
            if (c_Orbits.Checked)
            {
                Point[] p = new Point[29];
                for (short i = 0; i < 28; ++i)
                {
                    p[i].X = (int)(originTop.X + this.solarSystemData.copyOrb[name, i].X * mag);
                    p[i].Y = (int)(originTop.Y - this.solarSystemData.copyOrb[name, i].Y * mag);
                }
                p[28] = p[0];
                g.DrawCurve(new Pen(Color.Red), p);
            }

            this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.Rotate(angle_X, angle_Z);
            g.FillRectangle(new SolidBrush(color),
                (int)(originTop.X + this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.X * mag) - 2,
                (int)(originTop.Y - this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.Y * mag) - 2, 4, 4);
            if (isFor == "cf")
            {
                if (name == "Earth")
                {
                    angVec[0].X = (int)(originTop.X + this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.X * mag);
                    angVec[0].Y = (int)(originTop.Y - this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.Y * mag);
                }
                else
                {
                    angVec[avIndex].X = (int)(originTop.X + this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.X * mag);
                    angVec[avIndex].Y = (int)(originTop.Y - this.solarSystemData.SolarSystemObjects.GetObjectByName(name).Position.Y * mag);
                    ++avIndex;
                }
            }
        }

        private void pB_Space_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (c_Pluto.Checked) DrawSS(g, "Pluto", Color.Wheat);
            if (c_Neptune.Checked) DrawSS(g, "Neptune", Color.Blue);
            if (c_Uranus.Checked) DrawSS(g, "Uranus", Color.Aqua);
            if (c_Saturn.Checked) DrawSS(g, "Saturn", Color.SandyBrown);
            if (c_Jupiter.Checked) DrawSS(g, "Jupiter", Color.Gold);
            if (c_Mars.Checked) DrawSS(g, "Mars", Color.Red);
            if (c_Earth.Checked) DrawSS(g, "Earth", Color.SteelBlue);
            if (c_Venus.Checked) DrawSS(g, "Venus", Color.Orange);
            if (c_Mercury.Checked) DrawSS(g, "Mercury", Color.Gray);

            GraphicsPath sun = new GraphicsPath();
            sun.AddEllipse(originTop.X - 5, originTop.Y - 5, 10, 10);
            g.FillPath(new SolidBrush(Color.Yellow), sun);

            if (isFor == "cf")
            {
                g.DrawRectangle(new Pen(Color.Green), xg, yg, wg, hg);
                next = xg + 1;
                for (int i = 0; i < top - 1; ++i, ++next)
                {
                    if (i == index)
                        g.DrawLine(new Pen(Color.Red), new Point(next, yg + hg),
                            new Point(next, yg + 1));
                    g.DrawLine(new Pen(Color.Yellow), new Point(next + 1, yg + hg - 2),
                        new Point(next + 1, (int)(yg - 2 + hg - hg / (182 / graf[i]))));
                }
                g.DrawString("Angular Separation : " + Math.Round(printAD, 2).ToString(), new Font("Comic Sans MS", 10),
                    new SolidBrush(Color.White), xg + 30, yg - 30);

                g.DrawString("180", new Font("Comic Sans MS", 10),
                    new SolidBrush(Color.White), 0, yg);
                g.DrawString("90", new Font("Comic Sans MS", 10),
                    new SolidBrush(Color.White), 0, yg + hg / 2);
                g.DrawString("0", new Font("Comic Sans MS", 10),
                    new SolidBrush(Color.White), 0, yg + hg);

                for (int i = 0; i < avIndex; ++i)
                    g.DrawLine(new Pen(Color.Silver), angVec[0], angVec[i]);
            }
            avIndex = 1;
        }

        private void TestConjunction()
        {
            this.angularDistance = anglDist.AngularDistance(conStr);
            if (this.angularDistance <= oldAD + 0.001) tend = true;
            else tend = false;
            graf[index] = this.angularDistance;
            printAD = this.angularDistance;
            if (index < top - 1) ++index;
            else index = 0;
            if (start == true && cont == true && oldAD <= tolerance && tend == false)
            {
                StopTimer();
                found = true;
                printAD = oldAD;
                selected = "l_Day";
                ChangeTime(-1 * step);
                this.solarSystemData.PlanetPositions();
                pB_Space.Invalidate();
                selected = "";
            }
            if (this.angularDistance > tolerance) cont = true;
            oldAD = this.angularDistance;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            location.MainDateTime = location.MainDateTime.AddDays(step);
            if (location.MainDateTime < location.dtMin)
            {
                StopTimer();
                location.MainDateTime = location.dtMin;
                UpdateLabel();
            }
            if (location.MainDateTime > location.dtMax)
            {
                StopTimer();
                location.MainDateTime = location.dtMax;
                UpdateLabel();
            }
            this.solarSystemData.PlanetPositions();
            if (isFor == "cf") TestConjunction();
            UpdateLabel();
            pB_Space.Invalidate();
        }

        private void StartTimer()
        {
            this.angularDistance = oldAD = 0; cont = false; found = false;
            NormalizeLabel();
            this.solarSystemData.PlanetPositions();
            if (isFor == "cf") CreateConString();
            mag = 0;
            pB_Space.Invalidate(false);
            start = true;
            if (isFor == "cf")
            {
                if (c_Mercury.Checked) c_Mercury.Enabled = false;
                if (c_Venus.Checked) c_Venus.Enabled = false;
                if (c_Mars.Checked) c_Mars.Enabled = false;
                if (c_Jupiter.Checked) c_Jupiter.Enabled = false;
                if (c_Saturn.Checked) c_Saturn.Enabled = false;
                if (c_Uranus.Checked) c_Uranus.Enabled = false;
                if (c_Neptune.Checked) c_Neptune.Enabled = false;
                if (c_Pluto.Checked) c_Pluto.Enabled = false;
                if (c_Moon.Checked) c_Moon.Enabled = false;
            }
            b_StartStop.Text = "Stop";
            timer1 = new Timer();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void StopTimer()
        {
            mag = 0;
            start = false;
            if (isFor == "cf")
            {
                if (c_Mercury.Checked) c_Mercury.Enabled = true;
                if (c_Venus.Checked) c_Venus.Enabled = true;
                if (c_Mars.Checked) c_Mars.Enabled = true;
                if (c_Jupiter.Checked) c_Jupiter.Enabled = true;
                if (c_Saturn.Checked) c_Saturn.Enabled = true;
                if (c_Uranus.Checked) c_Uranus.Enabled = true;
                if (c_Neptune.Checked) c_Neptune.Enabled = true;
                if (c_Pluto.Checked) c_Pluto.Enabled = true;
                if (c_Moon.Checked) c_Moon.Enabled = true;
            }
            b_StartStop.Text = "Start";
            timer1.Stop();
        }

        private void b_StartStop_Click(object sender, System.EventArgs e)
        {
            if (start == false) { rotStart = true; StartTimer(); }
            else { rotStart = false; StopTimer(); }
            t_Decoy.Select();
        }

        private void b_skipIn_Click(object sender, System.EventArgs e)
        {
            ++step;
            UpdateLabel();
            t_Decoy.Select();
        }

        private void b_skipDe_Click(object sender, System.EventArgs e)
        {
            --step;
            UpdateLabel();
            t_Decoy.Select();
        }

        private void b_Step_Click(object sender, System.EventArgs e)
        {
            location.MainDateTime = location.MainDateTime.AddDays(step);
            this.solarSystemData.PlanetPositions();
            UpdateLabel();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Orbits_CheckedChanged(object sender, System.EventArgs e)
        {
            mag = 0;
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Moon_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Moon.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Mercury_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Mercury.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Venus_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Venus.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Earth_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Earth.Checked) c_Moon.Enabled = true;
            else c_Moon.Enabled = false;
            mag = 0;
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Mars_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Mars.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Jupiter_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Jupiter.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Saturn_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Saturn.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Uranus_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Uranus.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Neptune_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Neptune.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void c_Pluto_CheckedChanged(object sender, System.EventArgs e)
        {
            if (c_Pluto.Checked) ++countPl;
            else --countPl;
            mag = 0; if (countPl < 2) DisableBut(); else EnableBut();
            this.solarSystemData.PlanetPositions();
            t_Decoy.Select();
            pB_Space.Invalidate();
        }

        private void b_tolIn_Click(object sender, System.EventArgs e)
        {
            if (tolerance < 1) { tolerance += 0.25; UpdateLabel(); }
            else if (tolerance < 180) { ++tolerance; UpdateLabel(); }
            t_Decoy.Select();
        }

        private void b_tolDe_Click(object sender, System.EventArgs e)
        {
            if (tolerance > 1) { --tolerance; UpdateLabel(); }
            else if (tolerance > 0.25) { tolerance -= 0.25; UpdateLabel(); }
            t_Decoy.Select();
        }

        private void DisableBut()
        {
            if (isFor == "cf")
            {
                b_StartStop.Visible = false;
                c_Mercury.Enabled = true;
                c_Venus.Enabled = true;
                c_Mars.Enabled = true;
                c_Jupiter.Enabled = true;
                c_Saturn.Enabled = true;
                c_Uranus.Enabled = true;
                c_Neptune.Enabled = true;
                c_Pluto.Enabled = true;
                c_Moon.Enabled = true;
            }
        }

        private void EnableBut()
        {
            if (isFor == "cf")
            {
                b_StartStop.Visible = true;
                if (!c_Mercury.Checked) c_Mercury.Enabled = false;
                if (!c_Venus.Checked) c_Venus.Enabled = false;
                if (!c_Mars.Checked) c_Mars.Enabled = false;
                if (!c_Jupiter.Checked) c_Jupiter.Enabled = false;
                if (!c_Saturn.Checked) c_Saturn.Enabled = false;
                if (!c_Uranus.Checked) c_Uranus.Enabled = false;
                if (!c_Neptune.Checked) c_Neptune.Enabled = false;
                if (!c_Pluto.Checked) c_Pluto.Enabled = false;
                if (!c_Moon.Checked) c_Moon.Enabled = false;
            }
        }

        private void CreateConString()
        {
            conStr = (int)Planets.None;
            if (c_Mercury.Checked) conStr += (int)Planets.Mercury;
            if (c_Venus.Checked) conStr += (int)Planets.Venus;
            if (c_Mars.Checked) conStr += (int)Planets.Mars;
            if (c_Jupiter.Checked) conStr += (int)Planets.Jupiter;
            if (c_Saturn.Checked) conStr += (int)Planets.Saturn;
            if (c_Uranus.Checked) conStr += (int)Planets.Uranus;
            if (c_Neptune.Checked) conStr += (int)Planets.Neptune;
            if (c_Pluto.Checked) conStr += (int)Planets.Pluto;
            if (c_Moon.Checked) conStr += (int)Planets.Moon;
        }

        private void f_SolarSystem_Deactivate(object sender, System.EventArgs e)
        {
            StopTimer();
        }

        private void pB_Space_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                StopTimer();
                mDown = true;
                xmO = e.X;
                ymO = e.Y;
            }
        }

        private void pB_Space_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mDown == true)
            {
                xmN = e.X;
                ymN = e.Y;
                this.solarSystemData.PlanetPositions();
                if (angle_X >= 0 && angle_X <= 180)
                    angle_X -= (ymN - ymO);
                if (angle_X > 180) angle_X = 180;
                if (angle_X < 0) angle_X = 00;
                angle_Z += (360 + xmN - xmO);
                angle_Z = (angle_Z + 360) % 360;
                this.solarSystemData.RotateOrbit(angle_X, angle_Z);
                pB_Space.Invalidate();
                xmO = xmN;
                ymO = ymN;
            }
        }

        private void pB_Space_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mDown = false;
                if (rotStart == true && found == false) StartTimer();
            }
        }

        private void pB_Space_MouseLeave(object sender, System.EventArgs e)
        {
            mDown = false;
        }

        private double dt = 1;
        private void t_Decoy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (selected != "")
            {
                if (e.KeyCode == Keys.Up)
                    ChangeTime(dt);
                if (e.KeyCode == Keys.Down)
                    ChangeTime(-dt);
                dt += 0.1;
            }
        }

        private void t_Decoy_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            dt = 1;
        }

        private Graphics clg;
        private Point originTop = new Point();
        private Point originSide = new Point();
        private short mag = 0;
        private double step = 1;
        private string selected;
        private bool start = false, rotStart = false, found = false;
        private string isFor;
        private double tolerance = 5;
        private short countPl = 0;
        private int conStr = (int)Planets.None;
        private double angularDistance, oldAD, printAD;
        private bool tend = false, cont = true;
        private int xg, yg, wg, hg, next;
        private double[] graf;
        private int index = 0, top;
        private int angle_X = 0, angle_Z = 0;
        private bool mDown = false;
        private int xmO, xmN, ymO, ymN;
        private Point[] angVec = new Point[3];
        private int avIndex = 1;
    }
}
