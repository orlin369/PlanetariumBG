using SpaceObjects.Position;
using SpaceObjects.SolarSystem;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Planetarium
{
    /// <summary>
    /// Summary description for f_PlanetData.
    /// </summary>
    public class f_PlanetData : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.PictureBox pB_Graf;
		private System.Windows.Forms.CheckBox cB_Pluto;
		private System.Windows.Forms.CheckBox cB_Neptune;
		private System.Windows.Forms.CheckBox cB_Uranus;
		private System.Windows.Forms.CheckBox cB_Saturn;
		private System.Windows.Forms.CheckBox cB_Jupiter;
		private System.Windows.Forms.CheckBox cB_Mars;
		private System.Windows.Forms.CheckBox cB_Venus;
		private System.Windows.Forms.CheckBox cB_Mercury;
		private System.Windows.Forms.RadioButton rB_Elongation;
		private System.Windows.Forms.RadioButton rB_AngularDiametar;
		private System.Windows.Forms.RadioButton rB_Phase;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown nUD;

		public f_PlanetData()
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(f_PlanetData));
			this.pB_Graf = new System.Windows.Forms.PictureBox();
			this.cB_Pluto = new System.Windows.Forms.CheckBox();
			this.cB_Neptune = new System.Windows.Forms.CheckBox();
			this.cB_Uranus = new System.Windows.Forms.CheckBox();
			this.cB_Saturn = new System.Windows.Forms.CheckBox();
			this.cB_Jupiter = new System.Windows.Forms.CheckBox();
			this.cB_Mars = new System.Windows.Forms.CheckBox();
			this.cB_Venus = new System.Windows.Forms.CheckBox();
			this.cB_Mercury = new System.Windows.Forms.CheckBox();
			this.nUD = new System.Windows.Forms.NumericUpDown();
			this.rB_Elongation = new System.Windows.Forms.RadioButton();
			this.rB_AngularDiametar = new System.Windows.Forms.RadioButton();
			this.rB_Phase = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.nUD)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pB_Graf
			// 
			this.pB_Graf.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
			this.pB_Graf.Location = new System.Drawing.Point(0, 0);
			this.pB_Graf.Name = "pB_Graf";
			this.pB_Graf.Size = new System.Drawing.Size(592, 360);
			this.pB_Graf.TabIndex = 0;
			this.pB_Graf.TabStop = false;
			this.pB_Graf.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Graf_Paint);
			// 
			// cB_Pluto
			// 
			this.cB_Pluto.Location = new System.Drawing.Point(350, 417);
			this.cB_Pluto.Name = "cB_Pluto";
			this.cB_Pluto.Size = new System.Drawing.Size(64, 15);
			this.cB_Pluto.TabIndex = 41;
			this.cB_Pluto.Text = "Pluto";
			this.cB_Pluto.CheckedChanged += new System.EventHandler(this.cB_Pluto_CheckedChanged);
			// 
			// cB_Neptune
			// 
			this.cB_Neptune.Location = new System.Drawing.Point(350, 396);
			this.cB_Neptune.Name = "cB_Neptune";
			this.cB_Neptune.Size = new System.Drawing.Size(72, 15);
			this.cB_Neptune.TabIndex = 40;
			this.cB_Neptune.Text = "Neptune";
			this.cB_Neptune.CheckedChanged += new System.EventHandler(this.cB_Neptune_CheckedChanged);
			// 
			// cB_Uranus
			// 
			this.cB_Uranus.Location = new System.Drawing.Point(350, 375);
			this.cB_Uranus.Name = "cB_Uranus";
			this.cB_Uranus.Size = new System.Drawing.Size(64, 15);
			this.cB_Uranus.TabIndex = 39;
			this.cB_Uranus.Text = "Uranus";
			this.cB_Uranus.CheckedChanged += new System.EventHandler(this.cB_Uranus_CheckedChanged);
			// 
			// cB_Saturn
			// 
			this.cB_Saturn.Location = new System.Drawing.Point(260, 417);
			this.cB_Saturn.Name = "cB_Saturn";
			this.cB_Saturn.Size = new System.Drawing.Size(64, 15);
			this.cB_Saturn.TabIndex = 38;
			this.cB_Saturn.Text = "Saturn";
			this.cB_Saturn.CheckedChanged += new System.EventHandler(this.cB_Saturn_CheckedChanged);
			// 
			// cB_Jupiter
			// 
			this.cB_Jupiter.Location = new System.Drawing.Point(260, 396);
			this.cB_Jupiter.Name = "cB_Jupiter";
			this.cB_Jupiter.Size = new System.Drawing.Size(64, 15);
			this.cB_Jupiter.TabIndex = 37;
			this.cB_Jupiter.Text = "Jupiter";
			this.cB_Jupiter.CheckedChanged += new System.EventHandler(this.cB_Jupiter_CheckedChanged);
			// 
			// cB_Mars
			// 
			this.cB_Mars.Location = new System.Drawing.Point(260, 375);
			this.cB_Mars.Name = "cB_Mars";
			this.cB_Mars.Size = new System.Drawing.Size(64, 15);
			this.cB_Mars.TabIndex = 36;
			this.cB_Mars.Text = "Mars";
			this.cB_Mars.CheckedChanged += new System.EventHandler(this.cB_Mars_CheckedChanged);
			// 
			// cB_Venus
			// 
			this.cB_Venus.Location = new System.Drawing.Point(170, 407);
			this.cB_Venus.Name = "cB_Venus";
			this.cB_Venus.Size = new System.Drawing.Size(64, 15);
			this.cB_Venus.TabIndex = 35;
			this.cB_Venus.Text = "Venus";
			this.cB_Venus.CheckedChanged += new System.EventHandler(this.cB_Venus_CheckedChanged);
			// 
			// cB_Mercury
			// 
			this.cB_Mercury.Location = new System.Drawing.Point(170, 383);
			this.cB_Mercury.Name = "cB_Mercury";
			this.cB_Mercury.Size = new System.Drawing.Size(64, 15);
			this.cB_Mercury.TabIndex = 34;
			this.cB_Mercury.Text = "Mercury";
			this.cB_Mercury.CheckedChanged += new System.EventHandler(this.cB_Mercury_CheckedChanged);
			// 
			// nUD
			// 
			this.nUD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
			this.nUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.nUD.Location = new System.Drawing.Point(16, 334);
			this.nUD.Maximum = new System.Decimal(new int[] {
																2099,
																0,
																0,
																0});
			this.nUD.Minimum = new System.Decimal(new int[] {
																1900,
																0,
																0,
																0});
			this.nUD.Name = "nUD";
			this.nUD.Size = new System.Drawing.Size(48, 13);
			this.nUD.TabIndex = 21;
			this.nUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nUD.Value = new System.Decimal(new int[] {
															  2000,
															  0,
															  0,
															  0});
			this.nUD.ValueChanged += new System.EventHandler(this.nUD_ValueChanged);
			// 
			// rB_Elongation
			// 
			this.rB_Elongation.Checked = true;
			this.rB_Elongation.Location = new System.Drawing.Point(19, 21);
			this.rB_Elongation.Name = "rB_Elongation";
			this.rB_Elongation.Size = new System.Drawing.Size(80, 16);
			this.rB_Elongation.TabIndex = 42;
			this.rB_Elongation.TabStop = true;
			this.rB_Elongation.Text = "Elongation";
			this.rB_Elongation.CheckedChanged += new System.EventHandler(this.rB_Elongation_CheckedChanged);
			// 
			// rB_AngularDiametar
			// 
			this.rB_AngularDiametar.Location = new System.Drawing.Point(19, 40);
			this.rB_AngularDiametar.Name = "rB_AngularDiametar";
			this.rB_AngularDiametar.Size = new System.Drawing.Size(110, 16);
			this.rB_AngularDiametar.TabIndex = 43;
			this.rB_AngularDiametar.Text = "Angular Diametar";
			this.rB_AngularDiametar.CheckedChanged += new System.EventHandler(this.rB_AngularDiametar_CheckedChanged);
			// 
			// rB_Phase
			// 
			this.rB_Phase.Location = new System.Drawing.Point(19, 59);
			this.rB_Phase.Name = "rB_Phase";
			this.rB_Phase.Size = new System.Drawing.Size(64, 16);
			this.rB_Phase.TabIndex = 44;
			this.rB_Phase.Text = "Phase";
			this.rB_Phase.CheckedChanged += new System.EventHandler(this.rB_Phase_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
			this.groupBox1.Controls.Add(this.rB_Elongation);
			this.groupBox1.Controls.Add(this.rB_AngularDiametar);
			this.groupBox1.Controls.Add(this.rB_Phase);
			this.groupBox1.Location = new System.Drawing.Point(16, 358);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 81);
			this.groupBox1.TabIndex = 45;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Data Source";
			// 
			// f_PlanetData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
			this.ClientSize = new System.Drawing.Size(592, 448);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cB_Pluto);
			this.Controls.Add(this.cB_Neptune);
			this.Controls.Add(this.cB_Uranus);
			this.Controls.Add(this.cB_Saturn);
			this.Controls.Add(this.cB_Jupiter);
			this.Controls.Add(this.cB_Mars);
			this.Controls.Add(this.cB_Venus);
			this.Controls.Add(this.cB_Mercury);
			this.Controls.Add(this.nUD);
			this.Controls.Add(this.pB_Graf);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "f_PlanetData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Planet Data";
			this.Load += new System.EventHandler(this.f_PlanetData_Load);
			((System.ComponentModel.ISupportInitialize)(this.nUD)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void f_PlanetData_Load(object sender, System.EventArgs e)
		{
			this.Text = "Elongation";
			window = "Elongation";
		}

		private void nUD_ValueChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Mercury_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Venus_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Mars_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Jupiter_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Saturn_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Uranus_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Neptune_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void cB_Pluto_CheckedChanged(object sender, System.EventArgs e)
		{
			pB_Graf.Invalidate();
		}

		private void rB_Elongation_CheckedChanged(object sender, System.EventArgs e)
		{
			this.Text = "Elongation";
			window = "Elongation";
			pB_Graf.Invalidate();
		}

		private void rB_AngularDiametar_CheckedChanged(object sender, System.EventArgs e)
		{
			this.Text = "Angular diametar";
			window = "Angular diametar";
			pB_Graf.Invalidate();
		}

		private void rB_Phase_CheckedChanged(object sender, System.EventArgs e)
		{
			this.Text = "Phase (Percent illumination)";
			window = "Percent illumination";
			pB_Graf.Invalidate();
		}

		private void pB_Graf_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Graphics g = e.Graphics;
			DateTime dtOld = location.v_mainDT;

			g.DrawRectangle (new Pen(Color.Black,3), 10, 10, pB_Graf.Width-20, pB_Graf.Height-20);
			g.DrawLine (new Pen(Color.Black,3), 10, pB_Graf.Height-30, pB_Graf.Width-10, pB_Graf.Height-30);
			g.DrawLine (new Pen(Color.Black,3), 70, pB_Graf.Height-30, 70, pB_Graf.Height-10);

			for (int i=1; i<13; ++i)
				g.DrawLine (new Pen(Color.Black,3), (int)(70+i*(pB_Graf.Width-10-70)/12), pB_Graf.Height-30, 
					(int)(70+i*(pB_Graf.Width-10-70)/12), pB_Graf.Height-10);

			Pen pen = new Pen(Color.Black,1);
			pen.DashStyle = DashStyle.DashDotDot;
			for (int i=0; i<12; ++i)
				g.DrawLine (pen, (int)(70+i*(pB_Graf.Width-10-70)/12), 20, 
					(int)(70+i*(pB_Graf.Width-10-70)/12), pB_Graf.Height-32);

			switch (window){
				case "Elongation":{
					for (int i=1; i<7; ++i){
						g.DrawLine (pen, 70, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/6), 
							pB_Graf.Width-12, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/6));
						g.DrawString ((30*i).ToString(), new Font("Arial",10), new SolidBrush(Color.Black),
							30, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/6));
					}

					if (cB_Mercury.Checked)	DrawElong (g, "Mercury");
					if (cB_Venus.Checked)	DrawElong (g, "Venus");
					if (cB_Mars.Checked)	DrawElong (g, "Mars");
					if (cB_Jupiter.Checked) DrawElong (g, "Jupiter");
					if (cB_Saturn.Checked)	DrawElong (g, "Saturn");
					if (cB_Uranus.Checked)	DrawElong (g, "Uranus");
					if (cB_Neptune.Checked)	DrawElong (g, "Neptune");
					if (cB_Pluto.Checked)	DrawElong (g, "Pluto");
					
					break;
				}
				case "Angular diametar":{
					for (int i=1; i<8; ++i){
						g.DrawLine (pen, 70, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/7), 
							pB_Graf.Width-12, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/7));
						g.DrawString ((10*i).ToString(), new Font("Arial",10), new SolidBrush(Color.Black),
							30, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/7));
					}

					if (cB_Mercury.Checked)	DrawADiam (g, "Mercury");
					if (cB_Venus.Checked)	DrawADiam (g, "Venus");
					if (cB_Mars.Checked)	DrawADiam (g, "Mars");
					if (cB_Jupiter.Checked) DrawADiam (g, "Jupiter");
					if (cB_Saturn.Checked)	DrawADiam (g, "Saturn");
					if (cB_Uranus.Checked)	DrawADiam (g, "Uranus");
					if (cB_Neptune.Checked)	DrawADiam (g, "Neptune");
					if (cB_Pluto.Checked)	DrawADiam (g, "Pluto");
					
					break;
				}
				case "Percent illumination":{
					for (int i=1; i<5; ++i){
						g.DrawLine (pen, 70, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/4), 
							pB_Graf.Width-12, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/4));
						g.DrawString ((25*i).ToString()+" %", new Font("Arial",10), new SolidBrush(Color.Black),
							30, (int)((pB_Graf.Height-30)-i*(pB_Graf.Height-50)/4));
					}

					if (cB_Mercury.Checked)	DrawPhase (g, "Mercury");
					if (cB_Venus.Checked)	DrawPhase (g, "Venus");
					if (cB_Mars.Checked)	DrawPhase (g, "Mars");
					if (cB_Jupiter.Checked) DrawPhase (g, "Jupiter");
					if (cB_Saturn.Checked)	DrawPhase (g, "Saturn");
					if (cB_Uranus.Checked)	DrawPhase (g, "Uranus");
					if (cB_Neptune.Checked)	DrawPhase (g, "Neptune");
					if (cB_Pluto.Checked)	DrawPhase (g, "Pluto");
					
					break;
				}
			}
			location.v_mainDT = dtOld;

			g.DrawString ("Jan", new Font("Arial",10), new SolidBrush(Color.Black), 81, 332);
			g.DrawString ("Feb", new Font("Arial",10), new SolidBrush(Color.Black), 123, 332);
			g.DrawString ("Mar", new Font("Arial",10), new SolidBrush(Color.Black), 164, 332);
			g.DrawString ("Apr", new Font("Arial",10), new SolidBrush(Color.Black), 207, 332);
			g.DrawString ("May", new Font("Arial",10), new SolidBrush(Color.Black), 248, 332);
			g.DrawString ("Jun", new Font("Arial",10), new SolidBrush(Color.Black), 292, 332);
			g.DrawString ("Jul", new Font("Arial",10), new SolidBrush(Color.Black), 335, 332);
			g.DrawString ("Aug", new Font("Arial",10), new SolidBrush(Color.Black), 378, 332);
			g.DrawString ("Sep", new Font("Arial",10), new SolidBrush(Color.Black), 421, 332);
			g.DrawString ("Oct", new Font("Arial",10), new SolidBrush(Color.Black), 462, 332);
			g.DrawString ("Nov", new Font("Arial",10), new SolidBrush(Color.Black), 507, 332);
			g.DrawString ("Dec", new Font("Arial",10), new SolidBrush(Color.Black), 548, 332);
		}

		private void DrawElong (Graphics g, string name)
		{
			location.v_mainDT = new DateTime((int)nUD.Value, 1, 1);
			switch (name){
				case "Pluto":{c = Color.Gray; break;}
				case "Neptune":{c = Color.Blue; break;}
				case "Uranus":{c = Color.Aqua; break;}
				case "Saturn":{c = Color.SeaGreen; break;}
				case "Jupiter":{c = Color.Gold; break;}
				case "Mars":{c = Color.Red; break;}
				case "Venus":{c = Color.SaddleBrown; break;}
				case "Mercury":{c = Color.Wheat; break;}
			}

			Point[] p = new Point[183];
			for (int i=0, j=0; i<366; i+=2){
				pd.PlanetPositions();
				p[j].X = (int)(70+i*(pB_Graf.Width-10-70)/365);
				p[j++].Y = (int)(pB_Graf.Height-30-pd.planets[name].elong*(pB_Graf.Height-50)/180);
				location.v_mainDT = location.v_mainDT.AddDays(2);
			}
			g.DrawLines (new Pen(c,2), p);
		}

		private void DrawADiam (Graphics g, string name)
		{
			location.v_mainDT = new DateTime((int)nUD.Value, 1, 1);
			switch (name){
				case "Pluto":{c = Color.Gray; break;}
				case "Neptune":{c = Color.Blue; break;}
				case "Uranus":{c = Color.Aqua; break;}
				case "Saturn":{c = Color.SeaGreen; break;}
				case "Jupiter":{c = Color.Gold; break;}
				case "Mars":{c = Color.Red; break;}
				case "Venus":{c = Color.SaddleBrown; break;}
				case "Mercury":{c = Color.Wheat; break;}
			}

			Point[] p = new Point[183];
			for (int i=0, j=0; i<366; i+=2){
				pd.PlanetPositions();
				p[j].X = (int)(70+i*(pB_Graf.Width-10-70)/365);
				p[j++].Y = (int)(pB_Graf.Height-30-pd.planets[name].diam*(pB_Graf.Height-50)/70);
				location.v_mainDT = location.v_mainDT.AddDays(2);
			}
			g.DrawLines (new Pen(c,2), p);
		}

		private void DrawPhase (Graphics g, string name)
		{
			location.v_mainDT = new DateTime((int)nUD.Value, 1, 1);
			switch (name){
				case "Pluto":{c = Color.Gray; break;}
				case "Neptune":{c = Color.Blue; break;}
				case "Uranus":{c = Color.Aqua; break;}
				case "Saturn":{c = Color.SeaGreen; break;}
				case "Jupiter":{c = Color.Gold; break;}
				case "Mars":{c = Color.Red; break;}
				case "Venus":{c = Color.SaddleBrown; break;}
				case "Mercury":{c = Color.Wheat; break;}
			}

			Point[] p = new Point[183];
			for (int i=0, j=0; i<366; i+=2){
				pd.PlanetPositions();
				p[j].X = (int)(70+i*(pB_Graf.Width-10-70)/365);
				p[j++].Y = (int)(pB_Graf.Height-30-pd.planets[name].phase*100*(pB_Graf.Height-50)/100);
				location.v_mainDT = location.v_mainDT.AddDays(2);
			}
			g.DrawLines (new Pen(c,2), p);
		}

		private PlanetData pd = PlanetData.GetInstance();
		private LocationST location = LocationST.GetInstance();
		private static string[] planetNames = {"Mercury","Venus","Mars","Jupiter",
											   "Saturn","Uranus","Neptune","Pluto"};
		private Color c = new Color();
		string window;
	}
}
