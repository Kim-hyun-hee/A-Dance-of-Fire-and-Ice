using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public float Bpm;
    private float time;
    private float tickTime;
    private bool isCount;

    private void Awake()
    {
        time = 0;
        isCount = false;
        tickTime = 60 / Bpm;
    }
    void Update()
    {
        if(GameManager.instance.currentGameState == GameState.gameStart)
        {
            time += Time.deltaTime;
            if(time >= tickTime && !isCount)
            {
                time -= tickTime;
                StartCoroutine(StartCount_co());
                isCount = true;
            }
        }
    }
    IEnumerator StartCount_co()
    {
        for(int i = 0; i < 4; i++)
        {
            Debug.Log(i+1);
            yield return new WaitForSeconds (tickTime);
        }
    }
}
