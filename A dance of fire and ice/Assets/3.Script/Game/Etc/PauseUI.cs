using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private GameObject pause_UI;
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.pause)
        {
            pause_UI.SetActive(true);
            for (int i = 9; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            pause_UI.SetActive(false);
            for (int i = 9; i < transform.childCount; i++) 
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
