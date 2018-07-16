using UnityEngine;
using System.Collections;

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

        content = GetText();

        string output = "";
        output += "MootLuck Email Client \n";
        //output += " \n";
        for (int i = 0; i < shell.displayXY[0]; i++) { output += "="; }
        output += "To: " +content[0]+ "\n";
        output += "From: " + content[1] + "\n";
        output += "Subject: " + content[2] + "\n";
        for (int i = 0; i < shell.displayXY[0]; i++) { output += "_"; }
        output += "Message: " + content[3] + "\n";
        for (int i = 0; i < shell.displayXY[0]; i++) { output += "="; }

        issuer.terminal.shell.EnterViewMode(output);
        return "";
    }

    public string[] GetText()
    {
        string[] email = new string[4];
        TextAsset text = Resources.Load("emails") as TextAsset;
        

        return email;
    }
}
