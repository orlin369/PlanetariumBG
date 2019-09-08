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
using SpaceObjects.DeepSpace;
using SpaceObjects.SolarSystem;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;

namespace Planetarium
{
    /// <summary>
    /// 
    /// </summary>
    public class SkyView
    {
        public LocationST Location = LocationST.GetInstance();
        public SolarSystemData planetData = SolarSystemData.GetInstance();
        public DeepSpaceData DSData = DeepSpaceData.GetInstance();
        public f_PlanetPosition f_pp = new f_PlanetPosition();

        public SkyPosition center = new SkyPosition();
        public double viewAngle = 50;
        public double mag = 1;
        public Point origin;
        public double SunAlt = 0;
        public bool selected;
        public string selPl;
        public Color moonColor = Color.FromArgb(10, 10, 10);
        public ArrayList textPtArr = new ArrayList();

        public SkyPosition[,] grid = new SkyPosition[19, 25];
        public SkyPosition[,] EQgrid = new SkyPosition[19, 25];
        public SkyPosition[] direction = new SkyPosition[10];

        public bool bComp = true, bDay = true, bFull = true, bLine = false;
        public Color plTxtColor = Color.FromArgb(0, 128, 255);
        public Font plTxtFont = new Font("Arial", 8);
        public bool bShowPl = true, bPlLabel = false;
        public Color stTxtColor = Color.Tomato;
        public Font stTxtFont = new Font("Arial", 8);
        public bool bShowSt = true, bStLabel = false, bShowCo = false, bCoLabel = false;
        public bool bShowM = false, bMLabel = false, bShowEQ = false, bShowHOR = false, bGridLabel = false, bShowES = false;

        public SkyView()
        {
            Assembly asembly = Assembly.GetExecutingAssembly();

            // Stars
            Stream imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.starBlue.bmp");
            bmpBlue = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.starRed.bmp");
            bmpRed = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.starYellow.bmp");
            bmpYellow = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.maxStar.bmp");
            bmpMax = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.minRed.bmp");
            bmpMR = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.minYellow.bmp");
            bmpMY = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Stars.minBlue.bmp");
            bmpMB = Bitmap.FromStream(imgStream) as Bitmap;

            // Directions
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.N.bmp");
            bmpN = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.S.bmp");
            bmpS = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.E.bmp");
            bmpE = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.W.bmp");
            bmpW = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.NE.bmp");
            bmpNE = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.SE.bmp");
            bmpSE = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.NW.bmp");
            bmpNW = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.Directions.SW.bmp");
            bmpSW = Bitmap.FromStream(imgStream) as Bitmap;

            // 
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.ButtonIcons.oc.bmp");
            openCluster = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.ButtonIcons.gc.bmp");
            globularCluster = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.ButtonIcons.dn.bmp");
            difuzeNebula = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.ButtonIcons.cn.bmp");
            clusterWithNebula = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.ButtonIcons.pn.bmp");
            planetaryNebula = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.ButtonIcons.gal.bmp");
            galaxy = Bitmap.FromStream(imgStream) as Bitmap;

            // 
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.halo.gif");
            bmpHalo = Bitmap.FromStream(imgStream) as Bitmap;
            imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.moon.PNG");
            bmpMoon = Bitmap.FromStream(imgStream) as Bitmap;
        }

        public void Calculations(bool changePos)
        {
            double A, a, x, y, z, X, Y;
            A = viewAngle;
            a = 0;
            x = Math.Cos(a * Math.PI / 180) * Math.Sin(A * Math.PI / 180);
            y = Math.Sin(a * Math.PI / 180);
            z = Math.Cos(a * Math.PI / 180) * Math.Cos(A * Math.PI / 180);
            X = x / (1 + z + 0.00001);
            Y = y / (1 + z + 0.00001);
            mag = origin.X / X;

            if (changePos == true)
            {
                planetData.PlanetPositions();
                for (int i = 0; i < 12; ++i)
                {
                    planetData.SolarSystemObjects[i].SkyPosition.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                    if (planetData.SolarSystemObjects[i].Name == "Sun")
                        SunAlt = planetData.SolarSystemObjects[i].SkyPosition.a;
                }
                if (selected)
                {
                    center.RA = planetData.SolarSystemObjects.GetObjectByName(selPl).SkyPosition.RA;
                    center.Decl = planetData.SolarSystemObjects.GetObjectByName(selPl).SkyPosition.Decl;
                    center.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                }
                SolarSystemObject minV;
                int minI;
                for (int i = 0; i < 10; ++i)
                {
                    minV = planetData.SolarSystemObjects[i]; minI = i;
                    for (int j = i + 1; j < 10; ++j)
                    {
                        if (planetData.SolarSystemObjects[j].dist > minV.dist)
                        {
                            minV = planetData.SolarSystemObjects[j]; minI = j;
                        }
                    }
                    planetData.SolarSystemObjects[minI] = planetData.SolarSystemObjects[i];
                    planetData.SolarSystemObjects[i] = minV;
                }
                f_pp.pb.Invalidate();
            }

            center.aAToeq(this.Location.SIDTIME, this.Location.Latitude);
        }

