using SpaceObjects.Position;
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
		public PlanetData PlanetData = PlanetData.GetInstance();
		public DeepSpaceData DSData = DeepSpaceData.GetInstance();
		public f_PlanetPosition PlanetPosition = new f_PlanetPosition();

		public SkyPos Center = new SkyPos();
		public double ViewAngle=50;
		public double mag = 1;
		public Point Origin;
		public double SunAltitude = 0;
		public bool selected;
		public string selPl;
		public Color moonColor = Color.FromArgb(10,10,10);
		public ArrayList textPtArr = new ArrayList();

		public SkyPos[,] grid = new SkyPos[19,25];
		public SkyPos[,] EQgrid = new SkyPos[19,25];
		public SkyPos[] direction = new SkyPos[10];

		public bool bComp=true, bDay=true, bFull=true, bLine=false;
		public Color plTxtColor = Color.FromArgb(0,128,255);
		public Font plTxtFont = new Font("Arial",8);
		public bool bShowPl=true, bPlLabel=false;
		public Color stTxtColor = Color.Tomato;
		public Font stTxtFont = new Font("Arial",8);
		public bool bShowSt=true, bStLabel=false, bShowCo=false, bCoLabel=false;
		public bool bShowM=false, bMLabel=false, bShowEQ=false, bShowHOR=false, bGridLabel=false, bShowES=false;

		public SkyView()
		{
			Assembly asembly = Assembly.GetExecutingAssembly();
			Stream imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.starBlue.bmp");
			bmpBlue = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.starRed.bmp");
			bmpRed = Bitmap.FromStream (imgStream) as Bitmap;
		    imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.starYellow.bmp");
			bmpYellow = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.maxStar.bmp");
			bmpMax = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.minRed.bmp");
			bmpMR = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.minYellow.bmp");
			bmpMY = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.minBlue.bmp");
			bmpMB = Bitmap.FromStream (imgStream) as Bitmap;

			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.N.bmp");
			bmpN = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.S.bmp");
			bmpS = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.E.bmp");
			bmpE = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.W.bmp");
			bmpW = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.NE.bmp");
			bmpNE = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.SE.bmp");
			bmpSE = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.NW.bmp");
			bmpNW = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.SW.bmp");
			bmpSW = Bitmap.FromStream (imgStream) as Bitmap;

			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.oc.bmp");
			openCluster = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.gc.bmp");
			globularCluster = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.dn.bmp");
			difuzeNebula = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.cn.bmp");
			clusterWithNebula = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.pn.bmp");
			planetaryNebula = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.gal.bmp");
			galaxy = Bitmap.FromStream (imgStream) as Bitmap;

			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.halo.gif");
			bmpHalo = Bitmap.FromStream (imgStream) as Bitmap;
			imgStream = asembly.GetManifestResourceStream("Planetarium.Resources.moon.PNG");
			bmpMoon = Bitmap.FromStream (imgStream) as Bitmap;
		}

		public void Calculations (bool changePos)
		{
			double A, a, x, y, z, X, Y;
			A = ViewAngle;
			a = 0;
			x = Math.Cos(a*Math.PI/180)*Math.Sin(A*Math.PI/180);
			y = Math.Sin(a*Math.PI/180);
			z = Math.Cos(a*Math.PI/180)*Math.Cos(A*Math.PI/180);
			X = x/(1+z+0.00001);
			Y = y/(1+z+0.00001);
			mag = Origin.X/X;

			if (changePos == true){
				PlanetData.PlanetPositions();
				for (int i=0; i<12; ++i){
					PlanetData.planets[i].skyPosition.eqToaA (Location.SIDTIME, Location.v_Lat);
					if (PlanetData.planets[i].name == "Sun")
						SunAltitude = PlanetData.planets[i].skyPosition.a;
				}
				if (selected){
					Center.RA = PlanetData.planets[selPl].skyPosition.RA;
					Center.Decl = PlanetData.planets[selPl].skyPosition.Decl;
					Center.eqToaA (Location.SIDTIME, Location.v_Lat);
				}
				APlanet minV;
				int minI;
				for (int i=0; i<10; ++i){
					minV=PlanetData.planets[i];	minI=i;
					for (int j=i+1; j<10; ++j){
						if (PlanetData.planets[j].dist > minV.dist){
							minV=PlanetData.planets[j];	minI=j;
						}
					}
					PlanetData.planets[minI] = PlanetData.planets[i];	
					PlanetData.planets[i] = minV;
				}
				PlanetPosition.pb.Invalidate();
			}

			Center.aAToeq (Location.SIDTIME, Location.v_Lat);
		}

		public void DrawGrid (Graphics g)
		{
			ArrayList secArr = new ArrayList();
			ArrayList prArr = new ArrayList();
			bool notFound = false;
			double nn = 1.5;

			//horizontalna mreza
			if (bShowHOR){
				for (int i=0; i<19; ++i){
					for (int j=0; j<25; ++j){
						double ad = angDist.Calculation(grid[i,j].A, grid[i,j].a, Center.A, Center.a);
						if (2*ViewAngle > 50) nn = 1.5;
						if (2*ViewAngle < 50) nn = 5;
						if (2*ViewAngle < 10) nn = 40;
						if (ad < nn*ViewAngle){
							PointF p = ToScreanPt(grid[i,j]);
							if (notFound == false) secArr.Add (p);
							else prArr.Add (p);
						}
						else notFound = true;
					}

					PointF[] p1 = new PointF[prArr.Count];
					PointF[] p2 = new PointF[secArr.Count];
					int ii=0;
					if (prArr.Count > 0){
						foreach (PointF pp in prArr)
							p1[ii++] = pp;
						if (prArr.Count > 1) g.DrawCurve (Pens.DarkGreen, p1);
					}
					ii=0;
					if (secArr.Count > 0){
						foreach (PointF pp in secArr)
							p2[ii++] = pp;
						if (secArr.Count > 1) g.DrawCurve (Pens.DarkGreen, p2);
					}

					notFound = false;
					prArr.Clear();
					secArr.Clear();
				}
				for (int j=0; j<25; ++j){
					for (int i=0; i<19; ++i){
						double ad = angDist.Calculation(grid[i,j].A, grid[i,j].a, Center.A, Center.a);
						if (2*ViewAngle > 50) nn = 1.5;
						if (2*ViewAngle < 50) nn = 5;
						if (2*ViewAngle < 10) nn = 40;
						if (ad < nn*ViewAngle){
							PointF p = ToScreanPt(grid[i,j]);

							if (bGridLabel && grid[i,j].a!=90 && grid[i,j].a!=-90)
								g.DrawString (((grid[i,j].A)%360)+"\n"+grid[i,j].a, new Font("Arial",8), Brushes.DarkGreen, p.X, p.Y);

							if (notFound == false){
								if (grid[i,j].a!=90 && grid[i,j].a!=-90) secArr.Add (p);
								else if (j%2 != 0) secArr.Add (p);
							}
							else if (grid[i,j].a!=90 && grid[i,j].a!=-90) prArr.Add (p);
							else if (j%2 != 0) prArr.Add (p);
						}
						else notFound = true;
					}
					PointF[] p1 = new PointF[prArr.Count];
					PointF[] p2 = new PointF[secArr.Count];
					int ii=0;
					if (prArr.Count > 0){
						foreach (PointF pp in prArr)
							p1[ii++] = pp;
						if (prArr.Count > 1)
							g.DrawCurve (Pens.DarkGreen, p1);
					}
					ii=0;
					if (secArr.Count > 0){
						foreach (PointF pp in secArr)
							p2[ii++] = pp;
						if (secArr.Count > 1)
							g.DrawCurve (Pens.DarkGreen, p2);
					}

					notFound = false;
					prArr.Clear();
					secArr.Clear();
				}
			}

			//ekvatorijalna mreza
			if (bShowEQ){
				for (int i=0; i<19; ++i){
					for (int j=0; j<25; ++j){
						double ad = angDist.Calculation(EQgrid[i,j].RA, EQgrid[i,j].Decl, Center.RA, Center.Decl);
						if (2*ViewAngle > 50) nn = 1.5;
						if (2*ViewAngle < 50) nn = 5;
						if (2*ViewAngle < 10) nn = 40;
						if (ad < nn*ViewAngle){
							EQgrid[i,j].eqToaA (Location.SIDTIME, Location.v_Lat);
							PointF p = ToScreanPt(EQgrid[i,j]);

							if (bGridLabel && EQgrid[i,j].Decl!=90 && EQgrid[i,j].Decl!=-90)
								g.DrawString (((EQgrid[i,j].RA)%360)/15+" h\n"+EQgrid[i,j].Decl, new Font("Arial",8), Brushes.DarkRed, p.X, p.Y);

							if (notFound == false) secArr.Add (p);
							else prArr.Add (p);
						}
						else notFound = true;
					}

					PointF[] p1 = new PointF[prArr.Count];
					PointF[] p2 = new PointF[secArr.Count];
					int ii=0;
					if (prArr.Count > 0){
						foreach (PointF pp in prArr)
							p1[ii++] = pp;
						if (prArr.Count > 1) g.DrawCurve (Pens.DarkRed, p1);
					}
					ii=0;
					if (secArr.Count > 0){
						foreach (PointF pp in secArr)
							p2[ii++] = pp;
						if (secArr.Count > 1) g.DrawCurve (Pens.DarkRed, p2);
					}

					notFound = false;
					prArr.Clear();
					secArr.Clear();
				}
				for (int j=0; j<25; ++j){
					for (int i=0; i<19; ++i){
						double ad = angDist.Calculation(EQgrid[i,j].RA, EQgrid[i,j].Decl, Center.RA, Center.Decl);
						if (2*ViewAngle > 50) nn = 1.5;
						if (2*ViewAngle < 50) nn = 5;
						if (2*ViewAngle < 10) nn = 40;
						if (ad < nn*ViewAngle){
							PointF p = ToScreanPt(EQgrid[i,j]);
							if (notFound == false){
								if (EQgrid[i,j].Decl!=90 && EQgrid[i,j].Decl!=-90) secArr.Add (p);
								else if (j%2 != 0) secArr.Add (p);
							}
							else if (EQgrid[i,j].Decl!=90 && EQgrid[i,j].Decl!=-90) prArr.Add (p);
							else if (j%2 != 0) prArr.Add (p);
						}
						else
							notFound = true;
					}
					PointF[] p1 = new PointF[prArr.Count];
					PointF[] p2 = new PointF[secArr.Count];
					int ii=0;
					if (prArr.Count > 0){
						foreach (PointF pp in prArr)
							p1[ii++] = pp;
						if (prArr.Count > 1) g.DrawCurve (new Pen(Color.DarkRed), p1);
					}
					ii=0;
					if (secArr.Count > 0){
						foreach (PointF pp in secArr)
							p2[ii++] = pp;
						if (secArr.Count > 1)
							g.DrawCurve (new Pen(Color.DarkRed), p2);
					}

					notFound = false;
					prArr.Clear();
					secArr.Clear();
				}
			}
		}

		public void DrawConstellations (Graphics g)
		{
			foreach (ConstellationLine c in DSData.constellation){
				double ad1 = angDist.Calculation(c.sp1.RA, c.sp1.Decl, Center.RA, Center.Decl);
				double ad2 = angDist.Calculation(c.sp2.RA, c.sp2.Decl, Center.RA, Center.Decl);
				if (ad1<2*ViewAngle || ad2<2*ViewAngle){
					PointF p1 = new PointF();
					PointF p2 = new PointF();
					c.sp1.eqToaA (Location.SIDTIME, Location.v_Lat);
					p1 = ToScreanPt(c.sp1);
					c.sp2.eqToaA (Location.SIDTIME, Location.v_Lat);
					p2 = ToScreanPt(c.sp2);
					g.DrawLine (Pens.YellowGreen, p1, p2);
				}
			}

			if (bCoLabel == true){
				foreach (ConstellationName cn in DSData.constellationNames){
					double ad = angDist.Calculation(cn.skyPos.RA, cn.skyPos.Decl, Center.RA, Center.Decl);
					if (ad<1.2*ViewAngle){
						cn.skyPos.eqToaA (Location.SIDTIME, Location.v_Lat);
						PointF p = ToScreanPt(cn.skyPos);
						g.DrawString (cn.name, new Font("Arial",12), Brushes.Aqua, 
							(int)(p.X-cn.name.Length*4),(int)(p.Y+5));
					}
				}
			}
		}

		public void DrawStars (Graphics g)
		{
			foreach (Star s in DSData.stars){
				int w=0;
				switch ((int)Math.Round(s.magnitude,0)){
					case -1:{w = 7; break;}
					case 0:{w = 6; break;}
					case 1:{w = 5; break;}
					case 2:{w = 4; break;}
					case 3:{w = 3; break;}
					case 4:{w = 2; break;}
					case 5:{w = 1; break;}
					case 6:{w = 0; break;}
				}
				magX = (int)(50/ViewAngle)-1;
				if (ViewAngle<=10 && w<3) magX=4;
				w += magX;
				if (w > 0){
					double ad = angDist.Calculation(s.SkyPosition.RA, s.SkyPosition.Decl, Center.RA, Center.Decl);
					if (ad<1.2*ViewAngle){
						s.SkyPosition.eqToaA (Location.SIDTIME, Location.v_Lat);
						double dawn = (2*(Math.Round(s.magnitude,0)+2))-1;
						if (!bDay || dawn*(-1)>=SunAltitude){
							PointF p = ToScreanPt(s.SkyPosition);
							int size = w;
							char type = s.spectrum[0];
							Bitmap b = bmpRed;
							if (w == 1) {b=bmpMR; size=2;}
							if (type=='F' || type=='G')
								b = (w==1) ? bmpMY : bmpYellow;
							if (type=='O' || type=='B' || type=='A')
								b = (w==1) ? bmpMB : bmpBlue;
							if (size > 14){b=bmpMax; size=19;}

							if (w != 1) b.MakeTransparent();

							g.DrawImage (b, (float)(p.X-size/2), (float)(p.Y-size/2), size, size);
							if (bStLabel && w>=4 && s.designation!=""){
								string name;
								if (s.name == "") name = s.designation;
								else	name = s.name;
								
								PointF tempPt = new PointF();
								PointF textPt = new PointF();
								tempPt = p;
								SizeF sizeTxt = new SizeF();
								sizeTxt = g.MeasureString(name, stTxtFont);
								sizeTxt.Width += 8;
								textPt.X = p.X + 8;
								textPt.Y = p.Y + sizeTxt.Height/2;
								if (CheckTextPlace(p, sizeTxt) == true){p.X-=sizeTxt.Width; p.Y-=sizeTxt.Height; textPt.X=tempPt.X-8; textPt.Y=p.Y+sizeTxt.Height/2;}
								if (CheckTextPlace(p, sizeTxt) == true){p=tempPt; p.X-=sizeTxt.Width; textPt.X=tempPt.X-8; textPt.Y=p.Y+sizeTxt.Height/2;}
								if (CheckTextPlace(p, sizeTxt) == true){p=tempPt; p.X+=8; p.Y-=sizeTxt.Height; textPt.X=tempPt.X+5; textPt.Y=p.Y+sizeTxt.Height/2;}
								if (tempPt == p)	p.X += 8;
								if (CheckTextPlace(p, sizeTxt) == false){
									g.DrawLine (new Pen(stTxtColor), tempPt, textPt);
									g.DrawString (name, stTxtFont, new SolidBrush(stTxtColor), p.X, p.Y);
									textPtArr.Add (new PointF(p.X, p.Y));
								}
							}
						}
					}
				}
			}
		}

		public void DrawMessier (Graphics g)
		{
			foreach (Messier m in DSData.messier){
				double ad = angDist.Calculation(m.SkyPosition.RA, m.SkyPosition.Decl, Center.RA, Center.Decl);
				if (ad<1.2*ViewAngle){
					m.SkyPosition.eqToaA (Location.SIDTIME, Location.v_Lat);
					if (!bDay || SunAltitude<-15){
						PointF p = ToScreanPt(m.SkyPosition);
						Bitmap b = openCluster;
						switch (m.Type){
							case "OCl":{b = openCluster; break;}
							case "GCl":{b = globularCluster; break;}
							case "PlN":{b = planetaryNebula; break;}
							case "DfN":{b = difuzeNebula; break;}
							case "Gal":{b = galaxy; break;}
							case "C/N":{b = clusterWithNebula; break;}
						}
						
						b.MakeTransparent();
						g.DrawImage (b, p.X-5, p.Y-5, 10, 10);
						if (bMLabel){
							PointF tempPt = new PointF();
							PointF textPt = new PointF();
							tempPt = p;
							SizeF sizeTxt = new SizeF();
							sizeTxt = g.MeasureString(m.designation, stTxtFont);
							sizeTxt.Width += 8;
							textPt.X = p.X + 8;
							textPt.Y = p.Y + sizeTxt.Height/2;
							if (CheckTextPlace(p, sizeTxt) == true){p.X-=sizeTxt.Width; p.Y-=sizeTxt.Height; textPt.X=tempPt.X-8; textPt.Y=p.Y+sizeTxt.Height/2;}
							if (CheckTextPlace(p, sizeTxt) == true){p=tempPt; p.X-=sizeTxt.Width; textPt.X=tempPt.X-8; textPt.Y=p.Y+sizeTxt.Height/2;}
							if (CheckTextPlace(p, sizeTxt) == true){p=tempPt; p.X+=8; p.Y-=sizeTxt.Height; textPt.X=tempPt.X+5; textPt.Y=p.Y+sizeTxt.Height/2;}
							if (tempPt == p)	p.X += 8;
							if (CheckTextPlace(p, sizeTxt) == false){
								g.DrawLine (Pens.Gray, tempPt, textPt);
								g.DrawString (m.designation, stTxtFont, Brushes.Gray, p.X, p.Y);
								textPtArr.Add (new PointF(p.X, p.Y));
							}
						}
					}
				}
			}
		}

		public void DrawSol (Graphics g)
		{
			for (int i=0; i<12; ++i){
				if (PlanetData.planets[i].name!="Earth" && 
					(bLine==true || PlanetData.planets[i].skyPosition.a>(-8)))
				{
					double ad = angDist.Calculation(PlanetData.planets[i].skyPosition.RA, PlanetData.planets[i].skyPosition.Decl, Center.RA, Center.Decl);
					double dawn=-100;
					if (PlanetData.planets[i].name!="Sun" && PlanetData.planets[i].name!="Moon") 
						dawn = (2*(Math.Round(PlanetData.planets[i].magnitude,0)+2))-1;
					string name = PlanetData.planets[i].name;
					if (name=="Uranus" || name=="Neptune" || name=="Pluto")
						dawn = 10;
					if (ad<1.2*ViewAngle || (ViewAngle<1 && ad<8))
					{
						if (PlanetData.planets[i].elong<0.3 || selPl==name || 
							!bDay || dawn*(-1)>=SunAltitude)
						{
							PointF p = ToScreanPt(PlanetData.planets[i].skyPosition);

							int w = 0;
							switch ((int)Math.Round(PlanetData.planets[i].magnitude,0))
							{
								case -5:{w = 11; break;}
								case -4:{w = 10; break;}
								case -3:{w = 9; break;}
								case -2:{w = 8; break;}
								case -1:{w = 7; break;}
								case 0:{w = 6; break;}
								case 1:{w = 5; break;}
								case 2:{w = 4; break;}
								case 3:{w = 3; break;}
								case 4:{w = 2; break;}
								case 5:{w = 1; break;}
								case 6:{w = 0; break;}
							}
							if (w > 7)	w=7;
							if (w < 2)	w=2;
							int w2 = (int)((Origin.X)/((ViewAngle*3600)/PlanetData.planets[i].diam));
							if (w2 > w) w=w2;
							if (name=="Sun" || name=="Moon"){
								if (ViewAngle<25)
									w = (int)((Origin.X)/((ViewAngle*3600)/PlanetData.planets[i].diam));
								else
									w = (int)((Origin.X)/((20*3600)/PlanetData.planets[i].diam));
							}
							Color c = Color.Red;
							switch (PlanetData.planets[i].name)
							{
								case "Pluto":{c = Color.Wheat; break;}
								case "Neptune":{c = Color.Blue; break;}
								case "Uranus":{c = Color.Aqua; break;}
								case "Saturn":{c = Color.SandyBrown; break;}
								case "Jupiter":{c = Color.Goldenrod; break;}
								case "Mars":{c = Color.Salmon; break;}
								case "Venus":{c = Color.LightYellow; break;}
								case "Mercury":{c = Color.LightGray; break;}
								case "Moon":{c = Color.LightGray; break;}
								case "Sun":{c = Color.Yellow; break;}
							}

							if (PlanetData.planets[i].name=="Sun" && bFull && bDay){
								if ((2*ViewAngle) > 50) sizeH=(int)(8000/ViewAngle);
								bmpHalo.MakeTransparent();
								if ((2*ViewAngle) > 3)
									g.DrawImage (bmpHalo, (float)(p.X-sizeH/2), (float)(p.Y-sizeH/2), sizeH, sizeH);
							}

							if (name == "Moon" || (ViewAngle<1 && name == "Venus"))
							{
								if (w < 50) w=50;
								Bitmap bmp;
								if (w<300) bmp = new Bitmap(w, w);
								else bmp = new Bitmap(300, 300);
								bmpMoon.MakeTransparent();

								Graphics moonGr = Graphics.FromImage(bmp);
								if (name == "Moon")
									moonGr.DrawImage(bmpMoon, 0, 0, bmp.Width, bmp.Height);
								else
									moonGr.FillEllipse(new SolidBrush(c), 0, 0, bmp.Width, bmp.Height);
								GraphicsPath gp = new GraphicsPath();

								int n = (int)(PlanetData.planets[i].skyPosition.RA+360-PlanetData.planets["Sun"].skyPosition.RA)%360;
								double elong = 0;
								if (name == "Moon")	elong = PlanetData.planets[i].elong;
								else elong = 180 - PlanetData.planets[i].FV;
								double dx = 0;
								if (n<180)
								{
									gp.AddArc (0,0,bmp.Width, bmp.Height,90,180);
									if (elong <= 90)
									{
										dx = bmp.Width/2 * Math.Cos(elong*Math.PI/180);
										gp.AddArc ((float)(bmp.Width/2-dx), 0, (float)(2*dx), bmp.Height,270,180);
									}
									else
									{
										dx = bmp.Width/2 * Math.Cos((180-elong)*Math.PI/180);
										gp.AddArc ((float)(bmp.Width/2-dx), 0, (float)(2*dx), bmp.Height,90,180);
									}
								}
								else
								{
									gp.AddArc (0,0,bmp.Width, bmp.Height,270,180);
									if (elong <= 90)
									{
										dx = bmp.Width/2 * Math.Cos(elong*Math.PI/180);
										gp.AddArc ((float)(bmp.Width/2-dx), 0, (float)(2*dx), bmp.Height,90,180);
									}
									else
									{
										dx = bmp.Width/2 * Math.Cos((180-elong)*Math.PI/180);
										gp.AddArc ((float)(bmp.Width/2-dx), 0, (float)(2*dx), bmp.Height,270,180);
									}
								}	
								moonGr.FillPath (new SolidBrush(moonColor), gp);

								PointF[] pM = new PointF[3];
								double halfDiam = PlanetData.planets[i].diam/7200;
								if (name == "Moon" && ViewAngle>20)
									halfDiam *= (ViewAngle/20);

								SkyPos top = new SkyPos();
								SkyPos bottom = new SkyPos();
								top.RA = PlanetData.planets[i].skyPosition.RA;
								top.Decl = PlanetData.planets[i].skyPosition.Decl + halfDiam;
								top.eqToaA (Location.SIDTIME, Location.v_Lat);
								bottom.RA = PlanetData.planets[i].skyPosition.RA;
								bottom.Decl = PlanetData.planets[i].skyPosition.Decl - halfDiam;
								bottom.eqToaA (Location.SIDTIME, Location.v_Lat);
								PointF pt = ToScreanPt(top);
								PointF pb = ToScreanPt(bottom);
								double d = Math.Sqrt((pb.Y-pt.Y)*(pb.Y-pt.Y)+(pb.X-pt.X)*(pb.X-pt.X));
								if (pt.Y <= pb.Y)
								{
									if (pt.X <= pb.X)
									{
										double alpha = Math.Asin((pb.X-pt.X)/d)*180/Math.PI;
										double dX = d/2*Math.Cos(alpha*Math.PI/180);
										double dY = d/2*Math.Sin(alpha*Math.PI/180);
										pM[0].X = (float)(pt.X - dX);	pM[0].Y = (float)(pt.Y + dY);
										pM[1].X = (float)(pt.X + dX);	pM[1].Y = (float)(pt.Y - dY);
										pM[2].X = (float)(pb.X - dX);	pM[2].Y = (float)(pb.Y + dY);
									}
									else
									{
										double alpha = Math.Asin((pt.X-pb.X)/d)*180/Math.PI;
										double dX = d/2*Math.Cos(alpha*Math.PI/180);
										double dY = d/2*Math.Sin(alpha*Math.PI/180);
										pM[0].X = (float)(pt.X - dX);	pM[0].Y = (float)(pt.Y - dY);
										pM[1].X = (float)(pt.X + dX);	pM[1].Y = (float)(pt.Y + dY);
										pM[2].X = (float)(pb.X - dX);	pM[2].Y = (float)(pb.Y - dY);
									}
								}
								else
								{
									if (pt.X <= pb.X)
									{
										double alpha = Math.Asin((pb.X-pt.X)/d)*180/Math.PI;
										double dX = d/2*Math.Cos(alpha*Math.PI/180);
										double dY = d/2*Math.Sin(alpha*Math.PI/180);
										pM[0].X = (float)(pt.X + dX);	pM[0].Y = (float)(pt.Y + dY);
										pM[1].X = (float)(pt.X - dX);	pM[1].Y = (float)(pt.Y - dY);
										pM[2].X = (float)(pb.X + dX);	pM[2].Y = (float)(pb.Y + dY);
									}
									else
									{
										double alpha = Math.Asin((pt.X-pb.X)/d)*180/Math.PI;
										double dX = d/2*Math.Cos(alpha*Math.PI/180);
										double dY = d/2*Math.Sin(alpha*Math.PI/180);
										pM[0].X = (float)(pt.X + dX);	pM[0].Y = (float)(pt.Y - dY);
										pM[1].X = (float)(pt.X - dX);	pM[1].Y = (float)(pt.Y + dY);
										pM[2].X = (float)(pb.X + dX);	pM[2].Y = (float)(pb.Y - dY);
									}
								}
								g.DrawImage (bmp, pM);
								moonGr.Dispose();
								bmp.Dispose();
							}
							else if (name == "Earth shadow" && bShowES)
							{
								double RES = 0;

								//penumbra
								double RZ = 6378.140;
								double RS = 696000;
								double dS = PlanetData.planets["Sun"].dist * 1.49597870E8;
								double dM = PlanetData.planets["Moon"].dist * 1.49597870E8;
								((EarthShadow)PlanetData.planets["Earth shadow"]).DP = RES = (RZ+RS)*(dS+dM)/dS - RS;

								PlanetData.planets["Earth shadow"].diam = 7200*Math.Atan(RES/dM)*180/Math.PI;

								double dd = PlanetData.planets["Moon"].diam/7200 + PlanetData.planets["Earth shadow"].diam/7200;

								float W = 0;
								W = (float)((Origin.X)/((ViewAngle*3600)/RES));
								g.FillEllipse (new SolidBrush(Color.FromArgb(85,15,15,15)), (float)(p.X-W/2), (float)(p.Y-W/2), (float)W, (float)W);
								g.DrawEllipse (new Pen(Color.FromArgb(85,155,155,155)), (float)(p.X-W/2), (float)(p.Y-W/2), (float)W, (float)W);

								//umbra
								((EarthShadow)PlanetData.planets["Earth shadow"]).DU = RES = RS - ((RS-RZ)*(dS+dM))/dS;

								W = (float)((Origin.X)/((ViewAngle*3600)/RES));
								g.FillEllipse (new SolidBrush(Color.FromArgb(85,80,0,0)), (float)(p.X-W/2), (float)(p.Y-W/2), (float)W, (float)W);
								g.DrawEllipse (new Pen(Color.FromArgb(80,255,0,0)), (float)(p.X-W/2), (float)(p.Y-W/2), (float)W, (float)W);
							}
							else if (name != "Earth shadow")
								g.FillEllipse (new SolidBrush(c), (float)(p.X-w/2), (float)(p.Y-w/2), w, w);
							
							if ((bPlLabel || (selPl==PlanetData.planets[i].name && selected==true)) && (name!="Earth shadow" || this.bShowES==true))
							{
								PointF tempPt = new PointF();
								PointF textPt = new PointF();
								tempPt = p;
								SizeF sizeTxt = new SizeF();
								sizeTxt = g.MeasureString(name, plTxtFont);
								sizeTxt.Width += 8;
								textPt.X = p.X + 8;
								textPt.Y = p.Y + sizeTxt.Height/2;
								if (CheckTextPlace(p, sizeTxt) == true){p.X-=sizeTxt.Width; p.Y-=sizeTxt.Height; textPt.X=tempPt.X-8; textPt.Y=p.Y+sizeTxt.Height/2;}
								if (CheckTextPlace(p, sizeTxt) == true){p=tempPt; p.X-=sizeTxt.Width; textPt.X=tempPt.X-8; textPt.Y=p.Y+sizeTxt.Height/2;}
								if (CheckTextPlace(p, sizeTxt) == true){p=tempPt; p.X+=8; p.Y-=sizeTxt.Height; textPt.X=tempPt.X+5; textPt.Y=p.Y+sizeTxt.Height/2;}
								if (CheckTextPlace(p, sizeTxt) == false){
									if (tempPt == p)	p.X += 8;
									g.DrawLine (new Pen(plTxtColor), tempPt, textPt);
									g.DrawString (name, plTxtFont, new SolidBrush(plTxtColor), p.X, p.Y);
									textPtArr.Add (new PointF(p.X, p.Y));
								}
							}
						}
					}
				}
			}
		}

		public void DrawHorizon (Graphics g)
		{
			SkyPos[] horizont = new SkyPos[34];
			Point[] hor = new Point[34];

			hor[0].X=0;				hor[0].Y=2*Origin.Y+10;
			hor[32].X=2*Origin.X;	hor[32].Y=2*Origin.Y+10;
			hor[33].X=hor[0].X;		hor[33].Y=hor[0].Y;
			
			double step = (2*ViewAngle+ViewAngle/10)/30;
			horizont[1].A = Center.A-15*step;
			for (int i=2; i<32; ++i){
				horizont[i].A = horizont[i-1].A + step;
				horizont[i].a = 0;
			}

			for (int i=1; i<32; ++i){
				PointF p = ToScreanPt(horizont[i]);
				hor[i].X=(int)p.X;	hor[i].Y=(int)p.Y;
			}
			SolidBrush earCol;
			if (SunAltitude > 0)	earCol = new SolidBrush(Color.FromArgb(0,100,0));
			else	earCol = new SolidBrush(Color.FromArgb(0,50,0));
			GraphicsPath gp = new GraphicsPath();
			gp.AddPolygon (hor);
			if (bFull) g.FillPath (earCol, gp);
			if (bLine) g.DrawPath (new Pen(earCol), gp);
		}

		public void DrawDirection (Graphics g, bool zn)
		{
			for (int i=0; i<10; ++i){
				if (zn==false && i==8) break;
				double ad = angDist.Calculation(direction[i].A, direction[i].a, Center.A, Center.a);

				if (ad < 1.2*ViewAngle){
					PointF p = ToScreanPt(direction[i]);
					if (i < 8){
						Bitmap b = bmpS;
						switch ((int)direction[i].A){
							case 0:{b=bmpN; break;}
							case 45:{b=bmpNE; break;}
							case 90:{b=bmpE; break;}
							case 135:{b=bmpSE; break;}
							case 180:{b=bmpS; break;}
							case 225:{b=bmpSW; break;}
							case 270:{b=bmpW; break;}
							case 315:{b=bmpNW; break;}
						}
						int size = b.Width;
						b.MakeTransparent();
						g.DrawImage (b, (int)(p.X-size/2), (int)p.Y+10, size, size);
					}
					else{
						string str="";
						if (i==8) str="Zenith";
						if (i==9) str="Nadir";
						Font font = new Font("Arial",10);
						SizeF size = g.MeasureString(str, font);

						if (i == 8){
							PointF top = p;
							PointF b = new PointF(top.X, top.Y+8);
							PointF l = new PointF(top.X-2, top.Y+4);
							PointF r = new PointF(top.X+2, top.Y+4);
							g.DrawLine (Pens.Red, top, b);
							g.DrawLine (Pens.Red, top, l);
							g.DrawLine (Pens.Red, top, r);
							g.DrawString (str, font, Brushes.Red, (float)(p.X-size.Width/2), p.Y+8);
						}
						if (i == 9){
							PointF top = p;
							PointF b = new PointF(top.X, top.Y-8);
							PointF l = new PointF(b.X-2, b.Y+4);
							PointF r = new PointF(b.X+2, b.Y+4);
							g.DrawLine (Pens.Red, top, b);
							g.DrawLine (Pens.Red, top, l);
							g.DrawLine (Pens.Red, top, r);
							g.DrawString (str, font, Brushes.Red, (float)(p.X-size.Width/2), p.Y-size.Height-8);
						}
					}
				}
			}
		}

		PointF ToScreanPt (SkyPos sp)
		{
			double ZPX = (Center.A + 180)%360 - sp.A;
			double AA=0, Atemp=0, A=0, a=0;

			a = Math.Asin(
				Math.Sin(sp.a*pi/180)*Math.Sin((90-Center.a+0.000001)*pi/180)+
				Math.Cos(sp.a*pi/180)*Math.Cos((90-Center.a+0.000001)*pi/180)*Math.Cos(ZPX*pi/180))*180/pi;
			
			Atemp = (-Math.Sin(sp.a*pi/180)*Math.Cos((90-Center.a+0.000001)*pi/180)+
				Math.Sin((90-Center.a+0.000001)*pi/180)*Math.Cos(sp.a*pi/180)*Math.Cos(ZPX*pi/180))/
				Math.Sin((90-a+0.000001)*pi/180);
			if (Atemp > 1) Atemp=1;
			if (Atemp < -1) Atemp=-1;
			A = Math.Acos(Atemp)*180/pi;

			Atemp = Math.Sin(ZPX*pi/180)*Math.Cos(sp.a*pi/180)/Math.Sin((90-a+0.000001)*pi/180);
			if (Atemp > 1) Atemp=1;
			if (Atemp < -1) Atemp=-1;
			AA = Math.Asin(Atemp)*180/pi;
			
			if (Math.Round(A-AA,0) == 180) { A=(-AA); goto label;}
			if (Math.Round(AA+A,0) == 0) { A=180+AA; goto label;}
			if (Math.Round(AA-A,0) == 0) { A=180+A; goto label;}
			if (Math.Round(AA+A,0) == 180) A=360-AA;
			label:;
			A = 360 - A;

			double x, y, z, X, Y;
			x = Math.Cos(a*pi/180)*Math.Sin(A*pi/180);
			y = Math.Sin(a*pi/180);
			z = Math.Cos(a*pi/180)*Math.Cos(A*pi/180);
			X = mag*x/(1+z+0.0000001);
			Y = mag*y/(1+z+0.0000001);

			return new PointF((float)(Origin.X+X), (float)(Origin.Y-Y));
		}

		bool CheckTextPlace (PointF pt, SizeF size)
		{
			foreach (PointF p in textPtArr){
				if (Math.Abs(p.X-pt.X) <= size.Width &&
					Math.Abs(p.Y-pt.Y) <= size.Height)
					return true;
			}
			return false;
		}

		private double pi = Math.PI;
		private int sizeH;
		private Bitmap bmpBlue, bmpYellow, bmpRed, bmpMax, bmpMR, bmpMY, bmpMB;
		private Bitmap bmpN, bmpS, bmpE, bmpW, bmpNE, bmpNW, bmpSE, bmpSW;
		private Bitmap bmpHalo, bmpMoon;
		private Bitmap openCluster, globularCluster, planetaryNebula, clusterWithNebula,
			           difuzeNebula, galaxy;
		private int magX=0;
		private AngularDistances angDist = new AngularDistances();
	}
}
