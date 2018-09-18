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
		private const int HAUTEUR = 8;
		private const int LARGEUR = 14;
		
		private List<Rangee> listeRangees = null;
		
		public Carte(bool hasard)
		{
			listeRangees = new List<Rangee>();
			InitialiserCarte();
			if(hasard)
				CreerCarteHasard(LARGEUR, HAUTEUR);
		}
		
		private void InitialiserCarte()
		{
			for(int i = 0; i < HAUTEUR; i++)
			{
				listeRangees.Add(new Rangee());
			}
		}
		
		public void PlacerTuile(Tuile tuileAjoutee, int x, int y){
			listeRangees[y].PlacerTuile(tuileAjoutee, x);
		}
		
		public List<Rangee> GetListeRangees()
		{
			return listeRangees;
		}
		
		private void CreerCarteHasard(int largeur, int hauteur)
		{
			Random aleatoire = new Random();
			
			for(int x = 0; x < largeur ; x++ ) 
			{
				for(int y = 0; y < hauteur ; y++ ) 
				{
					int rng = aleatoire.Next(0, 4);
					Console.WriteLine(rng.ToString());
					switch ( rng )
					{
						case 0:
							this.PlacerTuile(new Foret(), x, y);
							break;
						
						case 1:
							this.PlacerTuile(new Herbe(), x, y);
							break;
						
						case 2:
							this.PlacerTuile(new Plage(), x, y);
							break;
						
						case 3:
							this.PlacerTuile(new Mer(), x, y);
							break;
					}
				}
			}
		}
		
		public string ExporterXML()
		{
			string chaineXML = "";
			
			foreach(Rangee rangee in listeRangees)
				chaineXML += rangee.ExporterXML();
			
			return chaineXML;
		}

	}
}
