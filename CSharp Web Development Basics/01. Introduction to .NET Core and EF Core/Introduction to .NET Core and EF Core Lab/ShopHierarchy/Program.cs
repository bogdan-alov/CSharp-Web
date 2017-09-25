using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopHierarchy.Models;

namespace ShopHierarchy
{
	class Program
	{
		static void Main()
		{
			using (var db = new MyDbContext())
			{
				SaveSalesmen(db);
				SaveItems(db);
				ExecuteCommands(db);
				//PrintSalesmenWithCustomersCount(db);
				//PrintCustomersAndOrders(db);
				//PrintCustomerOrdersSummary(db);
				//PrintCustomerInfo(db);
				PrintCustomerOrdersInfo(db);
			}
		}

		private static void PrintCustomerOrdersInfo(MyDbContext db)
		{
			int customerId = int.Parse(Console.ReadLine());

			var ordersCount = db.Orders
				.Where(o => o.CustomerId == customerId && o.Items.Count > 1)
				.Count();

			Console.WriteLine($"Orders: {ordersCount}");
		}

		private static  void PrintCustomerInfo(MyDbContext db)
		{
			int customerId = int.Parse(Console.ReadLine());

			var customerInfo = db.Customers
				.Where(c => c.Id == customerId)
				.Select(c => new
				{
					c.Name,
					OrdersCount = c.Orders.Count,
					ReviewsCount = c.Reviews.Count,
					SalesmanName = c.Salesman.Name
				}).FirstOrDefault();

			Console.WriteLine($"Customer: {customerInfo.Name}");
			Console.WriteLine($"Orders count: {customerInfo.OrdersCount}");
			Console.WriteLine($"Reviews: {customerInfo.ReviewsCount}");
			Console.WriteLine($"Salesman: {customerInfo.SalesmanName}");
		}

		private static void PrintCustomerOrdersSummary(MyDbContext db)
		{
			int customerId = int.Parse(Console.ReadLine());

			var customerSummary = db.Customers
				.Where(c => c.Id == customerId)
				.Select(c => new
				{
					Orders = c.Orders.Select(co => new
						{
							OrderId = co.Id,
							ItemsCount = co.Items.Count
						})
						.OrderBy(o => o.OrderId),
					ReviewsCount = c.Reviews.Count
				})
				.FirstOrDefault();

			foreach (var order in customerSummary.Orders)
			{
				Console.WriteLine($"order {order.OrderId}: {order.ItemsCount} items");
			}
			Console.WriteLine($"reviews: {customerSummary.ReviewsCount}");
		}

		private static void SaveItems(MyDbContext db)
		{
			string input = string.Empty;

			while ((input = Console.ReadLine()) != "END")
			{
				var tokens = input.Split(';');
				string name = tokens[0];
				decimal price = decimal.Parse(tokens[1]);

				db.Items.Add(new Item{Name = name, Price =  price});
			}

			db.SaveChanges();
		}

		private static void PrintCustomersAndOrders(MyDbContext db)
		{
			var results = db.Customers
				.Select(c => new
				{
					Name = c.Name,
					Orders = c.Orders.Count,
					Reviews = c.Reviews.Count
				})
				.OrderByDescending(cr => cr.Orders)
				.ThenByDescending(cr => cr.Reviews);

			foreach (var customerResult in results)
			{
				Console.WriteLine(customerResult.Name);
				Console.WriteLine($"Orders: {customerResult.Orders}");
				Console.WriteLine($"Reviews: {customerResult.Reviews}");
			}
		}

		private static void PrintSalesmenWithCustomersCount(MyDbContext db)
		{
			var results = db.Salesmen
				.Select(s => new
				{
					Name = s.Name,
					CustomersCount = s.Customers.Count
				})
				.OrderByDescending(s => s.CustomersCount)
				.ThenBy(s => s.Name);

			foreach (var salesman in results)
			{
				Console.WriteLine($"{salesman.Name} - {salesman.CustomersCount} customers");
			}
		}

		private static void ExecuteCommands(MyDbContext db)
		{
			string input = string.Empty;

			while ((input = Console.ReadLine()) != "END")
			{
				var tokens = input.Split('-');
				string commandName = tokens[0];
				string arguments = tokens[1];

				switch (commandName)
				{
					case "register":
						RegisterCustomer(db, arguments);
						break;

					case "order":
						SaveCustomerOrder(db, arguments);
						break;

					case "review":
						SaveCustomerReview(db, arguments);
						break;

					default:
						break;
				}
			}
		}

		private static void SaveCustomerReview(MyDbContext db, string arguments)
		{
			var tokens = arguments.Split(';');

			int customerId = int.Parse(tokens[0]);
			int itemId = int.Parse(tokens[1]);

			db.Reviews.Add(new Review{CustomerId = customerId, ItemId =  itemId});

			db.SaveChanges();
		}

		private static void SaveCustomerOrder(MyDbContext db, string arguments)
		{
			var tokens = arguments.Split(';');

			int customerId = int.Parse(tokens[0]);

			var order = new Order{CustomerId =  customerId};

			for (int i = 1; i < tokens.Length; i++)
			{
				var itemId = int.Parse(tokens[i]);

				order.Items.Add(new OrderItems()
				{
					ItemId = itemId
				});
			}

			db.Orders.Add(order);

			db.SaveChanges();
		}

		private static void RegisterCustomer(MyDbContext db, string arguments)
		{
			var customerInfo = arguments.Split(';');

			string customerName = customerInfo[0];
			int salesmanId = int.Parse(customerInfo[1]);

			db.Customers.Add(new Customer{Name = customerName, SalesmanId = salesmanId});

			db.SaveChanges();
		}

		private static void SaveSalesmen(MyDbContext db)
		{
			var salesmenNames = Console.ReadLine().Split(';');

			foreach (var name in salesmenNames)
			{
				db.Salesmen.Add(new Salesman{Name = name});
			}

			db.SaveChanges();
		}
	}
}