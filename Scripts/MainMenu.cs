using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        //SFX Confirmation Beep
        SceneManager.LoadScene("TestRoom");
    }

    public void QuitGame()
    {
        //SFX Confirmation Beep
        Application.Quit();
    }

    public void mainMenu()
    {
        //SFX Confirmation Beep
        SceneManager.LoadScene("AlphaMainMenu");
    }
}
