using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankSystem.Data;
using BankSystem.Models;

namespace BankSystem.Core
{
    class Engine
    {
	    public void Run()
	    {
			var ctx = new BankContext();
		    //ctx.Database.EnsureDeleted();
		    ctx.Database.EnsureCreated();

			// Seed some data
			//Seed(ctx);



		    //Deposit some money in SavingAccount
		    //DepositMoneySaving(ctx);

		    //Withdraw some money from SavingAccount
		    //WithdrawMoneySaving(ctx);

		    //Add interest rate to SavingAccount
			//AddInterest(ctx);


		    //Deposit some money in CheckingAccount
		    //DepositMoneyChecking(ctx);


		    //Withdraw some money from CheckingAccount
		    //WithdrawMoneyChecking(ctx);

		    //Deduct fee on CheckingAccount
		    //DeductFee(ctx);

		    //Bank Console
		    //BankConsole(ctx);
		    ctx.SaveChanges();
		}

	    private static void BankConsole(BankContext ctx)
	    {
		    Console.WriteLine("Hello, summoner! Welcome to Soft Uni Bank (SUB)");
		    Console.WriteLine("-----------------------------------------------");
		    Console.WriteLine("Type 'commands' to see the available commands!");
		    Console.WriteLine("Type 'Quit' to quit the application!");
		    Console.WriteLine("-----------------------------------------------");
		    string loggedUsername = "";
		    string loggedUserPassword = "";
		    var command = Console.ReadLine();
		    while (command != "Quit")
		    {
			    var array = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
			    if (command == "commands")
			    {
				    Console.WriteLine("1. Register <username> <password> <email> - That command add new user to the database in case username, password and email are valid. Otherwise print appropriate message informing why the user cannot be registered");
				    Console.WriteLine("2. Login <username> <password> - - That command set the current logged in user if exists. Otherwise print appropriate message.");
				    Console.WriteLine("3. Logout - log out the user from the system. If there is no logged in user print appropriate message.");
				    Console.WriteLine("4. Add SavingAccount <initial balance> <interest rate> - add saving account to the currently logged in user. ");
				    Console.WriteLine("5. Add CheckingAccount <initial balance> <fee> - add checking account to the currently logged in user. ");
				    Console.WriteLine("6. ListAccounts – prints a list of overall information for all accounts of currently logged in user.");
				    Console.WriteLine("7. Deposit <Account number> <money> - adds money to the account with given number");
				    Console.WriteLine("8. Withdraw <Account number> <money> - subtracts money from the account with given number");
				    Console.WriteLine("9. DeductFee <Account number> - deduct the fee from the balance of the account with given number");
				    Console.WriteLine("10. AddInterest <Account number> - add interest to the balance of the account with given number");
				    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
			    }
			    if (array[0] == "Register")
			    {
				    var user = new User();
				    user.Username = array[1];
				    user.Password = array[2];
				    user.Email = array[3];
				    ctx.Users.Add(user);
				    ctx.SaveChanges();
				    Console.WriteLine($"{user.Username} was registered.");
			    }
			    if (array[0] == "Login")
			    {
				    var username = array[1];
				    var password = array[2];
				    var user = ctx.Users.Where(u => u.Username == username).FirstOrDefault();
				    var listOfUsers = ctx.Users.ToList();
				    if (listOfUsers.Contains(user))
				    {
					    loggedUsername = user.Username;
					    loggedUserPassword = user.Password;
					    Console.WriteLine("Succesfully logged in!");
				    }
				    else
				    {
					    Console.WriteLine("There is no such user!");
				    }
			    }
			    if (array[0] == "Logout")
			    {
				    if (loggedUsername == string.Empty)
				    {
					    Console.WriteLine("Cannot log out. No user was logged in.");
				    }
				    else
				    {
					    Console.WriteLine($"{loggedUsername} succesfully logged out.");
					    loggedUsername = "";
					    loggedUserPassword = "";
				    }
			    }
			    if (array[0] == "Add")
			    {
				    if (loggedUsername == "")
				    {
					    Console.WriteLine("Please login first!");
				    }
				    else
				    {
					    if (array[1] == "SavingAccount")
					    {
						    var savingAccount = new SavingAccount();
						    savingAccount.Balance = decimal.Parse(array[2]);
						    savingAccount.InterestRate = decimal.Parse(array[3]);
						    savingAccount.AccountNumber = RandomString();
						    ctx.SavingAccounts.Add(savingAccount);
						    ctx.SaveChanges();
						    Console.WriteLine($"Succesfully added saving account with number: {savingAccount.AccountNumber}");
					    }
					    if (array[1] == "CheckingAccount")
					    {
						    var checkingAccount = new CheckingAccount();
						    checkingAccount.Balance = decimal.Parse(array[2]);
						    checkingAccount.Fee = decimal.Parse(array[3]);
						    checkingAccount.AccountNumber = RandomString();
						    ctx.CheckingAccounts.Add(checkingAccount);
						    ctx.SaveChanges();
						    Console.WriteLine($"Succesfully added checking account with number: {checkingAccount.AccountNumber}");
					    }
				    }
			    }
			    if (array[0] == "ListAccounts")
			    {
				    var list1 = ctx.SavingAccounts.OrderBy(c => c.AccountNumber).ToList();
				    var list2 = ctx.CheckingAccounts.OrderBy(c => c.AccountNumber).ToList();
				    Console.WriteLine("Saving accounts:");
				    foreach (var sa in list1)
				    {
					    Console.WriteLine($"-- {sa.AccountNumber} {sa.Balance} ");
				    }
				    Console.WriteLine("Checking accounts:");
				    foreach (var ca in list2)
				    {
					    Console.WriteLine($"-- {ca.AccountNumber} {ca.Balance}");
				    }
			    }
			    if (array[0] == "Deposit" && loggedUsername != "")
			    {
				    var accountNumber = array[1];
				    var sum = decimal.Parse(array[2]);
				    var list1 = ctx.SavingAccounts.ToList();
				    var list2 = ctx.CheckingAccounts.ToList();
				    foreach (var item in list1)
				    {
					    if (item.AccountNumber == accountNumber && item.User.Username == loggedUsername)
					    {
						    item.DepositMoney(sum);
						    ctx.SaveChanges();
						    Console.WriteLine($"Succesfully added money to saving account: {item.AccountNumber}");
						    Console.WriteLine($"Balance: {item.Balance}$");
					    }
				    }
				    foreach (var item in list2)
				    {
					    if (item.AccountNumber == accountNumber && item.User.Username == loggedUsername)
					    {
						    item.DepositMoney(sum);
						    ctx.SaveChanges();
						    Console.WriteLine($"Succesfully added money to checking account: {item.AccountNumber}");
						    Console.WriteLine($"Balance: {item.Balance}$");
					    }
				    }
			    }
			    if (array[0] == "Withdraw" && loggedUsername != "")
			    {
				    var accountNumber = array[1];
				    var sum = decimal.Parse(array[2]);
				    var list1 = ctx.SavingAccounts.ToList();
				    var list2 = ctx.CheckingAccounts.ToList();
				    foreach (var item in list1)
				    {
					    if (item.AccountNumber == accountNumber && item.User.Username == loggedUsername)
					    {
						    item.WithdrawMoney(sum);
						    ctx.SaveChanges();
						    if (item.Balance > sum)
						    {
							    Console.WriteLine($"Succesfully withdrawed money from saving account: {item.AccountNumber}");
							    Console.WriteLine($"Balance: {item.Balance}$");
						    }


					    }
				    }
				    foreach (var item in list2)
				    {
					    if (item.AccountNumber == accountNumber && item.User.Username == loggedUsername)
					    {
						    item.WithdrawMoney(sum);
						    ctx.SaveChanges();
						    if (item.Balance > sum)
						    {
							    Console.WriteLine($"Succesfully withdrawed money from saving account: {item.AccountNumber}");
							    Console.WriteLine($"Balance: {item.Balance}$");
						    }

					    }

				    }
			    }

			    if (array[0] == "DeductFee" && loggedUsername != "")
			    {
				    var accountNumber = array[1];
				    var list = ctx.CheckingAccounts.ToList();
				    foreach (var item in list)
				    {
					    if (item.AccountNumber == accountNumber && item.User.Username == loggedUsername)
					    {
						    var fee = decimal.Parse(array[2]);
						    item.DeductFee(fee);
						    ctx.SaveChanges();
						    Console.WriteLine("Succesfully added new fee!");
					    }
				    }
			    }
			    if (array[0] == "AddInterest" && loggedUsername != "")
			    {
				    var accountNumber = array[1];
				    var list = ctx.SavingAccounts.ToList();
				    foreach (var item in list)
				    {
					    if (item.AccountNumber == accountNumber && item.User.Username == loggedUsername)
					    {
						    var interest = decimal.Parse(array[2]);
						    item.AddInterest(interest);
						    ctx.SaveChanges();
						    Console.WriteLine("Succesfully added new interest!");
						    Console.WriteLine($"Balance: {item.Balance}$");
					    }
				    }
			    }
			    command = Console.ReadLine();
		    }
		    Console.WriteLine("GG WP!");
	    }

