using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_MovementDot : MonoBehaviour
{
    private G_DotController red;
    private G_DotController blue;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>().TryGetComponent(out blue);
    }
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.gameStart || GameManager.instance.currentGameState == GameState.gameClear || GameManager.instance.currentGameState == GameState.gameOver)
        {
            if (red.iscenter)
            {
                blue.transform.RotateAround(red.transform.position, new Vector3(0, 0, -1), (90 * Time.deltaTime * GameManager.instance.Bpm) / 60);
            }
            else if (blue.iscenter)
            {
                red.transform.RotateAround(blue.transform.position, new Vector3(0, 0, -1), (90 * Time.deltaTime * GameManager.instance.Bpm) / 60);
            }
        }
    }
}
