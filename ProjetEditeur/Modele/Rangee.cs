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
		private int LARGEUR;
		private List<Tuile> listeTuiles;
		
		public Rangee(int l)
		{
			listeTuiles = new List<Tuile>();
			LARGEUR = l;
			initialiserRangee();
		}
		
		private void initialiserRangee()
		{
			for(int i = 0; i < LARGEUR; i++)
			{
				listeTuiles.Add(new Vide());
			}
		}
		
		public TYPE_TUILES getTypeTuile(int x)
		{
			return listeTuiles[x].GetTypeTuile();
		}
		
		public List<Tuile> getListeTuile() { return listeTuiles; }
		
		public void placerTuile(Tuile tuilePlacee, int n){
			listeTuiles[n] = tuilePlacee;
		}
		
		public string exporterXML()
		{
			string chaineXML = "";
			
			foreach(Tuile tuile in listeTuiles)
					chaineXML += tuile.exporterXML();
			
			return chaineXML;
		}
	}
}
