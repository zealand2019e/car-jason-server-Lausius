using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Car car = new Car { Model="Tesla", Color="Red", RegNo="EL23400" };
            Car car2 = new Car { Model="Volkswagen", Color="Gray", RegNo="AI20394" };
            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car2);
            AutoSale carDealer = new AutoSale{Name = "Kurt", Address = "Maglevej 29", CarList = carList };

            TcpClient clientSocket = new TcpClient("localhost", 10001);

            using (clientSocket)
            {
                Console.WriteLine("Server found");
                Stream ns = clientSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                string carJasonString = JsonConvert.SerializeObject(carDealer);
                sw.WriteLine(carJasonString);
                Console.WriteLine(sr.ReadLine());
            }
        }
    }
}
