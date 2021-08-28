using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Prototype
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}
