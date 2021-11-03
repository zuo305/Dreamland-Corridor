using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameStatus{ 
    MenuStatus,
    GamingStatus,
}
public class GameManager : MonoBehaviour
{
    public MainMenu mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.StartGameEvent += StartGame;
    }

    private void StartGame(object sender, EventArgs args)
    {
        GameStatusSwitcher(GameStatus.GamingStatus);
    }

    private void GameStatusSwitcher(GameStatus status) {
        switch (status) {
            case GameStatus.GamingStatus:
                SceneManager.LoadScene("Level1");
                break;
            case GameStatus.MenuStatus:
                break;
            default:
                break;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
