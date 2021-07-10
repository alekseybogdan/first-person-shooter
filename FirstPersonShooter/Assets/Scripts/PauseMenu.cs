using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public MouseLook mouseLook;
    public AudioSource ambience;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        PauseGame(false);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        PauseGame(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            mouseLook.enabled = false;
            ambience.Pause();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            isGamePaused = true;
        }
        else
        {
            mouseLook.enabled = true;
            ambience.Play();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }
}
