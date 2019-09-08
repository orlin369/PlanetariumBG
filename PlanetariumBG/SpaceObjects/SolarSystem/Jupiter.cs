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
    public class Jupiter : SolarSystemObject
    {
        public Jupiter()
        {
            this.Name = "Jupiter";
        }

        public override void OrbitalElements()
        {
            N = 100.4542 + 2.76854E-5 * this.Location.DayNumber();
            i = 1.303 - 1.557E-7 * this.Location.DayNumber();
            w = 273.8777 + 1.64505E-5 * this.Location.DayNumber();
            a = 5.20256;
            ec = 0.048498 + 4.469E-9 * this.Location.DayNumber();
            M = 19.895 + 0.0830853001 * this.Location.DayNumber();
            M += ((int)Math.Abs(M / 360) + 1) * 360;
            d = 6; T = 11.9 * 365; d0 = 196.94;
            pert.Mj = M;
        }

        public override void Perturbations()
        {
            lon = (360 + (Math.Atan2(yeclip, xeclip) * 180 / Math.PI)) % 360;
            lon += pj.PertInLon();
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
            this.Magnitude = -9.25 + 5 * Math.Log10(helDist * dist) + 0.014 * FV;
        }

        private PertJupiter pj = new PertJupiter();
    }
}
