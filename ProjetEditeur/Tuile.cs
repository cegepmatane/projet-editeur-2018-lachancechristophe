/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-11
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Tuiles.
	/// </summary>
	public enum TYPE_TUILES {FORET, HERBE, PLAGE, MER, EFFACER, EPEE, BATEAU, JOYAU};
	
	abstract public class Tuile
    {
		protected TYPE_TUILES type;
		protected Color couleur;
		
    	public virtual string ExporterXML()
	    {
	        return "<tuile>Tuile invalide</tuile>\n";
	    }
    	
    	public Color GetCouleur(){ return couleur; }
    	public TYPE_TUILES GetType(){ return type; }
    }

    public class Plage : Tuile
    {
    	public Plage()
    	{
    		couleur = Colors.Beige;
    		type = TYPE_TUILES.PLAGE;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<plage/>";
    	}
    }
    
    public class Mer : Tuile
    {
    	public Mer()
    	{
    		couleur = Colors.SteelBlue;
    		type = TYPE_TUILES.MER;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<mer/>";
    	}
    }
    
    public class Herbe : Tuile
    {
    	public Herbe()
    	{
    		couleur = Colors.Green;
    		type = TYPE_TUILES.HERBE;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<herbe/>";
    	}
    }
    
    public class Foret : Tuile
    {
    	public Foret()
    	{
    		couleur = Colors.OliveDrab;
    		type = TYPE_TUILES.FORET;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<foret/>";
    	}
    }
    
    public class Vide : Tuile
    {
    	public Vide()
    	{
    		type = TYPE_TUILES.EFFACER;
    		couleur = Colors.Black;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<vide/>";
    	}
    }
    
    public class Artefact : Tuile
    {
    	public Artefact(){}
    	
    	public override string ExporterXML()
	    {
    		return "<artefact>Artefact invalide</artefact>";
    	}
    }
    
    public class Bateau : Artefact
    {
    	public Bateau()
    	{
    		couleur = Colors.Wheat;
    		type = TYPE_TUILES.BATEAU;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<bateau/>";
    	}
    }
    
    public class Joyau : Artefact
    {
    	public Joyau()
    	{
    		couleur = Colors.Gold;
    		type = TYPE_TUILES.JOYAU;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<joyau/>";
    	}
    }
    
    public class Epee : Artefact
    {
    	public Epee()
    	{
    		couleur = Colors.Gray;
    		type = TYPE_TUILES.EPEE;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<epee/>";
    	}
    }
}
