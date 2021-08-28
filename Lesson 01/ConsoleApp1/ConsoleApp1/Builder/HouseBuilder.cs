using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Builder
{
    public class HouseBuilder : IHouseBuilder
    {
        House house;
        public HouseBuilder()
        {
            house = new House();
        }
        public House Build()
        {
            return house;
        }

        public IHouseBuilder BuildDoors(int count)
        {
            house.Doors = count;
            return this;
        }

        public IHouseBuilder BuildGarage(Garage garage)
        {
            house.Garage = garage;
            return this;
        }

        public IHouseBuilder BuildPool(Pool pool)
        {
            house.Pool = pool;
            return this;
        }

        public IHouseBuilder BuildRooms(int count)
        {
            house.Rooms = count;
            return this;
        }

        public IHouseBuilder BuildWindows(int count)
        {
            house.Windows = count;
            return this;
        }
    }
}
