using System;
using System.Threading;

namespace _01.EvenNumbersThread
{
    class Program
    {
        static void Main()
        {
	        var args = Console.ReadLine().Split();
	        var start = int.Parse(args[0]);
	        var end = int.Parse(args[1]);

			Thread evens = new Thread(() => PrintEvenNumbers(start, end));
			evens.Start();
	        evens.Join();
	        Console.WriteLine("Thread finished work");
        }

	    private static void PrintEvenNumbers(int start, int end)
	    {
		    for (int i = start; i < end; i++)
		    {
			    if (i % 2 == 0)
			    {
				    Console.WriteLine(i);
			    }
		    }
	    }
    }
}
