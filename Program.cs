using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessExitCode
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var process = Process.Start("bash");
			Thread.Sleep(500);
			process.Kill();
			process.WaitForExit();
			Console.WriteLine("Exitcode are: " + process.ExitCode);
		}
	}
}
