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

#pragma region Headers

#include "ApplicationConfiguration.h"
#include "Vector3.h"
#include "OpCodes.h"
#include "super.h"

#ifdef MAGSENSOR_HMC5883
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_HMC5883_U.h>
#endif
#ifdef MAGSENSOR_LSM303
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_LSM303_U.h>
#endif
#pragma endregion

#pragma region Prototypes

 /** @brief Prepare the memory.
  *  @return Void.
  */
void prepare_all_variables();

/** @brief Setup the communication port.
 *  @return Void.
 */
void setup_port();

/** @brief Read incoming commands.
 *  @return Void.
 */
void read_frame();

/** @brief Parse and execute the incoming commands.
 *  @param frame, uint8_t *, The frame array.
 *  @param length, uint8_t, The frame array length.
 *  @return Void.
 */
void parse_frame(uint8_t* frame, uint8_t length);

#pragma endregion

#pragma region Variables

/** @brief Pointer to frame buffer. */
static uint8_t* ptrFrameBuffer;

/** @brief Communication frame buffer. */
uint8_t FrameBuffer_g[FRAME_MAX_LEN];

/** @brief Payload request buffer. */
uint8_t PayloadRequest_g[FRAME_MAX_DATA_LEN];

/** @brief Payload response buffer. */
uint8_t PayloadResponse_g[FRAME_MAX_DATA_LEN];

/** @brief Will store last time that the bus was updated. */
unsigned long PreviousMillisCom_g;

unsigned long PreviousMillisUpdate_g;

/** @brief Will store current time that the bus is updated. */
unsigned long CurrentMillis_g;

Vector3Union MVUnion_g;

bool Enable_g;

sensors_event_t SeneorEvent_g;

#ifdef MAGSENSOR_HMC5883
/* Assign a unique ID to this sensor at the same time */
Adafruit_HMC5883_Unified mag = Adafruit_HMC5883_Unified(12345);
#endif
#ifdef MAGSENSOR_LSM303
/* Assign a unique ID to this sensor at the same time */
Adafruit_LSM303_Mag_Unified mag = Adafruit_LSM303_Mag_Unified(12345);
#endif

#pragma endregion

/** @brief Setup the peripheral hardware and variables.
 *  @return Void.
 */
void setup()
{
	prepare_all_variables();

	// Setup the communication port.
	setup_port();

	if (!mag.begin())
	{
		/* There was a problem detecting the HMC5883 ... check your connections */
		while (1);
	}

	delay(3000);

	send_raw_request(OpCodes::Ready, NULL, 0);
}

/** @brief Main loop of the program.
 *  @return Void.
 */
void loop()
{
	CurrentMillis_g = millis();

	if (CurrentMillis_g - PreviousMillisCom_g >= COM_UPDATE)
	{
		// Save the last time you updated the bus.
		PreviousMillisCom_g = CurrentMillis_g;

		// read frame form serial.
		read_frame();
	}

	if (CurrentMillis_g - PreviousMillisUpdate_g >= UPDATE_RATE && Enable_g)
	{
		// Save the last time you updated the bus.
		PreviousMillisUpdate_g = CurrentMillis_g;

		// Get a new sensor event.
		mag.getEvent(&SeneorEvent_g);

		// Set data.
		MVUnion_g.Value.x = SeneorEvent_g.magnetic.x;
		MVUnion_g.Value.y = SeneorEvent_g.magnetic.y;
		MVUnion_g.Value.z = SeneorEvent_g.magnetic.z;

		// Sent data.
		send_raw_request(OpCodes::Compas, MVUnion_g.Buffer, sizeof(Vector3_t));
	}
}

#pragma region Communication

/** @brief Prepare the memory.
 *  @return Void.
 */
void prepare_all_variables()
{
	PreviousMillisCom_g = 0;
	CurrentMillis_g = 0;
	Enable_g = true;
}

/** @brief Setup communication port.
 *  @return Void.
 */
void setup_port()
{
	// Set serial communication.
	COM_PORT.begin(COM_BAUDREATE);
	COM_PORT.setTimeout(COM_PORT_TIMEOUT);
}

/** @brief Read incoming commands.
 *  @return Void.
 */
