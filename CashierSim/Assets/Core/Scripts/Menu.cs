using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused;

    private void Start()
    {
        PauseMenu.SetActive(false);
    }
    public void PlayGame()
    {
        Debug.Log("worked");
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();       
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused= true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused= false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
