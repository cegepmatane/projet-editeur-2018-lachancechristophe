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
				return this.dernieresActions.Pop();
			return null;
		}
		
	}
}