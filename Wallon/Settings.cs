namespace Wallon
{
	public static class Settings
	{
		//public static string Connection = @"Data Source=192.168.1.106;Initial Catalog=Wallons;Persist Security Info=True;User ID=sa;Password=6463f184f";
		private static string Server = "82.212.177.233";
		private static string User = "sa";
		private static string Password = "Nax2J,/nwdbLQGj";
		private static string Database = "WallonsTest";

		public static string Connection = $"Data Source={Server};Initial Catalog={Database};Persist Security Info=True;User ID={User};Password={Password}";
		public static bool Auth = false; // contient un boolen si la session est active ou pas
		public static int IdLocataire; // contient l'id de l'utilisateur loggé
	}
}
