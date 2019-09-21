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

using SpaceBridge.Data;
using SpaceBridge.Devices.Model1;
using SpaceBridge.Events;
using SpaceObjects.Data;
using SpaceObjects.SolarSystem;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Planetarium
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class f_MainForm : System.Windows.Forms.Form
    {
        #region Variables

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button b_suIn;
        private System.Windows.Forms.Label l_StepUnit;
        private System.Windows.Forms.Label l_Step;
        private System.Windows.Forms.Button b_FlowTime;
        private System.Windows.Forms.Button b_StepF;
        private System.Windows.Forms.Button b_PlayF;
        private System.Windows.Forms.Button b_PlayB;
        private System.Windows.Forms.Button b_StopTime;
        private System.Windows.Forms.Button b_StepB;
        private System.Windows.Forms.Label l_Year;
        private System.Windows.Forms.Label l_Month;
        private System.Windows.Forms.Label l_Day;
        private System.Windows.Forms.Button b_dtDe;
        private System.Windows.Forms.Button b_dtIn;
        private System.Windows.Forms.Label l_Sec;
        private System.Windows.Forms.Label l_Min;
        private System.Windows.Forms.Label l_Hour;
        private System.Windows.Forms.Button b_Now;
        private System.Windows.Forms.Button b_PosDe;
        private System.Windows.Forms.Button b_PosIn;
        private System.Windows.Forms.Label l_Lon;
        private System.Windows.Forms.Label l_Lat;
        private System.Windows.Forms.Button b_Home;
        private System.Windows.Forms.Label l_ViewAngle;
        private System.Windows.Forms.Button b_ViewDe;
        private System.Windows.Forms.Button b_ViewIn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button b_ViewMax;
        private System.Windows.Forms.Button b_suDe;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.MenuItem m_Select;
        private System.Windows.Forms.MenuItem m_Deselect;
        private System.Windows.Forms.MenuItem m_Sun;
        private System.Windows.Forms.MenuItem m_Moon;
        private System.Windows.Forms.MenuItem m_Mercury;
        private System.Windows.Forms.MenuItem m_Venus;
        private System.Windows.Forms.MenuItem m_Mars;
        private System.Windows.Forms.MenuItem m_Jupiter;
        private System.Windows.Forms.MenuItem m_Saturn;
        private System.Windows.Forms.MenuItem m_Uranus;
        private System.Windows.Forms.MenuItem m_Neptune;
        private System.Windows.Forms.MenuItem m_Pluto;
        private System.Windows.Forms.ToolTip tt_Stop;
        private System.Windows.Forms.ToolTip tt_StepBack;
        private System.Windows.Forms.ToolTip tt_StepForward;
        private System.Windows.Forms.ToolTip tt_PlayBack;
        private System.Windows.Forms.ToolTip tt_PlayForward;
        private System.Windows.Forms.ToolTip tt_RealTimeFlow;
        private System.Windows.Forms.ToolTip tt_ZoomIn;
        private System.Windows.Forms.ToolTip tt_ZoomOut;
        private System.Windows.Forms.ToolTip tt_StandardView;
        private System.Windows.Forms.TextBox t_Decoy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lm_Data;
        private System.Windows.Forms.Label lm_Tools;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lm_Select;
        private System.Windows.Forms.PictureBox pB_Space;
        private System.Windows.Forms.Panel p_Data;
        private System.Windows.Forms.Label lm_PlanetPositions;
        private System.Windows.Forms.Label lm_Ephemerides;
        private System.Windows.Forms.Label lm_ViewData;
        private System.Windows.Forms.Panel p_Tools;
        private System.Windows.Forms.Label lm_SolarEvents;
        private System.Windows.Forms.Label lm_ConjunctionFinder;
        private System.Windows.Forms.Label lm_SolarSystemView;
        private System.Windows.Forms.Panel p_Select;
        private System.Windows.Forms.Button b_Select;
        private System.Windows.Forms.TreeView tV_Select;
        private System.Windows.Forms.Label lt_GridLabel;
        private System.Windows.Forms.Label lt_HorGrid;
        private System.Windows.Forms.Label lt_EqGrid;
        private System.Windows.Forms.Label lt_MessierLabel;
        private System.Windows.Forms.Label lt_Messiers;
        private System.Windows.Forms.Label lt_StarLabel;
        private System.Windows.Forms.Label lt_Stars;
        private System.Windows.Forms.Label lt_PlanetLabel;
        private System.Windows.Forms.Label lt_Planets;
        private System.Windows.Forms.Label lt_HorizonLabel;
        private System.Windows.Forms.Label lt_LineHorizon;
        private System.Windows.Forms.Label lt_FullHorizon;
        private System.Windows.Forms.Label lt_Daylight;
        private System.Windows.Forms.ToolTip tt_ShowDaylight;
        private System.Windows.Forms.ToolTip tt_FullHor;
        private System.Windows.Forms.ToolTip tt_LineHor;
        private System.Windows.Forms.ToolTip tt_Label;
        private System.Windows.Forms.ToolTip tt_ShowPlanets;
        private System.Windows.Forms.ToolTip tt_ShowStars;
        private System.Windows.Forms.ToolTip tt_ShowMessiers;
        private System.Windows.Forms.ToolTip tt_EQGrid;
        private System.Windows.Forms.ToolTip tt_HORGrid;
        private System.Windows.Forms.Label lt_ConstellationLabel;
        private System.Windows.Forms.Label lt_Constellation;
        private System.Windows.Forms.ToolTip tt_ShowConstellations;
        private System.Windows.Forms.Label lt_EarthShadow;
        private System.Windows.Forms.ToolTip tt_ES;
        private Label lblDevice;
        private System.ComponentModel.IContainer components;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public f_MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            Assembly asembly = Assembly.GetExecutingAssembly();
            Stream curStream = asembly.GetManifestResourceStream("Planetarium.Resources.Cursors.open_hand.cur");
            openH = new Cursor(curStream);
            curStream = asembly.GetManifestResourceStream("Planetarium.Resources.Cursors.closed_hand.cur");
            closedH = new Cursor(curStream);

            pB_Space.Cursor = openH;

            for (int i = 0, a = 90; i < 19; ++i, a -= 10)
            {
                for (int j = 0, A = 0; j < 25; ++j, A += 15)
                {
                    skyView.grid[i, j] = new SkyPosition();
                    skyView.EQgrid[i, j] = new SkyPosition();
                }
            }
            for (int index = 0; index < skyView.direction.Length; index++)
            {
                skyView.direction[index] = new SkyPosition();
            }
            skyView.center = new SkyPosition();

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

            this.DisconnectFromSpaceBoard();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mercury");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Venus");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Moon");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Earth shadow");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Earth", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Mars");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Jupiter");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Saturn");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Uranus");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Neptune");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Pluto");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Sun", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.t_Decoy = new System.Windows.Forms.TextBox();
            this.b_suDe = new System.Windows.Forms.Button();
            this.b_suIn = new System.Windows.Forms.Button();
            this.l_StepUnit = new System.Windows.Forms.Label();
            this.l_Step = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.b_FlowTime = new System.Windows.Forms.Button();
            this.b_StepF = new System.Windows.Forms.Button();
            this.b_PlayF = new System.Windows.Forms.Button();
            this.b_PlayB = new System.Windows.Forms.Button();
            this.b_StopTime = new System.Windows.Forms.Button();
            this.b_StepB = new System.Windows.Forms.Button();
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
            this.b_Now = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.b_PosDe = new System.Windows.Forms.Button();
            this.b_PosIn = new System.Windows.Forms.Button();
            this.l_Lon = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_Lat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.b_Home = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.b_ViewMax = new System.Windows.Forms.Button();
            this.b_ViewIn = new System.Windows.Forms.Button();
            this.b_ViewDe = new System.Windows.Forms.Button();
            this.l_ViewAngle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.m_Select = new System.Windows.Forms.MenuItem();
            this.m_Sun = new System.Windows.Forms.MenuItem();
            this.m_Moon = new System.Windows.Forms.MenuItem();
            this.m_Mercury = new System.Windows.Forms.MenuItem();
            this.m_Venus = new System.Windows.Forms.MenuItem();
            this.m_Mars = new System.Windows.Forms.MenuItem();
            this.m_Jupiter = new System.Windows.Forms.MenuItem();
            this.m_Saturn = new System.Windows.Forms.MenuItem();
            this.m_Uranus = new System.Windows.Forms.MenuItem();
            this.m_Neptune = new System.Windows.Forms.MenuItem();
            this.m_Pluto = new System.Windows.Forms.MenuItem();
            this.m_Deselect = new System.Windows.Forms.MenuItem();
            this.tt_Stop = new System.Windows.Forms.ToolTip(this.components);
            this.tt_StepBack = new System.Windows.Forms.ToolTip(this.components);
            this.tt_StepForward = new System.Windows.Forms.ToolTip(this.components);
            this.tt_PlayBack = new System.Windows.Forms.ToolTip(this.components);
            this.tt_PlayForward = new System.Windows.Forms.ToolTip(this.components);
            this.tt_RealTimeFlow = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ZoomIn = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ZoomOut = new System.Windows.Forms.ToolTip(this.components);
            this.tt_StandardView = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lt_EarthShadow = new System.Windows.Forms.Label();
            this.lt_ConstellationLabel = new System.Windows.Forms.Label();
            this.lt_Constellation = new System.Windows.Forms.Label();
            this.lt_GridLabel = new System.Windows.Forms.Label();
            this.lt_HorGrid = new System.Windows.Forms.Label();
            this.lt_EqGrid = new System.Windows.Forms.Label();
            this.lt_MessierLabel = new System.Windows.Forms.Label();
            this.lt_Messiers = new System.Windows.Forms.Label();
            this.lt_StarLabel = new System.Windows.Forms.Label();
            this.lt_Stars = new System.Windows.Forms.Label();
            this.lt_PlanetLabel = new System.Windows.Forms.Label();
            this.lt_Planets = new System.Windows.Forms.Label();
            this.lt_HorizonLabel = new System.Windows.Forms.Label();
            this.lt_LineHorizon = new System.Windows.Forms.Label();
            this.lt_FullHorizon = new System.Windows.Forms.Label();
            this.lt_Daylight = new System.Windows.Forms.Label();
            this.lm_Select = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lm_Tools = new System.Windows.Forms.Label();
            this.lm_Data = new System.Windows.Forms.Label();
            this.pB_Space = new System.Windows.Forms.PictureBox();
            this.p_Data = new System.Windows.Forms.Panel();
            this.lm_PlanetPositions = new System.Windows.Forms.Label();
            this.lm_Ephemerides = new System.Windows.Forms.Label();
            this.lm_ViewData = new System.Windows.Forms.Label();
            this.p_Tools = new System.Windows.Forms.Panel();
            this.lm_SolarEvents = new System.Windows.Forms.Label();
            this.lm_ConjunctionFinder = new System.Windows.Forms.Label();
            this.lm_SolarSystemView = new System.Windows.Forms.Label();
            this.p_Select = new System.Windows.Forms.Panel();
            this.b_Select = new System.Windows.Forms.Button();
            this.tV_Select = new System.Windows.Forms.TreeView();
            this.tt_ShowDaylight = new System.Windows.Forms.ToolTip(this.components);
            this.tt_FullHor = new System.Windows.Forms.ToolTip(this.components);
            this.tt_LineHor = new System.Windows.Forms.ToolTip(this.components);
            this.tt_Label = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ShowPlanets = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ShowStars = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ShowMessiers = new System.Windows.Forms.ToolTip(this.components);
            this.tt_EQGrid = new System.Windows.Forms.ToolTip(this.components);
            this.tt_HORGrid = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ShowConstellations = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ES = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Space)).BeginInit();
            this.p_Data.SuspendLayout();
            this.p_Tools.SuspendLayout();
            this.p_Select.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.t_Decoy);
            this.panel1.Controls.Add(this.b_suDe);
            this.panel1.Controls.Add(this.b_suIn);
            this.panel1.Controls.Add(this.l_StepUnit);
            this.panel1.Controls.Add(this.l_Step);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.b_FlowTime);
            this.panel1.Controls.Add(this.b_StepF);
            this.panel1.Controls.Add(this.b_PlayF);
            this.panel1.Controls.Add(this.b_PlayB);
            this.panel1.Controls.Add(this.b_StopTime);
            this.panel1.Controls.Add(this.b_StepB);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.l_Year);
            this.panel1.Controls.Add(this.l_Month);
            this.panel1.Controls.Add(this.l_Day);
            this.panel1.Controls.Add(this.b_dtDe);
            this.panel1.Controls.Add(this.b_dtIn);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.l_Sec);
            this.panel1.Controls.Add(this.l_Min);
            this.panel1.Controls.Add(this.l_Hour);
            this.panel1.Controls.Add(this.b_Now);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.b_PosDe);
            this.panel1.Controls.Add(this.b_PosIn);
            this.panel1.Controls.Add(this.l_Lon);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.l_Lat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.b_Home);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 536);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 32);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(149, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(8, 23);
            this.label7.TabIndex = 49;
            // 
            // t_Decoy
            // 
            this.t_Decoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.t_Decoy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_Decoy.HideSelection = false;
            this.t_Decoy.Location = new System.Drawing.Point(152, 8);
            this.t_Decoy.Name = "t_Decoy";
            this.t_Decoy.ReadOnly = true;
            this.t_Decoy.Size = new System.Drawing.Size(2, 13);
            this.t_Decoy.TabIndex = 48;
            this.t_Decoy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t_Decoy_KeyDown);
            this.t_Decoy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.t_Decoy_KeyUp);
            this.t_Decoy.Leave += new System.EventHandler(this.t_Decoy_Leave);
            this.t_Decoy.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.t_Decoy_MouseWheel);
            // 
            // b_suDe
            // 
            this.b_suDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_suDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_suDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_suDe.Location = new System.Drawing.Point(580, 16);
            this.b_suDe.Name = "b_suDe";
            this.b_suDe.Size = new System.Drawing.Size(9, 9);
            this.b_suDe.TabIndex = 17;
            this.b_suDe.TabStop = false;
            this.b_suDe.UseVisualStyleBackColor = false;
            this.b_suDe.Visible = false;
            this.b_suDe.Click += new System.EventHandler(this.b_suDe_Click);
            // 
            // b_suIn
            // 
            this.b_suIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_suIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_suIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_suIn.Location = new System.Drawing.Point(580, 6);
            this.b_suIn.Name = "b_suIn";
            this.b_suIn.Size = new System.Drawing.Size(9, 9);
            this.b_suIn.TabIndex = 16;
            this.b_suIn.TabStop = false;
            this.b_suIn.UseVisualStyleBackColor = false;
            this.b_suIn.Visible = false;
            this.b_suIn.Click += new System.EventHandler(this.b_suIn_Click);
            // 
            // l_StepUnit
            // 
            this.l_StepUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_StepUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_StepUnit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_StepUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_StepUnit.Location = new System.Drawing.Point(532, 9);
            this.l_StepUnit.Name = "l_StepUnit";
            this.l_StepUnit.Size = new System.Drawing.Size(46, 13);
            this.l_StepUnit.TabIndex = 41;
            this.l_StepUnit.Text = "minutes";
            this.l_StepUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_StepUnit.Click += new System.EventHandler(this.l_StepUnit_Click);
            // 
            // l_Step
            // 
            this.l_Step.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Step.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Step.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Step.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Step.Location = new System.Drawing.Point(514, 11);
            this.l_Step.Name = "l_Step";
            this.l_Step.Size = new System.Drawing.Size(20, 10);
            this.l_Step.TabIndex = 40;
            this.l_Step.Text = "1";
            this.l_Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Step.Click += new System.EventHandler(this.l_Step_Click);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label20.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(484, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 12);
            this.label20.TabIndex = 39;
            this.label20.Text = "Step";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label19.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(218, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 8);
            this.label19.TabIndex = 38;
            this.label19.Text = "Date";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label18.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(217, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 8);
            this.label18.TabIndex = 37;
            this.label18.Text = "Time";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(480, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 23);
            this.label17.TabIndex = 36;
            // 
            // b_FlowTime
            // 
            this.b_FlowTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_FlowTime.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_FlowTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_FlowTime.Image = ((System.Drawing.Image)(resources.GetObject("b_FlowTime.Image")));
            this.b_FlowTime.Location = new System.Drawing.Point(434, 6);
            this.b_FlowTime.Name = "b_FlowTime";
            this.b_FlowTime.Size = new System.Drawing.Size(20, 20);
            this.b_FlowTime.TabIndex = 7;
            this.b_FlowTime.TabStop = false;
            this.tt_RealTimeFlow.SetToolTip(this.b_FlowTime, "Real Time Flow");
            this.b_FlowTime.UseVisualStyleBackColor = false;
            this.b_FlowTime.Click += new System.EventHandler(this.b_FlowTime_Click);
            // 
            // b_StepF
            // 
            this.b_StepF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_StepF.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_StepF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_StepF.Image = ((System.Drawing.Image)(resources.GetObject("b_StepF.Image")));
            this.b_StepF.Location = new System.Drawing.Point(455, 6);
            this.b_StepF.Name = "b_StepF";
            this.b_StepF.Size = new System.Drawing.Size(20, 20);
            this.b_StepF.TabIndex = 8;
            this.b_StepF.TabStop = false;
            this.tt_StepForward.SetToolTip(this.b_StepF, "Single Step Forward");
            this.b_StepF.UseVisualStyleBackColor = false;
            this.b_StepF.Click += new System.EventHandler(this.b_StepF_Click);
            // 
            // b_PlayF
            // 
            this.b_PlayF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_PlayF.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_PlayF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_PlayF.Image = ((System.Drawing.Image)(resources.GetObject("b_PlayF.Image")));
            this.b_PlayF.Location = new System.Drawing.Point(413, 6);
            this.b_PlayF.Name = "b_PlayF";
            this.b_PlayF.Size = new System.Drawing.Size(20, 20);
            this.b_PlayF.TabIndex = 6;
            this.b_PlayF.TabStop = false;
            this.tt_PlayForward.SetToolTip(this.b_PlayF, "Play Forward");
            this.b_PlayF.UseVisualStyleBackColor = false;
            this.b_PlayF.Click += new System.EventHandler(this.b_PlayF_Click);
            // 
            // b_PlayB
            // 
            this.b_PlayB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_PlayB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_PlayB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_PlayB.Image = ((System.Drawing.Image)(resources.GetObject("b_PlayB.Image")));
            this.b_PlayB.Location = new System.Drawing.Point(371, 6);
            this.b_PlayB.Name = "b_PlayB";
            this.b_PlayB.Size = new System.Drawing.Size(20, 20);
            this.b_PlayB.TabIndex = 4;
            this.b_PlayB.TabStop = false;
            this.tt_PlayBack.SetToolTip(this.b_PlayB, "Play Back");
            this.b_PlayB.UseVisualStyleBackColor = false;
            this.b_PlayB.Click += new System.EventHandler(this.b_PlayB_Click);
            // 
            // b_StopTime
            // 
            this.b_StopTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_StopTime.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_StopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_StopTime.Image = ((System.Drawing.Image)(resources.GetObject("b_StopTime.Image")));
            this.b_StopTime.Location = new System.Drawing.Point(392, 6);
            this.b_StopTime.Name = "b_StopTime";
            this.b_StopTime.Size = new System.Drawing.Size(20, 20);
            this.b_StopTime.TabIndex = 5;
            this.b_StopTime.TabStop = false;
            this.tt_Stop.SetToolTip(this.b_StopTime, "Stop");
            this.b_StopTime.UseVisualStyleBackColor = false;
            this.b_StopTime.Click += new System.EventHandler(this.b_StopTime_Click);
            // 
            // b_StepB
            // 
            this.b_StepB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_StepB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_StepB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_StepB.Image = ((System.Drawing.Image)(resources.GetObject("b_StepB.Image")));
            this.b_StepB.Location = new System.Drawing.Point(350, 6);
            this.b_StepB.Name = "b_StepB";
            this.b_StepB.Size = new System.Drawing.Size(20, 20);
            this.b_StepB.TabIndex = 3;
            this.b_StepB.TabStop = false;
            this.tt_StepBack.SetToolTip(this.b_StepB, "Single Step Back");
            this.b_StepB.UseVisualStyleBackColor = false;
            this.b_StepB.Click += new System.EventHandler(this.b_StepB_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(294, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(6, 8);
            this.label15.TabIndex = 24;
            this.label15.Text = "/";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(272, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(6, 8);
            this.label16.TabIndex = 23;
            this.label16.Text = "/";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Year
            // 
            this.l_Year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Year.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Year.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Year.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Year.Location = new System.Drawing.Point(300, 17);
            this.l_Year.Name = "l_Year";
            this.l_Year.Size = new System.Drawing.Size(30, 10);
            this.l_Year.TabIndex = 22;
            this.l_Year.Text = "1978";
            this.l_Year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Year.Click += new System.EventHandler(this.l_Year_Click);
            // 
            // l_Month
            // 
            this.l_Month.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Month.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Month.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Month.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Month.Location = new System.Drawing.Point(278, 17);
            this.l_Month.Name = "l_Month";
            this.l_Month.Size = new System.Drawing.Size(17, 10);
            this.l_Month.TabIndex = 21;
            this.l_Month.Text = "08";
            this.l_Month.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Month.Click += new System.EventHandler(this.l_Month_Click);
            // 
            // l_Day
            // 
            this.l_Day.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Day.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Day.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Day.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Day.Location = new System.Drawing.Point(256, 17);
            this.l_Day.Name = "l_Day";
            this.l_Day.Size = new System.Drawing.Size(17, 10);
            this.l_Day.TabIndex = 20;
            this.l_Day.Text = "06";
            this.l_Day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Day.Click += new System.EventHandler(this.l_Day_Click);
            // 
            // b_dtDe
            // 
            this.b_dtDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_dtDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_dtDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_dtDe.Location = new System.Drawing.Point(332, 16);
            this.b_dtDe.Name = "b_dtDe";
            this.b_dtDe.Size = new System.Drawing.Size(9, 9);
            this.b_dtDe.TabIndex = 15;
            this.b_dtDe.TabStop = false;
            this.b_dtDe.UseVisualStyleBackColor = false;
            this.b_dtDe.Visible = false;
            this.b_dtDe.Click += new System.EventHandler(this.b_dtDe_Click);
            // 
            // b_dtIn
            // 
            this.b_dtIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_dtIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_dtIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_dtIn.Location = new System.Drawing.Point(332, 6);
            this.b_dtIn.Name = "b_dtIn";
            this.b_dtIn.Size = new System.Drawing.Size(9, 9);
            this.b_dtIn.TabIndex = 14;
            this.b_dtIn.TabStop = false;
            this.b_dtIn.UseVisualStyleBackColor = false;
            this.b_dtIn.Visible = false;
            this.b_dtIn.Click += new System.EventHandler(this.b_dtIn_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(295, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(6, 8);
            this.label11.TabIndex = 17;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(273, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(6, 8);
            this.label10.TabIndex = 16;
            this.label10.Text = ":";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Sec
            // 
            this.l_Sec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Sec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Sec.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Sec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Sec.Location = new System.Drawing.Point(300, 4);
            this.l_Sec.Name = "l_Sec";
            this.l_Sec.Size = new System.Drawing.Size(17, 10);
            this.l_Sec.TabIndex = 15;
            this.l_Sec.Text = "29";
            this.l_Sec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Sec.Click += new System.EventHandler(this.l_Sec_Click);
            // 
            // l_Min
            // 
            this.l_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Min.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Min.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Min.Location = new System.Drawing.Point(278, 4);
            this.l_Min.Name = "l_Min";
            this.l_Min.Size = new System.Drawing.Size(17, 10);
            this.l_Min.TabIndex = 14;
            this.l_Min.Text = "59";
            this.l_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Min.Click += new System.EventHandler(this.l_Min_Click);
            // 
            // l_Hour
            // 
            this.l_Hour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Hour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Hour.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Hour.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Hour.Location = new System.Drawing.Point(256, 4);
            this.l_Hour.Name = "l_Hour";
            this.l_Hour.Size = new System.Drawing.Size(17, 10);
            this.l_Hour.TabIndex = 13;
            this.l_Hour.Text = "23";
            this.l_Hour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Hour.Click += new System.EventHandler(this.l_Hour_Click);
            // 
            // b_Now
            // 
            this.b_Now.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Now.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Now.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Now.Location = new System.Drawing.Point(169, 6);
            this.b_Now.Name = "b_Now";
            this.b_Now.Size = new System.Drawing.Size(40, 20);
            this.b_Now.TabIndex = 2;
            this.b_Now.TabStop = false;
            this.b_Now.Text = "Now   ";
            this.b_Now.UseVisualStyleBackColor = false;
            this.b_Now.Click += new System.EventHandler(this.b_Now_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(214, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 27);
            this.label6.TabIndex = 11;
            // 
            // b_PosDe
            // 
            this.b_PosDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_PosDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_PosDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_PosDe.Location = new System.Drawing.Point(121, 16);
            this.b_PosDe.Name = "b_PosDe";
            this.b_PosDe.Size = new System.Drawing.Size(9, 9);
            this.b_PosDe.TabIndex = 13;
            this.b_PosDe.TabStop = false;
            this.b_PosDe.UseVisualStyleBackColor = false;
            this.b_PosDe.Visible = false;
            this.b_PosDe.Click += new System.EventHandler(this.b_PosDe_Click);
            // 
            // b_PosIn
            // 
            this.b_PosIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_PosIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_PosIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_PosIn.Location = new System.Drawing.Point(121, 6);
            this.b_PosIn.Name = "b_PosIn";
            this.b_PosIn.Size = new System.Drawing.Size(9, 9);
            this.b_PosIn.TabIndex = 12;
            this.b_PosIn.TabStop = false;
            this.b_PosIn.UseVisualStyleBackColor = false;
            this.b_PosIn.Visible = false;
            this.b_PosIn.Click += new System.EventHandler(this.b_PosIn_Click);
            // 
            // l_Lon
            // 
            this.l_Lon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Lon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Lon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Lon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Lon.Location = new System.Drawing.Point(91, 17);
            this.l_Lon.Name = "l_Lon";
            this.l_Lon.Size = new System.Drawing.Size(27, 10);
            this.l_Lon.TabIndex = 7;
            this.l_Lon.Text = "-179";
            this.l_Lon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.l_Lon.Click += new System.EventHandler(this.l_Lon_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label4.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(63, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 8);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lon";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Lat
            // 
            this.l_Lat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Lat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_Lat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Lat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Lat.Location = new System.Drawing.Point(91, 4);
            this.l_Lat.Name = "l_Lat";
            this.l_Lat.Size = new System.Drawing.Size(27, 10);
            this.l_Lat.TabIndex = 5;
            this.l_Lat.Text = "-89";
            this.l_Lat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.l_Lat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_Lat_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label3.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(63, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 8);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lat";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_Home
            // 
            this.b_Home.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Home.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_Home.Location = new System.Drawing.Point(10, 6);
            this.b_Home.Name = "b_Home";
            this.b_Home.Size = new System.Drawing.Size(45, 20);
            this.b_Home.TabIndex = 1;
            this.b_Home.TabStop = false;
            this.b_Home.Text = "Home  ";
            this.b_Home.UseVisualStyleBackColor = false;
            this.b_Home.Click += new System.EventHandler(this.b_Home_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(60, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 27);
            this.label1.TabIndex = 3;
            // 
            // b_ViewMax
            // 
            this.b_ViewMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_ViewMax.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_ViewMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_ViewMax.Image = ((System.Drawing.Image)(resources.GetObject("b_ViewMax.Image")));
            this.b_ViewMax.Location = new System.Drawing.Point(771, 5);
            this.b_ViewMax.Name = "b_ViewMax";
            this.b_ViewMax.Size = new System.Drawing.Size(15, 15);
            this.b_ViewMax.TabIndex = 11;
            this.b_ViewMax.TabStop = false;
            this.tt_StandardView.SetToolTip(this.b_ViewMax, "Standard Field of View");
            this.b_ViewMax.UseVisualStyleBackColor = false;
            this.b_ViewMax.Click += new System.EventHandler(this.b_ViewMax_Click);
            // 
            // b_ViewIn
            // 
            this.b_ViewIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_ViewIn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_ViewIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_ViewIn.Image = ((System.Drawing.Image)(resources.GetObject("b_ViewIn.Image")));
            this.b_ViewIn.Location = new System.Drawing.Point(714, 5);
            this.b_ViewIn.Name = "b_ViewIn";
            this.b_ViewIn.Size = new System.Drawing.Size(15, 15);
            this.b_ViewIn.TabIndex = 10;
            this.b_ViewIn.TabStop = false;
            this.tt_ZoomOut.SetToolTip(this.b_ViewIn, "Zoom Out");
            this.b_ViewIn.UseVisualStyleBackColor = false;
            this.b_ViewIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_ViewIn_MouseDown);
            this.b_ViewIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_ViewIn_MouseUp);
            // 
            // b_ViewDe
            // 
            this.b_ViewDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_ViewDe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b_ViewDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_ViewDe.Image = ((System.Drawing.Image)(resources.GetObject("b_ViewDe.Image")));
            this.b_ViewDe.Location = new System.Drawing.Point(697, 5);
            this.b_ViewDe.Name = "b_ViewDe";
            this.b_ViewDe.Size = new System.Drawing.Size(15, 15);
            this.b_ViewDe.TabIndex = 9;
            this.b_ViewDe.TabStop = false;
            this.tt_ZoomIn.SetToolTip(this.b_ViewDe, "Zoom In");
            this.b_ViewDe.UseVisualStyleBackColor = false;
            this.b_ViewDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_ViewDe_MouseDown);
            this.b_ViewDe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_ViewDe_MouseUp);
            // 
            // l_ViewAngle
            // 
            this.l_ViewAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ViewAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.l_ViewAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_ViewAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_ViewAngle.Location = new System.Drawing.Point(731, 2);
            this.l_ViewAngle.Name = "l_ViewAngle";
            this.l_ViewAngle.Size = new System.Drawing.Size(37, 20);
            this.l_ViewAngle.TabIndex = 44;
            this.l_ViewAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // m_Select
            // 
            this.m_Select.Index = -1;
            this.m_Select.Text = "";
            // 
            // m_Sun
            // 
            this.m_Sun.Index = -1;
            this.m_Sun.Text = "";
            // 
            // m_Moon
            // 
            this.m_Moon.Index = -1;
            this.m_Moon.Text = "";
            // 
            // m_Mercury
            // 
            this.m_Mercury.Index = -1;
            this.m_Mercury.Text = "";
            // 
            // m_Venus
            // 
            this.m_Venus.Index = -1;
            this.m_Venus.Text = "";
            // 
            // m_Mars
            // 
            this.m_Mars.Index = -1;
            this.m_Mars.Text = "";
            // 
            // m_Jupiter
            // 
            this.m_Jupiter.Index = -1;
            this.m_Jupiter.Text = "";
            // 
            // m_Saturn
            // 
            this.m_Saturn.Index = -1;
            this.m_Saturn.Text = "";
            // 
            // m_Uranus
            // 
            this.m_Uranus.Index = -1;
            this.m_Uranus.Text = "";
            // 
            // m_Neptune
            // 
            this.m_Neptune.Index = -1;
            this.m_Neptune.Text = "";
            // 
            // m_Pluto
            // 
            this.m_Pluto.Index = -1;
            this.m_Pluto.Text = "";
            // 
            // m_Deselect
            // 
            this.m_Deselect.Index = -1;
            this.m_Deselect.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.lblDevice);
            this.panel2.Controls.Add(this.lt_EarthShadow);
            this.panel2.Controls.Add(this.lt_ConstellationLabel);
            this.panel2.Controls.Add(this.lt_Constellation);
            this.panel2.Controls.Add(this.lt_GridLabel);
            this.panel2.Controls.Add(this.lt_HorGrid);
            this.panel2.Controls.Add(this.lt_EqGrid);
            this.panel2.Controls.Add(this.lt_MessierLabel);
            this.panel2.Controls.Add(this.lt_Messiers);
            this.panel2.Controls.Add(this.lt_StarLabel);
            this.panel2.Controls.Add(this.lt_Stars);
            this.panel2.Controls.Add(this.lt_PlanetLabel);
            this.panel2.Controls.Add(this.lt_Planets);
            this.panel2.Controls.Add(this.lt_HorizonLabel);
            this.panel2.Controls.Add(this.lt_LineHorizon);
            this.panel2.Controls.Add(this.lt_FullHorizon);
            this.panel2.Controls.Add(this.lt_Daylight);
            this.panel2.Controls.Add(this.lm_Select);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lm_Tools);
            this.panel2.Controls.Add(this.lm_Data);
            this.panel2.Controls.Add(this.b_ViewIn);
            this.panel2.Controls.Add(this.b_ViewDe);
            this.panel2.Controls.Add(this.l_ViewAngle);
            this.panel2.Controls.Add(this.b_ViewMax);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 24);
            this.panel2.TabIndex = 5;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // lblDevice
            // 
            this.lblDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDevice.Location = new System.Drawing.Point(153, 2);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(57, 21);
            this.lblDevice.TabIndex = 66;
            this.lblDevice.Text = "Device";
            this.lblDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lt_EarthShadow
            // 
            this.lt_EarthShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_EarthShadow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_EarthShadow.Image = ((System.Drawing.Image)(resources.GetObject("lt_EarthShadow.Image")));
            this.lt_EarthShadow.Location = new System.Drawing.Point(367, 2);
            this.lt_EarthShadow.Name = "lt_EarthShadow";
            this.lt_EarthShadow.Size = new System.Drawing.Size(20, 20);
            this.lt_EarthShadow.TabIndex = 65;
            this.lt_EarthShadow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_ShowPlanets.SetToolTip(this.lt_EarthShadow, "Show Planets");
            this.tt_ES.SetToolTip(this.lt_EarthShadow, "Show earth shadow");
            this.lt_EarthShadow.Click += new System.EventHandler(this.lt_EarthShadow_Click);
            // 
            // lt_ConstellationLabel
            // 
            this.lt_ConstellationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_ConstellationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_ConstellationLabel.Image = ((System.Drawing.Image)(resources.GetObject("lt_ConstellationLabel.Image")));
            this.lt_ConstellationLabel.Location = new System.Drawing.Point(486, 2);
            this.lt_ConstellationLabel.Name = "lt_ConstellationLabel";
            this.lt_ConstellationLabel.Size = new System.Drawing.Size(20, 20);
            this.lt_ConstellationLabel.TabIndex = 64;
            this.lt_ConstellationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_Label.SetToolTip(this.lt_ConstellationLabel, "Constellations Label");
            this.lt_ConstellationLabel.Click += new System.EventHandler(this.lt_ConstellationLabel_Click);
            // 
            // lt_Constellation
            // 
            this.lt_Constellation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_Constellation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_Constellation.Image = ((System.Drawing.Image)(resources.GetObject("lt_Constellation.Image")));
            this.lt_Constellation.Location = new System.Drawing.Point(465, 2);
            this.lt_Constellation.Name = "lt_Constellation";
            this.lt_Constellation.Size = new System.Drawing.Size(20, 20);
            this.lt_Constellation.TabIndex = 63;
            this.lt_Constellation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_ShowConstellations.SetToolTip(this.lt_Constellation, "Show Constellations");
            this.lt_Constellation.Click += new System.EventHandler(this.lt_Constellation_Click);
            // 
            // lt_GridLabel
            // 
            this.lt_GridLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_GridLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_GridLabel.Image = ((System.Drawing.Image)(resources.GetObject("lt_GridLabel.Image")));
            this.lt_GridLabel.Location = new System.Drawing.Point(605, 2);
            this.lt_GridLabel.Name = "lt_GridLabel";
            this.lt_GridLabel.Size = new System.Drawing.Size(20, 20);
            this.lt_GridLabel.TabIndex = 62;
            this.lt_GridLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_Label.SetToolTip(this.lt_GridLabel, "Grid Label");
            this.lt_GridLabel.Click += new System.EventHandler(this.lt_GridLabel_Click);
            // 
            // lt_HorGrid
            // 
            this.lt_HorGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_HorGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_HorGrid.Image = ((System.Drawing.Image)(resources.GetObject("lt_HorGrid.Image")));
            this.lt_HorGrid.Location = new System.Drawing.Point(584, 2);
            this.lt_HorGrid.Name = "lt_HorGrid";
            this.lt_HorGrid.Size = new System.Drawing.Size(20, 20);
            this.lt_HorGrid.TabIndex = 61;
            this.lt_HorGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_HORGrid.SetToolTip(this.lt_HorGrid, "Horizontal Grid");
            this.lt_HorGrid.Click += new System.EventHandler(this.lt_HorGrid_Click);
            // 
            // lt_EqGrid
            // 
            this.lt_EqGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_EqGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_EqGrid.Image = ((System.Drawing.Image)(resources.GetObject("lt_EqGrid.Image")));
            this.lt_EqGrid.Location = new System.Drawing.Point(563, 2);
            this.lt_EqGrid.Name = "lt_EqGrid";
            this.lt_EqGrid.Size = new System.Drawing.Size(20, 20);
            this.lt_EqGrid.TabIndex = 60;
            this.lt_EqGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_EQGrid.SetToolTip(this.lt_EqGrid, "Equatorial Grid");
            this.lt_EqGrid.Click += new System.EventHandler(this.lt_EqGrid_Click);
            // 
            // lt_MessierLabel
            // 
            this.lt_MessierLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_MessierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_MessierLabel.Image = ((System.Drawing.Image)(resources.GetObject("lt_MessierLabel.Image")));
            this.lt_MessierLabel.Location = new System.Drawing.Point(535, 2);
            this.lt_MessierLabel.Name = "lt_MessierLabel";
            this.lt_MessierLabel.Size = new System.Drawing.Size(20, 20);
            this.lt_MessierLabel.TabIndex = 59;
            this.lt_MessierLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_Label.SetToolTip(this.lt_MessierLabel, "Messier Label");
            this.lt_MessierLabel.Click += new System.EventHandler(this.lt_MessierLabel_Click);
            // 
            // lt_Messiers
            // 
            this.lt_Messiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_Messiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_Messiers.Image = ((System.Drawing.Image)(resources.GetObject("lt_Messiers.Image")));
            this.lt_Messiers.Location = new System.Drawing.Point(514, 2);
            this.lt_Messiers.Name = "lt_Messiers";
            this.lt_Messiers.Size = new System.Drawing.Size(20, 20);
            this.lt_Messiers.TabIndex = 58;
            this.lt_Messiers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_ShowMessiers.SetToolTip(this.lt_Messiers, "Show Messier Objects");
            this.lt_Messiers.Click += new System.EventHandler(this.lt_Messiers_Click);
            // 
            // lt_StarLabel
            // 
            this.lt_StarLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_StarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_StarLabel.Image = ((System.Drawing.Image)(resources.GetObject("lt_StarLabel.Image")));
            this.lt_StarLabel.Location = new System.Drawing.Point(437, 2);
            this.lt_StarLabel.Name = "lt_StarLabel";
            this.lt_StarLabel.Size = new System.Drawing.Size(20, 20);
            this.lt_StarLabel.TabIndex = 57;
            this.lt_StarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_Label.SetToolTip(this.lt_StarLabel, "Star Label");
            this.lt_StarLabel.Click += new System.EventHandler(this.lt_StarLabel_Click);
            // 
            // lt_Stars
            // 
            this.lt_Stars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_Stars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_Stars.Image = ((System.Drawing.Image)(resources.GetObject("lt_Stars.Image")));
            this.lt_Stars.Location = new System.Drawing.Point(416, 2);
            this.lt_Stars.Name = "lt_Stars";
            this.lt_Stars.Size = new System.Drawing.Size(20, 20);
            this.lt_Stars.TabIndex = 56;
            this.lt_Stars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_ShowStars.SetToolTip(this.lt_Stars, "Show Stars");
            this.lt_Stars.Click += new System.EventHandler(this.lt_Stars_Click);
            // 
            // lt_PlanetLabel
            // 
            this.lt_PlanetLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_PlanetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_PlanetLabel.Image = ((System.Drawing.Image)(resources.GetObject("lt_PlanetLabel.Image")));
            this.lt_PlanetLabel.Location = new System.Drawing.Point(388, 2);
            this.lt_PlanetLabel.Name = "lt_PlanetLabel";
            this.lt_PlanetLabel.Size = new System.Drawing.Size(20, 20);
            this.lt_PlanetLabel.TabIndex = 55;
            this.lt_PlanetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_Label.SetToolTip(this.lt_PlanetLabel, "Planet Label");
            this.lt_PlanetLabel.Click += new System.EventHandler(this.lt_PlanetLabel_Click);
            // 
            // lt_Planets
            // 
            this.lt_Planets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_Planets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_Planets.Image = ((System.Drawing.Image)(resources.GetObject("lt_Planets.Image")));
            this.lt_Planets.Location = new System.Drawing.Point(346, 2);
            this.lt_Planets.Name = "lt_Planets";
            this.lt_Planets.Size = new System.Drawing.Size(20, 20);
            this.lt_Planets.TabIndex = 54;
            this.lt_Planets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_ShowPlanets.SetToolTip(this.lt_Planets, "Show Planets");
            this.lt_Planets.Click += new System.EventHandler(this.lt_Planets_Click);
            // 
            // lt_HorizonLabel
            // 
            this.lt_HorizonLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_HorizonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_HorizonLabel.Image = ((System.Drawing.Image)(resources.GetObject("lt_HorizonLabel.Image")));
            this.lt_HorizonLabel.Location = new System.Drawing.Point(318, 2);
            this.lt_HorizonLabel.Name = "lt_HorizonLabel";
            this.lt_HorizonLabel.Size = new System.Drawing.Size(20, 20);
            this.lt_HorizonLabel.TabIndex = 53;
            this.lt_HorizonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_Label.SetToolTip(this.lt_HorizonLabel, "Horizon Label");
            this.lt_HorizonLabel.Click += new System.EventHandler(this.lt_HorizonLabel_Click);
            // 
            // lt_LineHorizon
            // 
            this.lt_LineHorizon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_LineHorizon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_LineHorizon.Image = ((System.Drawing.Image)(resources.GetObject("lt_LineHorizon.Image")));
            this.lt_LineHorizon.Location = new System.Drawing.Point(297, 2);
            this.lt_LineHorizon.Name = "lt_LineHorizon";
            this.lt_LineHorizon.Size = new System.Drawing.Size(20, 20);
            this.lt_LineHorizon.TabIndex = 52;
            this.lt_LineHorizon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_LineHor.SetToolTip(this.lt_LineHorizon, "Line Horizon");
            this.lt_LineHorizon.Click += new System.EventHandler(this.lt_LineHorizon_Click);
            // 
            // lt_FullHorizon
            // 
            this.lt_FullHorizon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_FullHorizon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_FullHorizon.Image = ((System.Drawing.Image)(resources.GetObject("lt_FullHorizon.Image")));
            this.lt_FullHorizon.Location = new System.Drawing.Point(276, 2);
            this.lt_FullHorizon.Name = "lt_FullHorizon";
            this.lt_FullHorizon.Size = new System.Drawing.Size(20, 20);
            this.lt_FullHorizon.TabIndex = 51;
            this.lt_FullHorizon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_FullHor.SetToolTip(this.lt_FullHorizon, "Full Horizon");
            this.lt_FullHorizon.Click += new System.EventHandler(this.lt_FullHorizon_Click);
            // 
            // lt_Daylight
            // 
            this.lt_Daylight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lt_Daylight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lt_Daylight.Image = ((System.Drawing.Image)(resources.GetObject("lt_Daylight.Image")));
            this.lt_Daylight.Location = new System.Drawing.Point(255, 2);
            this.lt_Daylight.Name = "lt_Daylight";
            this.lt_Daylight.Size = new System.Drawing.Size(20, 20);
            this.lt_Daylight.TabIndex = 50;
            this.lt_Daylight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tt_ShowDaylight.SetToolTip(this.lt_Daylight, "Show Daylight");
            this.lt_Daylight.Click += new System.EventHandler(this.lt_Daylight_Click);
            // 
            // lm_Select
            // 
            this.lm_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lm_Select.Location = new System.Drawing.Point(106, 2);
            this.lm_Select.Name = "lm_Select";
            this.lm_Select.Size = new System.Drawing.Size(50, 20);
            this.lm_Select.TabIndex = 49;
            this.lm_Select.Text = "Select";
            this.lm_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_Select.MouseEnter += new System.EventHandler(this.lm_Select_MouseEnter);
            this.lm_Select.MouseLeave += new System.EventHandler(this.lm_Select_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(756, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 8);
            this.label2.TabIndex = 48;
            this.label2.Text = "o";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lm_Tools
            // 
            this.lm_Tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_Tools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lm_Tools.Location = new System.Drawing.Point(56, 2);
            this.lm_Tools.Name = "lm_Tools";
            this.lm_Tools.Size = new System.Drawing.Size(50, 20);
            this.lm_Tools.TabIndex = 2;
            this.lm_Tools.Text = "Tools";
            this.lm_Tools.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_Tools.MouseEnter += new System.EventHandler(this.lm_Tools_MouseEnter);
            this.lm_Tools.MouseLeave += new System.EventHandler(this.lm_Tools_MouseLeave);
            // 
            // lm_Data
            // 
            this.lm_Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lm_Data.Location = new System.Drawing.Point(6, 2);
            this.lm_Data.Name = "lm_Data";
            this.lm_Data.Size = new System.Drawing.Size(50, 20);
            this.lm_Data.TabIndex = 1;
            this.lm_Data.Text = "Data";
            this.lm_Data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_Data.MouseEnter += new System.EventHandler(this.lm_Data_MouseEnter);
            this.lm_Data.MouseLeave += new System.EventHandler(this.lm_Data_MouseLeave);
            // 
            // pB_Space
            // 
            this.pB_Space.BackColor = System.Drawing.Color.Black;
            this.pB_Space.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Space.Location = new System.Drawing.Point(0, 24);
            this.pB_Space.Name = "pB_Space";
            this.pB_Space.Size = new System.Drawing.Size(794, 512);
            this.pB_Space.TabIndex = 10;
            this.pB_Space.TabStop = false;
            this.pB_Space.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Space_Paint);
            this.pB_Space.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_Space_MouseDown);
            this.pB_Space.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pB_Space_MouseMove);
            this.pB_Space.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_Space_MouseUp);
            // 
            // p_Data
            // 
            this.p_Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(160)))));
            this.p_Data.Controls.Add(this.lm_PlanetPositions);
            this.p_Data.Controls.Add(this.lm_Ephemerides);
            this.p_Data.Controls.Add(this.lm_ViewData);
            this.p_Data.Location = new System.Drawing.Point(6, 24);
            this.p_Data.Name = "p_Data";
            this.p_Data.Size = new System.Drawing.Size(104, 64);
            this.p_Data.TabIndex = 13;
            this.p_Data.Visible = false;
            // 
            // lm_PlanetPositions
            // 
            this.lm_PlanetPositions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_PlanetPositions.Location = new System.Drawing.Point(2, 42);
            this.lm_PlanetPositions.Name = "lm_PlanetPositions";
            this.lm_PlanetPositions.Size = new System.Drawing.Size(100, 20);
            this.lm_PlanetPositions.TabIndex = 4;
            this.lm_PlanetPositions.Text = "Planet Positions";
            this.lm_PlanetPositions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_PlanetPositions.Click += new System.EventHandler(this.lm_PlanetPositions_Click);
            this.lm_PlanetPositions.MouseEnter += new System.EventHandler(this.lm_PlanetPositions_MouseEnter);
            this.lm_PlanetPositions.MouseLeave += new System.EventHandler(this.lm_PlanetPositions_MouseLeave);
            // 
            // lm_Ephemerides
            // 
            this.lm_Ephemerides.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_Ephemerides.Location = new System.Drawing.Point(2, 22);
            this.lm_Ephemerides.Name = "lm_Ephemerides";
            this.lm_Ephemerides.Size = new System.Drawing.Size(100, 20);
            this.lm_Ephemerides.TabIndex = 3;
            this.lm_Ephemerides.Text = "Ephemerides";
            this.lm_Ephemerides.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_Ephemerides.Click += new System.EventHandler(this.lm_Ephemerides_Click);
            this.lm_Ephemerides.MouseEnter += new System.EventHandler(this.lm_Ephemerides_MouseEnter);
            this.lm_Ephemerides.MouseLeave += new System.EventHandler(this.lm_Ephemerides_MouseLeave);
            // 
            // lm_ViewData
            // 
            this.lm_ViewData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_ViewData.Location = new System.Drawing.Point(2, 2);
            this.lm_ViewData.Name = "lm_ViewData";
            this.lm_ViewData.Size = new System.Drawing.Size(100, 20);
            this.lm_ViewData.TabIndex = 2;
            this.lm_ViewData.Text = "View Location";
            this.lm_ViewData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_ViewData.Click += new System.EventHandler(this.lm_ViewData_Click);
            this.lm_ViewData.MouseEnter += new System.EventHandler(this.lm_ViewData_MouseEnter);
            this.lm_ViewData.MouseLeave += new System.EventHandler(this.lm_ViewData_MouseLeave);
            // 
            // p_Tools
            // 
            this.p_Tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(160)))));
            this.p_Tools.Controls.Add(this.lm_SolarEvents);
            this.p_Tools.Controls.Add(this.lm_ConjunctionFinder);
            this.p_Tools.Controls.Add(this.lm_SolarSystemView);
            this.p_Tools.Location = new System.Drawing.Point(56, 24);
            this.p_Tools.Name = "p_Tools";
            this.p_Tools.Size = new System.Drawing.Size(124, 64);
            this.p_Tools.TabIndex = 14;
            this.p_Tools.Visible = false;
            // 
            // lm_SolarEvents
            // 
            this.lm_SolarEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_SolarEvents.Location = new System.Drawing.Point(2, 42);
            this.lm_SolarEvents.Name = "lm_SolarEvents";
            this.lm_SolarEvents.Size = new System.Drawing.Size(120, 20);
            this.lm_SolarEvents.TabIndex = 4;
            this.lm_SolarEvents.Text = "Solar Events";
            this.lm_SolarEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_SolarEvents.Click += new System.EventHandler(this.lm_SolarEvents_Click);
            this.lm_SolarEvents.MouseEnter += new System.EventHandler(this.lm_SolarEvents_MouseEnter);
            this.lm_SolarEvents.MouseLeave += new System.EventHandler(this.lm_SolarEvents_MouseLeave);
            // 
            // lm_ConjunctionFinder
            // 
            this.lm_ConjunctionFinder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_ConjunctionFinder.Location = new System.Drawing.Point(2, 22);
            this.lm_ConjunctionFinder.Name = "lm_ConjunctionFinder";
            this.lm_ConjunctionFinder.Size = new System.Drawing.Size(120, 20);
            this.lm_ConjunctionFinder.TabIndex = 3;
            this.lm_ConjunctionFinder.Text = "Conjunction Finder";
            this.lm_ConjunctionFinder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_ConjunctionFinder.Click += new System.EventHandler(this.lm_ConjunctionFinder_Click);
            this.lm_ConjunctionFinder.MouseEnter += new System.EventHandler(this.lm_ConjunctionFinder_MouseEnter);
            this.lm_ConjunctionFinder.MouseLeave += new System.EventHandler(this.lm_ConjunctionFinder_MouseLeave);
            // 
            // lm_SolarSystemView
            // 
            this.lm_SolarSystemView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lm_SolarSystemView.Location = new System.Drawing.Point(2, 2);
            this.lm_SolarSystemView.Name = "lm_SolarSystemView";
            this.lm_SolarSystemView.Size = new System.Drawing.Size(120, 20);
            this.lm_SolarSystemView.TabIndex = 2;
            this.lm_SolarSystemView.Text = "Solar System View";
            this.lm_SolarSystemView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lm_SolarSystemView.Click += new System.EventHandler(this.lm_SolarSystemView_Click);
            this.lm_SolarSystemView.MouseEnter += new System.EventHandler(this.lm_SolarSystemView_MouseEnter);
            this.lm_SolarSystemView.MouseLeave += new System.EventHandler(this.lm_SolarSystemView_MouseLeave);
            // 
            // p_Select
            // 
            this.p_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(160)))));
            this.p_Select.Controls.Add(this.b_Select);
            this.p_Select.Controls.Add(this.tV_Select);
            this.p_Select.Location = new System.Drawing.Point(106, 24);
            this.p_Select.Name = "p_Select";
            this.p_Select.Size = new System.Drawing.Size(145, 216);
            this.p_Select.TabIndex = 15;
            this.p_Select.Visible = false;
            // 
            // b_Select
            // 
            this.b_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.b_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Select.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_Select.Location = new System.Drawing.Point(2, 196);
            this.b_Select.Name = "b_Select";
            this.b_Select.Size = new System.Drawing.Size(142, 18);
            this.b_Select.TabIndex = 1;
            this.b_Select.Text = "Center and Lock";
            this.b_Select.UseVisualStyleBackColor = false;
            this.b_Select.Click += new System.EventHandler(this.b_Select_Click);
            // 
            // tV_Select
            // 
            this.tV_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.tV_Select.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tV_Select.FullRowSelect = true;
            this.tV_Select.HideSelection = false;
            this.tV_Select.Location = new System.Drawing.Point(2, 2);
            this.tV_Select.Name = "tV_Select";
            treeNode1.Name = "";
            treeNode1.Text = "Mercury";
            treeNode2.Name = "";
            treeNode2.Text = "Venus";
            treeNode3.Name = "";
            treeNode3.Text = "Moon";
            treeNode4.Name = "";
            treeNode4.Text = "Earth shadow";
            treeNode5.Name = "";
            treeNode5.Text = "Earth";
            treeNode6.Name = "";
            treeNode6.Text = "Mars";
            treeNode7.Name = "";
            treeNode7.Text = "Jupiter";
            treeNode8.Name = "";
            treeNode8.Text = "Saturn";
            treeNode9.Name = "";
            treeNode9.Text = "Uranus";
            treeNode10.Name = "";
            treeNode10.Text = "Neptune";
            treeNode11.Name = "";
            treeNode11.Text = "Pluto";
            treeNode12.Name = "";
            treeNode12.Text = "Sun";
            this.tV_Select.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.tV_Select.Scrollable = false;
            this.tV_Select.Size = new System.Drawing.Size(142, 193);
            this.tV_Select.TabIndex = 0;
            this.tV_Select.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tV_Select_AfterSelect);
            // 
            // f_MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.p_Select);
            this.Controls.Add(this.p_Tools);
            this.Controls.Add(this.p_Data);
            this.Controls.Add(this.pB_Space);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "f_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.f_MainForm_Activated);
            this.Load += new System.EventHandler(this.f_MainForm_Load);
            this.Resize += new System.EventHandler(this.f_MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Space)).EndInit();
            this.p_Data.ResumeLayout(false);
            this.p_Tools.ResumeLayout(false);
            this.p_Select.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new f_MainForm());
        }

        private void f_MainForm_Load(object sender, System.EventArgs e)
        {
            location.TimeNow();
            this.UpdateLabel();

            skyView.origin.X = pB_Space.Width / 2;
            skyView.origin.Y = pB_Space.Height / 2;

            for (int i = 0, a = 90; i < 19; ++i, a -= 10)
            {
                for (int j = 0, A = 0; j < 25; ++j, A += 15)
                {
                    skyView.grid[i, j] = new SkyPosition();
                    skyView.EQgrid[i, j] = new SkyPosition();

                    skyView.grid[i, j].a = a;
                    skyView.grid[i, j].A = A;

                    skyView.EQgrid[i, j].Declination = a;
                    skyView.EQgrid[i, j].Rectascence = A;
                }
            }

            for (int i = 0; i < 8; ++i)
            {
                skyView.direction[i].a = 0;
                skyView.direction[i].A = i * 45;
            }

            skyView.direction[8].a = 90;
            skyView.direction[8].A = 0;
            skyView.direction[9].a = -90;
            skyView.direction[9].A = 0;

            skyView.center.a = 0;
            skyView.center.A = 180;

            skyView.Calculations(true);

            if (skyView.bDay == true) lt_Daylight.BackColor = Color.Red;
            if (skyView.bFull == true) lt_FullHorizon.BackColor = Color.Red;
            if (skyView.bLine == true) lt_LineHorizon.BackColor = Color.Red;
            if (skyView.bComp == true) lt_HorizonLabel.BackColor = Color.Red;

            if (skyView.bShowPl == true) lt_Planets.BackColor = Color.Red;
            if (skyView.bPlLabel == true) lt_PlanetLabel.BackColor = Color.Red;

            if (skyView.bShowSt == true) lt_Stars.BackColor = Color.Red;
            if (skyView.bStLabel == true) lt_StarLabel.BackColor = Color.Red;

            if (skyView.bShowCo == true) lt_Constellation.BackColor = Color.Red;
            if (skyView.bCoLabel == true) lt_ConstellationLabel.BackColor = Color.Red;

            if (skyView.bShowM == true) lt_Messiers.BackColor = Color.Red;
            if (skyView.bMLabel == true) lt_MessierLabel.BackColor = Color.Red;

            if (skyView.bShowHOR == true) lt_HorGrid.BackColor = Color.Red;
            if (skyView.bShowEQ == true) lt_EqGrid.BackColor = Color.Red;
            if (skyView.bGridLabel == true) lt_GridLabel.BackColor = Color.Red;

            tV_Select.ExpandAll();

            this.ConnectToSpaceBoard();
        }

        #region Space Board

        private void ConnectToSpaceBoard()
        {
            try
            {
                device = Model1.NewDevice("COM3");

                device.OnCompasChange += Device_OnCompasChange;
                device.OnConnect += Device_OnConnect;
                device.OnDisconnect += Device_OnDisconnect;
                device.OnReady += Device_OnReady;
                device.Connect();
                device.Reset();

                Console.WriteLine("Waiting for device...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void DisconnectFromSpaceBoard()
        {
            try
            {
                device.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Device_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Decvice Connected...");
        }

        private void Device_OnDisconnect(object sender, EventArgs e)
        {
            Console.WriteLine("Decvice Connected...");
        }

        private void Device_OnReady(object sender, EventArgs e)
        {
            device.Enable();
            Console.WriteLine("Device ready...");
        }

        private void Device_OnCompasChange(object sender, EventArgsVector3 e)
        {
            if (mDown)
            {
                return;
            }

            Vector3 vector = e.Value;
            double heading = this.Heading(vector.Y, vector.X);

            Console.WriteLine("Vector: {0:#,###.##}, {1:#,###.##}, {2:#,###.##}, {3:#,###.##}",
                vector.X, vector.Y, vector.Z, heading);

            skyView.selected = false;
            skyView.selPl = "";

            skyView.center.A = heading;
            skyView.center.a = -vector.Y;
            if (skyView.center.a > 90) skyView.center.a = 90;
            if (skyView.center.a < -90) skyView.center.a = -90;

            pB_Space.Invalidate();
        }

        private double Heading(float x, float y)
        {
            // Hold the module so that Z is pointing 'up' and you can measure the heading with x&y
            // Calculate heading when the magnetometer is level, then correct for signs of axis.
            double heading = Math.Atan2(y, x);

            // Once you have your heading, you must then add your 'Declination Angle', which is the 'Error' of the magnetic field in your location.
            // Find yours here: http://www.magnetic-declination.com/
            // Mine is: -13* 2' W, which is ~13 Degrees, or (which we need) 0.22 radians
            // If you cannot find your Declination, comment out these two lines, your compass will be slightly off.
            double declinationAngle = 0.22f;
            heading += declinationAngle;

            // Correct for when signs are reversed.
            if (heading < 0)
            {
                heading += (2 * Math.PI);
            }

            // Check for wrap due to addition of declination.
            if (heading > (2 * Math.PI))
            {
                heading -= (2 * Math.PI);
            }

            // Convert radians to degrees for readability.
            double headingDegrees = (heading * (180 / Math.PI));

            return headingDegrees;
        }

        #endregion

        private void m_SolarSystemView_Click(object sender, System.EventArgs e)
        {
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            NormalizeButton();
            skyView.f_pp.Close();
            f_SolarSystem f_ssv = new f_SolarSystem();
            f_ssv.ShowDialog();
        }

        private void m_ConjunctionFinder_Click(object sender, System.EventArgs e)
        {
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            skyView.f_pp.Close();
            NormalizeButton();
            f_SolarSystem f_cf = new f_SolarSystem("cf");
            f_cf.ShowDialog();
        }

        private void m_SolarEvents_Click(object sender, System.EventArgs e)
        {
            skyView.f_pp.Close();
            f_SolarEvents f_sv = new f_SolarEvents();
            f_sv.ShowDialog();
        }

        private void m_Exit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void UpdateLabel()
        {
            l_ViewAngle.Text = (2 * skyView.viewAngle).ToString();
            l_Lat.Text = location.Latitude.ToString();
            l_Lon.Text = location.Longitude.ToString();

            l_Hour.Text = location.MainDateTime.Hour.ToString();
            l_Min.Text = location.MainDateTime.Minute.ToString();
            l_Sec.Text = location.MainDateTime.Second.ToString();
            l_Day.Text = location.MainDateTime.Day.ToString();
            l_Month.Text = location.MainDateTime.Month.ToString();
            l_Year.Text = location.MainDateTime.Year.ToString();

            l_Step.Text = location.Step.ToString();
            l_StepUnit.Text = location.v_unit;
        }

        private void NormalizeLabel()
        {
            switch (selected)
            {
                case "l_Lat":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Lat.BackColor = Color.FromArgb(175, 175, 100);
                        l_Lat.ForeColor = Color.Black;
                        break;
                    }
                case "l_Lon":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Lon.BackColor = Color.FromArgb(175, 175, 100);
                        l_Lon.ForeColor = Color.Black;
                        break;
                    }
                case "l_Hour":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Hour.BackColor = Color.FromArgb(175, 175, 100);
                        l_Hour.ForeColor = Color.Black;
                        break;
                    }
                case "l_Min":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Min.BackColor = Color.FromArgb(175, 175, 100);
                        l_Min.ForeColor = Color.Black;
                        break;
                    }
                case "l_Sec":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Sec.BackColor = Color.FromArgb(175, 175, 100);
                        l_Sec.ForeColor = Color.Black;
                        break;
                    }
                case "l_Day":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Day.BackColor = Color.FromArgb(175, 175, 100);
                        l_Day.ForeColor = Color.Black;
                        break;
                    }
                case "l_Month":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Month.BackColor = Color.FromArgb(175, 175, 100);
                        l_Month.ForeColor = Color.Black;
                        break;
                    }
                case "l_Year":
                    {
                        b_PosIn.Visible = false;
                        b_PosDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Year.BackColor = Color.FromArgb(175, 175, 100);
                        l_Year.ForeColor = Color.Black;
                        break;
                    }
                case "l_Step":
                    {
                        b_suIn.Visible = false;
                        b_suDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_Step.BackColor = Color.FromArgb(175, 175, 100);
                        l_Step.ForeColor = Color.Black;
                        break;
                    }
                case "l_StepUnit":
                    {
                        b_suIn.Visible = false;
                        b_suDe.Visible = false;
                        b_dtIn.Visible = false;
                        b_dtDe.Visible = false;
                        l_StepUnit.BackColor = Color.FromArgb(175, 175, 100);
                        l_StepUnit.ForeColor = Color.Black;
                        break;
                    }
            }
            selected = "";
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
                location.MainDateTime = location.dtMin;
                UpdateLabel();
            }
            if (location.MainDateTime > location.dtMax)
            {
                location.MainDateTime = location.dtMax;
                UpdateLabel();
            }
            changePos = true;
            pB_Space.Invalidate();
        }

        private void l_Lat_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Lat";
            b_PosIn.Visible = true;
            b_PosDe.Visible = true;
            l_Lat.BackColor = Color.Brown;
            l_Lat.ForeColor = Color.White;
        }

        private void l_Lon_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Lon";
            b_PosIn.Visible = true;
            b_PosDe.Visible = true;
            l_Lon.BackColor = Color.Brown;
            l_Lon.ForeColor = Color.White;
        }

        private void b_PosIn_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            changePos = true;
            if (selected == "l_Lat" && location.Latitude < 90)
            {
                ++location.Latitude;
                UpdateLabel();
                pB_Space.Invalidate();
            }
            if (selected == "l_Lon" && location.Longitude < 180)
            {
                ++location.Longitude;
                UpdateLabel();
                pB_Space.Invalidate();
            }
        }

        private void b_PosDe_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            changePos = true;
            if (selected == "l_Lat" && location.Latitude > -90)
            {
                --location.Latitude;
                UpdateLabel();
                pB_Space.Invalidate();
            }
            if (selected == "l_Lon" && location.Longitude > -179)
            {
                --location.Longitude;
                UpdateLabel();
                pB_Space.Invalidate();
            }
        }

        private void l_Hour_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Hour";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Hour.BackColor = Color.Brown;
            l_Hour.ForeColor = Color.White;
        }

        private void l_Min_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Min";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Min.BackColor = Color.Brown;
            l_Min.ForeColor = Color.White;
        }

        private void l_Sec_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Sec";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Sec.BackColor = Color.Brown;
            l_Sec.ForeColor = Color.White;
        }

        private void l_Day_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Day";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Day.BackColor = Color.Brown;
            l_Day.ForeColor = Color.White;
        }

        private void l_Month_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Month";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Month.BackColor = Color.Brown;
            l_Month.ForeColor = Color.White;
        }

        private void l_Year_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Year";
            b_dtIn.Visible = true;
            b_dtDe.Visible = true;
            l_Year.BackColor = Color.Brown;
            l_Year.ForeColor = Color.White;
        }

        private void b_dtIn_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            changePos = true;
            ChangeTime(1);
        }

        private void b_dtDe_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            changePos = true;
            ChangeTime(-1);
        }

        private void b_Now_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            location.TimeNow();
            UpdateLabel();
            NormalizeLabel();
            changePos = true;
            pB_Space.Invalidate();
        }

        private void b_Home_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            changePos = true;
            location.Latitude = location.HomeLatitude;
            location.Longitude = location.HomeLongitude;
            UpdateLabel();
            NormalizeLabel();
            pB_Space.Invalidate();
        }

        private void f_MainForm_Activated(object sender, System.EventArgs e)
        {
            UpdateLabel();
            changePos = true;
            pB_Space.Invalidate();
        }

        private void pB_Space_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            skyView.Calculations(changePos);

            double sun = skyView.SunAlt;
            if (skyView.bDay)
            {
                if (sun >= -15 && sun < 0)
                    pB_Space.BackColor = Color.FromArgb((int)(155 + 10 * sun), (int)(205 + 13 * sun), (int)(254 + 15 * sun));
                if (sun >= 0) pB_Space.BackColor = Color.FromArgb(155, 205, 254);
                if (sun < -15) pB_Space.BackColor = Color.Black;
            }
            else pB_Space.BackColor = Color.Black;
            Color color = pB_Space.BackColor;
            if (pB_Space.BackColor == Color.Black)
                skyView.moonColor = Color.FromArgb(230, 10, 10, 10);
            else skyView.moonColor = Color.FromArgb(240, color.R, color.G, color.B);

            skyView.DrawGrid(e.Graphics);
            if (skyView.bShowCo && (!skyView.bDay || sun <= 0))
                skyView.DrawConstellations(e.Graphics);
            if (skyView.bShowSt && (!skyView.bDay || sun <= 0))
                skyView.DrawStars(e.Graphics);
            if (skyView.bShowM) skyView.DrawMessier(e.Graphics);
            if (skyView.bShowPl) skyView.DrawSol(e.Graphics);
            if (skyView.bFull || skyView.bLine) skyView.DrawHorizon(e.Graphics);
            if (skyView.bComp) skyView.DrawDirection(e.Graphics, zenith);
            skyView.textPtArr.Clear();
            changePos = false;
        }

        private void f_MainForm_Resize(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            skyView.origin.X = pB_Space.Width / 2;
            skyView.origin.Y = pB_Space.Height / 2;
            pB_Space.Invalidate();
        }

        private void m_ViewLocation_Click(object sender, System.EventArgs e)
        {
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            NormalizeButton();
            skyView.f_pp.Close();
            changePos = true;
            f_ViewLocation f_vl = new f_ViewLocation();
            f_vl.ShowDialog();
        }

        private void pB_Space_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p_Data.Visible = false;
                p_Tools.Visible = false;
                p_Select.Visible = false;
                NormalizeLabel();
                skyView.selected = false;
                skyView.Calculations(true);
                timer2.Stop(); timer3.Stop();
                NormalizeLabel();
                pB_Space.Cursor = closedH;
                mDown = true; zenith = true;
                pOld.X = e.X; pOld.Y = e.Y;
            }
        }

        private void pB_Space_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mDown)
            {
                skyView.selected = false;
                skyView.selPl = "";
                pNew.X = e.X;
                pNew.Y = e.Y;
                double dx = pNew.X - pOld.X;
                double dy = pNew.Y - pOld.Y;
                double f = pB_Space.Width / (2 * skyView.viewAngle);

                skyView.center.A = (skyView.center.A - dx / f + 360) % 360;
                skyView.center.a += dy / f;
                if (skyView.center.a > 90) skyView.center.a = 90;
                if (skyView.center.a < -90) skyView.center.a = -90;

                //Console.WriteLine("a: {0}, A: {1}", skyView.center.a, skyView.center.A);
                pOld.X = pNew.X;
                pOld.Y = pNew.Y;
                pB_Space.Invalidate();
            }
        }

        private void pB_Space_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pB_Space.Cursor = openH;
            mDown = false; zenith = false;
            pB_Space.Invalidate();
            if (T == "timer2") timer2.Start();
            if (T == "timer3") timer3.Start();
        }

        private void ChangeVA()
        {
            timer1 = new Timer();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            double step = 1;
            if (skyView.viewAngle < 1) step = 0.125;
            if (XX == 'D')
            {
                if (skyView.viewAngle <= 2) step = 0.25;
                if (skyView.viewAngle > 0.25)
                {
                    skyView.viewAngle -= step;
                    UpdateLabel();
                    pB_Space.Invalidate();
                }
            }
            if (XX == 'I')
            {
                if (skyView.viewAngle < 2) step = 0.25;
                if (skyView.viewAngle < 50)
                {
                    skyView.viewAngle += step;
                    UpdateLabel();
                    pB_Space.Invalidate();
                }
            }
        }

        private void b_ViewDe_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (e.Button == MouseButtons.Left)
            {
                skyView.Calculations(true);
                timer2.Stop();
                timer3.Stop();
                XX = 'D';
                changePos = false;
                ChangeVA();
            }
        }

        private void b_ViewDe_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                if (T == "timer2") timer2.Start();
                if (T == "timer3") timer3.Start();
            }
        }

        private void b_ViewMax_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            skyView.viewAngle = 50;
            UpdateLabel();
            pB_Space.Invalidate();
        }

        private void b_ViewIn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (e.Button == MouseButtons.Left)
            {
                skyView.Calculations(true);
                timer2.Stop();
                timer3.Stop();
                XX = 'I';
                changePos = false;
                ChangeVA();
            }
        }

        private void b_ViewIn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                if (T == "timer2") timer2.Start();
                if (T == "timer3") timer3.Start();
            }
        }

        private void l_Step_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_Step";
            b_suIn.Visible = true;
            b_suDe.Visible = true;
            l_Step.BackColor = Color.Brown;
            l_Step.ForeColor = Color.White;
        }

        private void l_StepUnit_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            NormalizeLabel();
            selected = "l_StepUnit";
            b_suIn.Visible = true;
            b_suDe.Visible = true;
            l_StepUnit.BackColor = Color.Brown;
            l_StepUnit.ForeColor = Color.White;
        }

        private void b_suIn_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (selected == "l_Step" && location.Step < 60)
            {
                ++location.Step;
                l_Step.Text = location.Step.ToString();
            }
            if (selected == "l_StepUnit" && strIndex < 5)
            {
                ++strIndex;
                location.v_unit = timeUnit[strIndex];
                l_StepUnit.Text = location.v_unit.ToString();
            }
        }

        private void b_suDe_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (selected == "l_Step" && location.Step > 1)
            {
                --location.Step;
                l_Step.Text = location.Step.ToString();
            }
            if (selected == "l_StepUnit" && strIndex > 0)
            {
                --strIndex;
                location.v_unit = timeUnit[strIndex];
                l_StepUnit.Text = location.v_unit.ToString();
            }
        }

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            TimerWork(n);
        }

        private void TimerWork(short i)
        {
            switch (location.v_unit)
            {
                case "seconds":
                    {
                        location.MainDateTime = location.MainDateTime.AddSeconds(i * location.Step);
                        UpdateLabel();
                        changePos = true;
                        pB_Space.Invalidate();
                        break;
                    }
                case "minutes":
                    {
                        location.MainDateTime = location.MainDateTime.AddMinutes(i * location.Step);
                        UpdateLabel();
                        changePos = true;
                        pB_Space.Invalidate();
                        break;
                    }
                case "hours":
                    {
                        location.MainDateTime = location.MainDateTime.AddHours(i * location.Step);
                        UpdateLabel();
                        changePos = true;
                        pB_Space.Invalidate();
                        break;
                    }
                case "days":
                    {
                        location.MainDateTime = location.MainDateTime.AddDays(i * location.Step);
                        UpdateLabel();
                        changePos = true;
                        pB_Space.Invalidate();
                        break;
                    }
                case "months":
                    {
                        location.MainDateTime = location.MainDateTime.AddMonths(i * location.Step);
                        UpdateLabel();
                        changePos = true;
                        pB_Space.Invalidate();
                        break;
                    }
                case "years":
                    {
                        location.MainDateTime = location.MainDateTime.AddYears(i * location.Step);
                        UpdateLabel();
                        changePos = true;
                        pB_Space.Invalidate();
                        break;
                    }
            }
            if (location.MainDateTime < location.dtMin)
            {
                location.MainDateTime = location.dtMin;
                UpdateLabel();
                NormalizeButton();
                timerRun = false;
            }
            if (location.MainDateTime > location.dtMax)
            {
                location.MainDateTime = location.dtMax;
                UpdateLabel();
                NormalizeButton();
                timerRun = false;
            }
        }

        private void b_PlayF_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (location.MainDateTime < location.dtMax)
            {
                timerRun = true;
                NormalizeButton();
                b_PlayF.FlatStyle = FlatStyle.Flat;
                timer2.Stop();
                timer3.Stop();
                n = 1;
                timer2 = new Timer();
                timer2.Interval = 20;
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Enabled = true;
                timer2.Start();
                T = "timer2";
            }
        }

        private void b_StopTime_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            timerRun = false;
            changePos = true;
            NormalizeButton();
            T = "";
        }

        private void b_StepB_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            timerRun = false;
            NormalizeButton();
            T = "";
            TimerWork(-1);
        }

        private void b_StepF_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            timerRun = false;
            NormalizeButton();
            T = "";
            TimerWork(1);
        }

        private void b_PlayB_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (location.MainDateTime > location.dtMin)
            {
                timerRun = true;
                NormalizeButton();
                b_PlayB.FlatStyle = FlatStyle.Flat;
                n = -1;
                timer2 = new Timer();
                timer2.Interval = 20;
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Enabled = true;
                timer2.Start();
                T = "timer2";
            }
        }

        private void b_FlowTime_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
            if (location.MainDateTime < location.dtMax)
            {
                timerRun = true;
                NormalizeButton();
                b_FlowTime.FlatStyle = FlatStyle.Flat;
                timer3 = new Timer();
                timer3.Interval = 1000;
                timer3.Tick += new EventHandler(timer3_Tick);
                timer3.Enabled = true;
                timer3.Start();
                T = "timer3";
            }
        }

        private void timer3_Tick(object sender, System.EventArgs e)
        {
            location.MainDateTime = location.MainDateTime.AddSeconds(1);
            UpdateLabel();
            changePos = true;
            pB_Space.Invalidate();
        }

        private void NormalizeButton()
        {
            timer2.Stop();
            timer3.Stop();
            NormalizeLabel();
            b_FlowTime.FlatStyle = FlatStyle.Standard;
            b_PlayB.FlatStyle = FlatStyle.Standard;
            b_PlayF.FlatStyle = FlatStyle.Standard;
            b_StopTime.FlatStyle = FlatStyle.Standard;
            pB_Space.Invalidate();
        }

        private void m_Ephemerides_Click(object sender, System.EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            timerRun = false;
            T = "";
            skyView.f_pp.Close();
            NormalizeButton();
            f_PlanetData f_pd = new f_PlanetData();
            f_pd.ShowDialog();
        }

        private void m_PlanetPosition_Click(object sender, System.EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            timerRun = false;
            T = "";
            NormalizeButton();
            skyView.f_pp = new f_PlanetPosition();
            skyView.f_pp.Show();
        }

        private void UnCheckSel()
        {
            m_Sun.Checked = false;
            m_Moon.Checked = false;
            m_Mercury.Checked = false;
            m_Venus.Checked = false;
            m_Mars.Checked = false;
            m_Jupiter.Checked = false;
            m_Saturn.Checked = false;
            m_Uranus.Checked = false;
            m_Neptune.Checked = false;
            m_Pluto.Checked = false;
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
            else
            {
                if (e.KeyCode == Keys.Left)
                {
                    skyView.selected = false;
                    timer2.Stop(); timer3.Stop(); zenith = true;
                    skyView.center.A = (skyView.center.A - (skyView.viewAngle / 10)) % 360;
                    pB_Space.Invalidate();
                }
                if (e.KeyCode == Keys.Right)
                {
                    skyView.selected = false;
                    timer2.Stop(); timer3.Stop(); zenith = true;
                    skyView.center.A = (skyView.center.A + (skyView.viewAngle / 10)) % 360;
                    pB_Space.Invalidate();
                }
                if (e.KeyCode == Keys.Up)
                {
                    skyView.selected = false;
                    timer2.Stop(); timer3.Stop(); zenith = true;
                    if (skyView.center.a < 90)
                        skyView.center.a += (skyView.viewAngle / 10);
                    else
                        skyView.center.a = 90;
                    pB_Space.Invalidate();
                }
                if (e.KeyCode == Keys.Down)
                {
                    skyView.selected = false;
                    timer2.Stop(); timer3.Stop(); zenith = true;
                    if (skyView.center.a > -90)
                        skyView.center.a -= (skyView.viewAngle / 10);
                    else
                        skyView.center.a = -90;
                    pB_Space.Invalidate();
                }
                if (e.KeyCode == Keys.PageUp)
                {
                    timer2.Stop(); timer3.Stop();
                    double step = 1;
                    if (skyView.viewAngle <= 2) step = 0.25;
                    if (skyView.viewAngle < 1) step = 0.125;
                    if (skyView.viewAngle > 0.25)
                    {
                        skyView.viewAngle -= step;
                        UpdateLabel();
                        pB_Space.Invalidate();
                    }
                }
                if (e.KeyCode == Keys.PageDown)
                {
                    timer2.Stop(); timer3.Stop();
                    double step = 1;
                    if (skyView.viewAngle < 2) step = 0.25;
                    if (skyView.viewAngle < 1) step = 0.125;
                    if (skyView.viewAngle < 50)
                    {
                        skyView.viewAngle += step;
                        UpdateLabel();
                        pB_Space.Invalidate();
                    }
                }
            }
        }

        private void t_Decoy_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                zenith = false;
                dt = 1;
                pB_Space.Invalidate();
                if (T == "timer2") timer2.Start();
                if (T == "timer3") timer3.Start();
            }
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown)
            {
                if (T == "timer2") timer2.Start();
                if (T == "timer3") timer3.Start();
            }
        }

        private void t_Decoy_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer2.Stop(); timer3.Stop();
            double step = 1;

            if (e.Delta < 0)
            {
                if (skyView.viewAngle < 2) step = 0.25;
                if (skyView.viewAngle < 1) step = 0.125;
                if (skyView.viewAngle < 50) skyView.viewAngle += step;
            }
            else if (e.Delta > 0)
            {
                step = 1;
                if (skyView.viewAngle <= 2) step = 0.25;
                if (skyView.viewAngle < 1) step = 0.125;
                if (skyView.viewAngle > 0.25) skyView.viewAngle -= step;
            }
            UpdateLabel();
            pB_Space.Invalidate();
        }

        private void t_Decoy_Leave(object sender, System.EventArgs e)
        {
            t_Decoy.Select();
        }

        private void lm_Data_MouseEnter(object sender, System.EventArgs e)
        {
            p_Tools.Visible = false;
            p_Select.Visible = false;
            lm_Data.BackColor = Color.Brown;
            lm_Data.ForeColor = Color.White;
            p_Data.Visible = true;
        }

        private void lm_Data_MouseLeave(object sender, System.EventArgs e)
        {
            lm_Data.BackColor = Color.FromArgb(175, 175, 100);
            lm_Data.ForeColor = Color.Black;
        }

        private void lm_ViewData_MouseEnter(object sender, System.EventArgs e)
        {
            lm_ViewData.BackColor = Color.Brown;
            lm_ViewData.ForeColor = Color.White;
        }

        private void lm_ViewData_MouseLeave(object sender, System.EventArgs e)
        {
            lm_ViewData.BackColor = Color.FromArgb(175, 175, 100);
            lm_ViewData.ForeColor = Color.Black;
        }

        private void lm_ViewData_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            NormalizeButton();
            skyView.f_pp.Close();
            changePos = true;
            f_ViewLocation f_vl = new f_ViewLocation();
            f_vl.ShowDialog();
        }

        private void lm_Ephemerides_MouseEnter(object sender, System.EventArgs e)
        {
            lm_Ephemerides.BackColor = Color.Brown;
            lm_Ephemerides.ForeColor = Color.White;
        }

        private void lm_Ephemerides_MouseLeave(object sender, System.EventArgs e)
        {
            lm_Ephemerides.BackColor = Color.FromArgb(175, 175, 100);
            lm_Ephemerides.ForeColor = Color.Black;
        }

        private void lm_Ephemerides_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            timer2.Stop();
            timer3.Stop();
            timerRun = false;
            T = "";
            skyView.f_pp.Close();
            NormalizeButton();
            f_PlanetData f_pd = new f_PlanetData();
            f_pd.ShowDialog();
        }

        private void lm_PlanetPositions_MouseEnter(object sender, System.EventArgs e)
        {
            lm_PlanetPositions.BackColor = Color.Brown;
            lm_PlanetPositions.ForeColor = Color.White;
        }

        private void lm_PlanetPositions_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            timer2.Stop();
            timer3.Stop();
            timerRun = false;
            T = "";
            NormalizeButton();
            skyView.f_pp = new f_PlanetPosition();
            skyView.f_pp.Show();
        }

        private void lm_PlanetPositions_MouseLeave(object sender, System.EventArgs e)
        {
            lm_PlanetPositions.BackColor = Color.FromArgb(175, 175, 100);
            lm_PlanetPositions.ForeColor = Color.Black;
        }

        private void lm_Tools_MouseEnter(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Select.Visible = false;
            lm_Tools.BackColor = Color.Brown;
            lm_Tools.ForeColor = Color.White;
            p_Tools.Visible = true;
        }

        private void lm_Tools_MouseLeave(object sender, System.EventArgs e)
        {
            lm_Tools.BackColor = Color.FromArgb(175, 175, 100);
            lm_Tools.ForeColor = Color.Black;
        }

        private void lm_SolarSystemView_MouseEnter(object sender, System.EventArgs e)
        {
            lm_SolarSystemView.BackColor = Color.Brown;
            lm_SolarSystemView.ForeColor = Color.White;
        }

        private void lm_SolarSystemView_MouseLeave(object sender, System.EventArgs e)
        {
            lm_SolarSystemView.BackColor = Color.FromArgb(175, 175, 100);
            lm_SolarSystemView.ForeColor = Color.Black;
        }

        private void lm_SolarSystemView_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            NormalizeButton();
            skyView.f_pp.Close();
            f_SolarSystem f_ssv = new f_SolarSystem();
            f_ssv.ShowDialog();
        }

        private void lm_ConjunctionFinder_MouseEnter(object sender, System.EventArgs e)
        {
            lm_ConjunctionFinder.BackColor = Color.Brown;
            lm_ConjunctionFinder.ForeColor = Color.White;
        }

        private void lm_ConjunctionFinder_MouseLeave(object sender, System.EventArgs e)
        {
            lm_ConjunctionFinder.BackColor = Color.FromArgb(175, 175, 100);
            lm_ConjunctionFinder.ForeColor = Color.Black;
        }

        private void lm_ConjunctionFinder_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            skyView.f_pp.Close();
            NormalizeButton();
            f_SolarSystem f_cf = new f_SolarSystem("cf");
            f_cf.ShowDialog();
        }

        private void lm_SolarEvents_MouseEnter(object sender, System.EventArgs e)
        {
            lm_SolarEvents.BackColor = Color.Brown;
            lm_SolarEvents.ForeColor = Color.White;
        }

        private void lm_SolarEvents_MouseLeave(object sender, System.EventArgs e)
        {
            lm_SolarEvents.BackColor = Color.FromArgb(175, 175, 100);
            lm_SolarEvents.ForeColor = Color.Black;
        }

        private void lm_SolarEvents_Click(object sender, System.EventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            timer2.Stop(); timer3.Stop();
            timerRun = false;
            T = "";
            skyView.f_pp.Close();
            NormalizeButton();
            skyView.f_pp.Close();
            f_SolarEvents f_sv = new f_SolarEvents();
            f_sv.ShowDialog();
        }

        private void panel2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p_Data.Visible = false;
            p_Tools.Visible = false;
            p_Select.Visible = false;
        }

        private void lm_Select_MouseEnter(object sender, System.EventArgs e)
        {
            p_Tools.Visible = false;
            p_Data.Visible = false;
            lm_Select.BackColor = Color.Brown;
            lm_Select.ForeColor = Color.White;
            p_Select.Visible = true;
        }

        private void lm_Select_MouseLeave(object sender, System.EventArgs e)
        {
            lm_Select.BackColor = Color.FromArgb(175, 175, 100);
            lm_Select.ForeColor = Color.Black;
        }

        private void tV_Select_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Text != "Earth")
                tempSelect = e.Node.Text;
            else
                tempSelect = "";
        }

        private void b_Select_Click(object sender, System.EventArgs e)
        {
            if (tempSelect != "")
            {
                skyView.selPl = tempSelect;
                skyView.selected = true;
                p_Select.Visible = false;
                changePos = true;
                pB_Space.Invalidate();
            }
        }

        private void lt_Daylight_Click(object sender, System.EventArgs e)
        {
            if (lt_Daylight.BackColor == Color.Red)
                lt_Daylight.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_Daylight.BackColor = Color.Red;
            skyView.bDay = !skyView.bDay;
            pB_Space.Invalidate();
        }

        private void lt_FullHorizon_Click(object sender, System.EventArgs e)
        {
            skyView.bFull = !skyView.bFull;
            skyView.bLine = !skyView.bLine;
            if (lt_FullHorizon.BackColor == Color.Red)
                lt_FullHorizon.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_FullHorizon.BackColor = Color.Red;
            if (lt_LineHorizon.BackColor == Color.Red)
                lt_LineHorizon.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_LineHorizon.BackColor = Color.Red;
            pB_Space.Invalidate();
        }

        private void lt_LineHorizon_Click(object sender, System.EventArgs e)
        {
            skyView.bLine = !skyView.bLine;
            skyView.bFull = !skyView.bFull;
            if (lt_LineHorizon.BackColor == Color.Red)
                lt_LineHorizon.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_LineHorizon.BackColor = Color.Red;
            if (lt_FullHorizon.BackColor == Color.Red)
                lt_FullHorizon.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_FullHorizon.BackColor = Color.Red;
            pB_Space.Invalidate();
        }

        private void lt_HorizonLabel_Click(object sender, System.EventArgs e)
        {
            if (lt_HorizonLabel.BackColor == Color.Red)
                lt_HorizonLabel.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_HorizonLabel.BackColor = Color.Red;
            skyView.bComp = !skyView.bComp;
            pB_Space.Invalidate();
        }

        private void lt_Planets_Click(object sender, System.EventArgs e)
        {
            if (lt_Planets.BackColor == Color.Red)
                lt_Planets.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_Planets.BackColor = Color.Red;
            skyView.bShowPl = !skyView.bShowPl;
            pB_Space.Invalidate();
        }

        private void lt_EarthShadow_Click(object sender, System.EventArgs e)
        {
            if (lt_EarthShadow.BackColor == Color.Red)
                lt_EarthShadow.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_EarthShadow.BackColor = Color.Red;
            skyView.bShowES = !skyView.bShowES;
            pB_Space.Invalidate();
        }

        private void lt_PlanetLabel_Click(object sender, System.EventArgs e)
        {
            if (lt_PlanetLabel.BackColor == Color.Red)
                lt_PlanetLabel.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_PlanetLabel.BackColor = Color.Red;
            skyView.bPlLabel = !skyView.bPlLabel;
            pB_Space.Invalidate();
        }

        private void lt_Stars_Click(object sender, System.EventArgs e)
        {
            if (lt_Stars.BackColor == Color.Red)
                lt_Stars.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_Stars.BackColor = Color.Red;
            skyView.bShowSt = !skyView.bShowSt;
            pB_Space.Invalidate();
        }

        private void lt_StarLabel_Click(object sender, System.EventArgs e)
        {
            if (lt_StarLabel.BackColor == Color.Red)
                lt_StarLabel.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_StarLabel.BackColor = Color.Red;
            skyView.bStLabel = !skyView.bStLabel;
            pB_Space.Invalidate();
        }

        private void lt_Constellation_Click(object sender, System.EventArgs e)
        {
            if (lt_Constellation.BackColor == Color.Red)
                lt_Constellation.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_Constellation.BackColor = Color.Red;
            skyView.bShowCo = !skyView.bShowCo;
            pB_Space.Invalidate();
        }

        private void lt_ConstellationLabel_Click(object sender, System.EventArgs e)
        {
            if (lt_ConstellationLabel.BackColor == Color.Red)
                lt_ConstellationLabel.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_ConstellationLabel.BackColor = Color.Red;
            skyView.bCoLabel = !skyView.bCoLabel;
            pB_Space.Invalidate();
        }

        private void lt_Messiers_Click(object sender, System.EventArgs e)
        {
            if (lt_Messiers.BackColor == Color.Red)
                lt_Messiers.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_Messiers.BackColor = Color.Red;
            skyView.bShowM = !skyView.bShowM;
            pB_Space.Invalidate();
        }

        private void lt_MessierLabel_Click(object sender, System.EventArgs e)
        {
            if (lt_MessierLabel.BackColor == Color.Red)
                lt_MessierLabel.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_MessierLabel.BackColor = Color.Red;
            skyView.bMLabel = !skyView.bMLabel;
            pB_Space.Invalidate();
        }

        private void lt_EqGrid_Click(object sender, System.EventArgs e)
        {
            if (lt_EqGrid.BackColor == Color.Red)
                lt_EqGrid.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_EqGrid.BackColor = Color.Red;
            skyView.bShowEQ = !skyView.bShowEQ;
            pB_Space.Invalidate();
        }

        private void lt_HorGrid_Click(object sender, System.EventArgs e)
        {
            if (lt_HorGrid.BackColor == Color.Red)
                lt_HorGrid.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_HorGrid.BackColor = Color.Red;
            skyView.bShowHOR = !skyView.bShowHOR;
            pB_Space.Invalidate();
        }

        private void lt_GridLabel_Click(object sender, System.EventArgs e)
        {
            if (lt_GridLabel.BackColor == Color.Red)
                lt_GridLabel.BackColor = Color.FromArgb(175, 175, 100);
            else
                lt_GridLabel.BackColor = Color.Red;
            skyView.bGridLabel = !skyView.bGridLabel;
            pB_Space.Invalidate();
        }

        private LocationST location = LocationST.GetInstance();
        private readonly SolarSystemData solarSystemData = SolarSystemData.GetInstance();
        private SkyView skyView = new SkyView();
        private string selected;
        private bool changePos = false;
        private readonly Cursor openH, closedH;
        private string[] timeUnit = { "seconds", "minutes", "hours", "days", "months", "years" };
        private int strIndex = 1;
        private short n;
        private bool timerRun = false;
        private string T = "";
        private Point pOld = new Point();
        private Point pNew = new Point();
        private bool mDown = false;
        private char XX = 'N';
        private string tempSelect = "";
        private bool zenith = false;

        private Model1 device;
    }
}
