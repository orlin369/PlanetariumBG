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
	interface ISolarSystemObject
	{
		void OrbitalElements();

		double N  {get; set;}
		double i  {get; set;}
		double w  {get; set;}
		double a  {get; set;}
		double ec {get; set;}
		double M  {get; set;}

		double d	 {get; set;}
		double T	 {get; set;}
		double d0	 {get; set;}
		string name  {get; set;}

		double dist  {get; set;}
		double diam  {get; set;}
		double elong {get; set;}
		double FV {get; set;}
		double phase {get; set;}
		double magnitude {get; set;}
	}
}
