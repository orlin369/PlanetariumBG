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
using SpaceObjects.Perturbations;
using System;

namespace SpaceObjects.SolarSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class SolarSystemData
    {
        private static SolarSystemData instance;

        private LocationST location;

        private static string[] orbitNames = {"Mercury","Venus","Earth","Mars","Jupiter",
                                                 "Saturn","Uranus","Neptune","Pluto"};

        public double RES = 0;

        public SolarSystemObjects SolarSystemObjects
        {
            get;
            set;
        }

        public Orbits Orbits
        {
            get;
            set;
        }
        public Orbits copyOrb
        {
            get;
            set;
        }

        private SolarSystemData()
        {
            this.SolarSystemObjects = new SolarSystemObjects();
            this.SolarSystemObjects.Add(new Mercury());
            this.SolarSystemObjects.Add(new Venus());
            this.SolarSystemObjects.Add(new Earth());
            this.SolarSystemObjects.Add(new Mars());
            this.SolarSystemObjects.Add(new Jupiter());
            this.SolarSystemObjects.Add(new Saturn());
            this.SolarSystemObjects.Add(new Uranus());
            this.SolarSystemObjects.Add(new Neptune());
            this.SolarSystemObjects.Add(new Pluto());
            this.SolarSystemObjects.Add(new Sun());
            this.SolarSystemObjects.Add(new Moon());
            this.SolarSystemObjects.Add(new EarthShadow());

            this.location = LocationST.GetInstance();
            this.Orbits = new Orbits(orbitNames);
            this.copyOrb = new Orbits(orbitNames);
        }




        public static SolarSystemData GetInstance()
        {
            if (instance == null)
                instance = new SolarSystemData();
            return instance;
        }

        public void PlanetPositions()
        {
            this.SolarSystemObjects.GetObjectByName("Sun").ResetPlanet();

            this.SolarSystemObjects.GetObjectByName("Sun").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Jupiter").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Saturn").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Uranus").OrbitalElements();

            this.SolarSystemObjects.GetObjectByName("Sun").GeocentricPos();
            this.SolarSystemObjects.GetObjectByName("Earth").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Earth").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Earth shadow").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Earth shadow").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Moon").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Moon").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Moon").Perturbations();
            this.SolarSystemObjects.GetObjectByName("Moon").GeocentricPos();
            this.SolarSystemObjects.GetObjectByName("Moon").TopocentricPos();

            this.SolarSystemObjects.GetObjectByName("Mercury").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Mercury").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Mercury").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Venus").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Venus").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Venus").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Mars").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Mars").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Mars").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Jupiter").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Jupiter").Perturbations();
            this.SolarSystemObjects.GetObjectByName("Jupiter").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Saturn").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Saturn").Perturbations();
            this.SolarSystemObjects.GetObjectByName("Saturn").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Uranus").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Uranus").Perturbations();
            this.SolarSystemObjects.GetObjectByName("Uranus").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Neptune").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Neptune").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Neptune").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Pluto").OrbitalElements();
            this.SolarSystemObjects.GetObjectByName("Pluto").HeliocentricPos();
            this.SolarSystemObjects.GetObjectByName("Pluto").GeocentricPos();

            this.SolarSystemObjects.GetObjectByName("Sun").Ephemerides();
            this.SolarSystemObjects.GetObjectByName("Moon").Ephemerides();
            foreach (string orbitName in orbitNames)
            {
                this.SolarSystemObjects.GetObjectByName(orbitName).Ephemerides();
            }

            double RZ = 6378.140;
            double RS = 696000;
            double dS = this.SolarSystemObjects.GetObjectByName("Sun").Distance * 1.49597870E8;
            double dM = this.SolarSystemObjects.GetObjectByName("Moon").Distance * 1.49597870E8;
            ((EarthShadow)this.SolarSystemObjects.GetObjectByName("Earth shadow")).DP = RES = (RZ + RS) * (dS + dM) / dS - RS;
            this.SolarSystemObjects.GetObjectByName("Earth shadow").Diameter = 7200 * Math.Atan(RES / dM) * 180 / Math.PI;
            ((EarthShadow)this.SolarSystemObjects.GetObjectByName("Earth shadow")).DU = RS - ((RS - RZ) * (dS + dM)) / dS;
        }

        public void PlanetOrb()
        {
            DateTime dt = location.MainDateTime;
            foreach (string orbitName in orbitNames)
            {
                for (short i = 0; i < 30; ++i)
                {
                    PlanetPositions();
                    location.MainDateTime = location.MainDateTime.AddDays(this.SolarSystemObjects.GetObjectByName(orbitName).TrueAnomaly / 27.4);
                    PlanetPosition pp = new PlanetPosition();
                    pp.X = this.SolarSystemObjects.GetObjectByName(orbitName).Position.X;
                    pp.Y = this.SolarSystemObjects.GetObjectByName(orbitName).Position.Y;
                    pp.Z = this.SolarSystemObjects.GetObjectByName(orbitName).Position.Z;
                    pp.Name = orbitName;
                    Orbits[orbitName, i] = pp;
                }
                if (orbitName == "Saturn") location.MainDateTime = new DateTime(1950, 1, 1, 0, 0, 0);
                if (orbitName == "Uranus") location.MainDateTime = new DateTime(1920, 1, 1, 0, 0, 0);
                if (orbitName == "Neptune") location.MainDateTime = new DateTime(1900, 1, 1, 0, 0, 0);
                if (orbitName == "Pluto") location.MainDateTime = dt;
            }
        }

        public void RotateOrbit(int angle_x, int angle_z)
        {
            foreach (string orbitName in orbitNames)
            {
                for (short i = 0; i < 30; ++i)
                {
                    PlanetPosition pp = new PlanetPosition();
                    pp = Orbits[orbitName, i];
                    pp.Rotate(angle_x, angle_z);
                    copyOrb[orbitName, i] = pp;
                }
            }
        }


    }
}
