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

// ApplicationConfiguration.h

#ifndef _APPLICATIONCONFIGURATION_h
#define _APPLICATIONCONFIGURATION_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

/* slave id = 1, rs485 control-pin = 8, baud = 9600
 */
#define COM_SLAVE_ID 1
#define COM_CTRL_PIN 8
#define COM_BAUDREATE 9600


#define UPDATE_RATE 100

//#define MAGSENSOR_HMC5883
#define MAGSENSOR_LSM303

#define AZM_ENABLED true
#define AZM_PIN_1 2
#define AZM_PIN_2 3
#define AZM_PIN_3 4
#define AZM_PIN_4 5

#define DCM_ENABLED true
#define DCM_PIN_1 6
#define DCM_PIN_2 7
#define DCM_PIN_3 8
#define DCM_PIN_4 9

#endif

