﻿/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 09/13/2018
 * Time: 11:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Controlleur.
	/// </summary>
	public class Controlleur
	{
		enum TUILE{FORET, HERBE, PLAGE, MER, EFFACER};
		enum ARTEFACT{EPEE, BATEAU, JOYAU};
		
		readonly VueEditeur vueEditeur = null;
		readonly Carte modeleEditeur = null;
		
		private Tuile tuileActive;
		
		public Controlleur(VueEditeur vue, Carte modele)
		{
			this.vueEditeur = vue;
			this.modeleEditeur = modele;
		}
		
		public void notifierActionDessinerForet()
		{
			tuileActive = new Foret();
		}
		
		public void notifierActionDessinerHerbe()
		{
			tuileActive = new Herbe();
		}
		
		public void notifierActionDessinerPlage()
		{
			tuileActive = new Plage();
		}
		
		public void notifierActionDessinerMer()
		{
			tuileActive = new Mer();
		}
		
		public void notifierActionEffacer()
		{
			tuileActive = new Vide();
		}
		
		public void notifierActionDessinerEpee()
		{
			tuileActive = new Epee();
		}
		
		public void notifierActionDessinerBateau()
		{
			tuileActive = new Bateau();
		}
		
		public void notifierActionDessinerJoyau()
		{
			tuileActive = new Joyau();
		}
		
		public void notifierActionClicDessin(int x, int y)
		{
			Console.WriteLine(tuileActive.GetCouleur().ToString());
			modeleEditeur.PlacerTuile(tuileActive, x, y);
			vueEditeur.AfficherCarte();
		}
	}
}