        public void DrawGrid(Graphics g)
        {
            ArrayList secArr = new ArrayList();
            ArrayList prArr = new ArrayList();
            bool notFound = false;
            double nn = 1.5;

            //horizontalna mreza
            if (bShowHOR)
            {
                for (int i = 0; i < 19; ++i)
                {
                    for (int j = 0; j < 25; ++j)
                    {
                        double ad = angDist.Calculation(grid[i, j].A, grid[i, j].a, center.A, center.a);
                        if (2 * viewAngle > 50) nn = 1.5;
                        if (2 * viewAngle < 50) nn = 5;
                        if (2 * viewAngle < 10) nn = 40;
                        if (ad < nn * viewAngle)
                        {
                            PointF p = ToScreanPt(grid[i, j]);
                            if (notFound == false) secArr.Add(p);
                            else prArr.Add(p);
                        }
                        else notFound = true;
                    }

                    PointF[] p1 = new PointF[prArr.Count];
                    PointF[] p2 = new PointF[secArr.Count];
                    int ii = 0;
                    if (prArr.Count > 0)
                    {
                        foreach (PointF pp in prArr)
                            p1[ii++] = pp;
                        if (prArr.Count > 1) g.DrawCurve(Pens.DarkGreen, p1);
                    }
                    ii = 0;
                    if (secArr.Count > 0)
                    {
                        foreach (PointF pp in secArr)
                            p2[ii++] = pp;
                        if (secArr.Count > 1) g.DrawCurve(Pens.DarkGreen, p2);
                    }

                    notFound = false;
                    prArr.Clear();
                    secArr.Clear();
                }
                for (int j = 0; j < 25; ++j)
                {
                    for (int i = 0; i < 19; ++i)
                    {
                        double ad = angDist.Calculation(grid[i, j].A, grid[i, j].a, center.A, center.a);
                        if (2 * viewAngle > 50) nn = 1.5;
                        if (2 * viewAngle < 50) nn = 5;
                        if (2 * viewAngle < 10) nn = 40;
                        if (ad < nn * viewAngle)
                        {
                            PointF p = ToScreanPt(grid[i, j]);

                            if (bGridLabel && grid[i, j].a != 90 && grid[i, j].a != -90)
                                g.DrawString(((grid[i, j].A) % 360) + "\n" + grid[i, j].a, new Font("Arial", 8), Brushes.DarkGreen, p.X, p.Y);

                            if (notFound == false)
                            {
                                if (grid[i, j].a != 90 && grid[i, j].a != -90) secArr.Add(p);
                                else if (j % 2 != 0) secArr.Add(p);
                            }
                            else if (grid[i, j].a != 90 && grid[i, j].a != -90) prArr.Add(p);
                            else if (j % 2 != 0) prArr.Add(p);
                        }
                        else notFound = true;
                    }
                    PointF[] p1 = new PointF[prArr.Count];
                    PointF[] p2 = new PointF[secArr.Count];
                    int ii = 0;
                    if (prArr.Count > 0)
                    {
                        foreach (PointF pp in prArr)
                            p1[ii++] = pp;
                        if (prArr.Count > 1)
                            g.DrawCurve(Pens.DarkGreen, p1);
                    }
                    ii = 0;
                    if (secArr.Count > 0)
                    {
                        foreach (PointF pp in secArr)
                            p2[ii++] = pp;
                        if (secArr.Count > 1)
                            g.DrawCurve(Pens.DarkGreen, p2);
                    }

                    notFound = false;
                    prArr.Clear();
                    secArr.Clear();
                }
            }

            //ekvatorijalna mreza
            if (bShowEQ)
            {
                for (int i = 0; i < 19; ++i)
                {
                    for (int j = 0; j < 25; ++j)
                    {
                        double ad = angDist.Calculation(EQgrid[i, j].RA, EQgrid[i, j].Decl, center.RA, center.Decl);
                        if (2 * viewAngle > 50) nn = 1.5;
                        if (2 * viewAngle < 50) nn = 5;
                        if (2 * viewAngle < 10) nn = 40;
                        if (ad < nn * viewAngle)
                        {
                            EQgrid[i, j].eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                            PointF p = ToScreanPt(EQgrid[i, j]);

                            if (bGridLabel && EQgrid[i, j].Decl != 90 && EQgrid[i, j].Decl != -90)
                                g.DrawString(((EQgrid[i, j].RA) % 360) / 15 + " h\n" + EQgrid[i, j].Decl, new Font("Arial", 8), Brushes.DarkRed, p.X, p.Y);

                            if (notFound == false) secArr.Add(p);
                            else prArr.Add(p);
                        }
                        else notFound = true;
                    }

                    PointF[] p1 = new PointF[prArr.Count];
                    PointF[] p2 = new PointF[secArr.Count];
                    int ii = 0;
                    if (prArr.Count > 0)
                    {
                        foreach (PointF pp in prArr)
                            p1[ii++] = pp;
                        if (prArr.Count > 1) g.DrawCurve(Pens.DarkRed, p1);
                    }
                    ii = 0;
                    if (secArr.Count > 0)
                    {
                        foreach (PointF pp in secArr)
                            p2[ii++] = pp;
                        if (secArr.Count > 1) g.DrawCurve(Pens.DarkRed, p2);
                    }

                    notFound = false;
                    prArr.Clear();
                    secArr.Clear();
                }
                for (int j = 0; j < 25; ++j)
                {
                    for (int i = 0; i < 19; ++i)
                    {
                        double ad = angDist.Calculation(EQgrid[i, j].RA, EQgrid[i, j].Decl, center.RA, center.Decl);
                        if (2 * viewAngle > 50) nn = 1.5;
                        if (2 * viewAngle < 50) nn = 5;
                        if (2 * viewAngle < 10) nn = 40;
                        if (ad < nn * viewAngle)
                        {
                            PointF p = ToScreanPt(EQgrid[i, j]);
                            if (notFound == false)
                            {
                                if (EQgrid[i, j].Decl != 90 && EQgrid[i, j].Decl != -90) secArr.Add(p);
                                else if (j % 2 != 0) secArr.Add(p);
                            }
                            else if (EQgrid[i, j].Decl != 90 && EQgrid[i, j].Decl != -90) prArr.Add(p);
                            else if (j % 2 != 0) prArr.Add(p);
                        }
                        else
                            notFound = true;
                    }
                    PointF[] p1 = new PointF[prArr.Count];
                    PointF[] p2 = new PointF[secArr.Count];
                    int ii = 0;
                    if (prArr.Count > 0)
                    {
                        foreach (PointF pp in prArr)
                            p1[ii++] = pp;
                        if (prArr.Count > 1) g.DrawCurve(new Pen(Color.DarkRed), p1);
                    }
                    ii = 0;
                    if (secArr.Count > 0)
                    {
                        foreach (PointF pp in secArr)
                            p2[ii++] = pp;
                        if (secArr.Count > 1)
                            g.DrawCurve(new Pen(Color.DarkRed), p2);
                    }

                    notFound = false;
                    prArr.Clear();
                    secArr.Clear();
                }
            }
        }

