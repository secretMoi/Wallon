using System.IO;
using System.Text;
using Controls;

namespace QMag.Core
{
	class HtmlView
	{
		private StringBuilder _htmlCode;
		private int _nombreColonnes;
		private int _colonneActuelle;

		public HtmlView(string titre, int nombreColonnes)
		{
			_nombreColonnes = nombreColonnes;
			GenerateHead(titre);
		}

		private void GenerateHead(string titre)
		{
			_htmlCode = new StringBuilder();

			_htmlCode.Append(
				"<!doctype html>\r\n" +
				"<html lang=\"fr\">\r\n" +
				"<head>\r\n" +
				"<meta charset=\"utf-8\">\r\n" +
				"<title>" + titre + "</title>\r\n" +
				"</head>\r\n" +
				"<body>\r\n" +
				"<h1 align='center'>" + titre + "</h1>\r\n" +
				"<table align='center' cellpadding='5' cellspacing='0' style='border: 1px solid " + Theme.ColorToHex(Theme.BackDark) + ";'>\r\n"
			);
		}

		/*public void GenerateBody(params string[] data)
		{
			if(data.Length % _nombreColonnes != 0) return;

			for (int colonne = 0; colonne < data.Length; colonne++)
			{
				if (colonne % _nombreColonnes == 0)
					_htmlCode.Append("<tr>\r\n");

				_htmlCode.Append(
					"<th>" + data[colonne] + "</th>\r\n"
				);

				if (colonne % _nombreColonnes == 0)
					_htmlCode.Append("</tr>\r\n\r\n");
			}
		}*/

		public void GenerateColumn(params string[] data)
		{
			if (data.Length != _nombreColonnes) return;

			_htmlCode.Append("<tr>\r\n");

			foreach (string colonne in data)
			{
				_htmlCode.Append(
					"<th style='color: " + Theme.ColorToHex(Theme.Texte) + " ;background-color: " + Theme.ColorToHex(Theme.BackDark) + "; border: 1px solid " + Theme.ColorToHex(Theme.BackDark) + ";'>" +
					colonne +
					"</th>\r\n"
				);
			}

			_htmlCode.Append("</tr>\r\n\r\n");
		}

		public void GenerateBody(string data)
		{
			if (_colonneActuelle % _nombreColonnes == 0)
			{
				_htmlCode.Append("<tr>\r\n");

				if (_colonneActuelle != 0)
					_htmlCode.Append("</tr>\r\n\r\n");
			}

			_htmlCode.Append(
				"<td style='border: 1px solid " + Theme.ColorToHex(Theme.BackDark) + "'>" + 
				data + 
				"</td>\r\n"
			);

			_colonneActuelle++;
		}

		public void GenerateFooter()
		{
			_htmlCode.Append(
				"</tr>\r\n\r\n" +
				"</table>\r\n" +
				"</body>\r\n" +
				"</html>\r\n"
			);
		}

		public void SaveTo(string file)
		{
			GenerateFooter();
			File.WriteAllText(file + ".html", _htmlCode.ToString());
		}

		public string SourceCode => _htmlCode.ToString();

		public int NombreColonnes
		{
			get => _nombreColonnes;
			set => _nombreColonnes = value;
		}
	}
}
