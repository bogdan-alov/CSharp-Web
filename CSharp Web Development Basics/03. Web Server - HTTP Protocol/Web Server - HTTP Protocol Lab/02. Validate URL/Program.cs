using System;

namespace _02._Validate_URL
{
	class Program
	{
		static void Main(string[] args)
		{
			var url = Console.ReadLine();

			bool isUri = Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);

			if (isUri)
			{
				var uri = new Uri(url);
				Console.WriteLine($"Protocol: {uri.Scheme}");
				Console.WriteLine($"Host: {uri.Host}");
				Console.WriteLine($"Port: {uri.Port}");
				Console.WriteLine($"Path: {uri.AbsolutePath}");
				if (!string.IsNullOrEmpty(uri.Query))
				{
					Console.WriteLine($"Query: {uri.Query}");
				}
				if (!string.IsNullOrEmpty(uri.Fragment))
				{
					Console.WriteLine($"Fragment: {uri.Fragment}");
				}
			}
			else
			{
				Console.WriteLine($"Invalid URL");
			}
			
			
				
			

		}
	}
}
