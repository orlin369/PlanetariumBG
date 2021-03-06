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

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Sun : SolarSystemObject
    {
        public Sun()
        {
            this.Name = "Sun";
        }

        public override void OrbitalElements()
        {
            N = 0;
            this.Inclination = 0;
            this.MeanDistance = 1;
            this.Perihelion = 282.9404 + 4.70935E-5 * this.Location.DayNumber();
            ec = 0.016709 - 1.151E-9 * this.Location.DayNumber();
            this.MeanAnomaly = 356.047 + 0.9856002585 * this.Location.DayNumber();
            this.MeanAnomaly += ((int)Math.Abs(this.MeanAnomaly / 360) + 1) * 360;

            this.Location.Oblecl = 23.4393 - 3.563E-7 * this.Location.DayNumber();

            this.Perturbation.Msun = this.MeanAnomaly;
        }

        public override void GeocentricPos()
        {
            double L = (this.Perihelion + this.MeanAnomaly) % 360;
            double E = this.MeanAnomaly + (180 / Math.PI * ec * Math.Sin(this.MeanAnomaly * Math.PI / 180) * (1 + ec * Math.Cos(this.MeanAnomaly * Math.PI / 180)));
            double x1 = Math.Cos(E * Math.PI / 180) - ec;
            double y1 = Math.Sin(E * Math.PI / 180) * Math.Sqrt(1 - ec * ec);
            double r = Math.Sqrt(x1 * x1 + y1 * y1);
            double v = Math.Atan2(y1, x1) * 180 / Math.PI;
            double longtitude = v + this.Perihelion;
            this.Position.X = r * Math.Cos(longtitude * Math.PI / 180);
            this.Position.Y = r * Math.Sin(longtitude * Math.PI / 180);
            this.Position.Z = 0.0;
            double xeq = this.Position.X;
            double yeq = this.Position.Y * Math.Cos(this.Location.Oblecl * Math.PI / 180) - this.Position.Z * Math.Sin(this.Location.Oblecl * Math.PI / 180);
            double zeq = this.Position.Y * Math.Sin(this.Location.Oblecl * Math.PI / 180) + this.Position.Z * Math.Cos(this.Location.Oblecl * Math.PI / 180);
            this.Distance = Math.Sqrt(xeq * xeq + yeq * yeq + zeq * zeq);

            SkyPosition.Rectascence = (360 + (Math.Atan2(yeq, xeq) * 180 / Math.PI)) % 360;
            SkyPosition.Declination = Math.Asin(zeq / this.Distance) * 180 / Math.PI;

            this.Perturbation.Ls = L;
            this.Location.xs = this.Position.X;
            this.Location.ys = this.Position.Y;
            this.Location.zs = this.Position.Z;
            this.Location.slon = longtitude;
            this.Location.sRA = SkyPosition.Rectascence;
            this.Location.sDecl = SkyPosition.Declination;
        }

        public override void Ephemerides()
        {
            Diameter = 1919.26;
            this.Magnitude = -24;
        }

        public override void Perturbations()
        {
            throw new NotImplementedException();
        }
    }
}
