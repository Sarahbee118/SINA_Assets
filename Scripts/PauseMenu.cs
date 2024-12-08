using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public PlayerInputs playerControls;
    private InputAction pause;
    public GameObject firstSelected;

    private void Awake()
    {
        playerControls = new PlayerInputs(); //Required for new input system. Idek just have it
    }

    private void OnEnable() //Required for new input system
    {


        pause = playerControls.UI.Start; //same but for fire
        pause.Enable();
        pause.performed += Pause; //when pressed, do 
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (!GameIsPaused){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            EventSystem.current.SetSelectedGameObject(firstSelected);
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }
    // Update is called once per frame
        void Update()
    {
        
    }


    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause1 ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlphaMainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
