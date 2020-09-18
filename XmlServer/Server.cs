using ModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace XmlServer
{
    class Server
    {
        public void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 20001);
            serverSocket.Start();
            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server Activated");
                Stream ns = connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                var message = sr.ReadToEnd();
                Console.WriteLine(message);

                //http://stackoverflow.com/questions/2434534/serialize-an-object-to-string
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoSale));
                using (StringReader reader = new StringReader(message))
                {
                    AutoSale autoSaleCopy = (AutoSale)xmlSerializer.Deserialize(reader);
                    Console.WriteLine(autoSaleCopy);
                }
            }

        }
    }
}
