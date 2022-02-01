## Demo App ESP32 Starter Kit with NF

![BluinoNet](https://images.tokopedia.net/img/cache/900/VqbcmM/2021/3/21/91c34e84-ea68-4524-bc06-90e84c67463c.jpg)

This demo is using ESP 32 Starter Kit from Bluino Store [ESP32 Basic Shield](https://www.tokopedia.com/bluino/esp32-iot-starter-kit)

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

Enjoy and Cheers :D.

-BluinoNet Team from Buitenzorg Makers Club
