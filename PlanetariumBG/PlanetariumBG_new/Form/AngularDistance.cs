using System;

using SpaceObjects.SolarSystem;

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
				case "MerVen": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl);
				case "MerMar": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Mars"].skyPosition.RA,    pd.planets["Mars"].skyPosition.Decl);
				case "MerJup": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl);
				case "MerSat": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Saturn"].skyPosition.RA,  pd.planets["Saturn"].skyPosition.Decl);
				case "MerUra": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Uranus"].skyPosition.RA,  pd.planets["Uranus"].skyPosition.Decl);
				case "MerNep": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl);
				case "MerPlu": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA,   pd.planets["Pluto"].skyPosition.Decl);
				case "MerMoo": return Calculation(pd.planets["Mercury"].skyPosition.RA, pd.planets["Mercury"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,    pd.planets["Moon"].skyPosition.Decl);

				case "VenMar": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Mars"].skyPosition.RA,    pd.planets["Mars"].skyPosition.Decl);
				case "VenJup": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl);
				case "VenSat": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Saturn"].skyPosition.RA,  pd.planets["Saturn"].skyPosition.Decl);
				case "VenUra": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Uranus"].skyPosition.RA,  pd.planets["Uranus"].skyPosition.Decl);
				case "VenNep": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl);
				case "VenPlu": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA,   pd.planets["Pluto"].skyPosition.Decl);
				case "VenMoo": return Calculation(pd.planets["Venus"].skyPosition.RA, pd.planets["Venus"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,    pd.planets["Moon"].skyPosition.Decl);
				
				case "MarJup": return Calculation(pd.planets["Mars"].skyPosition.RA, pd.planets["Mars"].skyPosition.Decl, pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl);
				case "MarSat": return Calculation(pd.planets["Mars"].skyPosition.RA, pd.planets["Mars"].skyPosition.Decl, pd.planets["Saturn"].skyPosition.RA,  pd.planets["Saturn"].skyPosition.Decl);
				case "MarUra": return Calculation(pd.planets["Mars"].skyPosition.RA, pd.planets["Mars"].skyPosition.Decl, pd.planets["Uranus"].skyPosition.RA,  pd.planets["Uranus"].skyPosition.Decl);
				case "MarNep": return Calculation(pd.planets["Mars"].skyPosition.RA, pd.planets["Mars"].skyPosition.Decl, pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl);
				case "MarPlu": return Calculation(pd.planets["Mars"].skyPosition.RA, pd.planets["Mars"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA,   pd.planets["Pluto"].skyPosition.Decl);
				case "MarMoo": return Calculation(pd.planets["Mars"].skyPosition.RA, pd.planets["Mars"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,    pd.planets["Moon"].skyPosition.Decl);
				
				case "JupSat": return Calculation(pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl, pd.planets["Saturn"].skyPosition.RA,  pd.planets["Saturn"].skyPosition.Decl);
				case "JupUra": return Calculation(pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl, pd.planets["Uranus"].skyPosition.RA,  pd.planets["Uranus"].skyPosition.Decl);
				case "JupNep": return Calculation(pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl, pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl);
				case "JupPlu": return Calculation(pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA,   pd.planets["Pluto"].skyPosition.Decl);
				case "JupMoo": return Calculation(pd.planets["Jupiter"].skyPosition.RA, pd.planets["Jupiter"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,    pd.planets["Moon"].skyPosition.Decl);
				
				case "SatUra": return Calculation(pd.planets["Saturn"].skyPosition.RA, pd.planets["Saturn"].skyPosition.Decl, pd.planets["Uranus"].skyPosition.RA,  pd.planets["Uranus"].skyPosition.Decl);
				case "SatNep": return Calculation(pd.planets["Saturn"].skyPosition.RA, pd.planets["Saturn"].skyPosition.Decl, pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl);
				case "SatPlu": return Calculation(pd.planets["Saturn"].skyPosition.RA, pd.planets["Saturn"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA,   pd.planets["Pluto"].skyPosition.Decl);
				case "SatMoo": return Calculation(pd.planets["Saturn"].skyPosition.RA, pd.planets["Saturn"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,    pd.planets["Moon"].skyPosition.Decl);
				
				case "UraNep": return Calculation(pd.planets["Uranus"].skyPosition.RA, pd.planets["Uranus"].skyPosition.Decl, pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl);
				case "UraPlu": return Calculation(pd.planets["Uranus"].skyPosition.RA, pd.planets["Uranus"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA,   pd.planets["Pluto"].skyPosition.Decl);
				case "UraMoo": return Calculation(pd.planets["Uranus"].skyPosition.RA, pd.planets["Uranus"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,    pd.planets["Moon"].skyPosition.Decl);
				
				case "NepPlu": return Calculation(pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl, pd.planets["Pluto"].skyPosition.RA, pd.planets["Pluto"].skyPosition.Decl);
				case "NepMoo": return Calculation(pd.planets["Neptune"].skyPosition.RA, pd.planets["Neptune"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA,  pd.planets["Moon"].skyPosition.Decl);
				
				case "PluMoo": return Calculation(pd.planets["Pluto"].skyPosition.RA, pd.planets["Pluto"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA, pd.planets["Moon"].skyPosition.Decl);

				case "SunMoo": return Calculation(pd.planets["Sun"].skyPosition.RA, pd.planets["Sun"].skyPosition.Decl, pd.planets["Moon"].skyPosition.RA, pd.planets["Moon"].skyPosition.Decl);
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
