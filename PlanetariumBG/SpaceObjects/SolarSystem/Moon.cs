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
            i = 5.1454;
            w = (360 + (318.0634 + 0.1643573223 * this.Location.DayNumber())) % 360;
            a = 60.2666;
            ec = 0.0549;
            M = 115.3654 + 13.0649929509 * this.Location.DayNumber();
            M += ((int)Math.Abs(M / 360) + 1) * 360;

            pert.Mm = M;
            pert.Lm = N + w + M;
            pert.D = pert.Lm - pert.Ls;
            pert.F = pert.Lm - N;
        }

        public override void Perturbations()
        {
            lon += pm.PertInLon();
            lat += pm.PertInLat();
            dist = (a + pm.PertInDist());
        }

        public override void GeocentricPos()
        {
            double xeclip2 = Math.Cos(lon * Math.PI / 180.0D) * Math.Cos(lat * Math.PI / 180.0D);
            double yeclip2 = Math.Sin(lon * Math.PI / 180.0D) * Math.Cos(lat * Math.PI / 180.0D);
            double zeclip2 = Math.Sin(lat * Math.PI / 180.0D);
            double xequat = xeclip2;
            double yequat = yeclip2 * Math.Cos(this.Location.Oblecl * Math.PI / 180.0D) - zeclip2 * Math.Sin(this.Location.Oblecl * Math.PI / 180.0D);
            double zequat = yeclip2 * Math.Sin(this.Location.Oblecl * Math.PI / 180.0D) + zeclip2 * Math.Cos(this.Location.Oblecl * Math.PI / 180.0D);
            SkyPosition.Rectascence = (360 + (Math.Atan2(yequat, xequat) * 180.0D / Math.PI)) % 360;
            SkyPosition.Declination = Math.Atan2(zequat, Math.Sqrt(xequat * xequat + yequat * yequat)) * 180.0D / Math.PI;
        }

        public override void Ephemerides()
        {
            diam = 1873.7 * 60 / dist;
            dist = dist * 6378.140 / 1.49597870E8;
            elong = Math.Acos(
                Math.Sin(SkyPosition.Declination * Math.PI / 180.0D) * Math.Sin(this.Location.sDecl * Math.PI / 180.0D) +
                Math.Cos(SkyPosition.Declination * Math.PI / 180.0D) * Math.Cos(this.Location.sDecl * Math.PI / 180.0D) *
                Math.Cos((SkyPosition.Rectascence - this.Location.sRA) * Math.PI / 180.0D)) * 180.0D / Math.PI;
            phase = 180.0D - elong;
            this.Magnitude = -10;
        }

        //private PertElements pert = PertElements.GetInstance();
        private PertMoon pm = new PertMoon();
    }
}
