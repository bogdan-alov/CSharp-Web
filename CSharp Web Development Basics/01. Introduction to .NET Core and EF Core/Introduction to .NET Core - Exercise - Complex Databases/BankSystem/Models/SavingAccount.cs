using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankSystem.Models
{
    class SavingAccount
    {
	    public SavingAccount()
	    {
		    this.Balance = 0.00m;
		    this.InterestRate = 0.00m;
	    }
		[Key]
	    public int Id { get; set; }

	    
	    [Required]
		[MinLength(5)]
	    public string AccountNumber { get; set; }


	    public decimal Balance { get; set; }

		public int? UserId { get; set; }
	    public User User { get; set; }

		public decimal InterestRate { get; set; }

	    public decimal DepositMoney(decimal price)
	    {
		    Console.WriteLine($"{price}$ succesfully added to your balance!");
		    return this.Balance = this.Balance + price;
	    }

	    public decimal WithdrawMoney(decimal price)
	    {
		    if (this.Balance < price)
		    {
			    Console.WriteLine("Insufficent funds!");
			    return this.Balance;
		    }
		    Console.WriteLine($"{price}$ succefully withdrawed from your balance!");
		    return this.Balance = this.Balance - price;
	    }

	    public void AddInterest(decimal interest)
	    {
		    Console.WriteLine($"{interest} added to your Interest Rate!");
		    this.InterestRate += interest;
		    this.Balance += (this.Balance * (decimal)this.InterestRate);

	    }
	}
}
