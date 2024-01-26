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
        Debug.Log("Scene change initiated");
        
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (nextLevelIndex >= 0 && nextLevelIndex < sceneCount)
        {
            // Load the next level using it's index
            SceneManager.LoadScene(nextLevelIndex);

            nextLevelIndex += 1;

            // Register a callback for the scene being loaded
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Debug.LogError("Invalid level index. Ensure the nextLevelIndex is within the range of available scenes.");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unregister the callback to prevent multiple calls
        SceneManager.sceneLoaded -= OnSceneLoaded;

        //TODO: Move reset player to spawn into GameManager... *** Actually this whole method can be moved to the GameManager


        // Find the spawn point in the loaded scene and move the player
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player
        if (player != null)
        {
            Transform spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform; // Find the spawn point
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.position;
                player.transform.rotation = spawnPoint.rotation;
                Debug.Log("player moved to spawn position");
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
