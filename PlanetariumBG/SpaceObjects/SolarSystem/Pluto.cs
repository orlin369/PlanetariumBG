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

namespace SpaceObjects.SolarSystem
{
	/// <summary>
	/// 
	/// </summary>
	public class Pluto : APlanet
	{
		public Pluto(string name){this.name = name;}

		public override void OrbitalElements()
		{
			N = 110.30347 - 0.0000002839 * location.dayNumber();
			i = 17.14175 + 8.418889999999999E-8 * location.dayNumber();
			double lp = 224.06676 - .00000100578 * location.dayNumber();
			w = lp - N;
			ec = 0.24880766 + 0.00000000177002 * location.dayNumber();
			a = 39.48168677 - 0.0000000210574 * location.dayNumber();
			M = 14.882 + 0.00396*location.dayNumber();
			d=50;	T=248*365;	d0=3.14;	name="Pluto";
		}

		public override void Ephemerides()
		{
			diam = d0/dist;
			double test = (sunDist*sunDist + dist*dist - helDist*helDist)/
				          (2*sunDist*dist+0.000000001);
			if (test < -1) test=-1;
			if (test > 1) test=1;
			elong = Math.Acos(test)*180/PI;

			test = (helDist*helDist + dist*dist - sunDist*sunDist)/
				   (2*helDist*dist+0.000000001);
			if (test < -1) test=-1;
			if (test > 1) test=1;
			FV = Math.Acos(test)*180/PI;
			phase = (1+Math.Cos(FV*PI/180))/2;
			magnitude = 14;
		}
	}
}
