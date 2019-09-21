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
using SpaceObjects.Perturbations;
using SpaceObjects.Utilities;
using System;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Moon : SolarSystemObject
    {
        public Moon()
        {
            this.Name = "Moon";
        }

        public override void OrbitalElements()
        {
            N = 125.1228 - 0.0529538083 * this.Location.DayNumber();
            this.Inclination = 5.1454;
            this.Perihelion = (360 + (318.0634 + 0.1643573223 * this.Location.DayNumber())) % 360;
            this.MeanDistance = 60.2666;
            ec = 0.0549;
            this.MeanAnomaly = 115.3654 + 13.0649929509 * this.Location.DayNumber();
            this.MeanAnomaly += ((int)Math.Abs(this.MeanAnomaly / 360) + 1) * 360;

            pert.Mm = this.MeanAnomaly;
            pert.Lm = N + this.Perihelion + this.MeanAnomaly;
            pert.D = pert.Lm - pert.Ls;
            pert.F = pert.Lm - N;
        }

        public override void Perturbations()
        {
            lon += pm.PertInLon();
            lat += pm.PertInLat();
            this.Distance = (this.MeanDistance + pm.PertInDist());
        }

        public override void GeocentricPos()
        {
            double xeclip2 = Math.Cos(MathHelp.DegreeToRadian(lon)) * Math.Cos(MathHelp.DegreeToRadian(lat));
            double yeclip2 = Math.Sin(MathHelp.DegreeToRadian(lon)) * Math.Cos(MathHelp.DegreeToRadian(lat));
            double zeclip2 = Math.Sin(MathHelp.DegreeToRadian(lat));
            double xequat = xeclip2;
            double yequat = yeclip2 * Math.Cos(MathHelp.DegreeToRadian(this.Location.Oblecl)) - zeclip2 * Math.Sin(MathHelp.DegreeToRadian(this.Location.Oblecl));
            double zequat = yeclip2 * Math.Sin(MathHelp.DegreeToRadian(this.Location.Oblecl)) + zeclip2 * Math.Cos(MathHelp.DegreeToRadian(this.Location.Oblecl));
            SkyPosition.Rectascence = (360 + (Math.Atan2(yequat, xequat) * 180.0D / Math.PI)) % 360;
            SkyPosition.Declination = Math.Atan2(zequat, Math.Sqrt(xequat * xequat + yequat * yequat)) * 180.0D / Math.PI;
        }

        public override void Ephemerides()
        {
            Diameter = 1873.7 * 60 / this.Distance;
            this.Distance = this.Distance * 6378.140 / 1.49597870E8;
            Elongation = Math.Acos(
                Math.Sin(MathHelp.DegreeToRadian(SkyPosition.Declination)) * Math.Sin(MathHelp.DegreeToRadian(this.Location.sDecl)) +
                Math.Cos(MathHelp.DegreeToRadian(SkyPosition.Declination)) * Math.Cos(MathHelp.DegreeToRadian(this.Location.sDecl)) *
                Math.Cos(MathHelp.DegreeToRadian(SkyPosition.Rectascence - this.Location.sRA))) * 180.0D / Math.PI;
            this.Phase = 180.0D - Elongation;
            this.Magnitude = -10;
        }

        //private PertElements pert = PertElements.GetInstance();
        private PertMoon pm = new PertMoon();
    }
}
