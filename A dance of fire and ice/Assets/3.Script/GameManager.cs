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
    gameOver,
    loading,
    pause
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState;
    public GameState preGameState;
    public AudioSource audioSource;
    public ScreenEff screenEff;
    public bool isPause;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("이미 게임 매니저는 존재합니다.");
            Destroy(gameObject);   //싱글톤 편하게 구현
        }
        //Application.targetFrameRate = 75;
    }
    private void Start()
    {
        TryGetComponent(out audioSource);
        FindObjectOfType<ScreenEff>().TryGetComponent(out screenEff);
        StartCoroutine(screenEff.Move_co());
        isPause = false;
    }
    private void Update()
    {
        if (currentGameState == GameState.gameOver && Input.anyKeyDown) // 게임오버하면 다시 시작하기
        {
            if(!Input.GetKeyDown(KeyCode.Escape))
            {
                LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(currentGameState == GameState.gameClear && Input.anyKeyDown)
        {
            if(!Input.GetKeyDown(KeyCode.Escape))
            {
                // 게임 클리어하면 다음 스테이지로 넘어가기
                if (SceneManager.GetActiveScene().buildIndex < 7)
                {
                    LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if (SceneManager.GetActiveScene().buildIndex == 7)
                {
                    LoadScene(0);
                }
            }
        }
        Debug.Log(currentGameState);

        if(Input.GetKeyDown(KeyCode.Escape) && currentGameState != GameState.loading) // 일시정지
        {
            if(isPause == false)
            {
                preGameState = currentGameState;
                SetGameState(GameState.pause);
                Time.timeScale = 0;
                if(instance.audioSource.isPlaying)
                {
                    instance.audioSource.Pause();
                }
                isPause = true;
                return;
            }

            if(isPause == true)
            {
                currentGameState = preGameState;
                Time.timeScale = 1;
                if (!instance.audioSource.isPlaying && currentGameState == GameState.gameStart)
                {
                    instance.audioSource.Play();
                }
                isPause = false;
                return;
            }
        }
    }
    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
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
            if (!instance.audioSource.isPlaying)
            {
                instance.audioSource.Play();
            }
        }
        else if (newGameState == GameState.gameClear)
        {

        }
        else if(newGameState == GameState.gameOver)
        {
            if (audioSource.isPlaying)
            {
                instance.audioSource.Stop();
            }
            // 게임 씬 7 일때만 게임 오버 파티클                         
        }
        currentGameState = newGameState;
    }
}
