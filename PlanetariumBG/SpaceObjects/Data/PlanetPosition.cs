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

using System;

namespace SpaceObjects.Data
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PlanetPosition
    {
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }
        public double Z
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public PlanetPosition()
        {

        }

        public PlanetPosition(double x, double y, double z)
        {
            this.X = x; this.Y = y; this.Z = z; Name = "";
        }

        public void Rotate(double angle_x, double angle_z)
        {
            double r = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

            double a = 0, al = 0;
            al = Math.Atan(Math.Abs(this.Y) / Math.Abs(this.X)) * 180.0d / Math.PI;

            if (this.X > 0 && this.Y == 0) a = 0;
            if (this.X == 0 && this.Y > 0) a = 90;
            if (this.X < 0 && this.Y == 0) a = 180;
            if (this.X == 0 && this.Y < 0) a = 270;

            if (this.X > 0 && this.Y > 0) a = al;
            if (this.X < 0 && this.Y > 0) a = 180 - al;
            if (this.X < 0 && this.Y < 0) a = 180 + al;
            if (this.X > 0 && this.Y < 0) a = 360 - al;

            a += angle_z;
            a = a % 360;

            double tk = Math.Tan(a * Math.PI / 180);

            if (a >= 90 && a < 270)
            {
                this.X = -Math.Sqrt(r * r / (1 + tk * tk));
            }
            else
            {
                this.X = Math.Sqrt(r * r / (1 + tk * tk));
            }

            this.Y = this.X * tk;
            this.Y = this.Y * Math.Cos(angle_x * Math.PI / 180);
            this.Z = this.Z * Math.Sin(angle_x * Math.PI / 180);
            this.Y += this.Z;
        }
    }
}
