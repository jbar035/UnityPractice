using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        showMainMenu();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void showMainMenu()
    {
        Terminal.ClearScreen();
        string menuIntroText = ("Welcome to the main menu\nWhat would you like to hack into?");
        string menuOptions = ("1  - Airport\n2  - Workplace\n3  - Airport\n4 - Exit game");
        Terminal.WriteLine(menuIntroText);
        Terminal.WriteLine(menuOptions);
        Terminal.WriteLine("Enter selection: ");
     
    }

}
