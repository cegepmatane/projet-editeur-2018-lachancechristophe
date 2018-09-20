/*
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
			tuileActive = Tuiles.vide;
		}
		
		public void notifierActionDessinerForet()
		{
			tuileActive = Tuiles.foret;
		}
		
		public void notifierActionDessinerHerbe()
		{
			tuileActive = Tuiles.herbe;
		}
		
		public void notifierActionDessinerPlage()
		{
			tuileActive = Tuiles.plage;
		}
		
		public void notifierActionDessinerMer()
		{
			tuileActive = Tuiles.mer;
		}
		
		public void notifierActionEffacer()
		{
			tuileActive = Tuiles.vide;
		}
		
		public void notifierActionDessinerEpee()
		{
			tuileActive = Tuiles.epee;
		}
		
		public void notifierActionDessinerBateau()
		{
			tuileActive = Tuiles.bateau;
		}
		
		public void notifierActionDessinerJoyau()
		{
			tuileActive = Tuiles.joyau;
		}
		
		public void notifierActionSauvegarderXML()
		{
			Console.Write(modeleEditeur.ExporterXML());
		}
		
		public void notifierActionClicDessin(int x, int y)
		{
			modeleEditeur.PlacerTuile(tuileActive, x, y);
			vueEditeur.AfficherCarte();
		}
		
		public static class Tuiles
		{
			public static Foret foret = new Foret();
			public static Herbe herbe = new Herbe();
			public static Plage plage = new Plage();
			public static Mer mer = new Mer();
			public static Epee epee = new Epee();
			public static Joyau joyau = new Joyau();
			public static Bateau bateau = new Bateau();
			public static Vide vide = new Vide();
		}
	}
}
