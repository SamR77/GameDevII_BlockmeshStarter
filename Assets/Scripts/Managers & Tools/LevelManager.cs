using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    private CharacterController _characterController;

    public int sceneToLoad = 0; // Index of the next level to load 
    //public int previousLevelIndex = 0; // Index of the next level to load   
    public int currentSceneIndex = 0;
    public int displaySceneCount = 0;

    public void Awake()
    {
        // Find the object in the scene that has a GameManager component
        _gameManager = FindObjectOfType<GameManager>();        
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        displaySceneCount = SceneManager.sceneCountInBuildSettings;
        SceneLoadDebug();
    }

    public void LoadFirstLevel()
    {
        LoadLevel(+1);
    }

    public void LoadLevel(int increment)
    {
        // Starts listening for OnSceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // References the total scene count
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        sceneToLoad = currentSceneIndex += increment;

        if (sceneToLoad >= sceneCount - 1)                          { sceneToLoad = sceneCount - 1; Debug.LogError("Last scene in build order");   }
        else if (sceneToLoad <= 0)                                  { sceneToLoad = 0;              Debug.LogError("First scene in build order");   }        
        else if (sceneToLoad < 0 || sceneToLoad > sceneCount - 1)   { Debug.LogError("Invalid level index. Ensure the nextLevelIndex is within the range of available scenes."); }

        SceneManager.LoadScene(sceneToLoad);

        // if scene to load is "MainMenu" scene(The first of scene of build order)
        if (currentSceneIndex == 0)
        {
            _gameManager.gameState = GameManager.GameState.MainMenu;           
        }

        // if scene to load is a "Gameplay" scene (Not the first or last scene of build order)
        else if (currentSceneIndex > 0 && currentSceneIndex < sceneCount - 1)
        {
            _gameManager.gameState = GameManager.GameState.Gameplay;            
        }

        // if scene to load is a "GameEnd" scene (The last scene of build order)
        else if (currentSceneIndex == sceneCount - 1)
        {
            _gameManager.gameState = GameManager.GameState.GameEnd;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // References the total scene count
        int sceneCount = SceneManager.sceneCountInBuildSettings;            

        _gameManager.MovePlayerToSpawnPosition();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadTitleScreen()
    {        
        SceneManager.LoadScene(0);
        sceneToLoad = 0;
        _gameManager.gameState = GameManager.GameState.MainMenu;
    }

    void SceneLoadDebug()
    {
        if (Input.GetKey(KeyCode.RightBracket))
        {
            Debug.Log("load next level");
            LoadLevel(+1);
        }

        if(Input.GetKey(KeyCode.LeftBracket))
        {
            Debug.Log("load previous level");
            LoadLevel(-1);
        }
    }

}




