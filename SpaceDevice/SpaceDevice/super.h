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



#ifndef _SUPER_h
#define _SUPER_h

#pragma region Headers

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

#pragma endregion

#pragma region Definitions

/** @brief Communication port. */
#define COM_PORT Serial

/** @brief Communication port speed. */
#define COM_BAUDREATE 115200

/** @brief Communication port update rate. */
#define COM_UPDATE 100

/** @brief Communication port time out response time. */
#define COM_PORT_TIMEOUT 20

/** @brief Minimum frame length. */
#define FRAME_MIN_LEN 6

/** @brief Maximum frame length. */
#define FRAME_MAX_LEN 32

/** @brief Frame data size. */
#define FRAME_MAX_DATA_LEN 26

/** @brief Length of the CRC. */
#define FRAME_CRC_LEN 2

/** @brief Number 5 stand of sum of length of static size fields;
 * 1 - Start
 * 1 - Request / Response
 * 1 - Length
 * 2 - CRC
 */
#define FRAME_STATIC_FIELD_LENGTH 5

 /** @brief Static frame field offset. */
#define FRAME_STATIC_FIELD_OFFSET 4

/** @brief Frame sentinel. */
#define FRAME_SENTINEL 0xAA

/** @brief Payload response offset value. */
#define FRAME_RESPONSE_PAYLOAD_OFFSET 2

/** @brief Number 4 stand of sum of Sentinel, Req/Res, Length, Operation Code;
 * 1 - Start
 * 1 - Request / Response
 * 1 - Length
 * 1 - OpCode
 */
#define FRAME_REQUEST_STATIC_FIELD_SIZE 4


#pragma endregion

#pragma region Enums

 /** @brief Communication state machine states. */
enum CommState : uint8_t
{
	fsSentinel = 0U, ///< Beginning byte.
	fsRequestResponse, ///< Request / Response byte.
	fsLength, ///< Length of the frame byte.
	fsOperationCode,  ///< Operation Code byte.
	fsData, //< Data part.
	fsCRC, ///< CRC state.
};

/** @brief Frame indexes. */
enum FrameIndexes : uint8_t
{
	Sentinel = 0U, ///< Sentinel byte.
	FrmType, ///< Request / Response byte.
	Length, ///< Length of the frame.
	OperationCode,  ///< Operation Code byte.
	StatusCode  ///< Status Code byte.
};

/** @brief Request / Response types. */
enum FrameType : uint8_t
{
	Request = 1U, ///< Request.
	Response, ///< Response.
};

/** @brief Status codes types. */
enum StatusCodes : uint8_t
{
	Ok = 1U, ///< When everything is OK.
	Error, ///< When error occurred.
	Busy, ///< When busy in other operation.
	TimeOut ///< Then time for the operation has timed out.
};

#pragma endregion

#pragma region Prototypes

/** @brief Send RAW request frame.
 *  @param opcode uint8_t, Operation code.
 *  @param frame uint8_t*, Command for this operation code.
 *  @param length const uint8_t, Length of the payload.
 *  @return Void.
 */
void send_raw_request(uint8_t opcode, uint8_t* payload, const uint8_t length);

/** @brief Send RAW response frame.
 *  @param opcode uint8_t, Operation code.
 *  @param frame uint8_t*, Command for this operation code.
 *  @param length const uint8_t, Length of the payload.
 *  @return Void.
 */
void send_raw_response(uint8_t opcode, uint8_t status, uint8_t* payload, const uint8_t length);

/** @brief Validate the incoming commands.
 *  @param frame The frame string.
 *  @return True if successful; or False if failed.
 */
bool validate_frame(uint8_t* frame, uint8_t length);

/** @brief Validate the CRC.
 *  @param frame The frame string.
 *  @return True if successful; or False if failed.
 */
bool validate_CRC(uint8_t* frame, uint8_t length);

/** @brief Calculate the CRC.
 *  @param frame uint8_t *, The frame.
 *  @param length uint8_t, Length of the payload.
 *  @param out uint8_t *, CRC frame.
 *  @return Void
 */
void calculate_CRC(uint8_t* frame, uint8_t length, uint8_t* out);

/** @brief Extract the payload of the frame.
 *  @param frame String, Frame.
 *  @return Void.
 */
void get_payload(uint8_t* frame, uint8_t length, uint8_t* out);

/** @brief Extract the payload of the frame.
 *  @param frame uint8_t *, Frame buffer.
 *  @param length uint8_t, Length of the frame.
 *  @return Void.
 */
void clear_frame(uint8_t* frame, uint8_t length);

#pragma endregion

#endif

