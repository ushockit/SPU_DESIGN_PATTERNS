using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Singleton
{
    public class DataStorage
    {
        static DataStorage instance;
        public static DataStorage Instance => instance ?? (instance = new DataStorage());
        //static DataStorage instance = new DataStorage();
        //public static DataStorage Instance => instance;
        private DataStorage() 
        {
            Console.WriteLine("Create DataStorage");
        }
    }
}