void read_frame()
{
	static uint8_t TemporalDataLengthL = 0;
	static uint8_t CommStateL = CommState::fsSentinel;

	if (COM_PORT.available() < 1)
	{
		return;
	}

	byte InByteL = 0;
	while (COM_PORT.available() > 0)
	{
		InByteL = COM_PORT.read();

		switch (CommStateL)
		{
		case CommState::fsSentinel:
			if (InByteL == FRAME_SENTINEL)
			{
				FrameBuffer_g[FrameIndexes::Sentinel] = InByteL;
				//DEBUGLOG("fsSentinel -> fsRequestResponse\r\n");
				CommStateL = CommState::fsRequestResponse;
			}
			break;

		case CommState::fsRequestResponse:
			// Check request or response value.
			if ((InByteL == FrameType::Request) ||
				(InByteL == FrameType::Response))
			{
				FrameBuffer_g[FrameIndexes::FrmType] = InByteL;
				//DEBUGLOG("fsRequestResponse -> fsLength\r\n");
				CommStateL = CommState::fsLength;
			}
			else
			{
				//DEBUGLOG("fsRequestResponse -> fsSentinel\r\n");
				CommStateL = CommState::fsSentinel;
			}
			break;

		case CommState::fsLength:
			if ((InByteL >= 1) &&
				(InByteL <= 27))
			{
				FrameBuffer_g[FrameIndexes::Length] = InByteL;
				//DEBUGLOG("fsLength -> fsOperationCode\r\n");
				CommStateL = CommState::fsOperationCode;
			}
			else
			{
				//DEBUGLOG("fsLength -> fsSentinel\r\n");
				CommStateL = CommState::fsSentinel;
			}
			break;

		case CommState::fsOperationCode:
			FrameBuffer_g[FrameIndexes::OperationCode] = InByteL;
			if (FrameBuffer_g[FrameIndexes::Length] > 1)
			{
				TemporalDataLengthL = FrameBuffer_g[FrameIndexes::Length] - 1;
				//DEBUGLOG("fsOperationCode -> fsData\r\n");
				CommStateL = CommState::fsData;
			}
			else
			{
				TemporalDataLengthL = FRAME_CRC_LEN;
				//DEBUGLOG("fsOperationCode -> fsCRC\r\n");
				CommStateL = CommState::fsCRC;
			}
			ptrFrameBuffer = &FrameBuffer_g[FRAME_REQUEST_STATIC_FIELD_SIZE];
			break;

		case CommState::fsData:
			*ptrFrameBuffer++ = InByteL;
			if (--TemporalDataLengthL == 0)
			{
				TemporalDataLengthL = FRAME_CRC_LEN;
				//DEBUGLOG("fsData -> fsCRC\r\n");
				CommStateL = CommState::fsCRC;
			}
			break;

		case CommState::fsCRC:
			*ptrFrameBuffer++ = InByteL;
			if (--TemporalDataLengthL == 0)
			{
				//for (uint8_t index = 0; index < FrameBuffer_g[FrameIndexes::Length] + 5; index++)
				//{
				//	//DEBUGLOG("%02X ", FrameBuffer_g[index]);
				//}
				//DEBUGLOG("\r\n");

				if (validate_CRC(FrameBuffer_g, FrameBuffer_g[FrameIndexes::Length] + FRAME_REQUEST_STATIC_FIELD_SIZE - 1 + FRAME_CRC_LEN))
				{
					parse_frame(FrameBuffer_g, FrameBuffer_g[FrameIndexes::Length] + FRAME_REQUEST_STATIC_FIELD_SIZE - 1);
				}
				else
				{
					//DEBUGLOG("Invalid CRC\r\n");
				}

				CommStateL = CommState::fsSentinel;
			}
			break;

		default:
			break;
		}
	}
}

/** @brief Parse and execute the incoming commands.
 *  @param frame, uint8_t *, The frame array.
 *  @param length, uint8_t, The frame array length.
 *  @return Void.
 */
