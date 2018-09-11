/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-11
 * Time: 17:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Parseur.
	/// </summary>
	public class Parser
	{
		public Parser()
		{
		}
		
		private static Parser instance = null;
		
		public static Parser getInstance(){
			if(instance == null)
				instance = new Parser();
			return instance;
		}
		
		public List<Tuile> parserListeTuileXML(string listeTuileXML)
		{
			XElement listeTuilesRacine = XElement.Parse(listePersonnagesXML);
			//Console.WriteLine("Objet XElement : " + listePersonnagesRacine);
			List<Tuile> listeTuiles = new List<Tuile>();
			
			foreach(XElement element in listeTuilesRacine.Elements())
			{
				//Console.WriteLine("Element " + element);
				XElement typeElement = element.Element("type");
				//Console.WriteLine("Type : " + typeElement);
				string type = typeElement.Value; // equivalent de .innerHTML en JavaScript
				//Console.WriteLine("Type : " + type);
				
				Tuile tile = null;
				if(type.CompareTo("foret") == 0)
				{
					tile = new Foret();
				}
				else if(type.CompareTo("plage") == 0)
				{
					tile = new Plage();
				}
				else if(type.CompareTo("mer") == 0)
				{
					tile = new Mer();
				}
				else if(type.CompareTo("herbe") == 0)
				{
					tile = new Herbe();
				}
				else if(type.CompareTo("epee") == 0)
				{
					tile = new Epee();	
				}
				else if(type.CompareTo("bateau") == 0)
				{
					tile = new Bateau();	
				}
				else if(type.CompareTo("joyau") == 0)
				{
					tile = new Joyau();
				}
				if(tile != null) listeTuiles.Add(tile);
				// les ajouter a une liste quelconque
			}
			
			return listeTuiles;
		
		}
	}
}
