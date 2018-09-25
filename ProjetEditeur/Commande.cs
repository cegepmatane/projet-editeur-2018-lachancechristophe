/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-25
 * Time: 19:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Commande.
	/// </summary>
	public class Commande
	{
		public Commande()
		{
		}
		
		public virtual void executer()
		{
		}
		public virtual void annuler()
		{
		}
	}
	
	public class CommandeChangerTuile : Commande
	{
		private TYPE_TUILES tuileAvant, tuile;
		readonly Controlleur controlleurMaitre;
		
		public CommandeChangerTuile(TYPE_TUILES tuileInput, Controlleur ctrl)
		{
			this.controlleurMaitre = ctrl;
			this.tuileAvant = controlleurMaitre.GetTuileActive().GetType();
			this.tuile = tuileInput;
		}
		
		public virtual void executer()
		{
			controlleurMaitre.notifierActionChangerTuile(tuile);
		}
		public virtual void annuler()
		{
			controlleurMaitre.notifierActionChangerTuile(tuileAvant);
		}
	}
	
	
}
