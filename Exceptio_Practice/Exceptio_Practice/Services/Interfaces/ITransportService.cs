

namespace Exceptio_Practice.Services.Interfaces
{ 
	public interface ITransportService
	{
		 void CreateTransport(string model, string brand, int year, string title);
	     void GetAllTransports();


    }
}

