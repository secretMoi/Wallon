using System.Collections.Generic;
using RestServer.Models;

namespace RestServer.Data.Locataires
{
	public interface ILocataireRepo
	{
		bool SaveChanges();
		IEnumerable<Locataire> GetAllCommands();
		Locataire GetCommandById(int id);
		void CreateCommand(Locataire command);
		void UpdateCommand(Locataire command);
		void DeleteCommand(Locataire command);
	}
}
