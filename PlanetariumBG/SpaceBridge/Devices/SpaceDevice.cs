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

namespace SpaceBridge.Devices
{
    public class SpaceDevice
    {

        #region Properties

        /// <summary>
        /// True when robot is flowing the commands.
        /// Else false.
        /// </summary>
        public bool IsRuning
        {
            protected set;
            get;
        }

        public virtual bool IsConnected
        {
            set;
            get;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SpaceDevice()
        {

        }

        #endregion

        #region Virtual methods

        /// <summary>
        /// Connect to the Robot.
        /// </summary>
        public virtual void Connect()
        {
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public virtual void Disconnect()
        {
        }

        /// <summary>
        /// Disable axis.
        /// </summary>
        public virtual void Disable()
        {
        }

        /// <summary>
        /// Enable axis.
        /// </summary>
        public virtual void Enable()
        {
        }

        /// <summary>
        /// Move axis.
        /// </summary>
        public virtual void SetPosition()
        {
        }

        /// <summary>
        /// Read data from the joint.
        /// </summary>
        public virtual void GetPosition()
        {
        }

        /// <summary>
        /// Read inputs, by bit coding of 32 bit integer.
        /// </summary>
        /// <returns></returns>
        public virtual void ReadInputs()
        {
        }

        /// <summary>
        /// Write outputs by bit coding of 32 bit integer.
        /// </summary>
        /// <param name="data">Bit data.</param>
        public virtual void WriteOutputs(int data)
        {
        }

        /// <summary>
        /// Read output state.
        /// </summary>
        public virtual void ReadOutputs()
        {
        }

        public virtual void Reset()
        {
        }

        #endregion

        #region Protected methods

        protected void Busy(float delay)
        {
            //this.IsRuning = true;
            //if (this.OnMoveing != null)
            //{
            //    this.OnMoveing(this, new EventArgs());
            //}
            //
            //Thread wait = new Thread(
            //    new ThreadStart(
            //        delegate ()
            //        {
            //            Thread.Sleep((int)delay);
            //
            //            this.IsRuning = false;
            //            if (this.OnNotMoveing != null)
            //            {
            //                this.OnNotMoveing(this, new EventArgs());
            //            }
            //        }
            //    )
            //);
            //
            //wait.Start();
        }

        #endregion

    }
}
