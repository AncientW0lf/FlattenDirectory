using System;
using System.IO;

namespace FlattenDirectory
{
	internal class Program
	{
		private static void Main()
		{
			Console.WriteLine("Enter the full path to the directory you would like to flatten.");

			askdir:
			Console.Write("Directory: ");

			string dir = Console.ReadLine();

			if(!Directory.Exists(dir))
			{
				Console.WriteLine("This directory does not exist! Please try again.");
				goto askdir;
			}

			bool noErrors = true;

			Console.WriteLine("Flattening directory...");
			try
			{
				Flattener.Flatten(dir);
			}
			catch(Exception exc)
			{
				noErrors = false;
				Console.WriteLine($"Error: {exc.Message}");
			}
			Console.WriteLine($"Finished operation with {(noErrors ? "no " : "")}errors.");
		}
	}
}
