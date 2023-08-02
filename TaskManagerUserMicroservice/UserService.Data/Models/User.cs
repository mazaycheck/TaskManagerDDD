using System;
using Microsoft.AspNetCore.Identity;

namespace UserService.Data.Models
{
	public class UserDataModel : IdentityUser
	{
		public UserDataModel()
		{
		}

		public DateTimeOffset DOB { get; set; }

	}
}

