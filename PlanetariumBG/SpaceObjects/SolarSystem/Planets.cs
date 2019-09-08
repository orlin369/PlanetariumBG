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
	/// Summary description for Planets.
	/// </summary>
	public class Planets
	{
		private APlanet[] planets = new APlanet[12];
		private int counter = 0;

		public Planets (params APlanet[] initPlanets)
		{
			foreach (APlanet ap in initPlanets)
				planets[counter++] = ap;
		}

		public void Add (APlanet planet)
		{
			planets[counter++] = planet;
		}

		public APlanet this[int index]
		{
			get {return planets[index];}
			set {planets[index] = value;}
		}

		public APlanet this[string index]
		{
			get {return this[findString(index)];}
			set {planets[findString(index)] = value;}
		}

		private int findString (string searchString)
		{
			for (int i=0; i<planets.Length; i++){
				if (planets[i].name == searchString)
					return i;
			}
			return -1;
		}

		public int GetNumEntries()
		{
			return counter;
		}
	}
}
