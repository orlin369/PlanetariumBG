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

using SpaceObjects.Data;
using System;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// Summary description for MoonShadow.
    /// </summary>
    public class EarthShadow : SolarSystemObject
    {
        public EarthShadow()
        {
            this.Name = "Earth shadow";
        }

        public override void OrbitalElements()
        {

        }

        public override void GeocentricPos()
        {
            SkyPosition.Rectascence = (this.Location.sRA + 180) % 360;
            SkyPosition.Declination = -this.Location.sDecl;
        }

        public override void Ephemerides()
        {
            throw new NotImplementedException();
        }

        public override void Perturbations()
        {
            throw new NotImplementedException();
        }

        public double DU
        {
            get;
            set;
        }
        public double DP
        {
            get;
            set;
        }
    }
}
