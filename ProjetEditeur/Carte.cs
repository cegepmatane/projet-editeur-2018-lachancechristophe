/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-13
 * Time: 08:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Carte.
	/// </summary>
	public class Carte
	{
		private List<Tuile> listeTuiles;
		public Carte()
		{
			listeTuiles = new List<Tuile>();
		}
		
		public void ajouterTuile(Tuile tuileAjoutee){
			listeTuiles.Add(tuileAjoutee);
		}
		
		public List<Tuile> getListeTuiles()
		{
			return listeTuiles;
		}
		
		public string ExporterXML()
		{
			string chaineXML = "";
			foreach(Tuile tuile in listeTuiles)
			{
				chaineXML += tuile.ExporterXML();
			}
			return chaineXML;
		}
		
		public void ImporterListe(List<Tuile> liste)
		{
			listeTuiles = liste;
		}
	}
}
