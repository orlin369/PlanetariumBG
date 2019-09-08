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

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SpaceBridge.Adapters;
using SpaceBridge.Data;
using SpaceBridge.Events;

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

        /// <summary>
        /// Comunication adapter.
        /// </summary>
        private Adapter adapter;

        /// <summary>
        /// Serialization handle.
        /// </summary>
        private GCHandle handle;

        /// <summary>
        /// Compas vector.
        /// </summary>
        private Vector3 compasVector;

        #endregion

        #region Events

        /// <summary>
        /// On connect event.
        /// </summary>
        public event EventHandler<EventArgs> OnConnect;

        /// <summary>
        /// On disconnect
        /// </summary>
        public event EventHandler<EventArgs> OnDisconnect;

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
        public Model1(Adapter adapter)
        {
            this.adapter = adapter;
            this.IsReady = false;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Model1()
        {
        }

        #endregion

        #region Public Overrider Methods

        /// <summary>
        /// Connect to the Robot.
        /// </summary>
        public override void Connect()
        {
            this.Disconnect();
            this.adapter.OnConnect += Adapter_OnConnect;
            this.adapter.OnMessage += Adapter_OnMessage;
            this.adapter.OnDisconnect += Adapter_OnDisconnect;
            this.adapter.Connect();            
        }



        /// <summary>
        /// Disconnect
        /// </summary>
        public override void Disconnect()
        {
            if (this.adapter == null || !this.adapter.IsConnected) return;



            this.adapter.Disconnect();
        }

        /// <summary>
        /// Enables the motor.
        /// </summary>
        /// <param name="joint">Index of the motor.</param>
        public override void Enable()
        {
            SendRawRequest(OpCodes.Enable);
        }

        /// <summary>
        /// Disable the motor.
        /// </summary>
        /// <param name="joint">Index of the motor.</param>
        public override void Disable()
        {
            SendRawRequest(OpCodes.Disable);
        }

        /// <summary>
        /// Read the motor state.
        /// </summary>
        public override void GetPosition()
        {

        }

        /// <summary>
        /// Move relative single motor.
        /// </summary>
        public override void SetPosition()
        {

        }

        public override void Reset()
        {
            if (this.adapter != null)
            {
                this.adapter.Reset();
            }
        }

        #endregion

        public static Model1 NewDevice(string portName)
        {
            System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort(portName, 115200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            SpaceBridge.Adapters.SerialAdapter adapter = new SpaceBridge.Adapters.SerialAdapter(port);
            return new Model1(adapter);
        }

        #region Private

        private void Adapter_OnConnect(object sender, EventArgs e)
        {
            this.OnConnect?.Invoke(sender, e);
        }

        private void Adapter_OnDisconnect(object sender, EventArgs e)
        {
            this.OnDisconnect?.Invoke(sender, e);
        }

        private void Adapter_OnMessage(object sender, EventArgsByte e)
        {
            this.ParseFrame(e.Value);
        }


        /** @brief Parse and execute the incoming commands.
         *  @param frame, uint8_t *, The frame array.
         *  @param length, uint8_t, The frame array length.
         *  @return Void.
         */
        void ParseFrame(byte[] frame)
        {
            if (frame[(int)FrameIndexes.FrmType] == (byte)FrameType.Request)
            {
                if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Ping)
                {

                   // SendRawResponse(OpCodes.Ping, StatusCodes.Ok, PayloadRequest_g, frame[FrameIndexes.Length] - 1);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Stop)
                {

                   // SendRawResponse(OpCodes.Stop, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Disable)
                {

                   // SendRawResponse(OpCodes.Disable, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Enable)
                {

                   // SendRawResponse(OpCodes.Enable, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Clear)
                {

                   // SendRawResponse(OpCodes.Clear, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.MoveRelative)
                {

                    // Respond with success.
                    //SendRawResponse(OpCodes.MoveRelative, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.MoveAblolute)
                {

                    // Respond with success.
                   // SendRawResponse(OpCodes.MoveAblolute, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.DO)
                {

                    // Respond with success.
                   // SendRawResponse(OpCodes.DO, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.DI)
                {

                    //SendRawResponse(OpCodes.DI, StatusCodes.Ok, PayloadResponse_g, 1);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.IsMoving)
                {

                    //SendRawResponse(OpCodes.IsMoving, StatusCodes.Ok, PayloadResponse_g, 1);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.CurrentPosition)
                {

                    //SendRawResponse(OpCodes.CurrentPosition, StatusCodes.Ok, CurrentPositions_g.Buffer, sizeof(JointPosition_t));
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.MoveSpeed)
                {

                    // Respond with success.
                    //SendRawResponse(OpCodes.MoveSpeed, StatusCodes.Ok, NULL, 0);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.SetDeviceID)
                {

                    //SendRawResponse(OpCodes.SetRobotID, StatusCodes.Ok, PayloadRequest_g, frame[FrameIndexes.Length] - 1);
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.GetDeviceID)
                {
                    byte[] PayloadRequest_g = new byte[8];

                    SendRawResponse(OpCodes.GetDeviceID, StatusCodes.Ok, PayloadRequest_g);
                }
                else if(frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Compas)
                {
                    byte[] buff = GetPayload(frame);

                    if(buff == null)
                    {
                        SendRawResponse(OpCodes.Compas, StatusCodes.Error, null);
                        return;
                    }

                    handle = GCHandle.Alloc(buff, GCHandleType.Pinned);

                    compasVector = (Vector3)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Vector3));

                    handle.Free();

                    this.OnCompasChange?.Invoke(this, new EventArgsVector3(compasVector));

                    SendRawResponse(OpCodes.Compas, StatusCodes.Ok, null);
                }
                else if(frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Ready)
                {
                    this.IsReady = true;
                    this.OnReady?.Invoke(this, new EventArgs());
                }
            }
            else if (frame[(int)FrameIndexes.FrmType] == (byte)FrameType.Response)
            {
                if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Ping)
                {
                }
                else if (frame[(int)FrameIndexes.OperationCode] == (byte)OpCodes.Stop)
                {
                }
            }
        }

        private void SendRawResponse(OpCodes opcode, StatusCodes statusCode, byte[] data)
        {
            List<byte> command = new List<byte>();
            command.Add(SENTINEL);
            command.Add((byte)FrameType.Response);
            if(data == null)
            {
                command.Add(1);
            }
            else
            {
                command.Add((byte)(data.Length + FRAME_RESPONSE_PAYLOAD_OFFSET));
            }
            command.Add((byte)opcode);
            command.Add((byte)statusCode);
            if (data != null)
            {
                foreach (byte b in data)
                {
                    command.Add(b);
                }
            }
            byte[] crc = CalculateCRC(command.ToArray());
            foreach (byte b in crc)
            {
                command.Add(b);
            }

            this.adapter.SendRequest(command.ToArray());
        }

        private void SendRawRequest(OpCodes opcode, byte[] data = null)
        {
            List<byte> command = new List<byte>();
            command.Add(SENTINEL);
            command.Add((byte)FrameType.Request);
            if (data == null)
            {
                command.Add(1);
            }
            else
            {
                command.Add((byte)(data.Length + FRAME_RESPONSE_PAYLOAD_OFFSET));
            }
            command.Add((byte)opcode);
            if(data != null)
            {
                foreach (byte b in data)
                {
                    command.Add(b);
                }
            }
            byte[] crc = CalculateCRC(command.ToArray());
            foreach (byte b in crc)
            {
                command.Add(b);
            }

            this.adapter.SendRequest(command.ToArray());
        }

        /** @brief Calculate the CRC.
         *  @param frame uint8_t *, The frame.
         *  @param length uint8_t, Length of the payload.
         *  @param out uint8_t *, CRC frame.
         *  @return Void
         */
        private byte[] CalculateCRC(byte[] frame)
        {
            byte[] result = new byte[2];

            for (int index = 0; index < frame.Length; index++)
            {
                // Odd
                if ((index % 2 == 0))
                {
                    // Sum all odd indexes.
                    result[0] ^= frame[index];
		        }
		        // Even
		        else
		        {
                    // Sum all even indexes.
                    result[1] ^= frame[index];
                }
            }

            return result;
        }

        private byte[] GetPayload(byte[] frame)
        {
            List<byte> content = new List<byte>();
            int beginIndex = 0;
            int endIndex = frame[(int)FrameIndexes.Length] - 1;

            for (int index = beginIndex; index < endIndex; index++)
            {
                content.Add(frame[index + FRAME_STATIC_FIELD_OFFSET]);
            }

            return content.ToArray();
        }

        #endregion

    }
}

