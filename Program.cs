using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProcessExitCode
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var monoPrefix = Environment.GetEnvironmentVariable("MONO_PREFIX");
			Console.WriteLine("-----");
			Console.WriteLine("MONO_PATH " + Environment.GetEnvironmentVariable("MONO_PATH"));
			Console.WriteLine("LD_LIBRARY_PATH " + Environment.GetEnvironmentVariable("LD_LIBRARY_PATH"));
			Console.WriteLine("MONO_CFG_DIR " + Environment.GetEnvironmentVariable("MONO_CFG_DIR"));
			Console.WriteLine("-----");
			if (args.Contains("Process"))
			{
				ProccessTest();
			}

			if (args.Contains("gdi"))
			{
				GDIPlusTest();
			}

			if (args.Contains("http"))
			{
				WebRequestTest();
			}

			if (args.Contains("socket"))
			{
				SocketTest();
			}
		}

		private static void ProccessTest()
		{
			var process = Process.Start("bash");
			Thread.Sleep(500);
			process.Kill();
			process.WaitForExit();
			Console.WriteLine("Exitcode are: " + process.ExitCode);
		}

		private static void GDIPlusTest()
		{
			var image = Bitmap.FromFile ("test.bmp");
			Console.WriteLine("Image loaded");
		}

		private static void WebRequestTest()
		{
			var http = (HttpWebRequest)WebRequest.Create("http://google.com");
			Console.WriteLine(http.GetResponse().Headers);
		}

		private static void SocketTest()
		{
			Socket socket = new Socket(AddressFamily.InterNetwork,
								  SocketType.Stream,
								  ProtocolType.Tcp);
			var endPoint = new IPEndPoint(IPAddress.Any, 54999);
			socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			// socket.Blocking = false;
			Console.WriteLine(endPoint);
			socket.Bind(endPoint);
			socket.Listen(0);

			// If you call this method using a non-blocking Socket, 
			// and no connection requests are queued, Accept throws a SocketException.
			// If you receive a SocketException, 
			// use the SocketException.ErrorCode property to obtain the specific error code. 
			// After you have obtained this code, refer to the Windows 
			// Sockets version 2 API error code documentation in the MSDN library for a detailed description of the error.
			// https://msdn.microsoft.com/en-us/library/system.net.sockets.socket.accept(v=vs.110).aspx
			socket.Accept();
			Console.WriteLine("Accepting connections");
		}
	}
}
