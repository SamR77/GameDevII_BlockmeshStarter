using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class GameManager : MonoBehaviour
{
    private LevelManager _levelManager;
    private UIManager _uIManager;

    public enum GameState { MainMenu, Gameplay, Paused, GameEnd }

    public GameState gameState;

    public Transform spawnPoint;
    public Transform player;







    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

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
            case GameState.MainMenu:    MainMenu(); break;
            case GameState.Gameplay:    Gameplay(); break;
            case GameState.Paused:      Paused();   break;
            case GameState.GameEnd:     GameEnd();  break;
        }
    }


    private void MainMenu()
    {
        Time.timeScale = 1f;
        _uIManager.UIMainMenu();
        Cursor.visible = true;

        //if (Time.timeScale != 1f) { Debug.LogError("ERROR: timeScale not set to 1! game still paused."); }


    }


    private void Gameplay()
    {
        Time.timeScale = 1f;
        _uIManager.UIGameplay();

        //if (Time.timeScale != 1f) { Debug.LogError("ERROR: timeScale not set to 1! game still paused."); }

        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = GameState.Paused;
            
        }

    }

    private void Paused()
    {
        Time.timeScale = 0f;
        _uIManager.UIPaused();        

        //if (Time.timeScale != 0f) { Debug.LogError("ERROR: timeScale not set to 0 during Pause screen! Game is NOT paused."); }

        Cursor.visible = true;

        // buttons to:
        // - Return to game (unpause)
        // - Return to Main menu (load main menu)

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnPause();
        }
    }

    public void UnPause()
    {           
        gameState = GameState.Gameplay;
    }

    private void GameEnd()
    {
        _uIManager.UIGameEnd();
        Time.timeScale = 1f;   
        Cursor.visible = true;
        // Buttons on screen to quit game or return to main menu
    }






    public void LoadNextLevel()
    {             
        _levelManager.LoadNextLevel();       
    }

    public void QuitGame()
    {
        // Closes game back to windows
        Application.Quit();
    }

    public void SetPlayerToSpawn()
    {
        // Find the spawn point in the loaded scene and move the player
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player

        if (player != null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform; // Find the spawn point
            if (spawnPoint != null)
            {
                Debug.Log(spawnPoint.localPosition);
                player.transform.localPosition = spawnPoint.transform.localPosition;
                player.transform.rotation = spawnPoint.transform.rotation;
                Debug.Log("player moved to spawn position: " + spawnPoint.localPosition);                
            }
            else
            {
                Debug.LogWarning("Spawn point not found in the loaded scene. Player's position is unchanged.");
            }
        }
        else
        {
            Debug.LogError("Player not found in the loaded scene.");
        }
    }

 



}
