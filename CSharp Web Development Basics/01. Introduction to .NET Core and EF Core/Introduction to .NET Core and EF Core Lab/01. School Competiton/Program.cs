using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _01.School_Competiton
{
    class Program
    {
        static void Main(string[] args)
        {
			var categories = new Dictionary<string, SortedSet<string>>();
			var results = new Dictionary<string, int>();

	        var input = "";
	        while ((input = Console.ReadLine()) != "END")
	        {
		        var arr = input.Split(' ').ToArray();

		        var studentName = arr[0];
		        var categoryName = arr[1];
		        var result = int.Parse(arr[2]);

		        if (categories.ContainsKey(studentName) && results.ContainsKey(studentName))
		        {
			        categories[studentName].Add(categoryName);
			        results[studentName] += result;
				}
		        else
		        {
			        categories.Add(studentName, new SortedSet<string>());
			        categories[studentName].Add(categoryName);
					results.Add(studentName, result);

		        }
	        }

	        foreach (var student in results.OrderByDescending(c=> c.Value).ThenBy(c=> c.Key))
	        {
		        Console.WriteLine($"{student.Key}: {student.Value} [{string.Join(",", categories[student.Key])}]");
		        
	        }
        }
    }
}