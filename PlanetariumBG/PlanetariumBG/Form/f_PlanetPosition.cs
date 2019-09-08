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

using SpaceObjects.SolarSystem;
using System;
using System.Drawing;

namespace Planetarium
{
    /// <summary>
    /// Summary description for f_PlanetPosition.
    /// </summary>
    public class f_PlanetPosition : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public f_PlanetPosition()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(f_PlanetPosition));
            this.pb = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(175)), ((System.Byte)(100)));
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(234, 228);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Paint);
            // 
            // f_PlanetPosition
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(234, 228);
            this.Controls.Add(this.pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_PlanetPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planet Position";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
        #endregion

        private void pb_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int x = 1;
            StringFormat sf = new StringFormat();
            sf.Alignment = System.Drawing.StringAlignment.Center;
            g.DrawString("RA", new Font("Georgia", 9), new SolidBrush(Color.FromArgb(100, 100, 100)), 110, 5, sf);
            g.DrawString("Decl", new Font("Georgia", 9), new SolidBrush(Color.FromArgb(100, 100, 100)), 200, 5, sf);
            foreach (String planetName in planetNames)
            {
                g.DrawString(planetName + " :", new Font("Georgia", 9), new SolidBrush(Color.FromArgb(100, 100, 100)), 5, 5 + 20 * x);

                double rahTemp = planetData.SolarSystemObjects.GetObjectByName(planetName).SkyPosition.RA / 15;
                double ramTemp = (rahTemp - (int)rahTemp) * 60;
                double rasTemp = (ramTemp - (int)ramTemp) * 60;

                double dhTemp = planetData.SolarSystemObjects.GetObjectByName(planetName).SkyPosition.Decl;
                double dmTemp = Math.Abs((dhTemp - (int)dhTemp) * 60);
                double dsTemp = (dmTemp - (int)dmTemp) * 60;

                g.DrawString(((int)rahTemp).ToString(), new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Black), 90, 5 + 20 * x, sf);
                g.DrawString(((int)ramTemp).ToString(), new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Black), 110, 5 + 20 * x, sf);
                g.DrawString(((int)rasTemp).ToString(), new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Black), 130, 5 + 20 * x, sf);
                g.DrawString(((int)dhTemp).ToString(), new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Black), 180, 5 + 20 * x, sf);
                g.DrawString(((int)dmTemp).ToString(), new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Black), 200, 5 + 20 * x, sf);
                g.DrawString(((int)dsTemp).ToString(), new Font("Arial", 9, FontStyle.Bold), new SolidBrush(Color.Black), 220, 5 + 20 * x, sf);
                ++x;
            }
        }

        private SolarSystemData planetData = SolarSystemData.GetInstance();
        public System.Windows.Forms.PictureBox pb;
        private static string[] planetNames = {"Sun","Moon","Mercury","Venus","Mars",
                                               "Jupiter","Saturn","Uranus","Neptune","Pluto"};
    }
}
