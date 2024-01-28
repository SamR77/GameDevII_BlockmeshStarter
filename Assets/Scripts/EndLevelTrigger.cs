using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class EndLevelTrigger : MonoBehaviour
{
      
    public LevelManager _levelManager;

    private void Awake()
    {
        // Find the object in the scene that has a LevelManager component
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            if (_levelManager != null)
            {                
                _levelManager.LoadNextLevel();                
            }
            else
            {
                Debug.LogError("LevelManager not found in the scene");
            }
            
        }
    }


    
     



    
}
