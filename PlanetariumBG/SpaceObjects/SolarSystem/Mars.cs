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
    public class Mars : SolarSystemObject
    {
        public Mars()
        {
            this.Name = "Mars";
        }

        public override void OrbitalElements()
        {
            N = 49.5574 + 2.11081E-5 * this.Location.DayNumber();
            this.Inclination = 1.8497 - 1.78E-8 * this.Location.DayNumber();
            this.Perihelion = 286.5016 + 2.92961E-5 * this.Location.DayNumber();
            this.MeanDistance = 1.523688;
            ec = 0.093405 + 2.516E-9 * this.Location.DayNumber();
            this.MeanAnomaly = 18.6021 + 0.5240207766 * this.Location.DayNumber();
            this.MeanAnomaly += ((int)Math.Abs(this.MeanAnomaly / 360) + 1) * 360;

            this.MeanMotion = 1.7; this.TrueAnomaly = 687; d0 = 9.36;
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
            this.Magnitude = -1.51 + 5 * Math.Log10(helDist * this.Distance) + 0.016 * FV;
        }

        public override void Perturbations()
        {
            throw new NotImplementedException();
        }
    }
}
