using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{

    private bool pauseState = false;
    private Timer timer;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("lastSceneName", SceneManager.GetActiveScene().name);
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        pauseState = true;
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
        pauseMenu.SetActive(true);
        timer.PauseTimer();
        Time.timeScale = 0;
        // SceneManager.LoadSceneAsync("Paused", LoadSceneMode.Additive);
    }

    public void Resume()
    {
        pauseState = false;
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().OnApplicationFocus(true);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(true);
        // SceneManager.UnloadSceneAsync("Paused");
        pauseMenu.SetActive(false);
        timer.Start();
        Time.timeScale = 1;
    }

    // get unity input pause
    public void OnPause(InputValue value)
    {
        if (value.isPressed && !pauseState)
        {
            Pause();
        }
        else if (value.isPressed && pauseState)
        {
            Resume();
        }
    }

    public void OnRestart(InputValue value)
    {
        if (value.isPressed)
        {
            Restart();
        }
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
    }

    public void MainMenu()
    {
        Resume();
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // private void OnApplicationFocus(bool hasFocus)
    // {
    //     SetCursorState(cursorLocked);
    // }

    // private void SetCursorState(bool newState)
    // {
    //     Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    // }
}
