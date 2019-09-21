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
    /// Summary description for Constellation.
    /// </summary>
    public class ConstellationLine
    {

        #region Properties

        public SkyPosition SkyPosition1
        {
            get;
            set;
        }
        public SkyPosition SkyPosition2
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public ConstellationLine(double rectascence1, double declination1, double rectascence2, double declination2)
        {
            this.SkyPosition1 = new SkyPosition();
            this.SkyPosition2 = new SkyPosition();

            this.SkyPosition1.Rectascence = rectascence1;
            this.SkyPosition1.Declination = declination1;

            this.SkyPosition2.Rectascence = rectascence2;
            this.SkyPosition2.Declination = declination2;
        }

        #endregion

    }
}
