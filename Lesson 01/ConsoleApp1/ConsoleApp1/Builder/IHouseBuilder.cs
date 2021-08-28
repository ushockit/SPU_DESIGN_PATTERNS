using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Builder
{
    public interface IHouseBuilder
    {
        IHouseBuilder BuildWindows(int count);
        IHouseBuilder BuildDoors(int count);
        IHouseBuilder BuildRooms(int count);
        IHouseBuilder BuildPool(Pool pool);
        IHouseBuilder BuildGarage(Garage garage);
        House Build();
    }
}
