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

using SpaceObjects.Perturbations;

namespace SpaceObjects.SolarSystem
{
	/// <summary>
	/// 
	/// </summary>
	public class Moon : APlanet
	{
		public Moon(string name){this.name = name;}

		public override void OrbitalElements()
		{
			N = 125.1228 - 0.0529538083 * location.dayNumber();
			i = 5.1454;
			w = (360+(318.0634 + 0.1643573223 * location.dayNumber()))%360;
			a = 60.2666;
			ec = 0.0549;
			M = 115.3654 + 13.0649929509 * location.dayNumber();
			M += ((int)Math.Abs(M/360)+1)*360;

			pert.Mm = M;
			pert.Lm = N + w + M;
			pert.D = pert.Lm - pert.Ls;
			pert.F = pert.Lm - N;
		}

		public override void Perturbations()
		{
			lon += pm.PertInLon();
			lat += pm.PertInLat();
			dist = (a + pm.PertInDist());
		}

		public override void GeocentricPos()
		{
			double xeclip2 = Math.Cos(lon*PI/180) * Math.Cos(lat*PI/180);
			double yeclip2 = Math.Sin(lon*PI/180) * Math.Cos(lat*PI/180);
			double zeclip2 = Math.Sin(lat*PI/180);
			double xequat = xeclip2;
			double yequat = yeclip2 * Math.Cos(location.oblecl*PI/180) - zeclip2*Math.Sin(location.oblecl*PI/180);
			double zequat = yeclip2 * Math.Sin(location.oblecl*PI/180) + zeclip2*Math.Cos(location.oblecl*PI/180);
			SkyPosition.RA = (360+(Math.Atan2(yequat,xequat) * 180/PI))%360;
			SkyPosition.Decl = Math.Atan2(zequat,Math.Sqrt(xequat*xequat+yequat*yequat)) * 180/PI;
			name = "Moon";
		}

		public override void TopocentricPos()
		{
			double LON = location.v_Lon, 
				   LAT = location.v_Lat + 0.00000000001;
			double mpar = Math.Asin(1/dist) * 180/PI;
			double GMST0 = (pert.Ls/15 + 12 + (location.v_mainDT.Hour - LON/15) + (double)location.v_mainDT.Minute/60 + (double)location.v_mainDT.Second/3600)%24;
			double SIDTIME = (GMST0 + LON/15);
			double LST = SIDTIME * 15;
			location.SIDTIME = SIDTIME;

			double HA = (360+(LST - SkyPosition.RA))%360;
			double gclat = LAT - 0.1924*Math.Sin((2*LAT)*PI/180);
			double rho = 0.99833 + 0.00167*Math.Cos((2*LAT)*PI/180);
			double g = Math.Atan(Math.Tan(gclat*PI/180)/Math.Cos(HA*PI/180))*180/PI;
			double topRA = SkyPosition.RA - mpar*rho*Math.Cos(gclat*PI/180)*Math.Sin(HA*PI/180)/Math.Cos((SkyPosition.Decl+0.000000001)*PI/180);
			double topDecl = SkyPosition.Decl - mpar*rho*Math.Sin(gclat*PI/180)*Math.Sin((g-SkyPosition.Decl)*PI/180)/Math.Sin((g+0.00000001)*PI/180);
			SkyPosition.RA = topRA;
			SkyPosition.Decl = topDecl;
		}

		public override void Ephemerides()
		{
			diam = 1873.7*60/dist;
			dist = dist*6378.140/1.49597870E8;
			elong = Math.Acos(
				Math.Sin(SkyPosition.Decl*Math.PI/180)*Math.Sin(location.sDecl*Math.PI/180)+
				Math.Cos(SkyPosition.Decl*Math.PI/180)*Math.Cos(location.sDecl*Math.PI/180)*
				Math.Cos((SkyPosition.RA-location.sRA)*Math.PI/180))*180/Math.PI;
			phase = 180 - elong;
			magnitude = -10;
		}

		private PertElements pert = PertElements.GetInstance();
		private PertMoon pm = new PertMoon();
	}
}
