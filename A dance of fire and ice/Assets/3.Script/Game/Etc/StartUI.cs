using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    private float time;
    private float tickTime;
    private bool isCount;
    private void Awake()
    {
        time = 0;
        isCount = false;
    }

    private void Start()
    {
        tickTime = 60 / GameManager.instance.Bpm;
    }
    void Update()
    {
        if(GameManager.instance.currentGameState == GameState.gameStart && !isCount)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            time += Time.deltaTime;
            if(time >= tickTime && !isCount)
            {
                time -= tickTime;
                transform.GetChild(3).gameObject.SetActive(false);
                StartCoroutine(StartCount_co());
                isCount = true;
            }
        }
    }
    IEnumerator StartCount_co()
    {
        for(int i = 4; i < 8; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds (tickTime);
            transform.GetChild(i).gameObject.SetActive(false);
        }
        GameManager.instance.isStart = true;
    }
}
