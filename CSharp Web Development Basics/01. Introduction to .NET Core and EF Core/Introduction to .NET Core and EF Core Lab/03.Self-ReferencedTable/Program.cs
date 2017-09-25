using System;

namespace _03.Self_ReferencedTable
{
    class Program
    {
        static void Main()
        {
			var db = new MyContext();
	        //db.Database.EnsureDeleted();
	        //db.Database.EnsureCreated();
		}
    }
}