        public void DrawConstellations(Graphics g)
        {
            foreach (ConstellationLine c in DSData.constellation)
            {
                double ad1 = angDist.Calculation(c.sp1.RA, c.sp1.Decl, center.RA, center.Decl);
                double ad2 = angDist.Calculation(c.sp2.RA, c.sp2.Decl, center.RA, center.Decl);
                if (ad1 < 2 * viewAngle || ad2 < 2 * viewAngle)
                {
                    PointF p1 = new PointF();
                    PointF p2 = new PointF();
                    c.sp1.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                    p1 = ToScreanPt(c.sp1);
                    c.sp2.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                    p2 = ToScreanPt(c.sp2);
                    g.DrawLine(Pens.YellowGreen, p1, p2);
                }
            }

            if (bCoLabel == true)
            {
                foreach (ConstellationName cn in DSData.constellationNames)
                {
                    double ad = angDist.Calculation(cn.skyPos.RA, cn.skyPos.Decl, center.RA, center.Decl);
                    if (ad < 1.2 * viewAngle)
                    {
                        cn.skyPos.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                        PointF p = ToScreanPt(cn.skyPos);
                        g.DrawString(cn.name, new Font("Arial", 12), Brushes.Aqua,
                            (int)(p.X - cn.name.Length * 4), (int)(p.Y + 5));
                    }
                }
            }
        }

