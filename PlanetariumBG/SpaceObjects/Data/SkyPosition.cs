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

namespace SpaceObjects.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SkyPosition
    {

        #region Properties

        public double Rectascence
        {
            get;
            set;
        }

        public double Declination
        {
            get;
            set;
        }

        public double a
        {
            get;
            set;
        }

        public double A
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        public void eqToaA(double SIDTIME, double LAT)
        {
            double ZPX = SIDTIME * 15 - Rectascence;
            double AA = 0, Atemp = 0;

            a = Math.Asin(
                Math.Sin(Declination * Math.PI / 180) * Math.Sin(LAT * Math.PI / 180) +
                Math.Cos(Declination * Math.PI / 180) * Math.Cos(LAT * Math.PI / 180) * Math.Cos(ZPX * Math.PI / 180)
                         ) * 180 / Math.PI;

            Atemp = (-Math.Sin(Declination * Math.PI / 180) * Math.Cos(LAT * Math.PI / 180) +
                     Math.Sin(LAT * Math.PI / 180) * Math.Cos(Declination * Math.PI / 180) * Math.Cos(ZPX * Math.PI / 180)) /
                     Math.Sin((90 - a + 0.0000001) * Math.PI / 180);
            if (Atemp > 1) Atemp = 1;
            if (Atemp < -1) Atemp = -1;
            A = Math.Acos(Atemp) * 180 / Math.PI;

            Atemp = Math.Sin(ZPX * Math.PI / 180) * Math.Cos(Declination * Math.PI / 180) / Math.Sin((90 - a) * Math.PI / 180);
            if (Atemp > 1) Atemp = 1;
            if (Atemp < -1) Atemp = -1;
            AA = Math.Asin(Atemp) * 180 / Math.PI;

            if (Math.Round(A - AA, 3) == 180) { A = (-AA); return; }
            if (Math.Round(AA + A, 0) == 0) { A = 180 + AA; return; }
            if (Math.Round(AA - A, 0) == 0) { A = 180 + A; return; }
            if (Math.Round(AA + A, 0) == 180) A = 360 - AA;
        }

        public void aAToeq(double SIDTIME, double LAT)
        {
            SIDTIME *= 15;
            double RR = 0, Rtemp = 0;
            LAT += 0.0001;

            Rtemp = Math.Cos((a - 90) * Math.PI / 180) * Math.Sin(LAT * Math.PI / 180) -
                    Math.Sin((a - 90) * Math.PI / 180) * Math.Cos(LAT * Math.PI / 180) * Math.Cos(A * Math.PI / 180);
            if (Rtemp > 1) Rtemp = 1;
            if (Rtemp < -1) Rtemp = -1;
            Declination = Math.Asin(Rtemp) * 180 / Math.PI;

            Rtemp = Math.Sin((a - 90) * Math.PI / 180) * Math.Sin(A * Math.PI / 180) /
                    Math.Cos(Declination * Math.PI / 180);
            if (Rtemp > 1) Rtemp = 1;
            if (Rtemp < -1) Rtemp = -1;
            RR = (SIDTIME - Math.Asin(Rtemp) * 180 / Math.PI + 360) % 360;

            Rtemp = (Math.Cos(A * Math.PI / 180) * Math.Sin((a - 90) * Math.PI / 180) +
                     Math.Sin(Declination * Math.PI / 180) * Math.Cos(LAT * Math.PI / 180)) /
                    (Math.Sin(LAT * Math.PI / 180) * Math.Cos((Declination) * Math.PI / 180));
            if (Rtemp > 1) Rtemp = 1;
            if (Rtemp < -1) Rtemp = -1;
            Rectascence = SIDTIME - Math.Acos(Rtemp) * 180 / Math.PI;

            double RRR = (RR - Rectascence + 360) % 360;
            if ((Math.Round((Rectascence + RR) - ((2 * SIDTIME + 360) % 360), 0)) % 360 == 0 && (RRR < 179.8 || Math.Round(RRR, 1) == 360))
            {
                Rectascence = RR; return;
            }
            if (Math.Round(RRR, 0) == 180) { Rectascence = (180 + 2 * SIDTIME - RR + 360) % 360; ; return; }
            if (Math.Round((Rectascence + RR) - (2 * SIDTIME), 0) != 0) { Rectascence = (RR - RRR + 360) % 360; return; }
        }

        #endregion
    }
}
