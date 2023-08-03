using System;
namespace UserService.Domain.Models
{
	public class User
	{
		public User()
		{
		}

		public string UserId { get; set; }

		public string Username { get; set; }

		public string Email { get; set; }
	}
}

