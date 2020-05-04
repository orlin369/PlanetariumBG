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

using SpaceBridge.Events;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO.Ports;
using EasyModbus;
using SpaceBridge.Data;

namespace SpaceBridge.Devices.Model1
{
    public class Model1 : SpaceDevice
    {
        #region Constants

        /// <summary>
        /// Protocol sentinel.
        /// </summary>
        private const byte SENTINEL = 0xAA;

        /// <summary>
        /// Frame payload offset.
        /// </summary>
        private const byte FRAME_RESPONSE_PAYLOAD_OFFSET = 2;

        /// <summary>
        /// Frame static field offset.
        /// </summary>
        private const byte FRAME_STATIC_FIELD_OFFSET = 4;

        #endregion

        #region Variables

        private static Model1 device;

        /// <summary>
        /// Modbus client.
        /// </summary>
        ModbusClient mbClient;

        #endregion

        #region Events

        /// <summary>
        /// On connect event.
        /// </summary>
        public override event EventHandler<EventArgs> OnConnect;

        /// <summary>
        /// On disconnect
        /// </summary>
        public override event EventHandler<EventArgs> OnDisconnect;

        /// <summary>
        /// On device ready.
        /// </summary>
        public event EventHandler<EventArgs> OnReady;

        /// <summary>
        /// Raise when motor is ruining.
        /// </summary>
        public event EventHandler<EventArgsVector3> OnCompasChange;

        #endregion

        #region Properties

        public bool IsReady
        {
            private set;
            get;
        }

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName">Communication port.</param>
        public Model1(string portName, int baudrate, byte slaveId)
        {
            mbClient = new ModbusClient(portName);
            mbClient.UnitIdentifier = slaveId;
            mbClient.Baudrate = baudrate;
            mbClient.Parity = Parity.None;
            mbClient.StopBits = StopBits.One;
            this.IsReady = false;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Model1()
        {
            this.Disconnect();
        }

        #endregion

        #region Public Overrider Methods

        /// <summary>
        /// Connect to the Robot.
        /// </summary>
        public override void Connect()
        {
            this.Disconnect();
            if(!this.mbClient.Connected)
            {
                this.mbClient.NumberOfRetries = 3;
                this.mbClient.Connect();
                this.mbClient.ReceiveDataChanged += MbClient_ReceiveDataChanged;
                this.OnConnect?.Invoke(this, new EventArgs());
            }
        }

        private void MbClient_ReceiveDataChanged(object sender)
        {
            Console.WriteLine("MbClient_ReceiveDataChanged");
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public override void Disconnect()
        {
            if (this.mbClient == null || !this.mbClient.Connected) return;

            this.OnDisconnect?.Invoke(this, new EventArgs());
            this.mbClient.Disconnect();
            this.mbClient.ReceiveDataChanged -= MbClient_ReceiveDataChanged;
        }

        /// <summary>
        /// Enables the motor.
        /// </summary>
        /// <param name="joint">Index of the motor.</param>
        public override void Enable()
        {
            if (this.mbClient == null) return;

            this.mbClient.WriteSingleRegister(MemoryMap.MOTOR_STATE, 1);
        }

        /// <summary>
        /// Disable the motor.
        /// </summary>
        /// <param name="joint">Index of the motor.</param>
        public override void Disable()
        {
            if (this.mbClient == null) return;

            this.mbClient.WriteSingleRegister(MemoryMap.MOTOR_STATE, 0);
        }

        /// <summary>
        /// Read the motor state.
        /// </summary>
        public void GetPosition()
        {
            if (this.mbClient == null) return;

            int fields = 2;
            int[] result = mbClient.ReadHoldingRegisters(MemoryMap.MOTOR_POSITION, fields);
            if (result != null)
            {
                if (result.Length == fields * 2)
                {

                }

            }


            // TODO: Return position.
        }

        /// <summary>
        /// Move relative single motor.
        /// </summary>
        /// <param name="azimuth"></param>
        /// <param name="declination"></param>
        public void SetPosition(double azimuth, double declination)
        {
            if (this.mbClient == null) return;

            // Scale
            int az = (int)(azimuth * 1);
            int dc = (int)(declination * 1);

            // Convert to ints
            int az1 = az >> 16;
            int az0 = az & 0x0000FFFF;
            int dc1 = dc >> 16;
            int dc0 = dc & 0x0000FFFF;

            // Create array.
            int[] values = new int[] { az0, az1, dc0, dc1 };

            // Send it over the network.
            this.mbClient.WriteMultipleRegisters(MemoryMap.MOTOR_POSITION, values);
        }

        public override void Reset()
        {
            if (this.mbClient == null) return;

            this.Disable();

            int[] result = mbClient.ReadHoldingRegisters(MemoryMap.DEVICE_STATE, 1);
            if(result != null)
            {
                if(result[0] == 0)
                {
                    this.IsReady = true;
                }
            }

            //mbClient.WriteSingleCoil(10, true);
            //int[] res0 = mbClient.ReadInputRegisters(0, 20);
            //mbClient.WriteSingleRegister(2, 5);
            //mbClient.WriteMultipleRegisters(2, new int[] { 5 });
        }

        #endregion

        #region Singelton

        public static Model1 GetDevice(string portName, int baudrate, byte slaveId)
        {
            if(device == null)
            {
                device = new Model1(portName, baudrate, slaveId);
            }

            return device;
        }

        #endregion
    }
}

