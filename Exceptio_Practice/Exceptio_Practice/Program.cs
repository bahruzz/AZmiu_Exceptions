using Exceptio_Practice.Services;

RegisterService registerService = new RegisterService();
TransportService transportService = new TransportService();

bool isLoggedIn = false;

while (!isLoggedIn)
{
	Console.Clear();
	Console.WriteLine("===== AUTHENTICATION MENU =====");
	Console.WriteLine("1. Register");
	Console.WriteLine("2. Login");
	Console.WriteLine("0. Exit");
	Console.WriteLine("================================");
	Console.Write("Select an option: ");

	string authChoice = Console.ReadLine();

	try
	{
		switch (authChoice)
		{
			case "1":
				registerService.Register();
				Console.WriteLine("\nPress any key to continue...");
				Console.ReadKey();
				break;

			case "2":
				isLoggedIn = registerService.Login();
				if (isLoggedIn)
				{
					Console.WriteLine("\nPress any key to continue to Transport Management...");
					Console.ReadKey();
				}
				else
				{
					Console.WriteLine("\nPress any key to try again...");
					Console.ReadKey();
				}
				break;

			case "0":
				Console.WriteLine("Exiting... Goodbye!");
				return;

			default:
				Console.WriteLine("Invalid option! Please select 0, 1, or 2.");
				Console.WriteLine("\nPress any key to continue...");
				Console.ReadKey();
				break;
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error: {ex.Message}");
		Console.WriteLine("\nPress any key to continue...");
		Console.ReadKey();
	}
}
while (true)
{
	Console.Clear();
	Console.WriteLine("===== TRANSPORT MANAGEMENT SYSTEM =====");
	Console.WriteLine("1. Create Transport");
	Console.WriteLine("2. Get All Transports");
	Console.WriteLine("3. Get Transport By Id");
	Console.WriteLine("4. Delete Transport");
	Console.WriteLine("5. Get Transports By Brand");
	Console.WriteLine("0. Logout");
	Console.WriteLine("========================================");
	Console.Write("Select an option: ");

	string choice = Console.ReadLine();

	try
	{
		switch (choice)
		{
			case "1":
				transportService.CreateTransport("", "", 0, "");
				break;

			case "2":
				transportService.GetAllTransports();
				break;

			case "3":
				Console.Write("Enter Transport Id: ");
				if (int.TryParse(Console.ReadLine(), out int searchId))
				{
					transportService.GetTransportById(searchId);
				}
				else
				{
					Console.WriteLine("Invalid Id format!");
				}
				break;

			case "4":
				Console.Write("Enter Transport Id to delete: ");
				if (int.TryParse(Console.ReadLine(), out int deleteId))
				{
					transportService.DeleteTransport(deleteId);
				}
				else
				{
					Console.WriteLine("Invalid Id format!");
				}
				break;

			case "5":
				Console.Write("Enter Brand name: ");
				string brand = Console.ReadLine();
				transportService.GetTransportsByBrand(brand);
				break;

			case "0":
				Console.WriteLine("Logging out... Goodbye!");
				return;

			default:
				Console.WriteLine("Invalid option! Please select 0-5.");
				break;
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error: {ex.Message}");
	}

	Console.WriteLine("\nPress any key to continue...");
	Console.ReadKey();
}
