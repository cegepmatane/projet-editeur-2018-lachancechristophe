/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-25
 * Time: 19:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Historique.
	/// </summary>
	public class Historique
	{
	
		protected Stack<Commande> dernieresActions = new Stack<Commande>();
		protected Stack<Commande> actionsAnnulees = new Stack<Commande>();
		
		public Historique()
		{
		}
		
		public void memoriserAction(Commande commande)
		{
			this.dernieresActions.Push(commande);
		}
		
		public Commande abandonnerAction()
		{
			if(this.dernieresActions.Count > 0)
			{
				Commande command = this.dernieresActions.Pop();
				actionsAnnulees.Push( command );
				return command;
			}
			return null;
		}
		
		public Commande refaireAction()
		{
			if(this.actionsAnnulees.Count > 0)
			{
				Commande command = this.actionsAnnulees.Pop();
				dernieresActions.Push( command );
				return command;
			}
			return null;
		}
	}
}