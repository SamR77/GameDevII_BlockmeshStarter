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
        if (other.gameObject.CompareTag("Player"))
        {
            _levelManager.LoadLevel(+1);
        }     
    }
    
}
