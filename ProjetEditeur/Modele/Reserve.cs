/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 10/04/2018
 * Time: 08:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Reserve.
	/// </summary>
	public class Reserve
	{
		private Custom custom1, custom2;
		public Reserve()
		{
			custom1 = new Custom(System.Windows.Media.Colors.Aquamarine, "SeaDoo");
			custom2 = new Custom(System.Windows.Media.Colors.BlueViolet, "StadeOlympique");
		}
		
		public Custom creerSeaDoo(){ return custom1.Cloner(); }
		public Custom creerStadeOlympique(){ return custom2.Cloner(); }
	}
}
