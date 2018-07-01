using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game config data
    string[] lvl1Passwords = { "plane", "pilot", "lounge", "flying" };
    string[] lvl2Passwords = { "airconditioning", "employee", "computer", "coding" };
    string[] lvl3Passwords = { "food", "bartender", "garden", "beer" };

    int level;
    string password;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        string menuIntroText = ("Welcome to the main menu\nWhat would you like to hack into?");
        string menuOptions = ("1  - Airport\n2  - Workplace\n3  - Pub\n4  - Exit game");
        Terminal.WriteLine(menuIntroText);
        Terminal.WriteLine(menuOptions);
        Terminal.WriteLine("Enter selection: ");
    }
    // TODO add case for input = 4
    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                Terminal.WriteLine("You chose 1, Airport");
                password = lvl1Passwords[1];
                StartGame();
                break;
            case "2":
                Terminal.WriteLine("You chose 2, Workplace");
                password = lvl2Passwords[1];
                StartGame();
                break;
            case "3":
                Terminal.WriteLine("You chose 3, Pub");
                password = lvl3Passwords[1];
                StartGame();
                break;
            default:
                Terminal.WriteLine("Please enter a valid input");
                break;
        }
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go to main menu
        {
            ShowMainMenu();
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

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well done! You won!");
        }
        else
        {
            Terminal.WriteLine("Incorrect!");

        }

    }

}
