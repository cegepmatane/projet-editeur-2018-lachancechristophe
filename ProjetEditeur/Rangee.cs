/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-18
 * Time: 16:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Rangee.
	/// </summary>
	public class Rangee
	{
		private const int LARGEUR = 14;
		private List<Tuile> listeTuiles;
		
		public Rangee()
		{
			listeTuiles = new List<Tuile>();
			InitialiserRangee();
		}
		
		private void InitialiserRangee()
		{
			for(int i = 0; i < LARGEUR; i++)
			{
				listeTuiles.Add(new Vide());
			}
		}
		
		public TYPE_TUILES GetTypeTuile(int x)
		{
			return listeTuiles[x].GetTypeTuile();
		}
		
		public List<Tuile> GetListeTuile() { return listeTuiles; }
		
		public void PlacerTuile(Tuile tuilePlacee, int n){
			listeTuiles[n] = tuilePlacee;
		}
		
		public string ExporterXML()
		{
			string chaineXML = "";
			
			foreach(Tuile tuile in listeTuiles)
					chaineXML += tuile.ExporterXML();
			
			return chaineXML;
		}
	}
}
