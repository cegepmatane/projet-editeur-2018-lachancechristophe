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
			this.tuileAvant = controlleurMaitre.GetTuileActive().GetTypeTuile();
			this.tuile = tuileInput;
		}
		
		public override void executer()
		{
			controlleurMaitre.notifierActionChangerTuile(tuile, true);
		}
		public override void annuler()
		{
			controlleurMaitre.notifierActionChangerTuile(tuileAvant, false);
		}
	}
	
	public class CommandePlacerTuile : Commande
	{
		private TYPE_TUILES tuileAvant, type;
		private int x, y;
		readonly Controlleur controlleurMaitre;
		
		public CommandePlacerTuile(int xInput, int yInput, TYPE_TUILES typeInput ,Controlleur ctrl)
		{
			this.controlleurMaitre = ctrl;
			this.tuileAvant = controlleurMaitre.GetTypeTuileAuPoint(xInput, yInput);
			this.x = xInput;
			this.y = yInput;
			this.type = typeInput;
		}
		
		public override void executer()
		{
			controlleurMaitre.notifierActionChangerTuile(type, false);
			controlleurMaitre.notifierActionPlacerTuile(x, y, true);
		}
		public override void annuler()
		{
			controlleurMaitre.notifierActionChangerTuile(tuileAvant, false);
			controlleurMaitre.notifierActionPlacerTuile(x, y, false);
		}
	}
}
