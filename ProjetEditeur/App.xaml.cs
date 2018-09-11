using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace ProjetEditeur
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private List<Tuile> listeTuiles = null;
		
		public List<Tuile> importerXML(string xmlImport){ 
			return Parser.getInstance().parserListeTuileXML(xmlImport);
		}
		
		public string exporterXML(List<Tuile> listeTuiles){
			string exportedXML = "";
			foreach(Tuile tile in listeTuiles)
				exportedXML += tile.ExporterXML();
			return exportedXML;
		}
	}
}