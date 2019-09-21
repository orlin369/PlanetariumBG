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

using SpaceObjects.Utilities;
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
            this.Inclination = 3.3946 + 2.75E-8 * this.Location.DayNumber();
            this.Perihelion = 54.891 + 1.38374E-5 * this.Location.DayNumber();
            this.MeanDistance = 0.72333;
            ec = 0.006773 - 1.302E-9 * this.Location.DayNumber();
            this.MeanAnomaly = 48.0052 + 1.6021302244 * this.Location.DayNumber();
            this.MeanAnomaly += ((int)Math.Abs(this.MeanAnomaly / 360) + 1) * 360;

            this.MeanMotion = 0.9; this.TrueAnomaly = 225; d0 = 16.92;
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
            this.Phase = (1 + Math.Cos(MathHelp.DegreeToRadian(this.FV))) / 2;
            this.Magnitude = -4.34 + 5 * Math.Log10(helDist * this.Distance) + 0.013 * this.FV + (4.2E-7) * Math.Pow(this.FV, 3);
        }

        public override void Perturbations()
        {
            throw new NotImplementedException();
        }
    }
}
