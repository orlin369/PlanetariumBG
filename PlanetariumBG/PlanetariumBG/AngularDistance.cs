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
        public double AngularDistance(int planets)
        {
            solarSystemData.PlanetPositions();
            switch (planets)
            {
                case (int)Planets.Mercury + (int)Planets.Venus:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Mars:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Jupiter:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Saturn:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Uranus:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Neptune:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Mercury + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Venus + (int)Planets.Mars:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition);
                case (int)Planets.Venus + (int)Planets.Jupiter:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition);
                case (int)Planets.Venus + (int)Planets.Saturn:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case (int)Planets.Venus + (int)Planets.Uranus:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case (int)Planets.Venus + (int)Planets.Neptune:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case (int)Planets.Venus + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Venus + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Venus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Mars + (int)Planets.Jupiter:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition);
                case (int)Planets.Mars + (int)Planets.Saturn:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case (int)Planets.Mars + (int)Planets.Uranus:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case (int)Planets.Mars + (int)Planets.Neptune:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case (int)Planets.Mars + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Mars + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Mars").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Jupiter + (int)Planets.Saturn:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition);
                case (int)Planets.Jupiter + (int)Planets.Uranus:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case (int)Planets.Jupiter + (int)Planets.Neptune:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case (int)Planets.Jupiter + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Jupiter + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Saturn + (int)Planets.Uranus:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition);
                case (int)Planets.Saturn + (int)Planets.Neptune:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case (int)Planets.Saturn + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Saturn + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Uranus + (int)Planets.Neptune:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition);
                case (int)Planets.Uranus + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Uranus + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Neptune + (int)Planets.Pluto:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition);
                case (int)Planets.Neptune + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Pluto + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);

                case (int)Planets.Sun + (int)Planets.Moon:
                    return Distance(
                        solarSystemData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition,
                        solarSystemData.SolarSystemObjects.GetObjectByName("Moon").SkyPosition);
            }

            return 0;
        }

        public double Distance(SkyPosition a, SkyPosition b)
        {
            return Distance(a.Rectascence, a.Declination, b.Rectascence, b.Declination);
        }

        public double Distance(double rectascence1, double declination1, double rectascence2, double declination2)
        {
            return Math.Acos(
                Math.Sin(declination1 * Math.PI / 180) * Math.Sin(declination2 * Math.PI / 180) +
                Math.Cos(declination1 * Math.PI / 180) * Math.Cos(declination2 * Math.PI / 180) * Math.Cos((rectascence1 - rectascence2) * Math.PI / 180)) * 180 / Math.PI;
        }

        #endregion

    }
}
