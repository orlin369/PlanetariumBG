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
            double lon1 = 0.812 * Math.Sin((2 * pert.Mj - 5 * pert.Msat - 67.6) * Math.PI / 180);
            double lon2 = -0.229 * Math.Cos((2 * pert.Mj - 4 * pert.Msat - 2) * Math.PI / 180);
            double lon3 = 0.119 * Math.Sin((pert.Mj - 2 * pert.Msat - 3) * Math.PI / 180);
            double lon4 = 0.046 * Math.Sin((2 * pert.Mj - 6 * pert.Msat - 69) * Math.PI / 180);
            double lon5 = 0.014 * Math.Sin((pert.Mj - 3 * pert.Msat + 32) * Math.PI / 180);
            double lon = lon1 + lon2 + lon3 + lon4 + lon5;
            return lon;
        }

        public override double PertInLat()
        {
            double lat1 = -0.02 * Math.Cos((2 * pert.Mj - 4 * pert.Msat - 2) * Math.PI / 180);
            double lat2 = 0.018 * Math.Sin((2 * pert.Mj - 6 * pert.Msat - 49) * Math.PI / 180);
            double lat = lat1 + lat2;
            return lat;
        }

        public override double PertInDist()
        {
            return 0;
        }
    }
}
