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
    public class Venus : SolarSystemObject
    {
        public Venus()
        {
            this.Name = "Venus";
        }

        public override void OrbitalElements()
        {
            N = 76.6799 + 2.4659E-5 * this.Location.DayNumber();
            i = 3.3946 + 2.75E-8 * this.Location.DayNumber();
            w = 54.891 + 1.38374E-5 * this.Location.DayNumber();
            a = 0.72333;
            ec = 0.006773 - 1.302E-9 * this.Location.DayNumber();
            M = 48.0052 + 1.6021302244 * this.Location.DayNumber();
            M += ((int)Math.Abs(M / 360) + 1) * 360;

            d = 0.9; T = 225; d0 = 16.92;
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
            this.Magnitude = -4.34 + 5 * Math.Log10(helDist * dist) + 0.013 * FV + (4.2E-7) * Math.Pow(FV, 3);
        }

        public override void Perturbations()
        {
            throw new NotImplementedException();
        }
    }
}
