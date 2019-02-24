using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPSender
{
    class Program
    {
        private static readonly BlockingCollection<int> _bCollection = new BlockingCollection<int>(boundedCapacity: 2);
        private static readonly Random rnd = new Random();
        private static readonly UdpClient _udpClient = new UdpClient();
        static void Main(string[] args)
        {
            var num = 0;
            while (true)
            {
                num++;
                //var rndNumber = rnd.Next(1, 10);
                Console.WriteLine($"Adding {num} to collection...");                
                //_bCollection.Add(rndNumber);
                var payload = Encoding.UTF8.GetBytes(num.ToString());
                _udpClient.SendAsync(payload, payload.Length, "127.0.0.1", 6000);

                Thread.Sleep(1);
            }
        }
    }
}
