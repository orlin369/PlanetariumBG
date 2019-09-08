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
using SpaceObjects.Perturbations;
using System;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SolarSystemObject : BaseSpaceObject
    {


        public PlanetPosition Position
        {
            get;
            set;
        }

        public SolarSystemObject()
        {
            this.Position = new PlanetPosition();
            this.SkyPosition = new SkyPosition();
        }

        public void ResetPlanet()
        {
            this.SkyPosition = new SkyPosition();
            this.Position = new PlanetPosition();

            this.SkyPosition.Rectascence = 0;
            this.SkyPosition.Decl = 0;

            this.Position.X = 0;
            this.Position.Y = 0;
            this.Position.Z = 0;
        }

        virtual public void HeliocentricPos()
        {
            ResetPlanet();
            double E0 = M + (180 / Math.PI * ec * Math.Sin(M * Math.PI / 180) * (1 + ec * Math.Cos(M * Math.PI / 180)));
            double E1 = 0;
            for (short k = 0; k < 100; ++k)
            {
                E1 = E0 - (E0 - (180 / Math.PI) * ec * Math.Sin(E0 * Math.PI / 180) - M) / (1 + ec * Math.Sin(E0 * Math.PI / 180));
                if (Math.Abs(E0 - E1) < 0.00005) break;
                E0 = E1;
            }
            double E = E0;

            double x1 = a * (Math.Cos(E * Math.PI / 180) - ec);
            double y1 = a * Math.Sqrt(1 - ec * ec) * Math.Sin(E * Math.PI / 180);
            rr = Math.Sqrt(x1 * x1 + y1 * y1);
            v = (360 + Math.Atan2(y1, x1) * 180 / Math.PI) % 360;

            this.Position.X = xeclip = rr * (Math.Cos(N * Math.PI / 180) * Math.Cos((v + w) * Math.PI / 180) - Math.Sin(N * Math.PI / 180) * Math.Sin((v + w) * Math.PI / 180) * Math.Cos(i * Math.PI / 180));
            this.Position.Y = yeclip = rr * (Math.Sin(N * Math.PI / 180) * Math.Cos((v + w) * Math.PI / 180) + Math.Cos(N * Math.PI / 180) * Math.Sin((v + w) * Math.PI / 180) * Math.Cos(i * Math.PI / 180));
            this.Position.Z = zeclip = rr * Math.Sin((v + w) * Math.PI / 180) * Math.Sin(i * Math.PI / 180);

            helDist = Math.Sqrt(xeclip * xeclip + yeclip * yeclip + zeclip * zeclip);

            lon = (360 + (Math.Atan2(yeclip, xeclip) * 180 / Math.PI)) % 360;
            lat = Math.Asin(zeclip / rr) * 180 / Math.PI;
            a = Math.Sqrt(xeclip * xeclip + yeclip * yeclip + zeclip * zeclip);
        }

        public void TopocentricPos()
        {
            double LON = this.Location.Longitude,
                   LAT = this.Location.Latitude + 0.00000000001;
            double mpar = Math.Asin(1 / dist) * 180.0D / Math.PI;
            double GMST0 = (pert.Ls / 15 + 12 + (this.Location.MainDateTime.Hour - LON / 15) + (double)this.Location.MainDateTime.Minute / 60 + (double)this.Location.MainDateTime.Second / 3600) % 24;
            double SIDTIME = (GMST0 + LON / 15);
            double LST = SIDTIME * 15;
            this.Location.SIDTIME = SIDTIME;

            double HA = (360 + (LST - SkyPosition.Rectascence)) % 360;
            double gclat = LAT - 0.1924 * Math.Sin((2 * LAT) * Math.PI / 180.0D);
            double rho = 0.99833 + 0.00167 * Math.Cos((2 * LAT) * Math.PI / 180.0D);
            double g = Math.Atan(Math.Tan(gclat * Math.PI / 180.0D) / Math.Cos(HA * Math.PI / 180.0D)) * 180.0D / Math.PI;
            double topRA = SkyPosition.Rectascence - mpar * rho * Math.Cos(gclat * Math.PI / 180.0D) * Math.Sin(HA * Math.PI / 180.0D) / Math.Cos((SkyPosition.Decl + 0.000000001) * Math.PI / 180.0D);
            double topDecl = SkyPosition.Decl - mpar * rho * Math.Sin(gclat * Math.PI / 180.0D) * Math.Sin((g - SkyPosition.Decl) * Math.PI / 180.0D) / Math.Sin((g + 0.00000001) * Math.PI / 180.0D);
            SkyPosition.Rectascence = topRA;
            SkyPosition.Decl = topDecl;
        }

        protected PertElements pert = PertElements.GetInstance();
    }
}