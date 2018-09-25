/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 09/13/2018
 * Time: 11:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Controlleur.
	/// </summary>
	public class Controlleur
	{
		public enum TUILE{FORET, HERBE, PLAGE, MER, EFFACER, EPEE, BATEAU, JOYAU};
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
		
		public Tuile GetTuileActive() { return tuileActive; }
		
		public void notifierActionChangerTuile(TYPE_TUILES tuile) {
			switch (tuile){
				case TYPE_TUILES.FORET:
					tuileActive = Tuiles.foret;
					break;
				case TYPE_TUILES.HERBE:
					tuileActive = Tuiles.herbe;
					break;
				case TYPE_TUILES.PLAGE:
					tuileActive = Tuiles.plage;
					break;
				case TYPE_TUILES.MER:
					tuileActive = Tuiles.mer;
					break;
				case TYPE_TUILES.EFFACER:
					tuileActive = Tuiles.vide;
					break;
				case TYPE_TUILES.BATEAU:
					tuileActive = Tuiles.bateau;
					break;	
				case TYPE_TUILES.JOYAU:
					tuileActive = Tuiles.joyau;
					break;
				case TYPE_TUILES.EPEE:
					tuileActive = Tuiles.epee;
					break;
			}
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
			SaveFileDialog dialogueSauvegarde = new SaveFileDialog();  
		   	dialogueSauvegarde.Filter = "Carte|*.xml";  
		   	dialogueSauvegarde.Title = "Sauvegarder la carte en format XML";  
		   	dialogueSauvegarde.ShowDialog();  
		
		   	// If the file name is not an empty string open it for saving.  
		   	if(dialogueSauvegarde.FileName != "")  
		   	{
		   		File.WriteAllText(dialogueSauvegarde.FileName, modeleEditeur.ExporterXML());
		   	}
		}
		
		public void notifierActionChargerXML()
		{
			OpenFileDialog dialogueCharger = new OpenFileDialog();
			dialogueCharger.Filter = "Carte|*.xml";
			dialogueCharger.Title = "Charger la carte en format XML";  
			dialogueCharger.ShowDialog();
			
			if(dialogueCharger.FileName != "")  
		   	{
				Parser ps = Parser.getInstance();
				modeleEditeur.ImporterXML(
					ps.parserListeTuileXML(
						File.ReadAllText(
							dialogueCharger.FileName)));
				
				vueEditeur.AfficherCarte();
		   	}
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
