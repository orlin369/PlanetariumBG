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

namespace SpaceObjects
{
	/// <summary>
	/// Summary description for Stars.
	/// </summary>
	public class Star : ADSObject
	{
		public Star(){}

		public Star(string designation, string name, double RA, double Decl, double magnitude, string spectrum)
		{
			this.designation = designation;
			this.name = name;
			this.SkyPosition.RA = RA;
			this.SkyPosition.Decl = Decl;
			this.magnitude = magnitude;
			this.spectrum = spectrum;
		}

		public string spectrum
		{
			get {return v_spectrum;}
			set {v_spectrum = value;}
		}

		public double magnitude
		{
			get {return v_magnitude;}
			set {v_magnitude = value;}
		}

		private string v_spectrum;
		private double v_magnitude;
	}
}
