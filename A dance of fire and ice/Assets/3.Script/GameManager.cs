using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    lobi,
    inGame,
    gameStart,
    gameClear,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log("이미 게임 매니저는 존재합니다.");
            Destroy(gameObject);   //싱글톤 편하게 구현
        }
        //Application.targetFrameRate = 75;
    }
    private void Start()
    {
        currentGameState = GameState.lobi;
    }
    private void Update()
    {
        if (currentGameState == GameState.gameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.instance.SetGameState(GameState.inGame);
        }

        if(currentGameState == GameState.gameClear && Input.anyKeyDown)
        {
            // 다음 스테이지로 넘어가기
            if (SceneManager.GetActiveScene().buildIndex < 7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                SceneManager.LoadScene(1); 
            }
        }
        Debug.Log(currentGameState);
    }
    public void StartGame()
    {
        SetGameState(GameState.gameStart);
    }
    public void ClearGame()
    {

    }
    public void EndGame()
    {

    }

    public void SetGameState (GameState newGameState)
    {
        if(newGameState == GameState.lobi)
        {

        }
        else if(newGameState == GameState.inGame)
        {

        }
        else if(newGameState == GameState.gameStart)
        {

        }
        else if (newGameState == GameState.gameClear)
        {

        }
        else if(newGameState == GameState.gameOver)
        {

        }
        currentGameState = newGameState;
    }
}
