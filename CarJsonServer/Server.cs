using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CarJsonServer
{
    class Server
    {
        public void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 10001);
            serverSocket.Start();
            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server Activated");
                Stream ns = connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                var message = sr.ReadLine();
                Console.WriteLine("Json Serialized Car Object: " + message);
                Car deserializedCar = JsonConvert.DeserializeObject<Car>(message);
                Console.WriteLine("Deserialized Car Object: "+ deserializedCar);
            }
        }
    }
}
