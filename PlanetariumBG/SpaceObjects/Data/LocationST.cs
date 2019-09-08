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

using Microsoft.Win32;
using System;

namespace SpaceObjects.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationST
    {

        #region Variables

        private static LocationST instance;
        private DateTime dts = new DateTime(1, 3, 28, 2, 0, 0);
        private DateTime dte = new DateTime(1, 10, 30, 2, 0, 0);
        private RegistryKey regKey;
        public string v_unit = "minutes";
        public DateTime dtMin = new DateTime(1900, 1, 1, 0, 0, 0);
        public DateTime dtMax = new DateTime(2099, 12, 31, 23, 59, 59);

        #endregion

        #region Properties

        public int Longitude
        {
            get;
            set;
        }

        public int Latitude
        {
            get;
            set;
        }

        public int HomeLongitude
        {
            get;
            set;
        }

        public int HomeLatitude
        {
            get;
            set;
        }

        public double Oblecl
        {
            get;
            set;
        }

        public short Step
        {
            get;
            set;
        }

        public DateTime MainDateTime
        {
            get;
            set;
        }

        public double SIDTIME
        {
            get;
            set;
        }

        public double xs
        {
            get;
            set;
        }

        public double ys
        {
            get;
            set;
        }

        public double zs
        {
            get;
            set;
        }

        public double slon
        {
            get;
            set;
        }

        public double sRA
        {
            get;
            set;
        }

        public double sDecl
        {
            get;
            set;
        }

        #endregion

        #region Methods

        private LocationST()
        {
            this.Step = 1;
            this.TimeNow();

            regKey = Registry.CurrentUser;
            if ((regKey = regKey.OpenSubKey("Software\\PLANETARIUM\\Lokal", true)) == null)
            {
                regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey("Software", true);
                regKey.CreateSubKey("PLANETARIUM");
                regKey.CreateSubKey(@"PLANETARIUM\\Lokal");

                regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey("Software\\PLANETARIUM\\Lokal", true);
                regKey.SetValue("Lon", 16);
                regKey.SetValue("Lat", 46);
                HomeLongitude = Longitude = 16;
                HomeLatitude = Latitude = 46;
            }
            else
            {
                HomeLongitude = Longitude = (int)regKey.GetValue("Lon");
                HomeLatitude = Latitude = (int)regKey.GetValue("Lat");
            }
        }

        public static LocationST GetInstance()
        {
            if (instance == null)
                instance = new LocationST();
            return instance;
        }

        public double DayNumber()
        {
            double d = MainDateTime.Day - 32076 + 1461 * (MainDateTime.Year +
                4800 + (MainDateTime.Month - 14) / 12) / 4 +
                367 * (MainDateTime.Month - 2 - (MainDateTime.Month - 14) / 12 * 12) / 12 -
                3 * ((MainDateTime.Year + 4900 + (MainDateTime.Month - 14) / 12) / 100) / 4;

            d += (MainDateTime.Hour - (double)this.Longitude / 15 + 12.0) / 24.0;
            d += (MainDateTime.Minute) / 1440.0;
            d += (MainDateTime.Second) / 86400.0;
            d -= 2451543.5;

            return d;
        }

        public void FixTime()
        {
            if (dts.Year != 1) dts = dts.AddYears(-(MainDateTime.Year - 1));
            if (dte.Year != 1) dte = dte.AddYears(-(MainDateTime.Year - 1));

            dts = dts.AddYears(MainDateTime.Year - 1);
            dte = dte.AddYears(MainDateTime.Year - 1);

            if (MainDateTime >= dts && MainDateTime <= dte)
                MainDateTime = MainDateTime.AddHours(-1);
        }

        public void TimeNow()
        {
            MainDateTime = DateTime.Now;
        }

        public void ChangeRegistry()
        {
            regKey.SetValue("Lon", this.HomeLongitude);
            regKey.SetValue("Lat", this.HomeLatitude);
        }

        #endregion
    }
}