	    private static void DeductFee(BankContext ctx)
	    {
		    var checkingAccount = ctx.CheckingAccounts.Where(c => c.Id == 3).FirstOrDefault();
		    decimal fee = 50;
		    checkingAccount.DeductFee(fee);

	    }

	    private static void WithdrawMoneyChecking(BankContext ctx)
	    {
		    var checkingAccount = ctx.CheckingAccounts.Where(c => c.Id == 3).FirstOrDefault();
		    decimal price = 15000;
		    checkingAccount.WithdrawMoney(price);
	    }

	    private static void DepositMoneyChecking(BankContext ctx)
	    {
		    var checkingAccount = ctx.CheckingAccounts.Where(c => c.Id == 3).FirstOrDefault();
		    decimal price = 100;
		    checkingAccount.DepositMoney(price);
	    }

	    private static void AddInterest(BankContext ctx)
	    {

		    var savingAccount = ctx.SavingAccounts.Where(c => c.Id == 9).FirstOrDefault();
		    Console.WriteLine(savingAccount.InterestRate);
		    Console.WriteLine(savingAccount.Balance);
		    decimal interestRate = 20;
		    savingAccount.AddInterest(interestRate);
		    Console.WriteLine(savingAccount.InterestRate);
		    Console.WriteLine(savingAccount.Balance);


	    }

