using System;

namespace _02.One_To_Many_Relation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new MyContext();
	        db.Database.EnsureDeleted();
	        db.Database.EnsureCreated();

        }
    }
}