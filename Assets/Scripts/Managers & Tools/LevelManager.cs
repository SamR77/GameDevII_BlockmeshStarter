using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    private CharacterController _characterController;

    public int nextLevelIndex = 0; // Index of the next level to load    
    public int currentLevelIndex = 0;
    public int displaySceneCount = 0;


    public void Awake()
    {
        // Find the object in the scene that has a GameManager component
        _gameManager = FindObjectOfType<GameManager>();        
    }

    void Update()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        displaySceneCount = SceneManager.sceneCountInBuildSettings;
    }



    public void LoadNextLevel()
    {
        // Subscribe to the sceneLoaded event ( OnSceneLoaded() initiates once the scene is completed loading )
        

        // References the total scene count
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        nextLevelIndex += 1;

        if (nextLevelIndex >= 0 && nextLevelIndex < sceneCount-1)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            // Load the next level using it's index
            SceneManager.LoadScene(nextLevelIndex);            
        }
        else if (nextLevelIndex == sceneCount-1)
        {
            SceneManager.LoadScene(nextLevelIndex);
            _gameManager.gameState = GameManager.GameState.GameEnd;
        }

        
        else
        {
            Debug.LogError("Invalid level index. Ensure the nextLevelIndex is within the range of available scenes.");
        }
    }

    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameManager.gameState = GameManager.GameState.Gameplay;
        Debug.Log(_gameManager.gameState);

        _gameManager.MovePlayerToSpawnPosition();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadTitleScreen()
    {        
        SceneManager.LoadScene(0);
        nextLevelIndex = 0;
        _gameManager.gameState = GameManager.GameState.MainMenu;

    }
    




}
