using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;

namespace Wallon
{
	public class LocalOptions
	{
		private const string FichierConfiguration = @"config.ini";
		private Dictionary<string, string> _elementConfiguration;

		private static readonly LocalOptions instance = new LocalOptions();

		private static readonly Mutex VerrouAccesFichier = new Mutex();

		// juste pour le pattern Singleton, ne pas remplir
		static LocalOptions()
		{
		}

		public LocalOptions()
		{
			if (_elementConfiguration == null)
				ChargeFichier();
		}

		private void ChargeFichier()
		{
			_elementConfiguration = new Dictionary<string, string>();

			string nom = null, valeur = null;
			XmlReader xReader;

			XmlReaderSettings settings = new XmlReaderSettings
			{
				ConformanceLevel = ConformanceLevel.Fragment, // format conforme au w3c
				IgnoreWhitespace = true,
				IgnoreComments = true
			};
			try
			{
				xReader = XmlReader.Create(FichierConfiguration, settings);
			}
			catch (FileNotFoundException) // si le fichier n'existe pas on le crée
			{
				SaveGeneric();
				xReader = XmlReader.Create(FichierConfiguration, settings);
			}

			while (xReader.Read())
			{
				switch (xReader.NodeType)
				{
					case XmlNodeType.Element:
						nom = xReader.Name;
						break;
					case XmlNodeType.Text:
						valeur = xReader.Value;
						break;
				}

				if (nom == null || valeur == null) continue; // tant qu'on a pas le nom et le nb de pièces on continue de parcourir

				_elementConfiguration.Add(nom, valeur);

				// reset les valeurs pour lire le prochain noeud
				nom = null;
				valeur = null;
			}

			xReader.Close();
		}

		public string GetOption(string cle)
		{
			if (_elementConfiguration.TryGetValue(cle, out string valeur))
				return valeur;

			return null;
		}

		public void SetOption(string cle, string valeur)
		{
			if (_elementConfiguration.ContainsKey(cle))
				_elementConfiguration[cle] = valeur;
			else
				_elementConfiguration.Add(cle, valeur);
		}

		public void Enregistre()
		{
			Thread threadConnect = new Thread(SaveInThread);
			threadConnect.Start();
		}

		private void SaveInThread()
		{
			VerrouAccesFichier.WaitOne();

			SaveGeneric();

			VerrouAccesFichier.ReleaseMutex();
		}

		private void SaveGeneric()
		{
			XmlWriter xmlWriter = XmlWriter.Create(FichierConfiguration);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("config");

			foreach (KeyValuePair<string, string> element in _elementConfiguration)
			{
				xmlWriter.WriteStartElement(element.Key);
				xmlWriter.WriteString(element.Value);
				xmlWriter.WriteEndElement();
			}

			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}

		public static LocalOptions Instance => instance;
	}
}
