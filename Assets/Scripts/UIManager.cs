using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024

public class UIManager : MonoBehaviour
{
    public Canvas canvasMainMenu;
    public Canvas canvasGameplay;
    public Canvas canvasPaused;
    public Canvas canvasGameEnd;



    public void UIMainMenu()
    {
        canvasMainMenu.enabled = true;
        canvasGameplay.enabled = false;
        canvasPaused.enabled = false;
        canvasGameEnd.enabled = false;
    }

    public void UIGameplay()
    {
        canvasMainMenu.enabled = false;
        canvasGameplay.enabled = true;
        canvasPaused.enabled = false;
        canvasGameEnd.enabled = false;
    }

    public void UIPaused()
    {
        canvasMainMenu.enabled = false;
        canvasGameplay.enabled = false;
        canvasPaused.enabled = true;
        canvasGameEnd.enabled = false;
    }

    public void UIGameEnd()
    {
        canvasMainMenu.enabled = false;
        canvasGameplay.enabled = false;
        canvasPaused.enabled = false;
        canvasGameEnd.enabled = true;
    }


}