void parse_frame(uint8_t* frame, uint8_t length)
{
	if (frame[FrameIndexes::FrmType] == Request)
	{
		if (frame[FrameIndexes::OperationCode] == OpCodes::Ping)
		{
			get_payload(frame, length, PayloadRequest_g);

			send_raw_response(OpCodes::Ping, StatusCodes::Ok, PayloadRequest_g, frame[FrameIndexes::Length] - 1);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::Stop)
		{
			//stop_motors();

			send_raw_response(OpCodes::Stop, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::Disable)
		{
			Enable_g = false;

			send_raw_response(OpCodes::Disable, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::Enable)
		{
			Enable_g = true;

			send_raw_response(OpCodes::Enable, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::Clear)
		{
			//clear_motors();

			send_raw_response(OpCodes::Clear, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::MoveRelative)
		{
			//// If it is not enabled, do not execute.
			//if (MotorsEnabled_g == false)
			//{
			//	send_raw_response(OpCodes::MoveRelative, StatusCodes::Error, NULL, 0);
			//	return;
			//}
			//
			//// If it is move, do not execute the command.
			//if (MotorState_g != 0)
			//{
			//	PayloadResponse_g[0] = MotorState_g;
			//	send_raw_response(OpCodes::MoveRelative, StatusCodes::Busy, PayloadResponse_g, 1);
			//	return;
			//}
			//
			//// Extract motion data.
			//get_payload(frame, length, PayloadRequest_g);
			//
			//// TODO: Move to function.
			//JointPositionUnion Motion;
			//size_t DataLengthL = sizeof(JointPosition_t);
			//for (uint8_t index = 0; index < DataLengthL; index++)
			//{
			//	Motion.Buffer[index] = PayloadRequest_g[index];
			//}
			//
			//// Set motion data.
			//move_relative(Motion.Value);

			// Respond with success.
			send_raw_response(OpCodes::MoveRelative, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::MoveAblolute)
		{
			//// If it is not enabled, do not execute.
			//if (MotorsEnabled_g == false)
			//{
			//	// Respond with error.
			//	send_raw_response(OpCodes::MoveAblolute, StatusCodes::Error, NULL, 0);
			//
			//	// Exit
			//	return;
			//}
			//
			//// If it is move, do not execute the command.
			//if (MotorState_g != 0)
			//{
			//	PayloadResponse_g[0] = MotorState_g;
			//
			//	// Respond with busy.
			//	send_raw_response(OpCodes::MoveAblolute, StatusCodes::Busy, PayloadResponse_g, 1);
			//
			//	// Exit
			//	return;
			//}
			//
			//// Extract motion data.
			//// TODO: Move to function.
			//get_payload(frame, length, PayloadRequest_g);
			//JointPositionUnion Motion;
			//size_t DataLengthL = sizeof(JointPosition_t);
			//for (uint8_t index = 0; index < DataLengthL; index++)
			//{
			//	Motion.Buffer[index] = PayloadRequest_g[index];
			//}
			//
			//// Set motion data.
			//move_absolute(Motion.Value);

			// Respond with success.
			send_raw_response(OpCodes::MoveAblolute, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::DO)
		{
			// Extract port A data.
			get_payload(frame, length, PayloadRequest_g);

			// Set port A.
			//set_port_a(PayloadRequest_g[0]);

			// Respond with success.
			send_raw_response(OpCodes::DO, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::DI)
		{
			//PayloadResponse_g[0] = get_port_a();
			//DEBUGLOG("Payload: ");
			//DEBUGLOG(PayloadResponse_g[0]);
			//DEBUGLOG("\r\n");

			send_raw_response(OpCodes::DI, StatusCodes::Ok, PayloadResponse_g, 1);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::IsMoving)
		{
			//PayloadResponse_g[0] = MotorState_g;

			send_raw_response(OpCodes::IsMoving, StatusCodes::Ok, PayloadResponse_g, 1);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::CurrentPosition)
		{
			//CurrentPositions_g.Value = get_position();

			//send_raw_response(OpCodes::CurrentPosition, StatusCodes::Ok, CurrentPositions_g.Buffer, sizeof(JointPosition_t));
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::MoveSpeed)
		{
			//// If it is not enabled, do not execute.
			//if (MotorsEnabled_g == false)
			//{
			//	send_raw_response(OpCodes::MoveSpeed, StatusCodes::Error, NULL, 0);
			//	return;
			//}
			//
			//// Extract motion data.
			//get_payload(frame, length, PayloadRequest_g);
			//
			//// TODO: Move to function.
			//JointPositionUnion Motion;
			//uint8_t DataLengthL = frame[FrameIndexes::Length];
			//for (uint8_t index = 0; index < DataLengthL; index++)
			//{
			//	Motion.Buffer[index] = PayloadRequest_g[index];
			//}
			//
			//// Set motion data.
			//move_speed(Motion.Value);

			// Respond with success.
			send_raw_response(OpCodes::MoveSpeed, StatusCodes::Ok, NULL, 0);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::SetRobotID)
		{
			get_payload(frame, length, PayloadRequest_g);

			/*
			// TODO: Write to I2C EEPROM.
			for (uint8_t index = 0; index < DataLengthL; index++)
			{
				Motion.Buffer[index] = PayloadRequest_g[index];
			}
			*/

			send_raw_response(OpCodes::SetRobotID, StatusCodes::Ok, PayloadRequest_g, frame[FrameIndexes::Length] - 1);
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::GetRobotID)
		{

			/*
			// TODO: Read from I2C EEPROM.
			for (uint8_t index = 0; index < DataLengthL; index++)
			{
				PayloadRequest_g[index] = Motion.Buffer[index];
			}
			*/

			send_raw_response(OpCodes::GetRobotID, StatusCodes::Ok, PayloadRequest_g, frame[FrameIndexes::Length] - 1);
		}
	}
	else if (frame[FrameIndexes::FrmType] == FrameType::Response)
	{
		if (frame[FrameIndexes::OperationCode] == OpCodes::Ping)
		{
		}
		else if (frame[FrameIndexes::OperationCode] == OpCodes::Stop)
		{
		}
	}
}

#pragma endregion

