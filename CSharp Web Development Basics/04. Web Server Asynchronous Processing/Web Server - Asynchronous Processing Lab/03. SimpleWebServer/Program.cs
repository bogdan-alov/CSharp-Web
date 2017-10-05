﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _03._SimpleWebServer
{
	class Program
	{
		static void Main(string[] args)
		{
			int port = 8000;
			IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

			TcpListener listener = new TcpListener(ipAddress, port);
			listener.Start();

			Console.WriteLine("Server started.");
			Console.WriteLine("Listening to TCP clients at 127.0.0.1:8000");
			var task = Task.Run(() => ConnectWithTcpClient(listener));
			task.Wait();

		}

		private static async Task ConnectWithTcpClient(TcpListener listener)
		{
			while (true)
			{
				Console.WriteLine("Waiting for client...");
				var client = await listener.AcceptTcpClientAsync();

				Console.WriteLine("Client connected.");

				var buffer = new byte[1024];
				client.GetStream().Read(buffer, 0, buffer.Length);

				var message = Encoding.ASCII.GetString(buffer);
				Console.WriteLine(message);

				var data = Encoding.ASCII.GetBytes("Hello from server!");
				client.GetStream().Write(data, 0, data.Length);

				Console.WriteLine("Closing connection.");
				client.GetStream().Dispose();
			}
		}
	}
}
