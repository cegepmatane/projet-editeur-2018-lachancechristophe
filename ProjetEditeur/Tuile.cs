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
	
	abstract public class Tuile
    {
		protected Color couleur;
		
    	public virtual string ExporterXML()
	    {
	        return "<tuile>Tuile invalide</tuile>\n";
	    }
    	
    	public Color getCouleur(){ return couleur; }
    }

    public class Plage : Tuile
    {
    	public Plage()
    	{
    		couleur = Colors.Beige;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<plage></plage>";
    	}
    }
    
    public class Mer : Tuile
    {
    	public Mer()
    	{
    		couleur = Colors.DarkBlue;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<mer></mer>";
    	}
    }
    
    public class Herbe : Tuile
    {
    	public Herbe()
    	{
    		couleur = Colors.Green;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<herbe></herbe>";
    	}
    }
    
    public class Foret : Tuile
    {
    	public Foret()
    	{
    		couleur = Colors.DarkGreen;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<foret></foret>";
    	}
    }
    
    public class Vide : Tuile
    {
    	public Vide()
    	{
    		couleur = Colors.Black;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<vide></vide>";
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
    		couleur = Colors.BlanchedAlmond;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<bateau></bateau>";
    	}
    }
    
    public class Joyau : Artefact
    {
    	public Joyau()
    	{
    		couleur = Colors.Gold;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<joyau></joyau>";
    	}
    }
    
    public class Epee : Artefact
    {
    	public Epee()
    	{
    		couleur = Colors.LightGray;
    	}
    	
    	public override string ExporterXML()
	    {
    		return "<epee></epee>";
    	}
    }
}
