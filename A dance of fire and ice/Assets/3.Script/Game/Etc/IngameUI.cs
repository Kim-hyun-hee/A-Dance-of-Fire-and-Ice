using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inputAnykey_UI;

    void Update()
    {
        if(GameManager.instance.currentGameState == GameState.loading || GameManager.instance.currentGameState == GameState.inGame)
        {
            inputAnykey_UI.SetActive(true);
        }
        else
        {
            inputAnykey_UI.SetActive(false);
        }
    }
}
