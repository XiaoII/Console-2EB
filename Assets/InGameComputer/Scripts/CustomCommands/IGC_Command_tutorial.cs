using UnityEngine;
using System.Collections;

public class IGC_Command_tutorial : IGC_Command
{
    public IGC_Command_tutorial(ref IGC_VirtualSystem virtualSystem)
    {
        this.virtualSystem = virtualSystem;
        this.name = "tutorial";
        this.help_text = "Begins the tutorial scenario";
        this.description = "Begins the tutorial scenario";
    }

    public override string command_function()
    {
        string output = "";
        output += "Basics: \n";
        output += "Type 'pwd' to see which directory you are currently in  \n";
        output += "'ls' to show the files/folders in the current folder\n";
        output += "'cd' to change to a directory you specify \n";
        output += "'cat' opens the file you specify\n";
        output += "Use these commands to find and open the file - tutorial2.txt on this PC\n";
        output += "If you get stuck type 'help' and all commands will be explained \n";
        //output += " \n";
        issuer.terminal.shell.EnterViewMode(output);
        return "";
    }
}
