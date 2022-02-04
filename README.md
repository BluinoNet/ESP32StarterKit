## Demo App ESP32 Starter Kit with NF

![BluinoNet](https://images.tokopedia.net/img/cache/900/VqbcmM/2021/3/21/91c34e84-ea68-4524-bc06-90e84c67463c.jpg)

This demo is using ESP 32 Starter Kit from Bluino Store [ESP32 Starter Kit](https://www.tokopedia.com/bluino/esp32-iot-starter-kit)

.NET nanoFramework is a free and open-source platform that enables the writing of managed code applications for constrained embedded devices.

ESP32 is supported by NF. This repo contains driver and demo for this shield. Follow this instruction to get started:

### Install Dotnet

Follow this instruction: [Install Dotnet](https://dotnet.microsoft.com/en-us/download)

### Install Visual Studio

Get Editor: [Install Visual Studio](https://visualstudio.microsoft.com/downloads/)

### Install NanoFramework

Grab and install NF extension for VS [Install Extension NF](https://marketplace.visualstudio.com/items?itemName=nanoframework.nanoFramework-VS2019-Extension)

### Install Nano Flasher

open command line and type
```
dotnet tool install -g nanoff
```

### Flash NanoFramework to your device

Follow this instruction: [Flash NanoFramework to ESP32](https://github.com/nanoframework/nanoFirmwareFlasher)

open command line and type
```
nanoff --platform esp32 --update --serialport COM12
```
Note: COM12 can be replaced with the correct port of your ESP32 USB Serial Port

### Clone this repo

Download or clone this repo from command line 
```
git clone https://github.com/BluinoNet/ESP32StarterKit
```

### Open Project

Open solution with visual studio (BluinoNet.ESP32BasicShield.sln), set "DemoESP32BasicShield" as startup project then run (F5)

### Some Sample Codes

## Init board

```
static ESP32StarterKit board = board = new ESP32StarterKit();
```

## LED
```
board.SetupLed(ESP32Pins.IO23, ESP32Pins.IO02, ESP32Pins.IO04, ESP32Pins.IO05);
            while (true)
            {
                board.BoardLed1.TurnOn();
                Thread.Sleep(200);
                board.BoardLed1.TurnOff();
                Thread.Sleep(200);
                board.BoardLed2.TurnOn();
                Thread.Sleep(200);
                board.BoardLed2.TurnOff();
                Thread.Sleep(200);
                board.BoardLed3.TurnOn();
                Thread.Sleep(200);
                board.BoardLed3.TurnOff();
                Thread.Sleep(200);
                board.BoardLed4.TurnOn();
                Thread.Sleep(200);
                board.BoardLed4.TurnOff();
                Thread.Sleep(200);
            }
```

## Button and RGB LED
```
board.SetupButton(ESP32Pins.IO12, ESP32Pins.IO14);
            board.SetupLedRgb(ESP32Pins.IO02, ESP32Pins.IO04, ESP32Pins.IO05);
            Random rnd = new Random();
            board.BoardButton1.ButtonReleased += (a, b) => {

                board.BoardLedRgb.SetColorRGB(rnd.Next(1,255), rnd.Next(1, 255), rnd.Next(1, 255));
            };
```

## Display
```
board.SetupDisplay();
            var basicGfx = board.BoardDisplay;
            var colorBlue = BasicGraphics.ColorFromRgb(0, 0, 255);
            var colorGreen = BasicGraphics.ColorFromRgb(0, 255, 0);
            var colorRed = BasicGraphics.ColorFromRgb(255, 0, 0);
            //var colorWhite = BasicGraphics.ColorFromRgb(255, 255, 255);

            basicGfx.Clear();
            basicGfx.DrawString("BluinoNet", colorGreen, 1, 1, 1, 1);
            basicGfx.DrawString("Kick Ass", colorBlue, 1, 20, 1, 1);
            basicGfx.DrawString("--By BMC--", colorRed, 1, 40, 1, 1);

            Random color = new Random();
            for (var i = 10; i < 100; i++)
                basicGfx.DrawCircle((uint)color.Next(), i, 60, 2);

            basicGfx.Flush();

            Thread.Sleep(3000);
            //bounching balls demo
            var balls = new BouncingBalls(basicGfx);
            Thread.Sleep(Timeout.Infinite);
```

## BMP 180
```
board.SetupBMP180();
            board.SetupDisplay();
            var colorB = BasicGraphics.ColorFromRgb(255, 255, 255);
            var screen = board.BoardDisplay;

            while (true)
            {

                screen.Clear();
                screen.DrawString("Temperature", colorB, 0, 1, 1, 1);
                screen.DrawString($"{board.BoardBMP180.ReadTemperature().ToString("n2")} C", colorB, 0, 6, 2, 2);
                screen.DrawString("Pressure", colorB, 0, 30, 1, 1);
                screen.DrawString($"{board.BoardBMP180.ReadPressure().ToString("n2")} atm", colorB, 0, 20, 2, 2);
                screen.Flush();
                Thread.Sleep(2000);

                screen.Clear();
                screen.DrawString("Altitude", colorB, 0, 1, 1, 1);
                screen.DrawString($"{board.BoardBMP180.ReadAltitude().ToString("n2")} m", colorB, 0, 6, 2, 2);
                screen.DrawString("Sea Level Pres.", colorB, 0, 30, 1, 1);
                screen.DrawString($"{board.BoardBMP180.ReadSeaLevelPressure().ToString("n2")} atm", colorB, 0, 20, 2, 2);
                screen.Flush();
                Thread.Sleep(2000);
            }
```

## Buzzer
```
board.SetupBuzzer(ESP32Pins.IO23);
            board.SetupButton(ESP32Pins.IO12, ESP32Pins.IO14);
            board.SetupRelay(ESP32Pins.IO22);

            board.BoardButton1.ButtonReleased += (a, b) => {
                PlaySound();
            };
            board.BoardButton2.ButtonReleased += (a, b) =>
            {
                board.BoardRelay.Toggle();
            };
```

## LDR and PIR
```
board.SetupDisplay();
            board.SetupLightSensor(ESP32Pins.IO36, 0, ESP32ADCs.ADC0); // see https://docs.nanoframework.net/content/esp32/esp32_pin_out.html
            board.SetupPIR(ESP32Pins.IO22);
            var colorB = BasicGraphics.ColorFromRgb(255, 255, 255);
            var screen = board.BoardDisplay;
            board.BoardPIR.MotionCaptured += (x,e) => {
                Debug.WriteLine("motion detected");
            };
            while (true)
            {

                screen.Clear();
                screen.DrawString("Light", colorB, 0, 1, 1, 1);
                screen.DrawString($"{board.BoardLightSensor.GetIlluminance().ToString("n2")} Lux", colorB, 0, 6, 2, 2);
                screen.DrawString("PIR", colorB, 0, 30, 1, 1);
                screen.DrawString($"MOVEMENT: {board.BoardPIR.IsCaptureMovement}", colorB, 0, 20, 2, 2);
                screen.Flush();
                Thread.Sleep(500);

            }
```

## MPU 6050
```
board.SetupMpu6050();
            board.SetupDisplay();
            var colorB = BasicGraphics.ColorFromRgb(255, 255, 255);
            var screen = board.BoardDisplay;
            board.BoardMpu6050.StartUpdating();
            board.BoardMpu6050.SensorInterruptEvent += (a, e) => {
                screen.Clear();
                for (int i = 0; i < e.Values.Length; i++)
                {
                    screen.DrawString("ACCEL", colorB, 0, 1, 1, 1);
                    screen.DrawString($"{e.Values[i].AccelerationX.ToString("n3")},{e.Values[i].AccelerationY.ToString("n3")},{e.Values[i].AccelerationZ.ToString("n3")} ", colorB, 0, 10, 1, 1);

                    screen.DrawString("GYRO", colorB, 0, 25, 1, 1);
                    screen.DrawString($"{e.Values[i].GyroX.ToString("n3")},{e.Values[i].GyroY.ToString("n3")},{e.Values[i].GyroZ.ToString("n3")} ", colorB, 0, 35, 1, 1);
                    break;
                }
                screen.Flush();
            };
```

## DS18B20
```
board.SetupDS18B20(ESP32Pins.IO15);
            board.SetupDisplay();
            var colorB = BasicGraphics.ColorFromRgb(255, 255, 255);
            var screen = board.BoardDisplay;

            while (true)
            {
                board.BoardDS18B20.Update();
                screen.Clear();
                screen.DrawString("Temperature", colorB, 0, 1, 1, 1);
                screen.DrawString($"{board.BoardDS18B20.Temperature.ToString("n2")} C", colorB, 0, 6, 2, 2);
                screen.Flush();
                Thread.Sleep(2000);
            }
```

## Potensiometer
```
board.SetupDisplay();
            board.SetupPotentiometer(ESP32Pins.IO36, 0, ESP32ADCs.ADC0); // see https://docs.nanoframework.net/content/esp32/esp32_pin_out.html
            var colorB = BasicGraphics.ColorFromRgb(255, 255, 255);
            var screen = board.BoardDisplay;
            while (true)
            {

                screen.Clear();
                screen.DrawString("Potensiometer value", colorB, 0, 1, 1, 1);
                screen.DrawString($"{board.BoardPotentiometer.ReadProportion().ToString("n2")}", colorB, 0, 6, 2, 2);
                screen.Flush();
                Thread.Sleep(500);

            }
```

## MicroSD
```
MicroSd.SetupMicroSd(ESP32Pins.IO13);
            MicroSd.MountDrive();
            MicroSd.CreateFile("/text2.txt", "123qwe");
            MicroSd.CreateDirectory("/data/file/");
            MicroSd.RenameFile("/text2.txt", "/text1.txt");
            var contents = MicroSd.ListDirectory();
```

## HCSR04
```
board.SetupHCSR04(ESP32Pins.IO13,ESP32Pins.IO12);
            board.SetupDisplay();
            var colorB = BasicGraphics.ColorFromRgb(255, 255, 255);
            var screen = board.BoardDisplay;

            while (true)
            {
                screen.Clear();
                screen.DrawString("Distance", colorB, 0, 1, 1, 1);
                screen.DrawString($"{board.BoardHCSR04.CurrentDistance.ToString("n2")}", colorB, 0, 6, 2, 2);
                screen.Flush();
                Thread.Sleep(2000);
            }
```


Enjoy and Cheers :D.

-BluinoNet Team from Buitenzorg Makers Club
