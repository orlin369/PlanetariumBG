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

namespace SpaceObjects.Perturbations
{
	/// <summary>
	/// 
	/// </summary>
	public class PertUranus : APerturbations
	{
		public PertUranus(){}

		public override double PertInLon()
		{
			double lon1 = 0.04*Math.Sin((pert.Msat-2*pert.Mu+6)*PI/180); 
			double lon2 = 0.035*Math.Sin((pert.Msat-3*pert.Mu+33)*PI/180); 
			double lon3 = -0.015*Math.Sin((pert.Mj-pert.Mu+20)*PI/180);  
			double lon = lon1 + lon2 + lon3;
			return lon;
		}

		public override double PertInLat()
		{
			return 0;
		}

		public override double PertInDist()
		{
			return 0;
		}

		private double PI = Math.PI;
	}
}