        public void DrawStars(Graphics g)
        {
            foreach (Star s in DSData.stars)
            {
                int w = 0;
                switch ((int)Math.Round(s.Magnitude, 0))
                {
                    case -1: { w = 7; break; }
                    case 0: { w = 6; break; }
                    case 1: { w = 5; break; }
                    case 2: { w = 4; break; }
                    case 3: { w = 3; break; }
                    case 4: { w = 2; break; }
                    case 5: { w = 1; break; }
                    case 6: { w = 0; break; }
                }
                magX = (int)(50 / viewAngle) - 1;
                if (viewAngle <= 10 && w < 3) magX = 4;
                w += magX;
                if (w > 0)
                {
                    double ad = angDist.Calculation(s.SkyPosition.RA, s.SkyPosition.Decl, center.RA, center.Decl);
                    if (ad < 1.2 * viewAngle)
                    {
                        s.SkyPosition.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                        double dawn = (2 * (Math.Round(s.Magnitude, 0) + 2)) - 1;
                        if (!bDay || dawn * (-1) >= SunAlt)
                        {
                            PointF p = ToScreanPt(s.SkyPosition);
                            int size = w;
                            char type = s.Spectrum[0];
                            Bitmap b = bmpRed;
                            if (w == 1) { b = bmpMR; size = 2; }
                            if (type == 'F' || type == 'G')
                                b = (w == 1) ? bmpMY : bmpYellow;
                            if (type == 'O' || type == 'B' || type == 'A')
                                b = (w == 1) ? bmpMB : bmpBlue;
                            if (size > 14) { b = bmpMax; size = 19; }

                            if (w != 1) b.MakeTransparent();

                            g.DrawImage(b, (float)(p.X - size / 2), (float)(p.Y - size / 2), size, size);
                            if (bStLabel && w >= 4 && s.Designation != "")
                            {
                                string name;
                                if (s.Name == "") name = s.Designation;
                                else name = s.Name;

                                PointF tempPt = new PointF();
                                PointF textPt = new PointF();
                                tempPt = p;
                                SizeF sizeTxt = new SizeF();
                                sizeTxt = g.MeasureString(name, stTxtFont);
                                sizeTxt.Width += 8;
                                textPt.X = p.X + 8;
                                textPt.Y = p.Y + sizeTxt.Height / 2;
                                if (CheckTextPlace(p, sizeTxt) == true) { p.X -= sizeTxt.Width; p.Y -= sizeTxt.Height; textPt.X = tempPt.X - 8; textPt.Y = p.Y + sizeTxt.Height / 2; }
                                if (CheckTextPlace(p, sizeTxt) == true) { p = tempPt; p.X -= sizeTxt.Width; textPt.X = tempPt.X - 8; textPt.Y = p.Y + sizeTxt.Height / 2; }
                                if (CheckTextPlace(p, sizeTxt) == true) { p = tempPt; p.X += 8; p.Y -= sizeTxt.Height; textPt.X = tempPt.X + 5; textPt.Y = p.Y + sizeTxt.Height / 2; }
                                if (tempPt == p) p.X += 8;
                                if (CheckTextPlace(p, sizeTxt) == false)
                                {
                                    g.DrawLine(new Pen(stTxtColor), tempPt, textPt);
                                    g.DrawString(name, stTxtFont, new SolidBrush(stTxtColor), p.X, p.Y);
                                    textPtArr.Add(new PointF(p.X, p.Y));
                                }
                            }
                        }
                    }
                }
            }
        }

        public void DrawMessier(Graphics g)
        {
            foreach (Messier m in DSData.messier)
            {
                double ad = angDist.Calculation(m.SkyPosition.RA, m.SkyPosition.Decl, center.RA, center.Decl);
                if (ad < 1.2 * viewAngle)
                {
                    m.SkyPosition.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                    if (!bDay || SunAlt < -15)
                    {
                        PointF p = ToScreanPt(m.SkyPosition);
                        Bitmap b = openCluster;
                        switch (m.Type)
                        {
                            case "OCl": { b = openCluster; break; }
                            case "GCl": { b = globularCluster; break; }
                            case "PlN": { b = planetaryNebula; break; }
                            case "DfN": { b = difuzeNebula; break; }
                            case "Gal": { b = galaxy; break; }
                            case "C/N": { b = clusterWithNebula; break; }
                        }

                        b.MakeTransparent();
                        g.DrawImage(b, p.X - 5, p.Y - 5, 10, 10);
                        if (bMLabel)
                        {
                            PointF tempPt = new PointF();
                            PointF textPt = new PointF();
                            tempPt = p;
                            SizeF sizeTxt = new SizeF();
                            sizeTxt = g.MeasureString(m.Designation, stTxtFont);
                            sizeTxt.Width += 8;
                            textPt.X = p.X + 8;
                            textPt.Y = p.Y + sizeTxt.Height / 2;
                            if (CheckTextPlace(p, sizeTxt) == true) { p.X -= sizeTxt.Width; p.Y -= sizeTxt.Height; textPt.X = tempPt.X - 8; textPt.Y = p.Y + sizeTxt.Height / 2; }
                            if (CheckTextPlace(p, sizeTxt) == true) { p = tempPt; p.X -= sizeTxt.Width; textPt.X = tempPt.X - 8; textPt.Y = p.Y + sizeTxt.Height / 2; }
                            if (CheckTextPlace(p, sizeTxt) == true) { p = tempPt; p.X += 8; p.Y -= sizeTxt.Height; textPt.X = tempPt.X + 5; textPt.Y = p.Y + sizeTxt.Height / 2; }
                            if (tempPt == p) p.X += 8;
                            if (CheckTextPlace(p, sizeTxt) == false)
                            {
                                g.DrawLine(Pens.Gray, tempPt, textPt);
                                g.DrawString(m.Designation, stTxtFont, Brushes.Gray, p.X, p.Y);
                                textPtArr.Add(new PointF(p.X, p.Y));
                            }
                        }
                    }
                }
            }
        }

