using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.InputSystem;
public class MainMenu : MonoBehaviour
    
{
    private InputAction back;
    public GameObject skipText;
    public PlayerInputs menuControls;
    public TMP_Text version;

    private void Awake() //On game load
    {
        menuControls = new PlayerInputs();
        if (version != null)
        {
            version.text = "Version: " + Application.version.ToString();
        }

    }

   

    private void OnEnable()
    {
        back = menuControls.UI.Cancel;
        back.Enable();
        back.performed += BackToTitle;
        Debug.Log("A");
    }

    private void OnDisable()
    {
        back.Disable();
    }

    private void BackToTitle(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Title");

    }



    public void NewGame()
    {
        SinaManager.Instance.SinaHealth = 6;
        SinaManager.Instance.SinaMaxHealth = 6;
        SinaManager.Instance.SinaMaxAmmo = 0;
        SinaManager.Instance.SinaDirection = 1;
        SinaManager.Instance.SinaAmmo = 0;
        SinaManager.Instance.hasGun = false;
        SinaManager.Instance.hasDash = false;
        SinaManager.Instance.hasPunch2 = false;
        SinaManager.Instance.hasShield = false;
        SinaManager.Instance.hasShrink = false;
        SinaManager.Instance.screenExit = "top";
        SinaManager.Instance.currScreen = "C1";
        SinaManager.Instance.introComplete = false;
    SinaManager.Instance.heart1 = false;
    SinaManager.Instance.heart2 = false;
    SinaManager.Instance.heart3 = false;
    SinaManager.Instance.ammo1 = false;
    SinaManager.Instance.ammo2 = false;
    SinaManager.Instance.ammo3 = false;
    SinaManager.Instance.ammo4 = false;
    SinaManager.Instance.ammo5 = false;
    SceneManager.LoadScene("Cutscene1");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.dataPath + "/Sina.si"))
        {
            string saveFiletxt = File.ReadAllText(Application.dataPath + "/Sina.si");
            Debug.Log(File.ReadAllText(Application.dataPath + "/Sina.si"));
            Debug.Log(saveFiletxt);
            JsonUtility.FromJsonOverwrite(saveFiletxt, SinaManager.Instance);
            
            SceneManager.LoadScene(SinaManager.Instance.currScreen);

        }
        //SFX Confirmation Beep
        
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

    public void fullScreenOn() //fullscreen
    {
        Screen.fullScreen = true;
    }

    public void fullScreenOff()
    {
        Screen.fullScreen = false;
    }

    public void SevenTwentyP() { //sets screen resolutions
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

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void skip()
    {
        if (skipText.activeSelf == false)
        {
            skipText.SetActive(true);
        }
        else
        {
           SceneManager.LoadScene("Title");
        }
    }
}
