using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenEff : MonoBehaviour
{
    private RectTransform UItransform;
    public float moveSpeed;
    public Vector3 moveDirection = Vector3.zero;
    private void Awake()
    {
        UItransform = GetComponent<RectTransform>();
    }
   
    public IEnumerator Move_co()
    {
        GameManager.instance.SetGameState(GameState.loading);
        while (true)
        {
            if (UItransform.transform.position.x < -3000)
            {
                break;
            }
            UItransform.transform.position += moveDirection * moveSpeed;
            yield return 0.01f;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameManager.instance.SetGameState(GameState.lobi);
        }
        else
        {
            GameManager.instance.SetGameState(GameState.inGame);
        }
    }
}
