using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024

public class UIManager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject gameplayUI;
    public GameObject pausedUI;
    public GameObject gameEndUI;



    public void UIMainMenu()
    {
        MainMenuUI.SetActive(true);        
        pausedUI.SetActive(false);
        gameEndUI.SetActive(false);
    }

    public void UIGameplay()
    {
        MainMenuUI.SetActive(false);        
        pausedUI.SetActive(false);
        gameEndUI.SetActive(false);
    }

    public void UIPaused()
    {
        MainMenuUI.SetActive(false);       
        pausedUI.SetActive(true);
        gameEndUI.SetActive(false); 
    }

    public void UIGameEnd()
    {
        MainMenuUI.SetActive(false);        
        pausedUI.SetActive(false);
        gameEndUI.SetActive(true);
    }


}
