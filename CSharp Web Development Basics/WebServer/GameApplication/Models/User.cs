using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebServer.GameApplication.Models
{
    public class User
    {
	    public User()
	    {
		    this.Games = new List<UserGame>();
	    }


	    public int Id { get; set; }

		[DataType(DataType.EmailAddress)]
		[RegularExpression("[^ ]+[@][^ ]+[.][^ ]{1,4}")]
	    public string Email { get; set; }

	    private string password;


		[DataType(DataType.Password)]
	    public string Password {
			get { return this.password; }
			set
			{
				if (value.Length < 6)
				{
					throw new Exception("Password must be at least 6 symbols long");
				}

				if (!value.Any(c=> char.IsUpper(c)) || !value.Any(c=> char.IsDigit(c)) || !value.Any(c=> char.IsLetter(c)))
				{
					throw new Exception("The password should contain one uppercase, one letter and one digit.");
				}

				this.password = value;
			}
		}

	    public string FullName { get; set; }

	    public bool  IsAdmin { get; set; }

	    public List<UserGame> Games { get; set; }
    }
}
