/*
 * Created by SharpDevelop.
 * User: 0838660
 * Date: 2018-10-02
 * Time: 16:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ProjetEditeur
{
	/// <summary>
	/// Description of EditeurDAO.
	/// </summary>
	public class EditeurDAO
	{
		Controlleur ctrl;
		public EditeurDAO(Controlleur ctrlInput)
		{
			ctrl = ctrlInput;
		}
		
		public void SauvegarderXML(String exportXML){
			SaveFileDialog dialogueSauvegarde = new SaveFileDialog();  
		   	dialogueSauvegarde.Filter = "Carte|*.xml";  
		   	dialogueSauvegarde.Title = "Sauvegarder la carte en format XML";  
		   	dialogueSauvegarde.ShowDialog();  
		
		   	// If the file name is not an empty string open it for saving.  
		   	if(dialogueSauvegarde.FileName != "")  
		   	{
		   		File.WriteAllText(dialogueSauvegarde.FileName, exportXML);
		   	}
		}
		
		public List<Tuile> ChargerXML()
		{
		
			OpenFileDialog dialogueCharger = new OpenFileDialog();
			dialogueCharger.Filter = "Carte|*.xml";
			dialogueCharger.Title = "Charger la carte en format XML";  
			do 
			{
				dialogueCharger.ShowDialog();
			}	while(dialogueCharger.FileName == "") ;

			Parser ps = Parser.getInstance();
			List<Tuile> lst =
				ps.parserListeTuileXML(
					File.ReadAllText(
						dialogueCharger.FileName));
			
			return lst;
		}
	}
}
