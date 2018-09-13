/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-09-11
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of Tuiles.
	/// </summary>
	
	abstract public class Tuile
    {
    	public virtual string ExporterXML()
	    {
	        return "<tuile>Tuile invalide</tuile>\n";
	    }
    }

    public class Plage : Tuile
    {
    	public Plage(){}
    	
    	public override string ExporterXML()
	    {
    		return "<tuile>plage</tuile>";
    	}
    }
    
    public class Mer : Tuile
    {
    	public Mer(){}
    	
    	public override string ExporterXML()
	    {
    		return "<tuile>mer</tuile>";
    	}
    }
    
    public class Herbe : Tuile
    {
    	public Herbe(){}
    	
    	public override string ExporterXML()
	    {
    		return "<tuile>herbe</tuile>";
    	}
    }
    
    public class Foret : Tuile
    {
    	public Foret(){}
    	
    	public override string ExporterXML()
	    {
    		return "<tuile>foret</tuile>";
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
    	public Bateau(){}
    	
    	public override string ExporterXML()
	    {
    		return "<artefact>bateau</artefact>";
    	}
    }
    
    public class Joyau : Artefact
    {
    	public Joyau(){}
    	
    	public override string ExporterXML()
	    {
    		return "<artefact>joyau</artefact>";
    	}
    }
    
    public class Epee : Artefact
    {
    	public Epee(){}
    	
    	public override string ExporterXML()
	    {
    		return "<artefact>epee</artefact>";
    	}
    }
}
