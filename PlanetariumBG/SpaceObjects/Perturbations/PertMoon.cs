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

namespace SpaceObjects.Perturbations
{
    /// <summary>
    /// 
    /// </summary>
    public class PertMoon : APerturbations
    {
        public PertMoon() { }

        public override double PertInLon()
        {
            double lon1 = -1.274 * Math.Sin((this.Perturbation.Mm - 2 * this.Perturbation.D) * Math.PI / 180);
            double lon2 = 0.658 * Math.Sin((2 * this.Perturbation.D) * Math.PI / 180);
            double lon3 = -0.186 * Math.Sin((this.Perturbation.Msun) * Math.PI / 180);
            double lon4 = -0.059 * Math.Sin((2 * this.Perturbation.Mm - 2 * this.Perturbation.D) * Math.PI / 180);
            double lon5 = -0.057 * Math.Sin((this.Perturbation.Mm - 2 * this.Perturbation.D + this.Perturbation.Msun) * Math.PI / 180);
            double lon6 = 0.053 * Math.Sin((this.Perturbation.Mm + 2 * this.Perturbation.D) * Math.PI / 180);
            double lon7 = 0.046 * Math.Sin((2 * this.Perturbation.D - this.Perturbation.Msun) * Math.PI / 180);
            double lon8 = 0.041 * Math.Sin((this.Perturbation.Mm - this.Perturbation.Msun) * Math.PI / 180);
            double lon9 = -0.035 * Math.Sin((this.Perturbation.D) * Math.PI / 180);
            double lon10 = -0.031 * Math.Sin((this.Perturbation.Mm + this.Perturbation.Msun) * Math.PI / 180);
            double lon11 = -0.015 * Math.Sin((2 * this.Perturbation.F - 2 * this.Perturbation.D) * Math.PI / 180);
            double lon12 = +0.011 * Math.Sin((this.Perturbation.Mm - 4 * this.Perturbation.D) * Math.PI / 180);
            double longitude = lon1 + lon2 + lon3 + lon4 + lon5 + lon6 +
                         lon7 + lon8 + lon9 + lon10 + lon11 + lon12;
            return longitude;
        }

        public override double PertInLat()
        {
            double lat1 = -0.173 * Math.Sin((this.Perturbation.F - 2 * this.Perturbation.D) * Math.PI / 180);
            double lat2 = -0.055 * Math.Sin((this.Perturbation.Mm - this.Perturbation.F - 2 * this.Perturbation.D) * Math.PI / 180);
            double lat3 = -0.046 * Math.Sin((this.Perturbation.Mm + this.Perturbation.F - 2 * this.Perturbation.D) * Math.PI / 180);
            double lat4 = 0.033 * Math.Sin((this.Perturbation.F + 2 * this.Perturbation.D) * Math.PI / 180);
            double lat5 = 0.017 * Math.Sin((2 * this.Perturbation.Mm + this.Perturbation.F) * Math.PI / 180);
            double latitude = lat1 + lat2 + lat3 + lat4 + lat5;
            return latitude;
        }

        public override double PertInDist()
        {
            double d1 = -0.58 * Math.Cos((this.Perturbation.Mm - 2 * this.Perturbation.D) * Math.PI / 180);
            double d2 = -0.46 * Math.Cos((2 * this.Perturbation.D) * Math.PI / 180);
            double dist = d1 + d2;
            return dist;
        }
    }
}
