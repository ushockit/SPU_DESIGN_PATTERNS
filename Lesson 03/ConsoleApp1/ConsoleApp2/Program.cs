using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    interface IDevice
    {
        void Enable();
        void Disable();
    }

    class TV : IDevice
    {
        public void Disable()
        {
            Console.WriteLine("TV Disabled");
        }

        public void Enable()
        {
            Console.WriteLine("TV Enabled");
        }
    }

    class Radio : IDevice
    {
        public void Disable()
        {
            Console.WriteLine("Radio Disabled");
        }

        public void Enable()
        {
            Console.WriteLine("Radion enabled");
        }
    }

    class Remote
    {
        IDevice _device;

        bool _power = false;

        public Remote(IDevice device)
        {
            _device = device;
        }

        public void TogglePower()
        {
            if (_power)
            {
                _device.Disable();
            }
            else
            {
                _device.Enable();
            }
            _power = !_power;
            Console.WriteLine("Do: " + (_power ? "On" : "Off"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Remote remote = new Remote(new Radio());

            remote.TogglePower();

            Console.Read();
        }
    }
}
