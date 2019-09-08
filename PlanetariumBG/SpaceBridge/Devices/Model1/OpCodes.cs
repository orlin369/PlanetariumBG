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
using System.Linq;
using System.Text;

namespace SpaceBridge.Devices.Model1
{
    /** @brief Operation codes byte. */
    enum OpCodes : byte
    {
        Ping = 1, ///< Ping device.
        Stop, ///< Stop engines.
        Disable, ///< Disable engines.
        Enable, ///< Enable engines.
        Clear, ///< Clear robot position.
        MoveRelative, ///< Move to relative position.
        MoveAblolute, ///< Move to absolute position.
        DO, ///< Set digital port A value.
        DI, ///< Read digital port A value. 
        IsMoving, ///< Is robot is moveing?
        CurrentPosition, ///< Current robot position.
        MoveSpeed, ///< Move robot by speed parameter only.
        SetDeviceID, ///< Set robot ID.
        GetDeviceID, ///< Get robot ID.
        SaveGimblePosition, ///< Save current robot position.
        LoadGimblePosition, ///< Load current robot position.
        Compas,
        Ready,
    }
}
