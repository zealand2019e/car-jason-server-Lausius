using ModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Xml.Serialization;

namespace XmlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();
        }
    }

    public class Client
    {
        public void Start()
        {
            Car car = new Car { Model = "Tesla", Color = "Red", RegNo = "EL23400" };
            Car car2 = new Car { Model = "Volkswagen", Color = "Gray", RegNo = "AI20394" };
            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car2);
            AutoSale carDealer = new AutoSale { Name = "Kurt", Address = "Maglevej 29", CarList = carList };

            TcpClient clientSocket = new TcpClient("localhost", 20001);

            using (clientSocket)
            {
                Console.WriteLine("Server found");
                Stream ns = clientSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                // http://stackoverflow.com/questions/2434534/serialize-an-object-to-string
                XmlSerializer xmlSerailizer = new XmlSerializer(carDealer.GetType());
                string xmlString = "empty";
                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerailizer.Serialize(textWriter, carDealer);
                    xmlString = textWriter.ToString();
                    Console.WriteLine(xmlString);
                }
                sw.WriteLine(xmlString);
                //Console.WriteLine(sr.ReadLine());
            }
        }
    }
}
