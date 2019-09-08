using System;

namespace SpaceObjects.Data
{
    public class Star : BaseSpaceObject
    {
        public Star() { }

        public Star(string designation, string name, double ra, double decl, double magnitude, string spectrum)
        {
            this.Designation = designation;
            this.Name = name;
            this.SkyPosition = new SkyPosition();
            this.SkyPosition.Rectascence = ra;
            this.SkyPosition.Decl = decl;
            this.Magnitude = magnitude;
            this.Spectrum = spectrum;
        }

        public override void Ephemerides()
        {
            throw new NotImplementedException();
        }

        public override void OrbitalElements()
        {
            throw new NotImplementedException();
        }

        public override void Perturbations()
        {
            throw new NotImplementedException();
        }
    }
}
