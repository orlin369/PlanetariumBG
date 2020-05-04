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


#include <ModbusSlave.h>
#include "ApplicationConfiguration.h"
#include "Vector3.h"

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

#include <AccelStepper.h>

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

/**
 *  Modbus object declaration
 */
Modbus ModbusSlave_g(COM_SLAVE_ID, COM_CTRL_PIN);


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
Adafruit_HMC5883_Unified MagnitoSensor_g = Adafruit_HMC5883_Unified(12345);
#endif
#ifdef MAGSENSOR_LSM303
/* Assign a unique ID to this sensor at the same time */
Adafruit_LSM303_Mag_Unified MagnitoSensor_g = Adafruit_LSM303_Mag_Unified(12345);
#endif

AccelStepper AzimuthMotor(AccelStepper::FULL4WIRE, AZM_PIN_1, AZM_PIN_2, AZM_PIN_3, AZM_PIN_4, AZM_ENABLED);
AccelStepper DeclinationMotor(AccelStepper::FULL4WIRE, DCM_PIN_1, DCM_PIN_2, DCM_PIN_3, DCM_PIN_4, AZM_ENABLED);

#pragma endregion

/** @brief Setup the peripheral hardware and variables.
 *  @return Void.
 */
void setup()
{
	prepare_all_variables();

	// Setup the communication port.
	setup_port();

#ifdef MAGSENSOR_HMC5883 || MAGSENSOR_LSM303
	if (!MagnitoSensor_g.begin())
	{
		// There was a problem detecting the HMC5883 ... check your connections.
		while (1);
	}
#endif // MAGSENSOR_HMC5883 || MAGSENSOR_LSM303

}

/** @brief Main loop of the program.
 *  @return Void.
 */
void loop()
{
	CurrentMillis_g = millis();

	if (CurrentMillis_g - PreviousMillisUpdate_g >= UPDATE_RATE && Enable_g)
	{
		// Save the last time you updated the bus.
		PreviousMillisUpdate_g = CurrentMillis_g;

#ifdef MAGSENSOR_HMC5883 || MAGSENSOR_LSM303
		// Get a new sensor event.
		MagnitoSensor_g.getEvent(&SeneorEvent_g);

		// Set data.
		MVUnion_g.Value.x = SeneorEvent_g.magnetic.x;
		MVUnion_g.Value.y = SeneorEvent_g.magnetic.y;
		MVUnion_g.Value.z = SeneorEvent_g.magnetic.z;
#endif // MAGSENSOR_HMC5883 || MAGSENSOR_LSM303
	}

	/* listen for modbus commands con serial port
	 *
	 * on a request, handle the request.
	 * if the request has a user handler function registered in cbVector
	 * call the user handler function.
	 */
	ModbusSlave_g.poll();

	// Update motors.
	AzimuthMotor.run();
	DeclinationMotor.run();
}

#pragma region Functions

void prepare_motors()
{
	AzimuthMotor.setMaxSpeed(200.0);
	AzimuthMotor.setAcceleration(100.0);
	AzimuthMotor.moveTo(24);

	DeclinationMotor.setMaxSpeed(300.0);
	DeclinationMotor.setAcceleration(100.0);
	DeclinationMotor.moveTo(1000000);
}

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
	/* register handler functions
	 * into the modbus ModbusSlave_g callback vector.
	 */
	ModbusSlave_g.cbVector[CB_WRITE_COILS] = write_coils;
	ModbusSlave_g.cbVector[CB_READ_DISCRETE_INPUTS] = read_discrete_inputs;
	ModbusSlave_g.cbVector[CB_READ_INPUT_REGISTERS] = read_input_registers;
	ModbusSlave_g.cbVector[CB_READ_HOLDING_REGISTERS] = read_holding_registers;
	ModbusSlave_g.cbVector[CB_WRITE_HOLDING_REGISTERS] = write_holding_registers;

	// set Serial and ModbusSlave_g at baud 9600.
	Serial.begin(COM_BAUDREATE);
	ModbusSlave_g.begin(COM_BAUDREATE);
}

uint8_t read_holding_registers(uint8_t fc, uint16_t address, uint16_t length)
{
	ModbusSlave_g.writeRegisterToBuffer(address, 0);
	return STATUS_OK;
}

uint8_t write_holding_registers(uint8_t fc, uint16_t address, uint16_t length)
{
	
	return STATUS_OK;
}

/**
 * Handle Force Single Coil (FC=05) and Force Multiple Coils (FC=15)
 * set digital output pins (coils).
 */
uint8_t write_coils(uint8_t fc, uint16_t address, uint16_t length) {
	// set digital pin state(s).
	for (int i = 0; i < length; i++) {
		digitalWrite(address + i, ModbusSlave_g.readCoilFromBuffer(i));
	}

	return STATUS_OK;
}

/**
 * Handel Read Input Status (FC=02)
 * write back the values from digital in pins (input status).
 *
 * handler functions must return void and take:
 *      uint8_t  fc - function code
 *      uint16_t address - first register/coil address
 *      uint16_t length/status - length of data / coil status
 */
uint8_t read_discrete_inputs(uint8_t fc, uint16_t address, uint16_t length) {
	// read digital input
	for (int i = 0; i < length; i++) {
		ModbusSlave_g.writeCoilToBuffer(i, digitalRead(address + i));
	}

	return STATUS_OK;
}

/**
 * Handel Read Input Registers (FC=04)
 * write back the values from analog in pins (input registers).
 */
uint8_t read_input_registers(uint8_t fc, uint16_t address, uint16_t length)
{
	if (address >= 0 && address <= 3)
	{
		uint16_t RegisterValueL = 0;

		RegisterValueL = MVUnion_g.Buffer[address] | MVUnion_g.Buffer[address + 1] << 8;

		ModbusSlave_g.writeRegisterToBuffer(address, RegisterValueL);
	}

	return STATUS_OK;
}

#pragma endregion
