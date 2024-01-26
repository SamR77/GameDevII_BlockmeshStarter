using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class GameManager : MonoBehaviour
{

    private LevelManager _levelManager;
    private UIManager _uIManager;



    public enum GameState { MainMenu, Gameplay, Paused, GameEnd }

    private GameState gameState;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Find the object in the scene that has a LevelManager component
        _levelManager = FindObjectOfType<LevelManager>();

        // Find the object in the scene that has a UIManager component
        _uIManager = FindObjectOfType<UIManager>(); 
    }


    

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            // What's active during Main Menu

            case GameState.MainMenu:
                //do a thing;
                //do another thing;
                //do another thing;
                break;


            // What's active during Gameplay

            case GameState.Gameplay:
                //do a thing;
                //do another thing;
                //do another thing;
                break;


            // What's active during Pause menu

            case GameState.Paused:
                //do a thing;
                //do another thing;
                //do another thing;
                break;


            // What's active during Game End Screen

            case GameState.GameEnd:
                //do a thing;
                //do another thing;
                //do another thing;
                break;


        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unregister the callback to prevent multiple calls
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Update things in the current scene after it's done loading...
    }




}
