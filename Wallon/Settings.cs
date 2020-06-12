namespace Wallon
{
	public static class Settings
	{
		public static string Connection = @"Data Source=192.168.1.106;Initial Catalog=Wallons;Persist Security Info=True;User ID=sa;Password=6463f184f";
		public static bool Auth = false; // contient un boolen si la session est active ou pas
		public static int IdLocataire; // contient l'id de l'utilisateur loggé
	}
}
