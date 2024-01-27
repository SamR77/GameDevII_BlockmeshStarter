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
        //SceneManager.sceneLoaded += OnSceneLoaded;

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
            // maybe move some of these into their own methods...

            case GameState.MainMenu:

                _uIManager.UIMainMenu();

                if (Time.timeScale != 1f) { Debug.LogError("ERROR: timeScale not set to 1!"); }

                // TODO: Add logic
                // Show mouse cursor
                // buttons to:
                // - Play Game (load next level)
                // - Quit Game (application quit)

                break;


        

            case GameState.Gameplay:
                                
                _uIManager.UIGameplay();

                if(Time.timeScale != 1f)    {   Debug.LogError("ERROR: timeScale not set to 1!");   }

                // TODO: Add logic
                // set a warning debug to check if timescale has been properly reset
                // hide Mouse Cursor
                // UI display for:
                // - Level X/X...   Example: Level 1/3
                // - levelname...   Example: IcyPassage


                if (Input.GetKeyDown(KeyCode.Escape))
                    {                    
                    gameState = GameState.Paused;
                    Time.timeScale = 0f;
                    }

                // Esc button will trigger pause:
                // - Set timeScale to 0f
                // - switch to paused state

                break;                          

            case GameState.Paused:
                
                _uIManager.UIPaused();

                if (Time.timeScale != 0f) { Debug.LogError("ERROR: timeScale not set to 0 during Pause screen!"); }

                // TODO: Add logic
                // Show mouse cursor
                // ESC button will unpause and resume gameplay (do we have enough logic that it's worth breaking out into a seperate method?)
                // buttons to:
                // - Return to game (unpause)
                // - Return to Main menu (load main menu)
          

                break;


          

            case GameState.GameEnd:
                _uIManager.UIGameEnd();

                if (Time.timeScale != 0f) { Debug.LogError("ERROR: timeScale not set to 0!"); }

                // TODO: Add logic
                // Show mouse cursor
                // Buttons on screen to quit game or return to main menu

                break;


        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unregister the callback to prevent multiple calls
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Update things in the current scene after it's done loading...
    }


    public void StartGame()
    { 
        // used for PLAY button to loads the next level
        // and performs any other level prep
    }

    public void ResetPlayer()
    { 
        // used to reset player to spawn position, on level load as well as if the player were to fall off the game world into player catcher trigger
    
    }

    public void UnPause()
    {
        // Unpauses the game... 
        Time.timeScale = 1f;
    }


    /*

    void SwitchCanvas(Canvas canvas)
    {
        DisableAllCanvases();
        canvas.enabled = true;
    }

    void DisableAllCanvases()
    {
        MainMenu.enabled = false;
        Gameplay.enabled = false;
        Paused.enabled = false;
        GameEnd.enabled = false;
    }

    */



}
