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
			initialiserCarte();
			if(hasard)
				creerCarteHasard();
		}
		
		private void initialiserCarte()
		{
			for(int i = 0; i < HAUTEUR; i++)
			{
				listeRangees.Add(new Rangee(LARGEUR));
			}
		}
		
		public void placerTuile(Tuile tuileAjoutee, int x, int y){
			listeRangees[y].placerTuile(tuileAjoutee, x);
		}
		
		public List<Rangee> getListeRangees()
		{
			return listeRangees;
		}
		
		private void creerCarteHasard()
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
							this.placerTuile(new Foret(), x, y);
							break;
						
						case 1:
							this.placerTuile(new Herbe(), x, y);
							break;
						
						case 2:
							this.placerTuile(new Plage(), x, y);
							break;
						
						case 3:
							this.placerTuile(new Mer(), x, y);
							break;
					}
				}
			}
		}
		
		public TYPE_TUILES getTypeTuileAuPoint(int x, int y)
		{
			return listeRangees[y].getTypeTuile(x);
		}
		
		public void importerXML(List<Tuile> listeTuiles)
		{
			for(int x = 0; x < LARGEUR ; x++ ) 
			{
				for(int y = 0; y < HAUTEUR ; y++ ) 
				{
					if(listeTuiles[x + (y * LARGEUR)] != null)
						this.placerTuile(listeTuiles[x + (y * LARGEUR)], x, y);
					else
						this.placerTuile(Tuiles.vide, x, y);
				}
			}
		}
		
		public string exporterXML()
		{
			string chaineXML = "<carte>";
			
			foreach(Rangee rangee in listeRangees)
				chaineXML += rangee.exporterXML();
			
			return chaineXML + "</carte>";
		}

	}
}
