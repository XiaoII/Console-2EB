﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int tutorialProgression = 0;

    // Use this for initialization
    void Start() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update() {

    }

    public void Progress()
    {
        if (GameManager.instance.tutorialProgression == 1)
        {
            
            File.AppendAllText("Assets/Resources/emails.txt", "Tutorial@LazySharkGaming.com^Admin@LazySharkGaming.com^Tutorial5^Tutorial5 - Been added by GameManager^" + " \n");
            File.AppendAllText("Assets/Resources/emails.txt", "Tutorial@LazySharkGaming.com^Admin@LazySharkGaming.com^Tutorial6^Tutorial6 is this on a new line?^" + " \n");

            Debug.Log("Text added");
            


        }
    }
    
}
