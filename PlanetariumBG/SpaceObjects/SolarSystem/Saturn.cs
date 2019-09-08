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
            i = 2.4886 - 1.081E-7 * this.Location.DayNumber();
            w = 339.3939 + 2.97661E-5 * this.Location.DayNumber();
            a = 9.55475;
            ec = 0.055546 - 9.499E-9 * this.Location.DayNumber();
            M = 316.967 + 0.0334442282 * this.Location.DayNumber();

            d = 12; T = 29.5 * 365; d0 = 165.6;

            pert.Msat = M;
        }

        public override void Perturbations()
        {
            lon = (360 + (Math.Atan2(yeclip, xeclip) * 180 / Math.PI)) % 360;
            lat = Math.Asin(zeclip / rr) * 180 / Math.PI;

            lon += ps.PertInLon();
            lat += ps.PertInLat();
        }

        public override void Ephemerides()
        {
            diam = d0 / dist;
            double test = (sunDist * sunDist + dist * dist - helDist * helDist) /
                          (2 * sunDist * dist + 0.000000001);
            if (test < -1) test = -1;
            if (test > 1) test = 1;
            elong = Math.Acos(test) * 180 / Math.PI;

            test = (helDist * helDist + dist * dist - sunDist * sunDist) /
                   (2 * helDist * dist + 0.000000001);
            if (test < -1) test = -1;
            if (test > 1) test = 1;
            FV = Math.Acos(test) * 180 / Math.PI;
            phase = (1 + Math.Cos(FV * Math.PI / 180)) / 2;

            double ir = 28.06;
            double Nr = 169.51 + 3.82E-5 * this.Location.DayNumber();
            double ringTilt = Math.Asin(
                Math.Sin(lat * Math.PI / 180) * Math.Cos(ir * Math.PI / 180) -
                Math.Cos(lat * Math.PI / 180) * Math.Sin(ir * Math.PI / 180) * Math.Sin((lon - Nr) * Math.PI / 180)
                                        ) * 180 / Math.PI;
            double ring_mag = -2.6 * Math.Sin(Math.Abs(ringTilt) * Math.PI / 180) + 1.2 * Math.Pow(Math.Sin(ringTilt * Math.PI / 180), 2);
            this.Magnitude = -9.0 + 5 * Math.Log10(helDist * dist) + 0.044 * FV + ring_mag;
        }

        private PertSaturn ps = new PertSaturn();
    }
}
