using ConsoleApp1.Builder;
using ConsoleApp1.FactoryMethod;
using ConsoleApp1.Prototype;
using ConsoleApp1.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // -= Singleton =-
            //var storage = DataStorage.Instance;

            // -= Prototype =-
            //var person = new Person
            //{
            //    Id = 1,
            //    FirstName = "First name 1",
            //    LastName = "Last name 1",
            //    Birth = new DateTime(1990, 10, 10)
            //};

            //var person2 = person.Clone();

            //var person3 = person.Clone();


            // -= Builder =-
            //var builder = new HouseBuilder();

            //var house = builder.BuildDoors(2)
            //    .BuildWindows(4)
            //    .BuildGarage(new Garage { Height = 2.2, Width = 4.3, Length = 10 })
            //    .BuildPool(new Pool { Depth = 2, Length = 30, Width = 10 })
            //    .Build();

            // -= Factory method =-

            var account = new Account
            {
                Id = 1,
                Login = "vasya",
                Email = "vasya@gmail.com",
                Password = "123456",
                User = new User
                {
                    Id = 1,
                    FirstName = "Vasya",
                    LastName = "Pupkin"
                }
            };

            Console.WriteLine("Hello");
            Console.Read();
        }
    }
}
