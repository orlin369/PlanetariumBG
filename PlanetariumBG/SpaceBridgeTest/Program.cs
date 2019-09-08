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

using SpaceBridge.Data;
using SpaceBridge.Devices.Model1;
using SpaceBridge.Events;
using System;

namespace SpaceBridgeTest
{
    class Program
    {
        private static Model1 device;
        static void Main(string[] args)
        {
            device = Model1.NewDevice("COM3");

            device.OnCompasChange += Device_OnCompasChange;
            device.OnConnect += Device_OnConnect;
            device.Connect();
            device.Reset();

            Console.WriteLine("Waiting for device...");
            while (!device.IsReady)
            {
                System.Threading.Thread.Sleep(1000);
            }

            device.Enable();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine("Time to exit.");

            device.Disconnect();
        }

        private static void Device_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Connected...");
        }

        private static void Device_OnCompasChange(object sender, EventArgsVector3 e)
        {
            Vector3 vector = e.Value;

            Console.WriteLine("Vector: {0}, {1}, {2}", vector.X, vector.Y, vector.Z);
        }
    }
}
