using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        GameManager.instance.isPause = false;
    }

    public void Exit()
    {
        if(SceneManager.GetActiveScene().buildIndex > 0)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            GameManager.instance.isPause = false;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Application.Quit();
        }
    }

    public void Play()
    {
        GameManager.instance.currentGameState = GameManager.instance.preGameState;
        Time.timeScale = 1;
        if (!GameManager.instance.audioSource.isPlaying && GameManager.instance.currentGameState == GameState.gameStart)
        {
            GameManager.instance.audioSource.Play();
        }
        GameManager.instance.isPause = false;
    }
    
    public void PreStage()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        Time.timeScale = 1;
        GameManager.instance.isPause = false;
    }

    public void NextStage()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Time.timeScale = 1;
        GameManager.instance.isPause = false;
    }
}
