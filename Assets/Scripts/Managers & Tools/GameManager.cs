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
    private CharacterController _characterController;

    public enum GameState { MainMenu, Gameplay, Paused, GameEnd }

    public GameState gameState;
    
    public GameObject spawnPoint;
    public GameObject player;
    public FirstPersonController_Sam _fpsControllerScript;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player = GameObject.FindGameObjectWithTag("Player");

        gameState = GameState.MainMenu;        

        // Find the object in the scene that has a LevelManager component
        _levelManager = FindObjectOfType<LevelManager>();

        // Find the object in the scene that has a UIManager component
        _uIManager = FindObjectOfType<UIManager>();

        // Find the object in the scene that has a CharacterController component
        _characterController = FindObjectOfType<CharacterController>();        
        _fpsControllerScript = FindObjectOfType<FirstPersonController_Sam>();
    }

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

    # region Gamestate Logic

    private void MainMenu()
    {
        Time.timeScale = 1f;
        _uIManager.UIMainMenu();
        Cursor.visible = true;
    }

    private void Gameplay()
    {
        Time.timeScale = 1f;
        _uIManager.UIGameplay();

        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = GameState.Paused;            
        }
    }

    private void Paused()
    {
        Time.timeScale = 0f;
        _fpsControllerScript.enabled = false;

        _uIManager.UIPaused();        

        Cursor.visible = true;        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnPause();
        }
    }

    private void GameEnd()
    {
        _uIManager.UIGameEnd();
        Time.timeScale = 1f;
        Cursor.visible = true;
        // Buttons on screen to quit game or return to main menu
    }

    #endregion

    public void UnPause()
    {
        _fpsControllerScript.enabled = true;

        gameState = GameState.Gameplay;
        
        Cursor.visible = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void MovePlayerToSpawnPosition()
    {
        spawnPoint = GameObject.FindWithTag("SpawnPoint");

        _characterController.enabled = false;
        player.transform.position = spawnPoint.transform.position;
        player.transform.rotation = spawnPoint.transform.rotation;
        _characterController.enabled = true;        
    }

   


}



