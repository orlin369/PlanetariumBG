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

using SpaceObjects.Data;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace SpaceObjects.DeepSpace
{
    /// <summary>
    /// Summary description for DeepSpaceData.
    /// </summary>
    public class DeepSpaceData
    {

        #region Variables

        private static DeepSpaceData instance;

        #endregion

        #region Properties

        public ArrayList Stars
        {
            get;
            set;
        }
        public ArrayList Messier
        {
            get;
            set;
        }
        public ArrayList Constellation
        {
            get;
            set;
        }
        public ArrayList ConstellationNames
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        private DeepSpaceData()
        {
            this.Stars = new ArrayList();
            this.Messier = new ArrayList();
            this.Constellation = new ArrayList();
            this.ConstellationNames = new ArrayList();

            Assembly a = Assembly.GetExecutingAssembly();
            Stream txtStream = a.GetManifestResourceStream("SpaceObjects.Resources.HYG.txt");
            StreamReader sr = new StreamReader(txtStream);

            string delimStr = ";";
            char[] delimiter = delimStr.ToCharArray();
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            while (sr.Peek() >= 0)
            {
                string[] split = sr.ReadLine().Split(delimiter, 20);
                Stars.Add(new Star(split[0], split[1], Convert.ToDouble(split[2], provider) * 15,
                                    Convert.ToDouble(split[3], provider),
                                    Convert.ToDouble(split[4], provider), split[5]));
            }
            Stars.TrimToSize();

            a = Assembly.GetExecutingAssembly();
            txtStream = a.GetManifestResourceStream("SpaceObjects.Resources.Messier.txt");
            sr = new StreamReader(txtStream);

            while (sr.Peek() >= 0)
            {
                string[] split = sr.ReadLine().Split(delimiter, 20);
                Messier.Add(new Messier(split[0], Convert.ToDouble(split[1], provider) * 15,
                               Convert.ToDouble(split[2], provider), split[3], split[4]));
            }
            Messier.TrimToSize();

            a = Assembly.GetExecutingAssembly();
            txtStream = a.GetManifestResourceStream("SpaceObjects.Resources.Constellations.txt");
            sr = new StreamReader(txtStream);

            while (sr.Peek() >= 0)
            {
                string str = sr.ReadLine();
                if (str[0] != 'C')
                {
                    string[] split = str.Split(delimiter, 20);
                    Constellation.Add(new ConstellationLine(Convert.ToDouble(split[0], provider) * 15, Convert.ToDouble(split[1], provider),
                        Convert.ToDouble(split[2], provider) * 15, Convert.ToDouble(split[3], provider)));
                }
                else
                {
                    string[] split = str.Split(delimiter, 4);
                    SkyPosition sp = new SkyPosition();
                    sp.Rectascence = Convert.ToDouble(split[2], provider) * 15;
                    sp.Declination = Convert.ToDouble(split[3], provider);
                    ConstellationNames.Add(new ConstellationName(split[1], sp));
                }
            }
            Constellation.TrimToSize();
            ConstellationNames.TrimToSize();
        }

        #endregion

        public static DeepSpaceData GetInstance()
        {
            if (instance == null)
                instance = new DeepSpaceData();
            return instance;
        }


    }
}
