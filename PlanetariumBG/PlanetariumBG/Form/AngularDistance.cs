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
		public PlanetData pd = PlanetData.GetInstance();

		public AngularDistances(){}

		public double AngularDistance (string planets)
		{
			pd.PlanetPositions();
			switch (planets){
				case "MerVen": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl);
				case "MerMar": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Mars"].SkyPosition.RA,    pd.planets["Mars"].SkyPosition.Decl);
				case "MerJup": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl);
				case "MerSat": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Saturn"].SkyPosition.RA,  pd.planets["Saturn"].SkyPosition.Decl);
				case "MerUra": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Uranus"].SkyPosition.RA,  pd.planets["Uranus"].SkyPosition.Decl);
				case "MerNep": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl);
				case "MerPlu": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA,   pd.planets["Pluto"].SkyPosition.Decl);
				case "MerMoo": return Calculation(pd.planets["Mercury"].SkyPosition.RA, pd.planets["Mercury"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,    pd.planets["Moon"].SkyPosition.Decl);

				case "VenMar": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Mars"].SkyPosition.RA,    pd.planets["Mars"].SkyPosition.Decl);
				case "VenJup": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl);
				case "VenSat": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Saturn"].SkyPosition.RA,  pd.planets["Saturn"].SkyPosition.Decl);
				case "VenUra": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Uranus"].SkyPosition.RA,  pd.planets["Uranus"].SkyPosition.Decl);
				case "VenNep": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl);
				case "VenPlu": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA,   pd.planets["Pluto"].SkyPosition.Decl);
				case "VenMoo": return Calculation(pd.planets["Venus"].SkyPosition.RA, pd.planets["Venus"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,    pd.planets["Moon"].SkyPosition.Decl);
				
				case "MarJup": return Calculation(pd.planets["Mars"].SkyPosition.RA, pd.planets["Mars"].SkyPosition.Decl, pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl);
				case "MarSat": return Calculation(pd.planets["Mars"].SkyPosition.RA, pd.planets["Mars"].SkyPosition.Decl, pd.planets["Saturn"].SkyPosition.RA,  pd.planets["Saturn"].SkyPosition.Decl);
				case "MarUra": return Calculation(pd.planets["Mars"].SkyPosition.RA, pd.planets["Mars"].SkyPosition.Decl, pd.planets["Uranus"].SkyPosition.RA,  pd.planets["Uranus"].SkyPosition.Decl);
				case "MarNep": return Calculation(pd.planets["Mars"].SkyPosition.RA, pd.planets["Mars"].SkyPosition.Decl, pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl);
				case "MarPlu": return Calculation(pd.planets["Mars"].SkyPosition.RA, pd.planets["Mars"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA,   pd.planets["Pluto"].SkyPosition.Decl);
				case "MarMoo": return Calculation(pd.planets["Mars"].SkyPosition.RA, pd.planets["Mars"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,    pd.planets["Moon"].SkyPosition.Decl);
				
				case "JupSat": return Calculation(pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl, pd.planets["Saturn"].SkyPosition.RA,  pd.planets["Saturn"].SkyPosition.Decl);
				case "JupUra": return Calculation(pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl, pd.planets["Uranus"].SkyPosition.RA,  pd.planets["Uranus"].SkyPosition.Decl);
				case "JupNep": return Calculation(pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl, pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl);
				case "JupPlu": return Calculation(pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA,   pd.planets["Pluto"].SkyPosition.Decl);
				case "JupMoo": return Calculation(pd.planets["Jupiter"].SkyPosition.RA, pd.planets["Jupiter"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,    pd.planets["Moon"].SkyPosition.Decl);
				
				case "SatUra": return Calculation(pd.planets["Saturn"].SkyPosition.RA, pd.planets["Saturn"].SkyPosition.Decl, pd.planets["Uranus"].SkyPosition.RA,  pd.planets["Uranus"].SkyPosition.Decl);
				case "SatNep": return Calculation(pd.planets["Saturn"].SkyPosition.RA, pd.planets["Saturn"].SkyPosition.Decl, pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl);
				case "SatPlu": return Calculation(pd.planets["Saturn"].SkyPosition.RA, pd.planets["Saturn"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA,   pd.planets["Pluto"].SkyPosition.Decl);
				case "SatMoo": return Calculation(pd.planets["Saturn"].SkyPosition.RA, pd.planets["Saturn"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,    pd.planets["Moon"].SkyPosition.Decl);
				
				case "UraNep": return Calculation(pd.planets["Uranus"].SkyPosition.RA, pd.planets["Uranus"].SkyPosition.Decl, pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl);
				case "UraPlu": return Calculation(pd.planets["Uranus"].SkyPosition.RA, pd.planets["Uranus"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA,   pd.planets["Pluto"].SkyPosition.Decl);
				case "UraMoo": return Calculation(pd.planets["Uranus"].SkyPosition.RA, pd.planets["Uranus"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,    pd.planets["Moon"].SkyPosition.Decl);
				
				case "NepPlu": return Calculation(pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl, pd.planets["Pluto"].SkyPosition.RA, pd.planets["Pluto"].SkyPosition.Decl);
				case "NepMoo": return Calculation(pd.planets["Neptune"].SkyPosition.RA, pd.planets["Neptune"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA,  pd.planets["Moon"].SkyPosition.Decl);
				
				case "PluMoo": return Calculation(pd.planets["Pluto"].SkyPosition.RA, pd.planets["Pluto"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA, pd.planets["Moon"].SkyPosition.Decl);

				case "SunMoo": return Calculation(pd.planets["Sun"].SkyPosition.RA, pd.planets["Sun"].SkyPosition.Decl, pd.planets["Moon"].SkyPosition.RA, pd.planets["Moon"].SkyPosition.Decl);
			}
			return 0;
		}

		public double Calculation (double RA1, double decl1, double RA2, double decl2)
		{
			return Math.Acos(
				Math.Sin(decl1*Math.PI/180)*Math.Sin(decl2*Math.PI/180)+
				Math.Cos(decl1*Math.PI/180)*Math.Cos(decl2*Math.PI/180)*Math.Cos((RA1-RA2)*Math.PI/180))*180/Math.PI;
		}
	}
}