        public void DrawSol(Graphics g)
        {
            for (int i = 0; i < 12; ++i)
            {
                if (planetData.SolarSystemObjects[i].Name != "Earth" &&
                    (bLine == true || planetData.SolarSystemObjects[i].SkyPosition.a > (-8)))
                {
                    double ad = angDist.Calculation(planetData.SolarSystemObjects[i].SkyPosition.RA, planetData.SolarSystemObjects[i].SkyPosition.Decl, center.RA, center.Decl);
                    double dawn = -100;
                    if (planetData.SolarSystemObjects[i].Name != "Sun" && planetData.SolarSystemObjects[i].Name != "Moon")
                        dawn = (2 * (Math.Round(planetData.SolarSystemObjects[i].Magnitude, 0) + 2)) - 1;
                    string name = planetData.SolarSystemObjects[i].Name;
                    if (name == "Uranus" || name == "Neptune" || name == "Pluto")
                        dawn = 10;
                    if (ad < 1.2 * viewAngle || (viewAngle < 1 && ad < 8))
                    {
                        if (planetData.SolarSystemObjects[i].elong < 0.3 || selPl == name ||
                            !bDay || dawn * (-1) >= SunAlt)
                        {
                            PointF p = ToScreanPt(planetData.SolarSystemObjects[i].SkyPosition);

                            int w = 0;
                            switch ((int)Math.Round(planetData.SolarSystemObjects[i].Magnitude, 0))
                            {
                                case -5: { w = 11; break; }
                                case -4: { w = 10; break; }
                                case -3: { w = 9; break; }
                                case -2: { w = 8; break; }
                                case -1: { w = 7; break; }
                                case 0: { w = 6; break; }
                                case 1: { w = 5; break; }
                                case 2: { w = 4; break; }
                                case 3: { w = 3; break; }
                                case 4: { w = 2; break; }
                                case 5: { w = 1; break; }
                                case 6: { w = 0; break; }
                            }
                            if (w > 7) w = 7;
                            if (w < 2) w = 2;
                            int w2 = (int)((origin.X) / ((viewAngle * 3600) / planetData.SolarSystemObjects[i].diam));
                            if (w2 > w) w = w2;
                            if (name == "Sun" || name == "Moon")
                            {
                                if (viewAngle < 25)
                                    w = (int)((origin.X) / ((viewAngle * 3600) / planetData.SolarSystemObjects[i].diam));
                                else
                                    w = (int)((origin.X) / ((20 * 3600) / planetData.SolarSystemObjects[i].diam));
                            }
                            Color c = Color.Red;
                            switch (planetData.SolarSystemObjects[i].Name)
                            {
                                case "Pluto": { c = Color.Wheat; break; }
                                case "Neptune": { c = Color.Blue; break; }
                                case "Uranus": { c = Color.Aqua; break; }
                                case "Saturn": { c = Color.SandyBrown; break; }
                                case "Jupiter": { c = Color.Goldenrod; break; }
                                case "Mars": { c = Color.Salmon; break; }
                                case "Venus": { c = Color.LightYellow; break; }
                                case "Mercury": { c = Color.LightGray; break; }
                                case "Moon": { c = Color.LightGray; break; }
                                case "Sun": { c = Color.Yellow; break; }
                            }

                            if (planetData.SolarSystemObjects[i].Name == "Sun" && bFull && bDay)
                            {
                                if ((2 * viewAngle) > 50) sizeH = (int)(8000 / viewAngle);
                                bmpHalo.MakeTransparent();
                                if ((2 * viewAngle) > 3)
                                    g.DrawImage(bmpHalo, (float)(p.X - sizeH / 2), (float)(p.Y - sizeH / 2), sizeH, sizeH);
                            }

                            if (name == "Moon" || (viewAngle < 1 && name == "Venus"))
                            {
                                if (w < 50) w = 50;
                                Bitmap bmp;
                                if (w < 300) bmp = new Bitmap(w, w);
                                else bmp = new Bitmap(300, 300);
                                bmpMoon.MakeTransparent();

                                Graphics moonGr = Graphics.FromImage(bmp);
                                if (name == "Moon")
                                    moonGr.DrawImage(bmpMoon, 0, 0, bmp.Width, bmp.Height);
                                else
                                    moonGr.FillEllipse(new SolidBrush(c), 0, 0, bmp.Width, bmp.Height);
                                GraphicsPath gp = new GraphicsPath();

                                int n = (int)(planetData.SolarSystemObjects[i].SkyPosition.RA + 360 - planetData.SolarSystemObjects.GetObjectByName("Sun").SkyPosition.RA) % 360;
                                double elong = 0;
                                if (name == "Moon") elong = planetData.SolarSystemObjects[i].elong;
                                else elong = 180 - planetData.SolarSystemObjects[i].FV;
                                double dx = 0;
                                if (n < 180)
                                {
                                    gp.AddArc(0, 0, bmp.Width, bmp.Height, 90, 180);
                                    if (elong <= 90)
                                    {
                                        dx = bmp.Width / 2 * Math.Cos(elong * Math.PI / 180);
                                        gp.AddArc((float)(bmp.Width / 2 - dx), 0, (float)(2 * dx), bmp.Height, 270, 180);
                                    }
                                    else
                                    {
                                        dx = bmp.Width / 2 * Math.Cos((180 - elong) * Math.PI / 180);
                                        gp.AddArc((float)(bmp.Width / 2 - dx), 0, (float)(2 * dx), bmp.Height, 90, 180);
                                    }
                                }
                                else
                                {
                                    gp.AddArc(0, 0, bmp.Width, bmp.Height, 270, 180);
                                    if (elong <= 90)
                                    {
                                        dx = bmp.Width / 2 * Math.Cos(elong * Math.PI / 180);
                                        gp.AddArc((float)(bmp.Width / 2 - dx), 0, (float)(2 * dx), bmp.Height, 90, 180);
                                    }
                                    else
                                    {
                                        dx = bmp.Width / 2 * Math.Cos((180 - elong) * Math.PI / 180);
                                        gp.AddArc((float)(bmp.Width / 2 - dx), 0, (float)(2 * dx), bmp.Height, 270, 180);
                                    }
                                }
                                moonGr.FillPath(new SolidBrush(moonColor), gp);

                                PointF[] pM = new PointF[3];
                                double halfDiam = planetData.SolarSystemObjects[i].diam / 7200;
                                if (name == "Moon" && viewAngle > 20)
                                    halfDiam *= (viewAngle / 20);

                                SkyPosition top = new SkyPosition();
                                SkyPosition bottom = new SkyPosition();
                                top.RA = planetData.SolarSystemObjects[i].SkyPosition.RA;
                                top.Decl = planetData.SolarSystemObjects[i].SkyPosition.Decl + halfDiam;
                                top.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                                bottom.RA = planetData.SolarSystemObjects[i].SkyPosition.RA;
                                bottom.Decl = planetData.SolarSystemObjects[i].SkyPosition.Decl - halfDiam;
                                bottom.eqToaA(this.Location.SIDTIME, this.Location.Latitude);
                                PointF pt = ToScreanPt(top);
                                PointF pb = ToScreanPt(bottom);
                                double d = Math.Sqrt((pb.Y - pt.Y) * (pb.Y - pt.Y) + (pb.X - pt.X) * (pb.X - pt.X));
                                if (pt.Y <= pb.Y)
                                {
                                    if (pt.X <= pb.X)
                                    {
                                        double alpha = Math.Asin((pb.X - pt.X) / d) * 180 / Math.PI;
                                        double dX = d / 2 * Math.Cos(alpha * Math.PI / 180);
                                        double dY = d / 2 * Math.Sin(alpha * Math.PI / 180);
                                        pM[0].X = (float)(pt.X - dX); pM[0].Y = (float)(pt.Y + dY);
                                        pM[1].X = (float)(pt.X + dX); pM[1].Y = (float)(pt.Y - dY);
                                        pM[2].X = (float)(pb.X - dX); pM[2].Y = (float)(pb.Y + dY);
                                    }
                                    else
                                    {
                                        double alpha = Math.Asin((pt.X - pb.X) / d) * 180 / Math.PI;
                                        double dX = d / 2 * Math.Cos(alpha * Math.PI / 180);
                                        double dY = d / 2 * Math.Sin(alpha * Math.PI / 180);
                                        pM[0].X = (float)(pt.X - dX); pM[0].Y = (float)(pt.Y - dY);
                                        pM[1].X = (float)(pt.X + dX); pM[1].Y = (float)(pt.Y + dY);
                                        pM[2].X = (float)(pb.X - dX); pM[2].Y = (float)(pb.Y - dY);
                                    }
                                }
                                else
                                {
                                    if (pt.X <= pb.X)
                                    {
                                        double alpha = Math.Asin((pb.X - pt.X) / d) * 180 / Math.PI;
                                        double dX = d / 2 * Math.Cos(alpha * Math.PI / 180);
                                        double dY = d / 2 * Math.Sin(alpha * Math.PI / 180);
                                        pM[0].X = (float)(pt.X + dX); pM[0].Y = (float)(pt.Y + dY);
                                        pM[1].X = (float)(pt.X - dX); pM[1].Y = (float)(pt.Y - dY);
                                        pM[2].X = (float)(pb.X + dX); pM[2].Y = (float)(pb.Y + dY);
                                    }
                                    else
                                    {
                                        double alpha = Math.Asin((pt.X - pb.X) / d) * 180 / Math.PI;
                                        double dX = d / 2 * Math.Cos(alpha * Math.PI / 180);
                                        double dY = d / 2 * Math.Sin(alpha * Math.PI / 180);
                                        pM[0].X = (float)(pt.X + dX); pM[0].Y = (float)(pt.Y - dY);
                                        pM[1].X = (float)(pt.X - dX); pM[1].Y = (float)(pt.Y + dY);
                                        pM[2].X = (float)(pb.X + dX); pM[2].Y = (float)(pb.Y - dY);
                                    }
                                }
                                g.DrawImage(bmp, pM);
                                moonGr.Dispose();
                                bmp.Dispose();
                            }
                            else if (name == "Earth shadow" && bShowES)
                            {
                                double RES = 0;

                                //penumbra
                                double RZ = 6378.140;
                                double RS = 696000;
                                double dS = planetData.SolarSystemObjects.GetObjectByName("Sun").dist * 1.49597870E8;
                                double dM = planetData.SolarSystemObjects.GetObjectByName("Moon").dist * 1.49597870E8;
                                ((EarthShadow)planetData.SolarSystemObjects.GetObjectByName("Earth shadow")).DP = RES = (RZ + RS) * (dS + dM) / dS - RS;

                                planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam = 7200 * Math.Atan(RES / dM) * 180 / Math.PI;

                                double dd = planetData.SolarSystemObjects.GetObjectByName("Moon").diam / 7200 + planetData.SolarSystemObjects.GetObjectByName("Earth shadow").diam / 7200;

                                float W = 0;
                                W = (float)((origin.X) / ((viewAngle * 3600) / RES));
                                g.FillEllipse(new SolidBrush(Color.FromArgb(85, 15, 15, 15)), (float)(p.X - W / 2), (float)(p.Y - W / 2), (float)W, (float)W);
                                g.DrawEllipse(new Pen(Color.FromArgb(85, 155, 155, 155)), (float)(p.X - W / 2), (float)(p.Y - W / 2), (float)W, (float)W);

                                //umbra
                                ((EarthShadow)planetData.SolarSystemObjects.GetObjectByName("Earth shadow")).DU = RES = RS - ((RS - RZ) * (dS + dM)) / dS;

                                W = (float)((origin.X) / ((viewAngle * 3600) / RES));
                                g.FillEllipse(new SolidBrush(Color.FromArgb(85, 80, 0, 0)), (float)(p.X - W / 2), (float)(p.Y - W / 2), (float)W, (float)W);
                                g.DrawEllipse(new Pen(Color.FromArgb(80, 255, 0, 0)), (float)(p.X - W / 2), (float)(p.Y - W / 2), (float)W, (float)W);
                            }
                            else if (name != "Earth shadow")
                                g.FillEllipse(new SolidBrush(c), (float)(p.X - w / 2), (float)(p.Y - w / 2), w, w);

                            if ((bPlLabel || (selPl == planetData.SolarSystemObjects[i].Name && selected == true)) && (name != "Earth shadow" || this.bShowES == true))
                            {
                                PointF tempPt = new PointF();
                                PointF textPt = new PointF();
                                tempPt = p;
                                SizeF sizeTxt = new SizeF();
                                sizeTxt = g.MeasureString(name, plTxtFont);
                                sizeTxt.Width += 8;
                                textPt.X = p.X + 8;
                                textPt.Y = p.Y + sizeTxt.Height / 2;
                                if (CheckTextPlace(p, sizeTxt) == true) { p.X -= sizeTxt.Width; p.Y -= sizeTxt.Height; textPt.X = tempPt.X - 8; textPt.Y = p.Y + sizeTxt.Height / 2; }
                                if (CheckTextPlace(p, sizeTxt) == true) { p = tempPt; p.X -= sizeTxt.Width; textPt.X = tempPt.X - 8; textPt.Y = p.Y + sizeTxt.Height / 2; }
                                if (CheckTextPlace(p, sizeTxt) == true) { p = tempPt; p.X += 8; p.Y -= sizeTxt.Height; textPt.X = tempPt.X + 5; textPt.Y = p.Y + sizeTxt.Height / 2; }
                                if (CheckTextPlace(p, sizeTxt) == false)
                                {
                                    if (tempPt == p) p.X += 8;
                                    g.DrawLine(new Pen(plTxtColor), tempPt, textPt);
                                    g.DrawString(name, plTxtFont, new SolidBrush(plTxtColor), p.X, p.Y);
                                    textPtArr.Add(new PointF(p.X, p.Y));
                                }
                            }
                        }
                    }
                }
            }
        }

