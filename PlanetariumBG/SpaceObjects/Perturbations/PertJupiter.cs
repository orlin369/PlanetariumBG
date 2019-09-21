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
    public class PertJupiter : APerturbations
    {
        public PertJupiter() { }

        public override double PertInLon()
        {
            double lon1 = -0.332 * (Math.Sin((2 * this.Perturbation.Mj - 5 * this.Perturbation.Msat - 67.6) * Math.PI / 180));
            double lon2 = -0.056 * Math.Sin((2 * this.Perturbation.Mj - 2 * this.Perturbation.Msat + 21) * Math.PI / 180);
            double lon3 = 0.042 * Math.Sin((3 * this.Perturbation.Mj - 5 * this.Perturbation.Msat + 21) * Math.PI / 180);
            double lon4 = -0.036 * Math.Sin((this.Perturbation.Mj - 2 * this.Perturbation.Msat) * Math.PI / 180);
            double lon5 = 0.022 * Math.Cos((this.Perturbation.Mj - this.Perturbation.Msat) * Math.PI / 180);
            double lon6 = 0.023 * Math.Sin((2 * this.Perturbation.Mj - 3 * this.Perturbation.Msat + 52) * Math.PI / 180);
            double lon7 = -0.016 * Math.Sin((this.Perturbation.Mj - 5 * this.Perturbation.Msat - 69) * Math.PI / 180);
            double longitude = lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7;
            return longitude;
        }

        public override double PertInLat()
        {
            return 0;
        }

        public override double PertInDist()
        {
            return 0;
        }
    }
}
