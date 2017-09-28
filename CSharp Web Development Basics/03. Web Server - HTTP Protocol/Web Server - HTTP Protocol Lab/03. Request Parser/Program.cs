using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _03._Request_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = new List<string>();
	        var input = string.Empty;
	        while ((input = Console.ReadLine()) != "END")
	        {	
		        paths.Add(input);
	        }

			var request = Console.ReadLine().Split();

	        if (paths.Any(c=> c.EndsWith(request[0].ToLowerInvariant()) && c.Contains(request[1])))
	        {
			Console.WriteLine($"HTTP/1.1 {(int)HttpStatusCode.OK}");
		        Console.WriteLine($"Content-Lenght:{HttpStatusCode.OK.ToString().Length}");
		        Console.WriteLine($"Content-Type:text/plain");
		        Console.WriteLine();
		        Console.WriteLine(HttpStatusCode.OK.ToString());
	        }
	        else
	        {

		        Console.WriteLine($"HTTP/1.1 {(int)HttpStatusCode.NotFound}");
		        Console.WriteLine($"Content-Lenght:{HttpStatusCode.NotFound.ToString().Length}");
		        Console.WriteLine($"Content-Type:text/plain");
		        Console.WriteLine();
		        Console.WriteLine(HttpStatusCode.NotFound.ToString());
			}
        }
    }
}
