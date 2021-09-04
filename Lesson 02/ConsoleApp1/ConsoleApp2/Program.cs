using System;

namespace ConsoleApp2
{

    class XmlData
    {
        public string Xml { get; set; }
    }

    interface IFormatAdapter
    {
        string Adaptee();
    }

    class XmlToJsonAdapter : IFormatAdapter
    {
        readonly XmlData data;
        public XmlToJsonAdapter(XmlData data)
        {
            this.data = data;
        }

        public string Adaptee()
        {
            // TODO: Xml to Json
            // data.Xml
            Console.WriteLine($"Converting {data.Xml} to json...");
            return "{ json data ... }";
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            XmlData data = new XmlData { Xml = "<data>xml data</data>" };

            IFormatAdapter adapter = new XmlToJsonAdapter(data);
            string json = adapter.Adaptee();
            Console.WriteLine(json);



            Console.WriteLine("Hello World!");
        }
    }
}
