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

namespace SpaceObjects.Position
{
	/// <summary>
	/// 
	/// </summary>
	public struct PlanetPos
	{
		public double x, y, z;
		public string posName;

		public PlanetPos(double xx, double yy, double zz)
		{
			x = xx;	y = yy;	z = zz;	posName = "";
		}

		public void Rotate (double angle_x, double angle_z)
		{
			double r = Math.Sqrt(x*x+y*y+z*z);
			
			double a=0, al=0;
			al = Math.Atan(Math.Abs(y)/Math.Abs(x))*180/Math.PI;

			if (x>0 && y==0) a = 0;
			if (x==0 && y>0) a = 90;
			if (x<0 && y==0) a = 180;
			if (x==0 && y<0) a = 270;

			if (x>0 && y>0) a = al;
			if (x<0 && y>0) a = 180-al;
			if (x<0 && y<0) a = 180+al;
			if (x>0 && y<0) a = 360-al;

			a += angle_z;
			a = a%360;
			double tk = Math.Tan(a*Math.PI/180);
			if (a>=90 && a<270) x = -Math.Sqrt(r*r/(1+tk*tk));
			else x = Math.Sqrt(r*r/(1+tk*tk));    
			y = x*tk; 

			y = y*Math.Cos(angle_x*Math.PI/180);
			z = z*Math.Sin(angle_x*Math.PI/180);
			y += z;
		}
	}
}
