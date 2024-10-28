using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
    
{
    public GameObject skipText;
    public void PlayGame()
    {
        //SFX Confirmation Beep
        SceneManager.LoadScene(SinaManager.Instance.currScreen);
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

    public void fullScreenOn()
    {
        Screen.fullScreen = true;
    }

    public void fullScreenOff()
    {
        Screen.fullScreen = false;
    }

    public void SevenTwentyP() {
        Screen.SetResolution(1280, 720, Screen.fullScreen);
    }

    public void TenEightyP()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void FourK()
    {
        Screen.SetResolution(3840, 2160, Screen.fullScreen);
    }

    public void skip()
    {
        if (skipText.activeSelf == false)
        {
            skipText.SetActive(true);
        }
        else
        {
           SceneManager.LoadScene("AlphaMainMenu");
        }
    }
}
