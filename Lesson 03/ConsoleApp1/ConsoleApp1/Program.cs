using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class IDataSource
    {
        public FileStream Stream { get; private set; }
        public IDataSource()
        {
            
        }

        public void Open(string path, FileMode mode, FileAccess access)
        {
            Stream = new FileStream(path, mode, access);
        }
        public void Close()
        {
            Stream?.Close();
        }
        public abstract void WriteData(string data);
        public abstract string ReadData();
    }

    class FileDataSource : IDataSource
    {
        public FileDataSource()
        {
        }

        public override string ReadData()
        {
            byte[] buff = new byte[100];
            Stream.Read(buff, 0, buff.Length);
            string data = Encoding.UTF8.GetString(buff);
            Console.WriteLine("Read:" + data);
            return data;
        }

        public override void WriteData(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            Stream.Write(bytes, 0, bytes.Length);
            Console.WriteLine("Write: " + data);
        }
    }

    class DataSourceDecorator : IDataSource
    {
        IDataSource _dataSource;

        public DataSourceDecorator(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public override string ReadData()
        {
            return _dataSource.ReadData();
        }

        public override void WriteData(string data)
        {
            _dataSource.WriteData(data);
        }
    }

    class CompressingDecorator : DataSourceDecorator
    {
        public CompressingDecorator(IDataSource dataSource) : base(dataSource)
        {
        }

        public override string ReadData()
        {
            string data = base.ReadData();
            Console.WriteLine("Decompressing");
            return data;
        }
        public override void WriteData(string data)
        {
            Console.WriteLine("Compressing");
            base.WriteData(data);
        }
    }

    class EncodingDecorator : DataSourceDecorator
    {
        public EncodingDecorator(IDataSource dataSource) : base(dataSource)
        {
        }

        public override string ReadData()
        {
            string data = base.ReadData();
            Console.WriteLine("Decoding...");
            return data;
        }
        public override void WriteData(string data)
        {
            Console.WriteLine("Encoding...");
            base.WriteData(data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //using(FileStream fs = new FileStream("file.txt", FileMode.Create, FileAccess.Write))
            //{
            //    string data = "Hello world";
            //    byte[] bytes = Encoding.UTF8.GetBytes(data);
            //    fs.Write(bytes, 0, bytes.Length);
            //}

            IDataSource fileDataSource = new FileDataSource();
            fileDataSource.Open("file.txt", FileMode.Create, FileAccess.Write);
            // fileDataSource.Open("file.txt", FileMode.Open, FileAccess.Read);
            fileDataSource = new CompressingDecorator(fileDataSource);
            fileDataSource = new EncodingDecorator(fileDataSource);

            fileDataSource.WriteData("Hello world");

            // fileDataSource.ReadData();
            fileDataSource.Close();

            Console.Read();
        }
    }
}
