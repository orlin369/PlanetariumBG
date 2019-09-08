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

        public ArrayList stars = new ArrayList();
        public ArrayList messier = new ArrayList();
        public ArrayList constellation = new ArrayList();
        public ArrayList constellationNames = new ArrayList();

        public static DeepSpaceData GetInstance()
        {
            if (instance == null)
                instance = new DeepSpaceData();
            return instance;
        }

        private DeepSpaceData()
        {
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
                stars.Add(new Star(split[0], split[1], Convert.ToDouble(split[2], provider) * 15,
                                    Convert.ToDouble(split[3], provider),
                                    Convert.ToDouble(split[4], provider), split[5]));
            }
            stars.TrimToSize();

            a = Assembly.GetExecutingAssembly();
            txtStream = a.GetManifestResourceStream("SpaceObjects.Resources.Messier.txt");
            sr = new StreamReader(txtStream);

            while (sr.Peek() >= 0)
            {
                string[] split = sr.ReadLine().Split(delimiter, 20);
                messier.Add(new Messier(split[0], Convert.ToDouble(split[1], provider) * 15,
                               Convert.ToDouble(split[2], provider), split[3], split[4]));
            }
            messier.TrimToSize();

            a = Assembly.GetExecutingAssembly();
            txtStream = a.GetManifestResourceStream("SpaceObjects.Resources.Constellations.txt");
            sr = new StreamReader(txtStream);

            while (sr.Peek() >= 0)
            {
                string str = sr.ReadLine();
                if (str[0] != 'C')
                {
                    string[] split = str.Split(delimiter, 20);
                    constellation.Add(new ConstellationLine(Convert.ToDouble(split[0], provider) * 15, Convert.ToDouble(split[1], provider),
                        Convert.ToDouble(split[2], provider) * 15, Convert.ToDouble(split[3], provider)));
                }
                else
                {
                    string[] split = str.Split(delimiter, 4);
                    SkyPosition sp = new SkyPosition();
                    sp.RA = Convert.ToDouble(split[2], provider) * 15;
                    sp.Decl = Convert.ToDouble(split[3], provider);
                    constellationNames.Add(new ConstellationName(split[1], sp));
                }
            }
            constellation.TrimToSize();
            constellationNames.TrimToSize();
        }

        private static DeepSpaceData instance;
    }
}
