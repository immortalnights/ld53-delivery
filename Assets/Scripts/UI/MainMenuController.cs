using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void HandleNewGameClick()
    {
        // newGameEvent.RaiseEvent();
        SceneManager.LoadScene("Gameplay");
    }

    public void HandleExitClick()
    {
        Application.Quit();
    }
}
