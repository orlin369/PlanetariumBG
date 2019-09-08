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

#include "super.h"

/** @brief Send RAW request frame.
 *  @param opcode uint8_t, Operation code.
 *  @param frame uint8_t*, Command for this operation code.
 *  @param length const uint8_t, Length of the payload.
 *  @return Void.
 */
void send_raw_request(uint8_t opcode, uint8_t* payload, const uint8_t length) {

	const int FrameLengthL = length + FRAME_STATIC_FIELD_LENGTH + 1;

	uint8_t FrameL[(const int)FrameLengthL];

	FrameL[FrameIndexes::Sentinel] = FRAME_SENTINEL;
	FrameL[FrameIndexes::FrmType] = FrameType::Request;
	FrameL[FrameIndexes::Length] = length + 1;
	FrameL[FrameIndexes::OperationCode] = opcode;
	for (uint8_t index = 0; index < length; index++)
	{
		FrameL[index + FRAME_STATIC_FIELD_OFFSET] = payload[index];
	}

	uint8_t CRCL[FRAME_CRC_LEN] = { 0, 0 };
	calculate_CRC(FrameL, (uint8_t)(FrameLengthL - FRAME_CRC_LEN), CRCL);

	for (uint8_t index = 0; index < FRAME_CRC_LEN; index++)
	{
		uint8_t FrmaeIndexL = index + FRAME_STATIC_FIELD_OFFSET + length;
		FrameL[FrmaeIndexL] = CRCL[index];
	}

	COM_PORT.write(FrameL, FrameLengthL);
}

/** @brief Send RAW response frame.
 *  @param opcode uint8_t, Operation code.
 *  @param frame uint8_t*, Command for this operation code.
 *  @param length const uint8_t, Length of the payload.
 *  @return Void.
 */
void send_raw_response(uint8_t opcode, uint8_t status, uint8_t* payload, const uint8_t length) {

	const int FrameLengthL = length + FRAME_STATIC_FIELD_LENGTH + FRAME_RESPONSE_PAYLOAD_OFFSET;

	uint8_t FrameL[(const int)FrameLengthL];

	FrameL[FrameIndexes::Sentinel] = FRAME_SENTINEL;
	FrameL[FrameIndexes::FrmType] = FrameType::Response;
	FrameL[FrameIndexes::Length] = length + FRAME_RESPONSE_PAYLOAD_OFFSET;
	FrameL[FrameIndexes::OperationCode] = opcode;
	FrameL[FrameIndexes::StatusCode] = status;
	for (uint8_t index = 0; index < length; index++)
	{
		FrameL[index + FRAME_STATIC_FIELD_OFFSET + 1] = payload[index];
	}

	uint8_t CRCL[FRAME_CRC_LEN] = { 0, 0 };
	calculate_CRC(FrameL, (uint8_t)(FrameLengthL - FRAME_CRC_LEN), CRCL);

	for (uint8_t index = 0; index < FRAME_CRC_LEN; index++)
	{
		uint8_t FrmaeIndexL = index + FRAME_STATIC_FIELD_OFFSET + length + 1;
		FrameL[FrmaeIndexL] = CRCL[index];
	}

	COM_PORT.write(FrameL, FrameLengthL);
}

/** @brief Validate the incoming commands.
 *  @param frame The frame string.
 *  @return True if successful; or False if failed.
 */
bool validate_frame(uint8_t* frame, uint8_t length)
{
	// If frame is less the minimal lent of 6 directly exit.
	if (length < FRAME_MIN_LEN)
	{
		return false;
	}

	// If frame is less the minimal lent of 32 directly exit.
	if (length > FRAME_MAX_LEN)
	{
		return false;
	}

	// Check defined size.
	if (frame[FrameIndexes::Length] != (length - FRAME_STATIC_FIELD_LENGTH))
	{
		return false;
	}

	// Check sentinel value.
	if (frame[FrameIndexes::Sentinel] != FRAME_SENTINEL)
	{
		return false;
	}

	// Check request or response value.
	if ((frame[FrameIndexes::FrmType] != FrameType::Request) &&
		(frame[FrameIndexes::FrmType] != FrameType::Response))
	{
		return false;
	}

	if (validate_CRC(frame, length) == false)
	{
		return false;
	}

	return true;
}

/** @brief Validate the CRC.
 *  @param frame The frame string.
 *  @return True if successful; or False if failed.
 */
bool validate_CRC(uint8_t* frame, uint8_t length)
{
	uint8_t PayloadLen = length - FRAME_CRC_LEN;
	uint8_t CRCL[FRAME_CRC_LEN] = { 0, 0 };

	calculate_CRC(frame, PayloadLen, CRCL);

	// Check odd byte and even bytes.
	return (frame[PayloadLen] == CRCL[0]) && (frame[PayloadLen + 1] == CRCL[1]);
}

/** @brief Calculate the CRC.
 *  @param frame uint8_t *, The frame.
 *  @param length uint8_t, Length of the payload.
 *  @param out uint8_t *, CRC frame.
 *  @return Void
 */
void calculate_CRC(uint8_t* frame, uint8_t length, uint8_t* out)
{
	for (uint8_t index = 0; index < length; index++)
	{
		// Odd
		if ((index % 2 == 0))
		{
			// Sum all odd indexes.
			out[0] ^= frame[index];
		}
		// Even
		else
		{
			// Sum all even indexes.
			out[1] ^= frame[index];
		}
	}
}

/** @brief Extract the payload of the frame.
 *  @param frame String, Frame.
 *  @return Void.
 */
void get_payload(uint8_t* frame, uint8_t length, uint8_t* out)
{
	uint8_t EndIndexL = frame[FrameIndexes::Length] - 1;

	for (uint8_t index = 0; index < EndIndexL; index++)
	{
		out[index] = frame[index + FRAME_STATIC_FIELD_OFFSET];
	}
}

/** @brief Extract the payload of the frame.
 *  @param frame uint8_t *, Frame buffer.
 *  @param length uint8_t, Length of the frame.
 *  @return Void.
 */
void clear_frame(uint8_t* frame, uint8_t length)
{
	for (uint8_t index = 0; index < length; index++)
	{
		frame[index] = 0;
	}
}
