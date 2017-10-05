using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _02.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
	        Console.Write("File name:");
	        var fileName = Console.ReadLine();
	        Console.Write("Pieces:");
	        var pieces = int.Parse(Console.ReadLine());

			var resultDir = "Pieces";
	        if (!Directory.Exists(resultDir))
	        {
		        Directory.CreateDirectory(resultDir);
	        }

	        SliceAsync(fileName, pieces, resultDir);

		


			while (true)
	        {
		        Console.Write($"Anything else?");
		        var input = Console.ReadLine();

		        if (input == "No")
		        {
			        break;
		        }

		        if(input == "timenow") 
		        {
			        Console.WriteLine(DateTime.Now);
		        }

		        if (input == "dayofweek")
		        {
			        Console.WriteLine(DateTime.Now.DayOfWeek);
		        }
	        }
        }

	    private static void SliceAsync(string fileName, int pieces, string resultDir)
	    {
		    Task.Run(() => { Slice(fileName, pieces, resultDir); });
	    }

	    private static void Slice(string sourceFile, int parts, string destinationDirectory)
	    {
		    using (var source = new FileStream(sourceFile, FileMode.Open))
		    {
				var fileInfo = new FileInfo(sourceFile);
			    for (int i = 0; i < parts; i++)
			    {
				    string filePath = string.Format("{0}/Part-{1}{2}", destinationDirectory, i, fileInfo.Extension);
				    using (var destination = new FileStream(filePath, FileMode.CreateNew))
				    {
					    byte[] buffer = new byte[4096];
					    while (true)
					    {
						    int readBytes = source.Read(buffer, 0, buffer.Length);
						    if (readBytes == 0)
						    {
							    break;
						    }
						    destination.Write(buffer, 0, readBytes);
					    }
				    }
					Thread.Sleep(1000);
			    }	
		    }

			Console.WriteLine("Slice complete!");
	    }
    }
}
