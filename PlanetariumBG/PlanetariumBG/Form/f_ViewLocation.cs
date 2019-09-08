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
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Planetarium
{
    /// <summary>
    /// Summary description for f_ViewLocation.
    /// </summary>
    public class f_ViewLocation : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_Lon;
        private System.Windows.Forms.Label l_Lat;
        private System.Windows.Forms.Button b_SetAsHome;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_ViewLocation;

        private LocationST location = LocationST.GetInstance();
        private bool mDown, mUp;
        private Bitmap bmp;
        private System.Windows.Forms.PictureBox pB_Earth;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public f_ViewLocation()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(f_ViewLocation));
            this.l_Lon = new System.Windows.Forms.Label();
            this.l_Lat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_SetAsHome = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.b_ViewLocation = new System.Windows.Forms.Button();
            this.pB_Earth = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // l_Lon
            // 
            this.l_Lon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_Lon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Lon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.l_Lon.Location = new System.Drawing.Point(232, 205);
            this.l_Lon.Name = "l_Lon";
            this.l_Lon.Size = new System.Drawing.Size(40, 20);
            this.l_Lon.TabIndex = 3;
            this.l_Lon.Text = "0";
            this.l_Lon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Lat
            // 
            this.l_Lat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_Lat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Lat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.l_Lat.Location = new System.Drawing.Point(136, 205);
            this.l_Lat.Name = "l_Lat";
            this.l_Lat.Size = new System.Drawing.Size(40, 20);
            this.l_Lat.TabIndex = 4;
            this.l_Lat.Text = "0";
            this.l_Lat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.label1.Location = new System.Drawing.Point(96, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lat :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.label2.Location = new System.Drawing.Point(192, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lon :";
            // 
            // b_SetAsHome
            // 
            this.b_SetAsHome.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.b_SetAsHome.Location = new System.Drawing.Point(8, 240);
            this.b_SetAsHome.Name = "b_SetAsHome";
            this.b_SetAsHome.Size = new System.Drawing.Size(104, 23);
            this.b_SetAsHome.TabIndex = 8;
            this.b_SetAsHome.Text = "Set as Home";
            this.b_SetAsHome.Click += new System.EventHandler(this.b_SetAsHome_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.b_Cancel.Location = new System.Drawing.Point(312, 240);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(48, 23);
            this.b_Cancel.TabIndex = 9;
            this.b_Cancel.Text = "Close";
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.label5.Location = new System.Drawing.Point(176, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 8);
            this.label5.TabIndex = 10;
            this.label5.Text = "o";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.label6.Location = new System.Drawing.Point(272, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 8);
            this.label6.TabIndex = 11;
            this.label6.Text = "o";
            // 
            // b_ViewLocation
            // 
            this.b_ViewLocation.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.b_ViewLocation.Location = new System.Drawing.Point(144, 240);
            this.b_ViewLocation.Name = "b_ViewLocation";
            this.b_ViewLocation.Size = new System.Drawing.Size(104, 23);
            this.b_ViewLocation.TabIndex = 12;
            this.b_ViewLocation.Text = "View Location";
            this.b_ViewLocation.Click += new System.EventHandler(this.b_ViewLocation_Click);
            // 
            // pB_Earth
            // 
            this.pB_Earth.Location = new System.Drawing.Point(9, 8);
            this.pB_Earth.Name = "pB_Earth";
            this.pB_Earth.Size = new System.Drawing.Size(362, 182);
            this.pB_Earth.TabIndex = 13;
            this.pB_Earth.TabStop = false;
            this.pB_Earth.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Earth_Paint);
            this.pB_Earth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_Earth_MouseUp);
            this.pB_Earth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pB_Earth_MouseMove);
            this.pB_Earth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_Earth_MouseDown);
            // 
            // f_ViewLocation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(380, 286);
            this.Controls.Add(this.pB_Earth);
            this.Controls.Add(this.b_ViewLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_SetAsHome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_Lat);
            this.Controls.Add(this.l_Lon);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_ViewLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Location";
            this.Load += new System.EventHandler(this.f_ViewLocation_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void f_ViewLocation_Load(object sender, System.EventArgs e)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            Stream imgStream = a.GetManifestResourceStream("Planetarium.Resources.earth.jpg");
            bmp = Bitmap.FromStream(imgStream) as Bitmap;
            pB_Earth.BackgroundImage = bmp;

            l_Lat.Text = location.Latitude.ToString();
            l_Lon.Text = location.Longitude.ToString();
        }

        private void b_Cancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void b_ViewLocation_Click(object sender, System.EventArgs e)
        {
            location.Latitude = Convert.ToInt16(l_Lat.Text);
            location.Longitude = Convert.ToInt16(l_Lon.Text);
            Close();
        }

        private void b_SetAsHome_Click(object sender, System.EventArgs e)
        {
            location.HomeLatitude = Convert.ToInt32(l_Lat.Text);
            location.HomeLongitude = Convert.ToInt32(l_Lon.Text);
            location.ChangeRegistry();
            Close();
        }

        private void pB_Earth_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red), 3),
                180 + Convert.ToInt16(l_Lon.Text) - 4, 90 - Convert.ToInt16(l_Lat.Text) - 4, 8, 8);
        }

        private void pB_Earth_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mDown = true;
            l_Lat.Text = (90 - e.Y).ToString();
            l_Lon.Text = (e.X - 180).ToString();
            pB_Earth.Invalidate();
        }

        private void pB_Earth_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mDown)
            {
                if (e.Y < 0 || e.Y > 180 || e.X < 0 || e.X > 360)
                {
                    mDown = false;
                    return;
                }
                l_Lat.Text = (90 - e.Y).ToString();
                l_Lon.Text = (e.X - 180).ToString();
                pB_Earth.Invalidate();
            }
        }

        private void pB_Earth_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mDown = false;
        }
    }
}
