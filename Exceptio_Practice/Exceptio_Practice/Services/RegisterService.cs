using Exceptio_Practice.Enums;
using Exceptio_Practice.Exceptions;
using Exceptio_Practice.Model;
using Exceptio_Practice.Services.Interfaces;

namespace Exceptio_Practice.Services
{
	public class RegisterService : IRegisterService
	{
		Email[] users = new Email[0];

		public void Register()
		{
			Console.WriteLine("\n===== REGISTER =====");

			string fullName = "";
		FullNameInput:
			Console.Write("Enter Full Name: ");
			try
			{
				fullName = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(fullName))
				{
					throw new NullorException("Full Name cannot be null");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				goto FullNameInput;
			}

			string emailAddress = "";
		EmailInput:
			Console.Write("Enter Email: ");
			try
			{
				emailAddress = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(emailAddress))
				{
					throw new NullorException("Email cannot be null");
				}

				foreach (var user in users)
				{
					if (user.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase))
					{
						throw new DuplicateTitleException("Email already exists");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				goto EmailInput;
			}

			string password = "";
		PasswordInput:
			Console.Write("Enter Password (min 6 characters): ");
			try
			{
				password = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
				{
					throw new LengthException("Password must be at least 6 characters");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				goto PasswordInput;
			}

			int age = 0;
		AgeInput:
			Console.Write("Enter Age: ");
			try
			{
				if (!int.TryParse(Console.ReadLine(), out age) || age < 1 || age > 120)
				{
					throw new FormatException("Age must be between 1 and 120");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				goto AgeInput;
			}

			Gender gender = Gender.Other;
		GenderInput:
			Console.WriteLine("Select Gender:");
			Console.WriteLine("1. Male");
			Console.WriteLine("2. Female");
			Console.WriteLine("3. Other");
			Console.Write("Your choice: ");
			try
			{
				if (!int.TryParse(Console.ReadLine(), out int genderChoice) || genderChoice < 1 || genderChoice > 3)
				{
					throw new FormatException("Invalid gender choice. Select 1, 2, or 3");
				}
				gender = (Gender)genderChoice;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				goto GenderInput;
			}

			Console.Write("Enter Address: ");
			string address = Console.ReadLine();

			Console.Write("Enter Phone: ");
			string phone = Console.ReadLine();

			Email newUser = new Email
			{
				Id = users.Length + 1,
				FullName = fullName,
				EmailAddress = emailAddress,
				Password = password,
				Age = age,
				Gender = gender,
				Address = address,
				Phone = phone,
				CreatedDate = DateTime.Now
			};

			Array.Resize(ref users, users.Length + 1);
			users[users.Length - 1] = newUser;

			Console.WriteLine("\n? Registration successful! You can now login.");
		}

		public bool Login()
		{
			Console.WriteLine("\n===== LOGIN =====");

			Console.Write("Enter Email: ");
			string email = Console.ReadLine();

			Console.Write("Enter Password: ");
			string password = Console.ReadLine();

			foreach (var user in users)
			{
				if (user.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase) &&
					user.Password == password)
				{
					Console.WriteLine($"\n? Welcome, {user.FullName}!");
					return true;
				}
			}

			Console.WriteLine("\n? Invalid email or password!");
			return false;
		}
	}
}
