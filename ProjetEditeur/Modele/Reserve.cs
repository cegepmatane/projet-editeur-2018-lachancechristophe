/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 10/04/2018
 * Time: 08:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Reserve.
	/// </summary>
	public class Reserve
	{
		private Custom customTuile, customArtefact;
		public Reserve()
		{
			customTuile = new Custom(Colors.Aquamarine, TYPE_TUILES.CUSTOMTILE);
			customArtefact = new Custom(Colors.BlueViolet, TYPE_TUILES.CUSTOMARTEFACT);
		}
		
		public void setTuileCustom(Color couleur) { customTuile = new Custom(couleur, TYPE_TUILES.CUSTOMTILE); }
		public void setArtefactCustom(Color couleur) { customArtefact = new Custom(couleur, TYPE_TUILES.CUSTOMARTEFACT); }
		
		public Custom creerTuileCustom(){ return customTuile.Cloner(); }
		public Custom creerArtefactCustom(){ return customArtefact.Cloner(); }
	}
}
