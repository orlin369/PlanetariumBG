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
	public class Mars : APlanet
	{
		public Mars(string name){this.name = name;}

		public override void OrbitalElements()
		{
			N = 49.5574 + 2.11081E-5 * location.dayNumber();
			i = 1.8497 - 1.78E-8 * location.dayNumber();
			w = 286.5016 + 2.92961E-5 * location.dayNumber();
			a = 1.523688;
			ec = 0.093405 + 2.516E-9 * location.dayNumber();
			M = 18.6021 + 0.5240207766 * location.dayNumber();
			M += ((int)Math.Abs(M/360)+1)*360;

			d=1.7;	T=687;	d0=9.36;	name="Mars";
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
			magnitude = -1.51 + 5*Math.Log10(helDist*dist) + 0.016*FV;
		}
	}
}
