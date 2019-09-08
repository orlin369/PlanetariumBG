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
	public class PertElements
	{
		public static PertElements GetInstance()
		{
			if( instance == null )
				instance = new PertElements();
			return instance;
		}

		public double Mj {
			get {return v_Mj;}
			set {v_Mj = value;}
		}

		public double Msat {
			get {return v_Msat;}
			set {v_Msat = value;}
		}

		public double Mu {
			get {return v_Mu;}
			set {v_Mu = value;}
		}

		public double Ls {
			get {return v_Ls;}
			set {v_Ls = value;}
		}

		public double Lm {
			get {return v_Lm;}
			set {v_Lm = value;}
		}

		public double Msun {
			get {return v_Msun;}
			set {v_Msun = value;}
		}

		public double Mm {
			get {return v_Mm;}
			set {v_Mm = value;}
		}

		public double D {
			get {return v_D;}
			set {v_D = value;}
		}

		public double F {
			get {return v_F;}
			set {v_F = value;}
		}

		private double v_Mj;
		private double v_Msat;
		private double v_Mu;
		private double v_Ls;
		private double v_Lm;
		private double v_Msun;
		private double v_Mm;
		private double v_D;
		private double v_F;

		private PertElements(){}
		private static PertElements instance;
	}
}
