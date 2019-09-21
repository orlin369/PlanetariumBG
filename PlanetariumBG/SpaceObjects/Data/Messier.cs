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

namespace SpaceObjects.Data
{
    /// <summary>
    /// Summary description for Messier.
    /// </summary>
    public class Messier : BaseSpaceObject
    {

        #region Constructor

        public Messier() { }

        public Messier(string designation, double Rectascence, double Declination, string type, string name)
        {
            if (designation != "")
            {
                this.Designation = "M" + designation;
            }
            else
            {
                this.Designation = name;
            }
            this.Name = name;
            this.SkyPosition.Rectascence = Rectascence;
            this.SkyPosition.Declination = Declination;
            this.Type = type;
        }

        #endregion

        #region Public Methods

        public override void Ephemerides()
        {
            throw new System.NotImplementedException();
        }

        public override void OrbitalElements()
        {
            throw new System.NotImplementedException();
        }

        public override void Perturbations()
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
