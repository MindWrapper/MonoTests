using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MonoTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----");
            Console.WriteLine("MONO_PREFIX " + Environment.GetEnvironmentVariable("MONO_PREFIX"));
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

            if (args.Contains("embedded"))
            {
                EmbeddedResourceTest();
            }

            if (args.Contains("readtoend"))
            {
                P4ProcessTest();
            }

            if (args.Contains("print"))
            {
                Console.WriteLine("Hello world!");
            }
        }

        private static void EmbeddedResourceTest()
        {
            var expectedResourceName = "MonoTests.SomeFolder.Dummy.zip";
            var manifestResourceNames = typeof(Program).Assembly.GetManifestResourceNames();
            if (!manifestResourceNames.Contains(expectedResourceName))
            {
                Console.WriteLine("FAILURE: Could not find expected resource `{0}`, found resources are:\n\t{1}", expectedResourceName, string.Join("\n\t", manifestResourceNames));
            }
            else
            {
                Console.WriteLine("SUCCESS: Embedded resource found");
            }
        }

        private static void P4ProcessTest()
        {
            Process process = new Process();
            process.StartInfo.FileName = "MonoTests.exe";
            process.StartInfo.Arguments = "print";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            var output = process.StandardOutput;
            Console.WriteLine(output.ReadToEnd());
            process.WaitForExit();
            Console.WriteLine("Good bye!");
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
            var image = Bitmap.FromFile("test.bmp");
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
