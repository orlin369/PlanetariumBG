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
using SpaceObjects.SolarSystem;
using System;

namespace Planetarium
{
    /// <summary>
    /// 
    /// </summary>
    public class AngularDistances
    {

        #region Variables

        /// <summary>
        /// Solar system data.
        /// </summary>
        public SolarSystemData solarSystemData;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AngularDistances()
        {
            this.solarSystemData = SolarSystemData.GetInstance();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Angular dstance to planets.
        /// </summary>
        /// <param name="planets"></param>
        /// <returns></returns>
        public double AngularDistance(string planets)
        {
            // TODO: Migreate all strings to ENUM.
            solarSystemData.PlanetPositions();
            switch (planets)
            {
                case "MerVen":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition);
                case "MerMar":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition);
                case "MerJup":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition);
                case "MerSat":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case "MerUra":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case "MerNep":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case "MerPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "MerMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "VenMar":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition);
                case "VenJup":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition);
                case "VenSat":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case "VenUra":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case "VenNep":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case "VenPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "VenMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "MarJup":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition);
                case "MarSat":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case "MarUra":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case "MarNep":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case "MarPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "MarMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "JupSat":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case "JupUra":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case "JupNep":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case "JupPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "JupMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "SatUra":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case "SatNep":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case "SatPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "SatMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "UraNep":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case "UraPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "UraMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "NepPlu":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case "NepMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "PluMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case "SunMoo":
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);
            }
            return 0;
        }


        public double Distance(SkyPosition a, SkyPosition b)
        {
            return Distance(a.Rectascence, a.Decl, b.Rectascence, b.Decl);
        }

        public double Distance(double RA1, double decl1, double RA2, double decl2)
        {
            return Math.Acos(
                Math.Sin(decl1 * Math.PI / 180) * Math.Sin(decl2 * Math.PI / 180) +
                Math.Cos(decl1 * Math.PI / 180) * Math.Cos(decl2 * Math.PI / 180) * Math.Cos((RA1 - RA2) * Math.PI / 180)) * 180 / Math.PI;
        }

        #endregion

    }
}
