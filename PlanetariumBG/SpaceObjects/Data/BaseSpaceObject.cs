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

namespace SpaceObjects.Data
{
    [Serializable]
    public abstract class BaseSpaceObject : ISpaceObject
    {
        public string Spectrum
        {
            get;
            set;
        }

        public double Magnitude
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public SkyPosition SkyPosition
        {
            get;
            set;
        }

        public BaseSpaceObject()
        {
            this.SkyPosition = new SkyPosition();
            this.Location = LocationST.GetInstance();
        }

        #region Properties

        public double d
        {
            get;
            set;
        }
        public double T
        {
            get;
            set;
        }
        public double d0
        {
            get;
            set;
        }
        public double N
        {
            get;
            set;
        }
        public double i
        {
            get;
            set;
        }
        public double w
        {
            get;
            set;
        }
        public double a
        {
            get;
            set;
        }
        public double ec
        {
            get;
            set;
        }
        public double M
        {
            get;
            set;
        }
        public double dist
        {
            get;
            set;
        }
        public double diam
        {
            get;
            set;
        }
        public double elong
        {
            get;
            set;
        }
        public double FV
        {
            get;
            set;
        }
        public double phase
        {
            get;
            set;
        }

        #endregion

        public LocationST Location
        {
            get;
            set;
        }

        public abstract void Ephemerides();

        public abstract void OrbitalElements();

        public abstract void Perturbations();



        protected double helDist
        {
            get;
            set;
        }
        protected double sunDist
        {
            get;
            set;
        }


        protected double rr, v, xeclip, yeclip, zeclip, lon, lat;

        virtual public void GeocentricPos()
        {
            xeclip += this.Location.xs;
            yeclip += this.Location.ys;
            zeclip += this.Location.zs;
            dist = Math.Sqrt(xeclip * xeclip + yeclip * yeclip + zeclip * zeclip);

            double xequat = xeclip;
            double yequat = yeclip * Math.Cos(this.Location.Oblecl * Math.PI / 180) - zeclip * Math.Sin(this.Location.Oblecl * Math.PI / 180);
            double zequat = yeclip * Math.Sin(this.Location.Oblecl * Math.PI / 180) + zeclip * Math.Cos(this.Location.Oblecl * Math.PI / 180);

            sunDist = Math.Sqrt(this.Location.xs * this.Location.xs + this.Location.ys * this.Location.ys + this.Location.zs * this.Location.zs);

            SkyPosition.RA = (360 + (Math.Atan2(yequat, xequat) * 180 / Math.PI)) % 360;
            SkyPosition.Decl = Math.Atan2(zequat, Math.Sqrt(xequat * xequat + yequat * yequat)) * 180 / Math.PI;
        }
    }
}