        public void DrawHorizon(Graphics g)
        {
            SkyPosition[] horizont = new SkyPosition[34];
            for (int index = 0; index < 34; index++)
            {
                horizont[index] = new SkyPosition();
            }
            Point[] hor = new Point[34];

            hor[0].X = 0; hor[0].Y = 2 * origin.Y + 10;
            hor[32].X = 2 * origin.X; hor[32].Y = 2 * origin.Y + 10;
            hor[33].X = hor[0].X; hor[33].Y = hor[0].Y;

            double step = (2 * viewAngle + viewAngle / 10) / 30;
            horizont[1].A = center.A - 15 * step;
            for (int i = 2; i < 32; ++i)
            {
                horizont[i].A = horizont[i - 1].A + step;
                horizont[i].a = 0;
            }

            for (int i = 1; i < 32; ++i)
            {
                PointF p = ToScreanPt(horizont[i]);
                hor[i].X = (int)p.X; hor[i].Y = (int)p.Y;
            }
            SolidBrush earCol;
            if (SunAlt > 0) earCol = new SolidBrush(Color.FromArgb(0, 100, 0));
            else earCol = new SolidBrush(Color.FromArgb(0, 50, 0));
            GraphicsPath gp = new GraphicsPath();
            gp.AddPolygon(hor);
            if (bFull) g.FillPath(earCol, gp);
            if (bLine) g.DrawPath(new Pen(earCol), gp);
        }

