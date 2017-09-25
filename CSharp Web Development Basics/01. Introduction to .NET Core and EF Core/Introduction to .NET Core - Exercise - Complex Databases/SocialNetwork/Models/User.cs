using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SocialNetwork.Models
{
    class User
    {

	    private readonly char[] specialSymbols = new char[] {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?'};
		[Key]
	    public int Id { get; set; }

		[Required]
		[MinLength(4), MaxLength(30)]
	    public string Username { get; set; }


	    private string password;

		[Required]
		[DataType(DataType.Password)]
		[MinLength(6), MaxLength(50)]
		public string Password {
			get { return this.password; }
			set
			{
				if (!value.Any(c=> char.IsLower(c)) && !value.Any(c=> char.IsUpper(c)) && !value.Any(c=> char.IsDigit(c)) && !value.Any(c=> specialSymbols.Any(x=> x.Equals(c))))
				{
					throw new InvalidOperationException("Name mut contain at lesat one 1 lowercase & uppercase letter, 1 digit and 1 special symbol (!, @, #, $, %, ^, &, *, (, ), _, +, <, >, ?)");
				}
				this.password = value;
			}
				 }

		[Required]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]
		public string Email { get; set; }

	    public string ProfilePicture { get; set; }

	    public DateTime RegisteredOn { get; set; }

	    public DateTime LastTimeLoggedIn { get; set; }

	    [Range(1, 120, ErrorMessage = "Can only be between 1 .. 120")]
		public int Age { get; set; }

	    public bool IsDeleted { get; set; }

	    public ICollection<Friend> Friends { get; set; } = new List<Friend>();
	    public ICollection<Friend> Users { get; set; } = new List<Friend>();
	    public ICollection<Album> Albums { get; set; }	= new List<Album>();
	}
}
