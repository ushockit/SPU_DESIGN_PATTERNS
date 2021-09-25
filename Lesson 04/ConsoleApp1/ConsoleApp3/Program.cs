using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    interface IStrategy
    {
        void Execute();
    }

    class CarStrategy : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Car...");
        }
    }

    class BusStrategy : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Bus strategy...");
        }
    }

    class Context
    {
        IStrategy _strategy;


        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void DoAction()
        {
            _strategy.Execute();
        }
    }

    class Product
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }
    }
    interface IProductFilterStrategy
    {
        bool Handle(Product product);
    }

    class RemoveNotActiveProductStrategy : IProductFilterStrategy
    {
        public bool Handle(Product product)
            => product.Active;
    }
    class RemoveQuantityZeroProductStrategy : IProductFilterStrategy
    {
        public bool Handle(Product product)
            => product.Quantity > 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Context ctx = new Context();
            //ctx.SetStrategy(new CarStrategy());


            //ctx.DoAction();

            //ctx.SetStrategy(new BusStrategy());
            //ctx.DoAction();

            var products = new List<Product>
            {
                new Product { Active = false, Quantity = 0 },
                new Product { Active = true, Quantity = 20 },
                new Product { Active = true, Quantity = 0 },
                new Product { Active = false, Quantity = 5 },
            };
            var strategies = new IProductFilterStrategy[]
            {
                new RemoveNotActiveProductStrategy(),
                new RemoveQuantityZeroProductStrategy()
            };

            var filteredProducts = products.Where(prod => strategies.All(s => s.Handle(prod))).ToList();
            ;


            Console.WriteLine("Hello World!");
        }
    }
}