	    private static void WithdrawMoneySaving(BankContext ctx)
	    {
		    var savingAccount = ctx.SavingAccounts.Where(c => c.Id == 9).FirstOrDefault();
		    decimal price = 9000;
		    savingAccount.WithdrawMoney(price);

	    }

	    private static void DepositMoneySaving(BankContext ctx)
	    {
		    var savingAccount = ctx.SavingAccounts.Where(c => c.Id == 9).FirstOrDefault();
		    decimal price = 100;
		    savingAccount.DepositMoney(price);
	    }

	    private static Random random = new Random();
	    public static string RandomString()
	    {
		    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		    return new string(Enumerable.Repeat(chars, 10)
			    .Select(s => s[random.Next(s.Length)]).ToArray());
	    }


		public void Seed(BankContext ctx)
		{
			ctx.CheckingAccounts.AddRange(
				new CheckingAccount { AccountNumber = "123BAN321", Fee = 100, Balance = 5 },
				new CheckingAccount { AccountNumber = "456BAN321", Fee = 10000, Balance = 5000000 },
				new CheckingAccount { AccountNumber = "124BAN321", Fee = 1000, Balance = 250 },
				new CheckingAccount { AccountNumber = "123NAB321", Fee = 10, Balance = 500 },
				new CheckingAccount { AccountNumber = "BN1231-312", Balance = 10000 }
				);

			ctx.SavingAccounts.AddRange(
				new SavingAccount { AccountNumber = "MES1235672", Balance = 5000, InterestRate = 10 },
				new SavingAccount { AccountNumber = "QUE1235672", Balance = 50000, InterestRate = 1 },
				new SavingAccount { AccountNumber = "UN12356722", Balance = 15000, InterestRate = 3 },
				new SavingAccount { AccountNumber = "CLUB123567", Balance = 200000, InterestRate = 5 },
				new SavingAccount { AccountNumber = "MES1236773", Balance = 30000, InterestRate = 6 },
				new SavingAccount { AccountNumber = "MESS113564", Balance = 4000, InterestRate = 7 },
				new SavingAccount { AccountNumber = "MES1235675", Balance = 100, InterestRate = 3 },
				new SavingAccount { AccountNumber = "MES1235678", Balance = 5, InterestRate = 5 },
				new SavingAccount { AccountNumber = "MES1235677", Balance = 8, InterestRate = 4 }


				);

			ctx.SaveChanges();

		}
	}
}

