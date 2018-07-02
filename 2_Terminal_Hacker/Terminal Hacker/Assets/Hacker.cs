using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game config data
    const string menuHint = "You may type 'menu' at any time.";
    string[] level1Passwords = { "plane", "pilot", "lounge", "flying" };
    string[] level2Passwords = { "Stan", "Kyle", "Kenny", "Cartman" };
    string[] level3Passwords = { "food", "bartender", "garden", "beer" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Airport");
        Terminal.WriteLine("Press 2 for South Park Studios");
        Terminal.WriteLine("Press 3 for the Pub!");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }


    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Take to the skies...");
                Terminal.WriteLine(@"

           __!__
       _____(_)_____
          !  !  !
"
                );
                break;
            case 2:
                Terminal.WriteLine("YOU KILLED KENNY, YOU BASTARD!!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
 
    .- <O> -.        .-====-.      ,-------.      .-=<>=-.
   /_-\'''/-_\      / / '' \ \     |,-----.|     /__----__\
  |/  o) (o  \|    | | ')(' | |   /,'-----'.\   |/ (')(') \|
   \   ._.   /      \ \    / /   {_/(') (')\_}   \   __   /
   ,>-_,,,_-<.       >'=jf='<     `.   _   .'    ,'--__--'.
 /      .      \    /        \     /'-___-'\    /    :|    \
(_)     .     (_)  /          \   /         \  (_)   :|   (_)
 \_-----'____--/  (_)        (_) (_)_______(_)   |___:|____|
  \___________/     |________|     \_______/     |_________|        
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
 _____   _____   _____   _____    _____  
|  _  \ | ____| | ____| |  _  \  /  ___/ 
| |_| | | |__   | |__   | |_| |  | |___  
|  _  { |  __|  |  __|  |  _  /  \___  \ 
| |_| | | |___  | |___  | | \ \   ___| | 
|_____/ |_____| |_____| |_|  \_\ /_____/ 
"
                );
                Terminal.WriteLine("Beers on you, smartass!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
