/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-11
 * Time: 17:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProjetEditeur
{
	/// <summary>
	/// Interaction logic for Editeur.xaml
	/// </summary>
	public partial class VueEditeur : Window
	{
		private const int HAUTEUR = 16;
		private const int LARGEUR = 28;
		const int LARGEUR_TUILE = 25;
		
		private SolidColorBrush brosseActif, brosseInactif;
		
		private Controlleur controlleurEditeur = null;
		private Carte modeleEditeur = null;
		
		public VueEditeur()
		{
			InitializeComponent();
			
			controlleurEditeur = new Controlleur(this);
			
			modeleEditeur = controlleurEditeur.getCarte();
			
			afficherCarte(modeleEditeur);
			
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
		
		public void afficherCarte(Carte carteAffichee)
		{
			canvasCarte.Children.Clear();
			
			int x, y;
			x = y = 0;

			foreach(Rangee rangee in carteAffichee.getListeRangees())
			{
				foreach(Tuile tuile in rangee.getListeTuile())
				{
					SolidColorBrush brosse = new SolidColorBrush();
					Rectangle carre = new Rectangle();
					brosse.Color = tuile.GetCouleur();
					carre.Fill = brosse;
					carre.Margin = new Thickness(x, y, 0, 0);
					TYPE_TUILES tt = tuile.GetTypeTuile();
//					if((tt == TYPE_TUILES.JOYAU) || (tt == TYPE_TUILES.BATEAU) || (tt == TYPE_TUILES.EPEE))
//						carre.Width = carre.Height = LARGEUR_TUILE/2;
//					else
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
		    controlleurEditeur.notifierActionPlacerTuile(nX, nY, true);
		}
		void boutonHerbe_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.HERBE, true);
		}
		void boutonForet_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.FORET, true);
		}
		void boutonPlage_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.PLAGE, true);
		}
		void boutonMer_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.MER, true);
		}
		void boutonJoyau_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.JOYAU, true);
		}
		void boutonBateau_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.BATEAU, true);
		}
		void boutonEpee_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.EPEE, true);
		}
		void boutonEffacer_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChangerTuile(TYPE_TUILES.EFFACER, true);
		}
		void boutonSauver_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionSauvegarderXML();
		}
		void boutonCharger_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionChargerXML();
		}
		void boutonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionRetour();
		}
		
		public void illuminerBouton(TYPE_TUILES type)
		{
			setBoutonsInactif();
			switch (type){
					case TYPE_TUILES.FORET:
					boutonForet.Background = brosseActif;
					break;
				case TYPE_TUILES.HERBE:
					boutonHerbe.Background = brosseActif;
					break;
				case TYPE_TUILES.PLAGE:
					boutonPlage.Background = brosseActif;
					break;
				case TYPE_TUILES.MER:
					boutonMer.Background = brosseActif;
					break;
				case TYPE_TUILES.EFFACER:
					boutonEffacer.Background = brosseActif;
					break;
				case TYPE_TUILES.BATEAU:
					boutonBateau.Background = brosseActif;
					break;	
				case TYPE_TUILES.JOYAU:
					boutonJoyau.Background = brosseActif;
					break;
				case TYPE_TUILES.EPEE:
					boutonEpee.Background = brosseActif;
					break; 
			}
		}
		void boutonRefaire_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionRefaire();
		}
		void boutonPrototype1_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionClonerTuile(0, true);
		}
		void boutonPrototype2_Click(object sender, RoutedEventArgs e)
		{
			controlleurEditeur.notifierActionClonerTuile(1, true);
		}
	}
}