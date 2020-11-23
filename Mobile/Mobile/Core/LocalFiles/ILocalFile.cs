using System.Threading.Tasks;

namespace Mobile.Core.LocalFiles
{
	public interface ILocalFile
	{
		string Path { get; set; }

		/**
		 * <summary>Sauvegarde des bytes dans un fichier</summary>
		 * <param name="data">Données à sauvegarder</param>
		 * <returns>true si tout s'est bien passé, false en cas d'erreur</returns>
		 */
		Task<bool> SaveBytes(byte[] data);

		/**
		 * <summary>RestoreAsync un fichier de bytes</summary>
		 * <returns>Un tabluea de byte contenant les données si tout s'est bien, null sinon</returns>
		 */
		Task<byte[]> ReadBytes();

		/**
		 * <summary>Vérifie qu'un chemin est valide</summary>
		 * <param name="path">Nom du chemin</param>
		 * <returns>true si il est valide, false sinon</returns>
		 */
		bool ValidPath(string path);
	}
}