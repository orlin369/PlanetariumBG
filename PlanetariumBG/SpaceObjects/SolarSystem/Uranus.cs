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
using SpaceObjects.Utilities;
using System;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Uranus : SolarSystemObject
    {
        public Uranus()
        {
            this.Name = "Uranus";
        }

        public override void OrbitalElements()
        {
            N = 74.0005 + 1.3978E-5 * this.Location.DayNumber();
            this.Inclination = 0.7733 + 1.9E-8 * this.Location.DayNumber();
            this.Perihelion = 96.6612 + 3.0565E-5 * this.Location.DayNumber();
            this.MeanDistance = 19.18171 - 1.55E-8 * this.Location.DayNumber();
            ec = 0.047318 + 7.45E-9 * this.Location.DayNumber();
            this.MeanAnomaly = 142.5905 + 0.011725806 * this.Location.DayNumber();

            this.MeanMotion = 24; this.TrueAnomaly = 84 * 365; d0 = 56.8;

            this.Perturbation.Mu = this.MeanAnomaly;
        }

        public override void Perturbations()
        {
            this.Longitude = (360 + (Math.Atan2(this.YEclipse, this.XEclipse) * 180 / Math.PI)) % 360;
            this.Longitude += pu.PertInLon();
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
            this.Magnitude = -7.15 + 5 * Math.Log10(helDist * this.Distance) + 0.001 * this.FV;
        }

        private PertUranus pu = new PertUranus();
    }
}
