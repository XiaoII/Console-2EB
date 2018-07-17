using UnityEngine;
using System.Collections;

public class IGC_Command_extract : IGC_Command
{
    public IGC_Command_extract(ref IGC_VirtualSystem virtualSystem)
    {
        this.virtualSystem = virtualSystem;
        this.name = "extract";
        this.help_text = "usage: extract <Filename> <Destination server IP>";
        this.description = "Move files between machines";
    }

    public override string command_function()
    {
        if (argv.Length != 3) { return this.malformed_error + "\n" + this.usage; }
        else
            GameManager.instance.tutorialProgression = 1;
        //Debug.Log(GameManager.instance.tutorialProgression);
        GameManager.instance.Progress();
        return "file moved";
    }
}
