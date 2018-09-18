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
		enum JOYAU{EPEE, BATEAU, JOYAU};
		
		private VueEditeur vueEditeur = null;
		private Carte modeleEditeur = null;
		
		private TUILE tuileActive;
		private JOYAU joyauActif;
		
		public Controlleur(VueEditeur vue)
		{
			this.vueEditeur = vue;
		}
		
		public void notifierActionDessinerForet()
		{
			this.tuileActive = TUILE.FORET;
		}
		
		public void notifierActionDessinerHerbe()
		{
			this.tuileActive = TUILE.HERBE;
		}
		
		public void notifierActionDessinerPlage()
		{
			this.tuileActive = TUILE.PLAGE;
		}
		
		public void notifierActionDessinerMer()
		{
			this.tuileActive = TUILE.MER;
		}
		
		public void notifierActionEffacer()
		{
			this.tuileActive = TUILE.EFFACER;
		}
		
		public void notifierActionClicDessin(int x, int y)
		{
			//TODO: 
		}
	}
}
