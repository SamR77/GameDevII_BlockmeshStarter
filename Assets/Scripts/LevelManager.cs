using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
    //TODO: revise script to use level Index instead of name.
    
    public string nextLevelName; // Name of the next level to load
    public Transform spawnPoint; // Transform representing the spawn position

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(nextLevelName);

        // Move the player to the spawn position
        if (spawnPoint != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player
            if (player != null)
            {
                player.transform.position = spawnPoint.position;
                player.transform.rotation = spawnPoint.rotation;
            }
            else
            {
                Debug.LogError("Player not found in the scene.");
            }
        }
        else
        {
            Debug.LogError("Spawn point not assigned.");
        }
    }
}

