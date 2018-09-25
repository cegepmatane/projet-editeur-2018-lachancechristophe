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
		const int LARGEUR_TUILE = 50;
		
		private SolidColorBrush brosseActif, brosseInactif;
		
		private Controlleur controlleurEditeur = null;
		private Carte modeleEditeur = null;
		
		public VueEditeur()
		{
			InitializeComponent();
			
			modeleEditeur = new Carte(false);
			
			controlleurEditeur = new Controlleur(this, modeleEditeur);
			
			AfficherCarte();
			
			brosseActif = new SolidColorBrush();
			brosseInactif = (SolidColorBrush) boutonHerbe.Background;
			brosseActif.Color = Colors.AliceBlue;
		}
		
		private void setBoutonsInactif()
		{
			boutonHerbe.Background = brosseInactif;
			boutonForet.Background = brosseInactif;
			boutonPlage.Background = brosseInactif;
			boutonMer.Background = brosseInactif;
			boutonJoyau.Background = brosseInactif;
			boutonEpee.Background = brosseInactif;
			boutonBateau.Background = brosseInactif;
			boutonEffacer.Background = brosseInactif;
		}
		
		public void AfficherCarte()
		{
			canvasCarte.Children.Clear();
			
			int x, y;
			x = y = 0;

			
			foreach(Rangee rangee in modeleEditeur.GetListeRangees())
			{
				foreach(Tuile tuile in rangee.GetListeTuile())
				{
					SolidColorBrush brosse = new SolidColorBrush();
					Rectangle carre = new Rectangle();
					brosse.Color = tuile.GetCouleur();
					carre.Fill = brosse;
					carre.Margin = new Thickness(x, y, 0, 0);
					carre.Width = carre.Height = LARGEUR_TUILE;

					canvasCarte.Children.Add(carre);
					x += LARGEUR_TUILE -1; // -1 pour eviter les espaces entres les tuiles lors du rendu
				}
				
				x = 0; 
				y += LARGEUR_TUILE -1; // -1 pour eviter les espaces entres les tuiles lors du rendu
			}
		}
		
		void canvasCarte_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			//Récupérer les positions X et Y du clic
			Point p = e.GetPosition(canvasCarte);
    
		    int nX = (int) p.X / (LARGEUR_TUILE-1);
		    int nY = (int) p.Y / (LARGEUR_TUILE-1);
		    controlleurEditeur.notifierActionClicDessin(nX, nY);
		}
		void boutonHerbe_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonHerbe.Background = brosseActif;
			//controlleurEditeur.notifierActionDessinerHerbe();
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.HERBE);
		}
		void boutonForet_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonForet.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.FORET);
		}
		void boutonPlage_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonPlage.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.PLAGE);
		}
		void boutonMer_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonMer.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.MER);
		}
		void boutonJoyau_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonJoyau.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.JOYAU);
		}
		void boutonBateau_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonBateau.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.BATEAU);
		}
		void boutonEpee_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonEpee.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.EPEE);
		}
		void boutonEffacer_Click(object sender, RoutedEventArgs e)
		{
			setBoutonsInactif();
			boutonEffacer.Background = brosseActif;
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.EFFACER);
		}
		void boutonSauver_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionSauvegarderXML();
		}
		void boutonCharger_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChargerXML();
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