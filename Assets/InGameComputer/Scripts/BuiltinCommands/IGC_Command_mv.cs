﻿using UnityEngine;
using System.Collections;

public class IGC_Command_mv : IGC_Command {
	
	public IGC_Command_mv(ref IGC_VirtualSystem virtualSystem)
	{
		this.virtualSystem = virtualSystem;
		this.name = "mv";
		this.usage = "usage: mv <old_file_location> <new_file_location>";
		this.help_text = "use this command to move a file to another location and or change its name.";
		this.description = "move or rename a file";
	}
	
	public override string command_function()
	{
		if(argv.Length != 3){return this.malformed_error+"\n"+this.usage;}

		IGC_FileSystem fs = virtualSystem.fileSystem;

        

		IGC_URL 
			oldURL = fs.ParseURL(argv[1], issuer.cwd),
			newURL = fs.ParseURL(argv[2], issuer.cwd);

		if(!fs.FileExists(oldURL.fullpath)){return "cant move "+argv[1]+" because it doesn't exist";}
        Debug.Log("from " + oldURL.fullpath);
		if(!fs.FileExists(newURL.dirpath)){return "cant move "+argv[1]+" to "+newURL.dirname+" because that directory does not exist.";}
        Debug.Log("to " + newURL.dirpath);
        if (fs.FileExists(newURL.fullpath)){return "new path "+argv[2]+" already exists - have you added the file name to the path?";}
        Debug.Log("to fullpath " + newURL.fullpath);

        IGC_File file = fs.GetFile (oldURL.fullpath);
		IGC_File dir = fs.GetFile (newURL.dirpath);

		if(!fs.CanAccessFile(file, issuer)){return "you do not have permission to edit "+oldURL.fullpath;}
		if(!fs.CanAccessFile(dir, issuer)){return "you do not have permission to access "+newURL.dirname;}

        if (argv[2] == "SVR-01")
        {

        }
        //if svr get gameobject tagged playerserver - move the file from current gameobject to the playerserver gameobject
        //new move file method in FS required, one that takes gameobjects - convert this to extract command?
        fs.MoveFile(oldURL, newURL);

		if(virtualSystem.networkReady){
			fs.GetComponent<NetworkView>().RPC ("MoveFileRPC", RPCMode.Others, oldURL.fullpath, newURL.fullpath);
		}

		return oldURL.filename+" changed to "+newURL.fullpath;
	}
}