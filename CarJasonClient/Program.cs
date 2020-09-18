using ModelLib;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CarJasonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Client client = new Client();
            client.Start();
        }
    }

    public class Client
    {
        public void Start()
        {
            Car car = new Car("Tesla", "Red", "EL23400");
            TcpClient clientSocket = new TcpClient("localhost", 10001);

            using (clientSocket)
            {
                Console.WriteLine("Server found");
                Stream ns = clientSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                string carJasonString = JsonConvert.SerializeObject(car);
                sw.WriteLine(carJasonString);
                Console.WriteLine(sr.ReadLine());
            }
        }
    }
}
