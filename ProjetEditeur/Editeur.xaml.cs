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
	public partial class Editeur : Window
	{
		public Editeur()
		{
			InitializeComponent();
			
			Carte carteAleatoire = CreerCarte(112);
			
			AfficherCarte(carteAleatoire);
			
			/*
			string export = carteAleatoire.ExporterXML();
			Console.Write(export);
			
			File.WriteAllText("export.xml", export);
			
			
			Parser p = new Parser();
			
			string importXML = File.ReadAllText("export.xml");
			
			Carte carteImportee = p.parserListeTuileXML(importXML);
			AfficherCarte(carteImportee);
			*/
			
		}
		
		public void AfficherCarte(Carte carteAffichee)
		{
			int x, y;
			x = y = 0;
			const int largeurTuile = 50;
			try
			{
				foreach(Tuile tuile in carteAffichee.getListeTuiles())
				{
					SolidColorBrush brosse = new SolidColorBrush();
					Rectangle carre = new Rectangle();
					brosse.Color = tuile.getCouleur();
					carre.Fill = brosse;
					carre.Margin = new Thickness(x,y,0,0);
					carre.Width = carre.Height = largeurTuile;
					
					if(x + 50 >= canvasCarte.Width){ x = 0; y += 50; }
					else x += 50;
					
					canvasCarte.Children.Add(carre);
				}
			} catch ( Exception e) {
				Console.WriteLine(e.Message);
			}
		}
		
		private Carte CreerCarte(int n)
		{
			Carte nouvelleCarte = new Carte();
			Random aleatoire = new Random();
			
			for(int i = 0; i < n ; i++ ) 
			{
				int rng = aleatoire.Next(0, 7);
				Console.WriteLine(rng.ToString());
				switch ( rng )
				{
					case 0:
						nouvelleCarte.ajouterTuile(new Foret());
						break;
					
					case 1:
						nouvelleCarte.ajouterTuile(new Herbe());
						break;
					
					case 2:
						nouvelleCarte.ajouterTuile(new Plage());
						break;
					
					case 3:
						nouvelleCarte.ajouterTuile(new Mer());
						break;
					
					case 4:
						nouvelleCarte.ajouterTuile(new Bateau());
						break;
					
					case 5:
						nouvelleCarte.ajouterTuile(new Joyau());
						break;
					
					case 6:
						nouvelleCarte.ajouterTuile(new Epee());
						break;
				}
			}
			return nouvelleCarte;
		}
	}
}