using UnityEngine;
using System.Collections;
using System.IO;

public class IGC_Command_email : IGC_Command
{
    public IGC_Command_email(ref IGC_VirtualSystem virtualSystem)
    {
        this.virtualSystem = virtualSystem;
        this.name = "email";
        this.help_text = "Usage: <email> ";
        this.description = "Loads specified users emails";
    }

    public override string command_function()
    {
        IGC_Shell shell = issuer.terminal.shell;
        IGC_Language lang = virtualSystem.language;
        string[] content = new string[4];
        int numberOfEmails = 0;
        

        //content = GetText();

        numberOfEmails = GetNumberOfEmails();

        string output = "";
        output += "MootLuck Email Client \n";
        for (int i = 0; i < shell.displayXY[0]; i++) { output += "="; }
        //output += " \n";


        if (numberOfEmails == 0)
        {
            for (int i = 0; i < shell.displayXY[0]; i++) { output += "~"; }
            output += " You have no emails to read \n";
            for (int i = 0; i < shell.displayXY[0]; i++) { output += "_"; }
            return output;
        }
        else
        {
            for (int j = 0; j < numberOfEmails; j++)
            {
                content = GetText(j);
                output += "To: " + content[0] + "\n";
                output += "From: " + content[1] + "\n";
                output += "Subject: " + content[2] + "\n";
                //for (int i = 0; i < shell.displayXY[0]; i++) { output += "_"; }
                output += "Message: " + content[3] + "\n";
                for (int i = 0; i < shell.displayXY[0]; i++) { output += "="; }

                issuer.terminal.shell.EnterViewMode(output);
                
            }
            return "";
        }
    }

    public string[] GetText(int line)
    {
        string[] emailContent = new string[4];
        int numberOfEmails = 0;
        numberOfEmails = GetNumberOfEmails();

        //TextAsset text = Resources.Load("emails") as TextAsset;
        
        

        //get number of emails first, then define the array based on that number
        
        string[] emailLine = new string[numberOfEmails];
        
        string[] text = File.ReadAllLines("Assets/Resources/emails.txt");
        
        
        
        
        emailContent = text[line].ToString().Split('^');
        
        //get each line as email
        //split line into parts of email

        //emails = text.ToString().Split('^');
        
        return emailContent;
    }

    public int GetNumberOfEmails()
    {
        int numberOfEmails = 0;
        string[] readText = File.ReadAllLines("Assets/Resources/emails.txt");
        numberOfEmails = readText.Length;
        //Debug.Log(readText.Length);
        //TextAsset text = Resources.Load("emails") as TextAsset;
        //numberOfEmails = readText.ToString().Split('\n').Length-1;
        //Debug.Log("Get number of emails = " + numberOfEmails);

        return numberOfEmails;
    }
}
