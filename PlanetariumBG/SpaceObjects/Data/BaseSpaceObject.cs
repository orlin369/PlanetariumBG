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

        #region Variables

        protected double rr, v, xeclip, yeclip, zeclip;
        protected double Longitude;
        protected double Latitude;

        #endregion

        #region Properties

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

        public string Type
        {
            get;
            set;
        }

        public SkyPosition SkyPosition
        {
            get;
            set;
        }

        public double Inclination
        {
            get;
            set;
        }

        /// <summary>
        /// The perihelion is the point in the orbit of a planet, asteroid or comet that is nearest to the sun.
        /// It is the opposite of aphelion, which is the point farthest from the sun.
        /// </summary>
        public double Perihelion
        {
            get;
            set;
        }

        /// <summary>
        /// Mean Distance (a) - the semi-major axis of the orbit measured in Astronomical Units (1 AU = 149.59787 million km);
        /// </summary>
        public double MeanDistance
        {
            get;
            set;
        }

        /// <summary>
        /// Mean Anomaly (M) - angle increasing uniformly with time by 360 degrees per orbital period from 0 at perihelion;
        /// </summary>
        public double MeanAnomaly
        {
            get;
            set;
        }

        /// <summary>
        /// Distance from Earth.
        /// </summary>
        public double Distance
        {
            get;
            set;
        }

        /// <summary>
        /// Physical diameter.
        /// </summary>
        public double Diameter
        {
            get;
            set;
        }

        /// <summary>
        /// In astronomy, a planet's elongation is the angular separation between the Sun and the planet, with Earth as the reference point.
        /// </summary>
        public double Elongation
        {
            get;
            set;
        }

        public double Phase
        {
            get;
            set;
        }

        public LocationST Location
        {
            get;
            set;
        }

        /// <summary>
        /// True Anomaly (TA) - the actual angle between the spacecraft position and the perihelion as seen from the Sun.
        /// This angle increases non-uniformly with time, changing most rapidly at perihelion.
        /// </summary>
        public double TrueAnomaly
        {
            get;
            set;
        }

        /// <summary>
        /// In orbital mechanics, mean motion (represented by n) is the angular speed required for a body to complete one orbit,
        /// assuming constant speed in a circular orbit which completes in the same time as the variable speed,
        /// elliptical orbit of the actual body.[
        /// </summary>
        public double MeanMotion
        {
            get;
            set;
        }

        protected double helDist
        {
            get;
            set;
        }

        protected double SunDistance
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

        public double ec
        {
            get;
            set;
        }

        public double FV
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public BaseSpaceObject()
        {
            this.SkyPosition = new SkyPosition();
            this.Location = LocationST.GetInstance();
        }

        #endregion

        #region Public Methods

        public abstract void Ephemerides();

        public abstract void OrbitalElements();

        public abstract void Perturbations();

        virtual public void GeocentricPos()
        {
            xeclip += this.Location.xs;
            yeclip += this.Location.ys;
            zeclip += this.Location.zs;
            this.Distance = Math.Sqrt(xeclip * xeclip + yeclip * yeclip + zeclip * zeclip);

            double xequat = xeclip;
            double yequat = yeclip * Math.Cos(this.Location.Oblecl * Math.PI / 180) - zeclip * Math.Sin(this.Location.Oblecl * Math.PI / 180);
            double zequat = yeclip * Math.Sin(this.Location.Oblecl * Math.PI / 180) + zeclip * Math.Cos(this.Location.Oblecl * Math.PI / 180);

            this.SunDistance = Math.Sqrt(this.Location.xs * this.Location.xs + this.Location.ys * this.Location.ys + this.Location.zs * this.Location.zs);

            SkyPosition.Rectascence = (360 + (Math.Atan2(yequat, xequat) * 180 / Math.PI)) % 360;
            SkyPosition.Declination = Math.Atan2(zequat, Math.Sqrt(xequat * xequat + yequat * yequat)) * 180 / Math.PI;
        }

        #endregion

    }
}
