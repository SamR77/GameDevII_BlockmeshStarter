using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int nextLevelIndex; // Index of the next level to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (nextLevelIndex >= 0 && nextLevelIndex < sceneCount)
        {
            // Load the next level using its index
            SceneManager.LoadScene(nextLevelIndex);

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

        // Find the spawn point in the loaded scene and move the player
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player
        if (player != null)
        {
            Transform spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform; // Find the spawn point
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.position;
                player.transform.rotation = spawnPoint.rotation;
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
