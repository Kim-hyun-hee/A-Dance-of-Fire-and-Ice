using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            Debug.Log("�̹� ���� �Ŵ����� �����մϴ�.");
            Destroy(gameObject);   //�̱��� ���ϰ� ����
        }
        //Application.targetFrameRate = 75;
    }
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            instance.SetGameState(GameState.lobi);
        }
        else
        {
            instance.SetGameState(GameState.inGame);
        }
    }
    private void Update()
    {
        if (currentGameState == GameState.gameOver && Input.anyKeyDown) // ���ӿ����ϸ� �ٽ� �����ϱ�
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(currentGameState == GameState.gameClear && Input.anyKeyDown)
        {
            // ���� Ŭ�����ϸ� ���� ���������� �Ѿ��
            if (SceneManager.GetActiveScene().buildIndex < 7)
            {
                LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                LoadScene(0);
            }
        }
        Debug.Log(currentGameState);
    }
    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
        // ���� ��� �̵�
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
