using Exceptio_Practice.Services;

TransportService transportService = new TransportService();

while(true)
{
	transportService.CreateTransport("", "", 0, "");
	transportService.GetAllTransports();

	Console.WriteLine("\nDo you want to add another transport? (y/n)");
	string response = Console.ReadLine();
	if (response?.ToLower() != "y")
	{
		break;
	}
}