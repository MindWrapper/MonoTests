using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;

namespace ProcessExitCode
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (args.Contains("Process"))
			{
				ProccessTest();
			}

			if (args.Contains("gdi"))
			{
				GDIPlusTest();
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
		}
	}
}
