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
            this.Inclination = 1.303 - 1.557E-7 * this.Location.DayNumber();
            this.Perihelion = 273.8777 + 1.64505E-5 * this.Location.DayNumber();
            this.MeanDistance = 5.20256;
            ec = 0.048498 + 4.469E-9 * this.Location.DayNumber();
            this.MeanAnomaly = 19.895 + 0.0830853001 * this.Location.DayNumber();
            this.MeanAnomaly += ((int)Math.Abs(this.MeanAnomaly / 360) + 1) * 360;
            this.MeanMotion = 6; this.TrueAnomaly = 11.9 * 365; d0 = 196.94;
            this.Perturbation.Mj = this.MeanAnomaly;
        }

        public override void Perturbations()
        {
            this.Longitude = (360 + (Math.Atan2(yeclip, xeclip) * 180 / Math.PI)) % 360;
            this.Longitude += pj.PertInLon();
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
            FV = Math.Acos(test) * 180 / Math.PI;
            this.Phase = (1 + Math.Cos(FV * Math.PI / 180)) / 2;
            this.Magnitude = -9.25 + 5 * Math.Log10(helDist * this.Distance) + 0.014 * FV;
        }

        private PertJupiter pj = new PertJupiter();
    }
}
