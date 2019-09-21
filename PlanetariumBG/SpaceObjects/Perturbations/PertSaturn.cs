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
    public class PertSaturn : APerturbations
    {
        public PertSaturn() { }

        public override double PertInLon()
        {
            double lon1 = 0.812 * Math.Sin((2 * this.Perturbation.Mj - 5 * this.Perturbation.Msat - 67.6) * Math.PI / 180);
            double lon2 = -0.229 * Math.Cos((2 * this.Perturbation.Mj - 4 * this.Perturbation.Msat - 2) * Math.PI / 180);
            double lon3 = 0.119 * Math.Sin((this.Perturbation.Mj - 2 * this.Perturbation.Msat - 3) * Math.PI / 180);
            double lon4 = 0.046 * Math.Sin((2 * this.Perturbation.Mj - 6 * this.Perturbation.Msat - 69) * Math.PI / 180);
            double lon5 = 0.014 * Math.Sin((this.Perturbation.Mj - 3 * this.Perturbation.Msat + 32) * Math.PI / 180);
            double longitude = lon1 + lon2 + lon3 + lon4 + lon5;
            return longitude;
        }

        public override double PertInLat()
        {
            double lat1 = -0.02 * Math.Cos((2 * this.Perturbation.Mj - 4 * this.Perturbation.Msat - 2) * Math.PI / 180);
            double lat2 = 0.018 * Math.Sin((2 * this.Perturbation.Mj - 6 * this.Perturbation.Msat - 49) * Math.PI / 180);
            double latitude = lat1 + lat2;
            return latitude;
        }

        public override double PertInDist()
        {
            return 0;
        }
    }
}
