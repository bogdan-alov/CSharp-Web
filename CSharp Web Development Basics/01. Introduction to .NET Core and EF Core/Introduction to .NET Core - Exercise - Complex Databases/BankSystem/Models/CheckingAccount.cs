using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankSystem.Models
{
    class CheckingAccount
    {
	    public CheckingAccount()
	    {
		    this.Balance = 0.00m;
		    this.Fee = 0.00m;
	    }
		[Key]
	    public int Id { get; set; }

	    [Required]
	    [MinLength(5)]
		public string AccountNumber { get; set; }

	    public decimal Balance { get; set; }

	    public decimal Fee { get; set; }


	    public int? UserId { get; set; }
	    public User User { get; set; }

	    public decimal DepositMoney(decimal price)
	    {

		    if (price < this.Fee)
		    {
			    this.Balance = this.Balance - this.Fee;
		    }
		    else
		    {
			    price = price - this.Fee;
		    }
		    Console.WriteLine($"{price}$ succesfully added to your balance!");
		    return this.Balance += price;
	    }


	    public decimal WithdrawMoney(decimal price)
	    {
		    if (this.Balance < price + this.Fee)
		    {
			    Console.WriteLine("Insufficent funds!");
			    return this.Balance;
		    }
		    Console.WriteLine($"{price}$ succefully withdrawed from your balance!");
		    return this.Balance -= price + this.Fee;
	    }

	    public void DeductFee(decimal fee)
	    {
		    if (this.Balance < this.Fee)
		    {
			    Console.WriteLine("Your account will be erased! Not enough money for fee!");
			    this.Balance = 0.00m;
		    }
		    else
		    {
			    this.Balance = this.Balance - this.Fee;

			    this.Fee = fee;
			    Console.WriteLine($@"Fees were applied on Account: {this.AccountNumber} Current Balance: {this.Balance}");
		    }

	    }
	}
}
