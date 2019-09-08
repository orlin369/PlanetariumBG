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

namespace SpaceObjects.Perturbations
{
    /// <summary>
    /// 
    /// </summary>
    public class PertElements
    {

        #region Variables

        private static PertElements instance;

        #endregion

        #region Properties

        public double Mj
        {
            get;
            set;
        }

        public double Msat
        {
            get;
            set;
        }

        public double Mu
        {
            get;
            set;
        }

        public double Ls
        {
            get;
            set;
        }

        public double Lm
        {
            get;
            set;
        }

        public double Msun
        {
            get;
            set;
        }

        public double Mm
        {
            get;
            set;
        }

        public double D
        {
            get;
            set;
        }

        public double F
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        private PertElements()
        {
        }

        #endregion

        #region Public Methods

        public static PertElements GetInstance()
        {
            if (instance == null)
                instance = new PertElements();
            return instance;
        }

        #endregion

    }
}
