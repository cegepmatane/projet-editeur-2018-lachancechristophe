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
			
			//Créeer une carte aléatoire
			modeleEditeur = new Carte(true);
			
			controlleurEditeur = new Controlleur(this, modeleEditeur);
			
			AfficherCarte();
			
		}
		
		public void AfficherCarte()
		{
			canvasCarte.Children.Clear();
			
			int x, y;
			x = y = 0;
			const int largeurTuile = 50;
			//try
			//{
				foreach(Rangee rangee in modeleEditeur.GetListeRangees())
				{
					foreach(Tuile tuile in rangee.GetListeTuile())
					{
						SolidColorBrush brosse = new SolidColorBrush();
						Rectangle carre = new Rectangle();
						brosse.Color = tuile.GetCouleur();
						carre.Fill = brosse;
						carre.Margin = new Thickness(x,y,0,0);
						carre.Width = carre.Height = largeurTuile;
						
						x += 50;
						
						canvasCarte.Children.Add(carre);
						System.Console.WriteLine(x + ", " + y + "\n");
					}
					
					x = 0; 
					y += 50;
				}
			/*} catch ( Exception e) {
				Console.WriteLine(e.Message);
			}*/
		}
		
		//https://stackoverflow.com/questions/23670612/how-i-get-the-x-and-the-y-point-of-a-image-from-a-mouseevent
		void canvasCarte_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			//Récupérer les positions X et Y du clic par rapport au canevas
			Point p = e.GetPosition(canvasCarte);
		    double pixelWidth = canvasCarte.ActualWidth;
		    double pixelHeight = canvasCarte.ActualHeight;
		    double x = pixelWidth * p.X / canvasCarte.ActualWidth;
		    double y = pixelHeight * p.Y / canvasCarte.ActualHeight;
		    
		    //Convertir ces valeurs selon les dimensions de la carte et des tuiles
		    int nX, nY;
		    nX = nY = 0;
		    
		    nX = (int) x / 50;
		    nY = (int) y / 50;
		    controlleurEditeur.notifierActionClicDessin(nX, nY);
		}
		void boutonHerbe_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionDessinerHerbe();
		}
		void boutonForet_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionDessinerForet();
		}
		void boutonPlage_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionDessinerPlage();
		}
		void boutonMer_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionDessinerMer();
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