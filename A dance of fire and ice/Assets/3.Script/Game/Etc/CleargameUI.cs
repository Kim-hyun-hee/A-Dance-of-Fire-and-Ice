using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleargameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject congratuation_UI;

    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.gameClear)
        {
            congratuation_UI.SetActive(true);
        }
        else
        {
            congratuation_UI.SetActive(false);
        }
    }
}
