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
		
		public List<Tuile> parserListeTuileXML(string listeTuileXML)
		{						
			List<Tuile> listeTuiles = new List<Tuile>();
			
			using (XmlReader reader = XmlReader.Create(new StringReader(listeTuileXML))) 
			{
				reader.Read(); 
				 while (reader.Read())
			     {
				 	Tuile tile = null;
		            switch (reader.Name)
		            {
		                case "foret":
		            		tile = Tuiles.foret;
		                    break;
		                case "plage":
		                   	tile = Tuiles.plage;
		                    break;
		                case "mer":
		                    tile = Tuiles.mer;
		                    break;
		                case "herbe":
		                    tile = Tuiles.herbe;
		                    break;
		                case "epee":
		                    tile = Tuiles.epee;
		                    break;
		                case "joyau":
		                    tile = Tuiles.joyau;
		                    break;
		                case "bateau":
		                    tile = Tuiles.bateau;
		                    break;
		                default:
		                    Console.WriteLine("Other node {0} with value {1}",
		                                    reader.NodeType, reader.Value);
		                    break;
		            }
		            listeTuiles.Add(tile);
		        }
			}	
			return listeTuiles;
		}
	}
}
