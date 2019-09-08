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

using SpaceObjects.SolarSystem;
using System;

namespace Planetarium
{
    /// <summary>
    /// 
    /// </summary>
    public class AngularDistances
    {
        public SolarSystemData pd = SolarSystemData.GetInstance();

        public AngularDistances() { }

        public double AngularDistance(string planets)
        {
            pd.PlanetPositions();
            switch (planets)
            {
                case "MerVen": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl);
                case "MerMar": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl);
                case "MerJup": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl);
                case "MerSat": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl);
                case "MerUra": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl);
                case "MerNep": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl);
                case "MerPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "MerMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mercury").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "VenMar": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl);
                case "VenJup": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl);
                case "VenSat": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl);
                case "VenUra": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl);
                case "VenNep": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl);
                case "VenPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "VenMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Venus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "MarJup": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl);
                case "MarSat": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl);
                case "MarUra": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl);
                case "MarNep": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl);
                case "MarPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "MarMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Mars").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "JupSat": return Calculation(pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl);
                case "JupUra": return Calculation(pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl);
                case "JupNep": return Calculation(pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl);
                case "JupPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "JupMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Jupiter").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "SatUra": return Calculation(pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl);
                case "SatNep": return Calculation(pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl);
                case "SatPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "SatMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Saturn").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "UraNep": return Calculation(pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl);
                case "UraPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "UraMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Uranus").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "NepPlu": return Calculation(pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl);
                case "NepMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Neptune").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "PluMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Pluto").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);

                case "SunMoo": return Calculation(pd.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.Decl, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.RA, pd.SolarSystemObjects.GetObjectByName("Moon").SkyPosition.Decl);
            }
            return 0;
        }

        public double Calculation(double RA1, double decl1, double RA2, double decl2)
        {
            return Math.Acos(
                Math.Sin(decl1 * Math.PI / 180) * Math.Sin(decl2 * Math.PI / 180) +
                Math.Cos(decl1 * Math.PI / 180) * Math.Cos(decl2 * Math.PI / 180) * Math.Cos((RA1 - RA2) * Math.PI / 180)) * 180 / Math.PI;
        }
    }
}
