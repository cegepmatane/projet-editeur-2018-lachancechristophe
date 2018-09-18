/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-11
 * Time: 17:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;

namespace ProjetEditeur
{
	/// <summary>
	/// Interaction logic for Editeur.xaml
	/// </summary>
	public partial class VueEditeur : Window
	{
		private const int HAUTEUR = 8;
		private const int LARGEUR = 14;
		
		private Controlleur controlleurEditeur = null;
		private Carte modeleEditeur = null;
		
		public VueEditeur()
		{
			InitializeComponent();
			
			controlleurEditeur = new Controlleur(this);
			
			modeleEditeur = new Carte(true);
			
			AfficherCarte(modeleEditeur);
			
		}
		
		public void AfficherCarte(Carte carteAffichee)
		{
			int x, y;
			x = y = 0;
			const int largeurTuile = 50;
			try
			{
				foreach(Rangee rangee in carteAffichee.GetListeRangees())
				{
					foreach(Tuile tuile in rangee.GetListeTuile())
					{
						SolidColorBrush brosse = new SolidColorBrush();
						Rectangle carre = new Rectangle();
						brosse.Color = tuile.getCouleur();
						carre.Fill = brosse;
						carre.Margin = new Thickness(x,y,0,0);
						carre.Width = carre.Height = largeurTuile;
						
						x += 50;
						
						canvasCarte.Children.Add(carre);
					}
					
					x = 0; 
					y += 50;
				}
			} catch ( Exception e) {
				Console.WriteLine(e.Message);
			}
		}
		void canvasCarte_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}

			
			/*
			string export = carteAleatoire.ExporterXML();
			Console.Write(export);
			
			File.WriteAllText("export.xml", export);
			
			
			Parser p = new Parser();
			
			string importXML = File.ReadAllText("export.xml");
			
			Carte carteImportee = p.parserListeTuileXML(importXML);
			AfficherCarte(carteImportee);
			*/