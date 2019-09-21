using System;

namespace SpaceObjects.Data
{
    [Serializable]
    public class Star : BaseSpaceObject
    {

        #region Constructor

        public Star() { }

        public Star(string designation, string name, double rectascence, double declination, double magnitude, string spectrum)
        {
            this.Designation = designation;
            this.Name = name;
            this.SkyPosition = new SkyPosition();
            this.SkyPosition.Rectascence = rectascence;
            this.SkyPosition.Declination = declination;
            this.Magnitude = magnitude;
            this.Spectrum = spectrum;
        }

        #endregion

        #region Public Methods

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

        #endregion

    }
}
