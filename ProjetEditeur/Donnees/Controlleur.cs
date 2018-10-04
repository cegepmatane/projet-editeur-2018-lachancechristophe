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
		readonly Historique historique = new Historique();
		readonly EditeurDAO localDAO = null;
		
		private Tuile tuileActive;
		private TYPE_TUILES typeActif;
		
		public Reserve reservePrototypes = new Reserve();
		
		public Controlleur(VueEditeur vue)
		{
			this.modeleEditeur = new Carte(false);
			this.vueEditeur = vue;
			tuileActive = Tuiles.vide;
			localDAO = new EditeurDAO(this);
		}
		
		public Carte getCarte() { return modeleEditeur; }
		
		public Tuile getTuileActive() { return tuileActive; }
		
		public TYPE_TUILES getTypeTuileAuPoint(int x, int y)
		{
			return modeleEditeur.getTypeTuileAuPoint(x, y);
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
			localDAO.sauvegarderXML(modeleEditeur.exporterXML());
		}
		
		public void notifierActionChargerXML()
		{
			modeleEditeur.importerXML(localDAO.chargerXML());
			vueEditeur.afficherCarte(modeleEditeur);
		}
		
		public void notifierActionPlacerTuile(int x, int y, bool enregistrer)
		{
			if (enregistrer) historique.memoriserAction(new CommandePlacerTuile(x, y, typeActif, this));
			
			TYPE_TUILES tt = tuileActive.GetTypeTuile();
			if((tt == TYPE_TUILES.JOYAU) || (tt == TYPE_TUILES.BATEAU) || (tt == TYPE_TUILES.EPEE)  || (tt == TYPE_TUILES.CUSTOMARTEFACT))
				//Si c'est un artefact
			{
				modeleEditeur.placerArtefact(tuileActive, x, y);
			} 
			else 
				if(tt == TYPE_TUILES.EFFACER){
				//Sinon si c'est pour effacer
					if(modeleEditeur.getTypeArtefactAuPoint(x, y) != TYPE_TUILES.EFFACER)
					//Si un artefact est present, effacer celui-ci
						modeleEditeur.placerArtefact(tuileActive, x, y);
					else
					//Sinon effacer la tuile
						modeleEditeur.placerTuile(tuileActive, x, y);
			} else {
				modeleEditeur.placerTuile(tuileActive, x, y);
			}
			
			vueEditeur.afficherCarte(modeleEditeur);
		}
		
		public void notifierActionClonerTuile(int n, bool enregistrer)
		{
			if (enregistrer) historique.memoriserAction(new CommandeClonerTuile(n, this));
			
			switch(n)
			{
				case 0:
					tuileActive = reservePrototypes.creerTuileCustom();
					break;
				case 1:
					tuileActive = reservePrototypes.creerArtefactCustom();
					break;
			}
		}
		
		public void notifierActionRetour()
		{
			Console.WriteLine("notifierActionRetourner()");
			Commande commande = historique.abandonnerAction();
			if(null != commande) commande.annuler();
		}
		
		public void notifierActionRefaire()
		{
			Console.WriteLine("notifierActionRefaire()");
			Commande commande = historique.refaireAction();
			if(null != commande) commande.executer();
		}
		
		
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
