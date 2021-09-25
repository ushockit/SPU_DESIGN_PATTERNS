using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Cache<T> where T : class
    {
        Dictionary<string, T> cache = new Dictionary<string, T>();

        public void Add(string key, T value)
        {
            cache.Add(key, value);
        }

        public T Get(string key, T defaultValue = default)
        {
            return cache.GetValueOrDefault(key, defaultValue);
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Cache<object> cache = new Cache<object>();

            var person = new Person { FirstName = "Vasya", LastName = "Pupkin" };


            var cacheValue = cache.Get("person");
            
            if (cacheValue is null)
            {
                cache.Add("person", person);
            }
             




            Console.Read();
        }
    }
}
