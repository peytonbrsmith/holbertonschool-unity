using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public bool isInverted;

    public GameObject yToggle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
        {
            yToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
            isInverted = true;
        }
        else
        {
            yToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
            isInverted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isInverted);
        // Debug.Log(PlayerPrefs.GetInt("invertedY"));
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
        // SceneManager.UnloadSceneAsync("Options");
    }

    public void Apply()
    {
        applyInvertY();
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
    }

    public void ToggleInvert()
    {
        Debug.Log("Toggle Invert");
        isInverted = !isInverted;
    }

    private void applyInvertY()
    {
        if (isInverted)
        {
            PlayerPrefs.SetInt("invertedY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("invertedY", 0);
        }
    }
}
