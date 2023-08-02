using System;
using Microsoft.AspNetCore.Identity;

namespace UserService.Data.Models
{
	public class UserDbModel : IdentityUser
	{
		public UserDbModel()
		{
		}

		public DateTimeOffset DOB { get; set; }

	}
}

