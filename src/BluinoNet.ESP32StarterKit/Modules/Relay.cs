using System;
using System.Device.Gpio;

namespace BluinoNet.Modules
{
    public class Relay
    {
        GpioPin _Relay;
        public Relay(int RelayPin)
        {
            var gpio = new GpioController();
            _Relay = gpio.OpenPin(RelayPin, PinMode.Output);
        }

        public void TurnOn()
        {
            _Relay.Write(PinValue.High);
        }
        public void Toggle()
        {
            var state = _Relay.Read();
            _Relay.Write(state == PinValue.High ? PinValue.Low : PinValue.High);
        }

        public void TurnOff()
        {
            _Relay.Write(PinValue.Low);
        }
    }
}
