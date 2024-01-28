using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;

    public int nextLevelIndex = 0; // Index of the next level to load    


    public void Awake()
    {
        // Find the object in the scene that has a GameManager component
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadNextLevel()
    {        
        // References the total scene count
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (nextLevelIndex >= 0 && nextLevelIndex < sceneCount)
        {
            // Starts listening for message when scene is completed loading.  (OnSceneLoaded() Triggers when the scene is done loading)
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Load the next level using it's index
            SceneManager.LoadScene(nextLevelIndex);
            nextLevelIndex += 1;            
        }
        else
        {
            Debug.LogError("Invalid level index. Ensure the nextLevelIndex is within the range of available scenes.");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unregister the callback to prevent multiple calls        
        SceneManager.sceneLoaded -= OnSceneLoaded;

        _gameManager.SetPlayerToSpawn();

        _gameManager.gameState = GameManager.GameState.Gameplay;
               
    }


}
