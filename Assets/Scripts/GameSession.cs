using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] public float gameScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject resumeButton;

    void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    void Update()
    {
        scoreText.text = gameScore.ToString("F0");
        PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menuButton.SetActive(!menuButton.activeInHierarchy);
            resumeButton.SetActive(!resumeButton.activeInHierarchy);
        }
    }
    
}