        public void DrawDirection(Graphics g, bool zn)
        {
            for (int i = 0; i < 10; ++i)
            {
                if (zn == false && i == 8) break;
                double ad = angDist.Calculation(direction[i].A, direction[i].a, center.A, center.a);

                if (ad < 1.2 * viewAngle)
                {
                    PointF p = ToScreanPt(direction[i]);
                    if (i < 8)
                    {
                        Bitmap b = bmpS;
                        switch ((int)direction[i].A)
                        {
                            case 0: { b = bmpN; break; }
                            case 45: { b = bmpNE; break; }
                            case 90: { b = bmpE; break; }
                            case 135: { b = bmpSE; break; }
                            case 180: { b = bmpS; break; }
                            case 225: { b = bmpSW; break; }
                            case 270: { b = bmpW; break; }
                            case 315: { b = bmpNW; break; }
                        }
                        int size = b.Width;
                        b.MakeTransparent();
                        g.DrawImage(b, (int)(p.X - size / 2), (int)p.Y + 10, size, size);
                    }
                    else
                    {
                        string str = "";
                        if (i == 8) str = "Zenith";
                        if (i == 9) str = "Nadir";
                        Font font = new Font("Arial", 10);
                        SizeF size = g.MeasureString(str, font);

                        if (i == 8)
                        {
                            PointF top = p;
                            PointF b = new PointF(top.X, top.Y + 8);
                            PointF l = new PointF(top.X - 2, top.Y + 4);
                            PointF r = new PointF(top.X + 2, top.Y + 4);
                            g.DrawLine(Pens.Red, top, b);
                            g.DrawLine(Pens.Red, top, l);
                            g.DrawLine(Pens.Red, top, r);
                            g.DrawString(str, font, Brushes.Red, (float)(p.X - size.Width / 2), p.Y + 8);
                        }
                        if (i == 9)
                        {
                            PointF top = p;
                            PointF b = new PointF(top.X, top.Y - 8);
                            PointF l = new PointF(b.X - 2, b.Y + 4);
                            PointF r = new PointF(b.X + 2, b.Y + 4);
                            g.DrawLine(Pens.Red, top, b);
                            g.DrawLine(Pens.Red, top, l);
                            g.DrawLine(Pens.Red, top, r);
                            g.DrawString(str, font, Brushes.Red, (float)(p.X - size.Width / 2), p.Y - size.Height - 8);
                        }
                    }
                }
            }
        }

