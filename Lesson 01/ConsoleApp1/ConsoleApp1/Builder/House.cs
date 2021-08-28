using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Builder
{
    public class House
    {
        public int Doors { get; set; }
        public int Windows { get; set; }
        public int Rooms { get; set; }
        public Pool Pool { get; set; }
        public Garage Garage { get; set; }
    }
}
