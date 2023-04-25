using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class DotController : MonoBehaviour
{
    [SerializeField] private bool isCenter;
    [SerializeField] private DotController anotherDot;
    [SerializeField] private GameObject stage1Ex;
    [SerializeField] private GameObject stage2Ex;
    public bool iscenter => isCenter;
    
    private float dist;
    private float minDist;
    public Vector2Int movePos;
    private bool pass = false;
    
    void Update()
    {
        if (Input.anyKeyDown && GameManager.instance.currentGameState != GameState.pause)
        {
            if(!Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(setPosition_co());
            }
        }
    }
    IEnumerator setPosition_co()
    {
        GetDotNextPos();
        yield return null;
        if (!pass)
        {
            if (isCenter && !anotherDot.pass)
            {
                isCenter = !isCenter;
            }
            else if (!isCenter && !anotherDot.pass)
            {
                if (movePos.x == 13 && movePos.y == -2)
                {
                    stage1Ex.SetActive(true);
                }
                else
                {
                    stage1Ex.SetActive(false);
                }
                if (movePos.x == 20 && movePos.y == -2)
                {
                    stage2Ex.SetActive(true);
                }
                else
                {
                    stage2Ex.SetActive(false);
                }
                if (movePos.x == 13 && movePos.y == -1)
                {
                    GameManager.instance.LoadScene(1);
                    gameObject.transform.position = new Vector2(movePos.x, movePos.y);
                    isCenter = !isCenter;
                }
                else
                {
                    gameObject.transform.position = new Vector2(movePos.x, movePos.y);
                    isCenter = !isCenter;
                }
            }
        }
        yield return null;
    
    }

    private void GetDotNextPos()
    {
        minDist = 2f;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), 0.32f))
        {
            if (col.gameObject.transform.localPosition != anotherDot.transform.position
                && Vector2.Distance(col.gameObject.transform.localPosition, anotherDot.transform.position) < 1.1)
            {
                dist = Vector2.Distance(col.gameObject.transform.localPosition, gameObject.transform.position);
                if (dist < minDist)
                {
                    movePos = new Vector2Int((int)col.gameObject.transform.localPosition.x, (int)col.gameObject.transform.localPosition.y);
                    minDist = dist;
                    if (col.gameObject.CompareTag("boundary"))
                    {
                        pass = true;
                    }
                    else
                    {
                        pass = false;
                    }
                }
            }
        }
    }
}