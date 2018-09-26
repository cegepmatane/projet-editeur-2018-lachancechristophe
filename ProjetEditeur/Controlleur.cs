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
		readonly VueEditeur vueEditeur = null;
		readonly Carte modeleEditeur = null;
		
		private Historique historique = new Historique();
		private Tuile tuileActive;
		private TYPE_TUILES typeActif;
		
		public Controlleur(VueEditeur vue, Carte modele)
		{
			this.vueEditeur = vue;
			this.modeleEditeur = modele;
			tuileActive = Tuiles.vide;
		}
		
		public Tuile GetTuileActive() { return tuileActive; }
		
		public TYPE_TUILES GetTypeTuileAuPoint(int x, int y)
		{
			return modeleEditeur.GetTypeTuileAuPoint(x, y);
		}
		
		public void notifierActionChangerTuile(TYPE_TUILES tuile, bool enregistrer)
		{
			if (enregistrer) historique.memoriserAction(new CommandeChangerTuile(tuile, this));
			
			typeActif = tuile;
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
			vueEditeur.illuminerBouton(tuile);
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
		
		public void notifierActionPlacerTuile(int x, int y, bool enregistrer)
		{
			if (enregistrer) historique.memoriserAction(new CommandePlacerTuile(x, y, typeActif, this));
			modeleEditeur.PlacerTuile(tuileActive, x, y);
			vueEditeur.AfficherCarte();
		}
		
		public void notifierActionRetour()
		{
			Console.WriteLine("notifierActionRetourner()");
			Commande commande = historique.AbandonnerAction();
			if(null != commande) commande.annuler();
		}
		
		public void notifierActionRefaire()
		{
			Console.WriteLine("notifierActionRefaire()");
			Commande commande = historique.RefaireAction();
			if(null != commande) commande.executer();
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
