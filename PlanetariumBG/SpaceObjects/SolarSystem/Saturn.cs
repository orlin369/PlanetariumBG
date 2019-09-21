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

using SpaceObjects.Perturbations;
using System;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Saturn : SolarSystemObject
    {
        public double ringTilt;

        public Saturn()
        {
            this.Name = "Saturn";
        }

        public override void OrbitalElements()
        {
            N = 113.6634 + 2.3898E-5 * this.Location.DayNumber();
            this.Inclination = 2.4886 - 1.081E-7 * this.Location.DayNumber();
            this.Perihelion = 339.3939 + 2.97661E-5 * this.Location.DayNumber();
            this.MeanDistance = 9.55475;
            ec = 0.055546 - 9.499E-9 * this.Location.DayNumber();
            this.MeanAnomaly = 316.967 + 0.0334442282 * this.Location.DayNumber();

            this.MeanMotion = 12; this.TrueAnomaly = 29.5 * 365; d0 = 165.6;

            this.Perturbation.Msat = this.MeanAnomaly;
        }

        public override void Perturbations()
        {
            this.Longitude = (360 + (Math.Atan2(this.YEclipse, this.XEclipse) * 180 / Math.PI)) % 360;
            this.Latitude = Math.Asin(this.ZEclipse / rr) * 180 / Math.PI;

            this.Longitude += ps.PertInLon();
            Latitude += ps.PertInLat();
        }

        public override void Ephemerides()
        {
            Diameter = d0 / this.Distance;
            double test = (this.SunDistance * this.SunDistance + this.Distance * this.Distance - helDist * helDist) /
                          (2 * this.SunDistance * this.Distance + 0.000000001);
            if (test < -1) test = -1;
            if (test > 1) test = 1;
            Elongation = Math.Acos(test) * 180 / Math.PI;

            test = (helDist * helDist + this.Distance * this.Distance - this.SunDistance * this.SunDistance) /
                   (2 * helDist * this.Distance + 0.000000001);
            if (test < -1) test = -1;
            if (test > 1) test = 1;
            this.FV = Math.Acos(test) * 180 / Math.PI;
            this.Phase = (1 + Math.Cos(this.FV * Math.PI / 180)) / 2;

            double ir = 28.06;
            double Nr = 169.51 + 3.82E-5 * this.Location.DayNumber();
            double ringTilt = Math.Asin(
                Math.Sin(this.Latitude * Math.PI / 180) * Math.Cos(ir * Math.PI / 180) -
                Math.Cos(this.Latitude * Math.PI / 180) * Math.Sin(ir * Math.PI / 180) * Math.Sin((this.Longitude - Nr) * Math.PI / 180)
                                        ) * 180 / Math.PI;
            double ring_mag = -2.6 * Math.Sin(Math.Abs(ringTilt) * Math.PI / 180) + 1.2 * Math.Pow(Math.Sin(ringTilt * Math.PI / 180), 2);
            this.Magnitude = -9.0 + 5 * Math.Log10(helDist * this.Distance) + 0.044 * this.FV + ring_mag;
        }

        private PertSaturn ps = new PertSaturn();
    }
}
