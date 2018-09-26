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
		private const int HAUTEUR = 16;
		private const int LARGEUR = 28;
		
		private List<Rangee> listeRangees = null;
		
		public Carte(bool hasard)
		{
			listeRangees = new List<Rangee>();
			InitialiserCarte();
			if(hasard)
				CreerCarteHasard();
		}
		
		private void InitialiserCarte()
		{
			for(int i = 0; i < HAUTEUR; i++)
			{
				listeRangees.Add(new Rangee(LARGEUR));
			}
		}
		
		public void PlacerTuile(Tuile tuileAjoutee, int x, int y){
			listeRangees[y].PlacerTuile(tuileAjoutee, x);
		}
		
		public List<Rangee> GetListeRangees()
		{
			return listeRangees;
		}
		
		private void CreerCarteHasard()
		{
			Random aleatoire = new Random();
			
			for(int x = 0; x < LARGEUR ; x++ ) 
			{
				for(int y = 0; y < HAUTEUR ; y++ ) 
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
		
		public TYPE_TUILES GetTypeTuileAuPoint(int x, int y)
		{
			return listeRangees[y].GetTypeTuile(x);
		}
		
		public void ImporterXML(List<Tuile> listeTuiles)
		{
			for(int x = 0; x < LARGEUR ; x++ ) 
			{
				for(int y = 0; y < HAUTEUR ; y++ ) 
				{
					if(listeTuiles[x + (y * LARGEUR)] != null)
						this.PlacerTuile(listeTuiles[x + (y * LARGEUR)], x, y);
					else
						this.PlacerTuile(Tuiles.vide, x, y);
				}
			}
		}
		
		public string ExporterXML()
		{
			string chaineXML = "<carte>";
			
			foreach(Rangee rangee in listeRangees)
				chaineXML += rangee.ExporterXML();
			
			return chaineXML + "</carte>";
		}

	}
}
