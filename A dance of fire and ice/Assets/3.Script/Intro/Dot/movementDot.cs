using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementDot : MonoBehaviour
{
    private DotController red;
    private DotController blue;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>().TryGetComponent(out blue);
    }
    void Update()
    {
        if (red.iscenter && GameManager.instance.currentGameState == GameState.lobi)
        {
            blue.transform.RotateAround(red.transform.position, new Vector3(0, 0, -1), (90 * Time.deltaTime * GameManager.instance.Bpm) / 60);
        }
        else if (blue.iscenter && GameManager.instance.currentGameState == GameState.lobi)
        {
            red.transform.RotateAround(blue.transform.position, new Vector3(0, 0, -1), (90 * Time.deltaTime * GameManager.instance.Bpm) / 60);
        }
    }

}
