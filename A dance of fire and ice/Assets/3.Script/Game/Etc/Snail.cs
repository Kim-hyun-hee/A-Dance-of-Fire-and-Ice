using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    private G_DotController red;
    private G_DotController blue;
    public float speed;
    private bool isDone;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>().TryGetComponent(out blue);
        isDone = false;
    }
    private void Update()
    {
        if(red.iscenter)
        {
            if(transform.position == red.tiles[red.curIndex].gameObject.transform.localPosition && !isDone)
            {
                GameManager.instance.Bpm = GameManager.instance.Bpm / speed;
                isDone = true;
            }
        }
        if(blue.iscenter)
        {
            if(transform.position == blue.tiles[blue.curIndex].gameObject.transform.localPosition && !isDone)
            {
                GameManager.instance.Bpm = GameManager.instance.Bpm / speed;
                isDone = true;
            }
        }
    }
}