        PointF ToScreanPt(SkyPosition sp)
        {
            double ZPX = (center.A + 180) % 360 - sp.A;
            double AA = 0, Atemp = 0, A = 0, a = 0;

            a = Math.Asin(
                Math.Sin(sp.a * Math.PI / 180) * Math.Sin((90 - center.a + 0.000001) * Math.PI / 180) +
                Math.Cos(sp.a * Math.PI / 180) * Math.Cos((90 - center.a + 0.000001) * Math.PI / 180) * Math.Cos(ZPX * Math.PI / 180)) * 180 / Math.PI;

            Atemp = (-Math.Sin(sp.a * Math.PI / 180) * Math.Cos((90 - center.a + 0.000001) * Math.PI / 180) +
                Math.Sin((90 - center.a + 0.000001) * Math.PI / 180) * Math.Cos(sp.a * Math.PI / 180) * Math.Cos(ZPX * Math.PI / 180)) /
                Math.Sin((90 - a + 0.000001) * Math.PI / 180);
            if (Atemp > 1) Atemp = 1;
            if (Atemp < -1) Atemp = -1;
            A = Math.Acos(Atemp) * 180 / Math.PI;

            Atemp = Math.Sin(ZPX * Math.PI / 180) * Math.Cos(sp.a * Math.PI / 180) / Math.Sin((90 - a + 0.000001) * Math.PI / 180);
            if (Atemp > 1) Atemp = 1;
            if (Atemp < -1) Atemp = -1;
            AA = Math.Asin(Atemp) * 180 / Math.PI;

            if (Math.Round(A - AA, 0) == 180) { A = (-AA); goto label; }
            if (Math.Round(AA + A, 0) == 0) { A = 180 + AA; goto label; }
            if (Math.Round(AA - A, 0) == 0) { A = 180 + A; goto label; }
            if (Math.Round(AA + A, 0) == 180) A = 360 - AA;
            label:;
            A = 360 - A;

            double x, y, z, X, Y;
            x = Math.Cos(a * Math.PI / 180) * Math.Sin(A * Math.PI / 180);
            y = Math.Sin(a * Math.PI / 180);
            z = Math.Cos(a * Math.PI / 180) * Math.Cos(A * Math.PI / 180);
            X = mag * x / (1 + z + 0.0000001);
            Y = mag * y / (1 + z + 0.0000001);

            return new PointF((float)(origin.X + X), (float)(origin.Y - Y));
        }

        bool CheckTextPlace(PointF pt, SizeF size)
        {
            foreach (PointF p in textPtArr)
            {
                if (Math.Abs(p.X - pt.X) <= size.Width &&
                    Math.Abs(p.Y - pt.Y) <= size.Height)
                    return true;
            }
            return false;
        }

        private int sizeH;
        private Bitmap bmpBlue, bmpYellow, bmpRed, bmpMax, bmpMR, bmpMY, bmpMB;
        private Bitmap bmpN, bmpS, bmpE, bmpW, bmpNE, bmpNW, bmpSE, bmpSW;
        private Bitmap bmpHalo, bmpMoon;
        private Bitmap openCluster, globularCluster, planetaryNebula, clusterWithNebula,
                       difuzeNebula, galaxy;
        private int magX = 0;
        private AngularDistances angDist = new AngularDistances();
    }
}
