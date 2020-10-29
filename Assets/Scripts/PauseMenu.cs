using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject resumeButton;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        mainMenuButton.SetActive(false);
        resumeButton.SetActive(false);
    }
}
