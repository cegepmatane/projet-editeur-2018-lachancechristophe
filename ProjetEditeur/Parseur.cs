/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-11
 * Time: 17:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;

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
		
		public Carte parserListeTuileXML(string listeTuileXML)
		{
			Carte carteImportee = new Carte(false);
			
			XmlReaderSettings settings = new XmlReaderSettings();
					
			List<Tuile> listeTuiles = new List<Tuile>();
			
			using (XmlReader reader = XmlReader.Create(new StringReader(listeTuileXML), settings)) 
			{
				 while (reader.Read() && reader.Read())
			     {
				 	Tuile tile = null;
		            switch (reader.Name)
		            {
		                case "foret":
		                    tile = new Foret();
		                    break;
		                case "plage":
		                   	tile = new Plage();
		                    break;
		                case "mer":
		                    tile = new Mer();
		                    break;
		                case "herbe":
		                    tile = new Herbe();
		                    break;
		                case "epee":
		                    tile = new Epee();
		                    break;
		                case "joyau":
		                    tile = new Joyau();
		                    break;
		                case "bateau":
		                    tile = new Bateau();
		                    break;
		                default:
		                    Console.WriteLine("Other node {0} with value {1}",
		                                    reader.NodeType, reader.Value);
		                    break;
		            }
		            //carteImportee.ajouterTuile(tile);
		        }
			}	
			return carteImportee;
		}
	}
}
