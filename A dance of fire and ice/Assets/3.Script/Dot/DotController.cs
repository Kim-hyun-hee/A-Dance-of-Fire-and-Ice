using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class DotController : MonoBehaviour
{
    [SerializeField] private bool isCenter;
    [SerializeField] private DotController anotherDot; // gameObject가 aroundDot일때 centerDot
    public bool iscenter => isCenter;
    private float dist;
    private float minDist;
    private Vector2 movePos;
    private bool pass = false;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SetDotNextPos();
            //var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            //var type = assembly.GetType("UnityEditor.LogEntries");
            //var method = type.GetMethod("Clear");
            //method.Invoke(new object(), null);

            //Debug.Log(gameObject.tag + " isCenter : " + isCenter);
            //Debug.Log(gameObject.tag + " pass : " + pass);
            //Debug.Log(gameObject.tag + " anotherpass : " + anotherDot.pass);
            if (!pass)
            {
                if (isCenter && !anotherDot.pass)
                {
                    isCenter = !isCenter;
                    Debug.Log(gameObject.tag + " : 1");
                }
                else if (!isCenter && !anotherDot.pass)
                {
                    gameObject.transform.position = new Vector2(movePos.x, movePos.y);
                    isCenter = !isCenter;
                    Debug.Log(gameObject.tag + " : 2");
                }
                else if (isCenter && anotherDot.pass)
                {
                    Debug.Log(gameObject.tag + " : 3");
                }
            }
            else if (pass) // 파란공이 center일때 여기가 안됨
            {
                if (!isCenter && !anotherDot.pass)
                {
                    Debug.Log(gameObject.tag + " : 4");
                }
            }
        }
    }
    private void SetDotNextPos()
    {
        minDist = 2f;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), 0.32f))
        {
            // Debug.Log
            // Debug.Log("겹친 블럭 좌표" + col.gameObject.transform.localPosition.x + "  " + col.gameObject.transform.localPosition.y);
            //
            if (col.gameObject.transform.localPosition != anotherDot.transform.position
                && Vector2.Distance(col.gameObject.transform.localPosition, anotherDot.transform.position) < 1.1)
            {
                // Debug.Log("한번 필터링" + col.gameObject.transform.localPosition.x + "  " + col.gameObject.transform.localPosition.y);

                dist = Vector2.Distance(col.gameObject.transform.localPosition, gameObject.transform.position);
                if (dist < minDist)
                {
                    movePos = new Vector2(col.gameObject.transform.localPosition.x, col.gameObject.transform.localPosition.y);
                    minDist = dist;
                    if (col.gameObject.CompareTag("boundary")) // 마지막으로 갱신된 타일 정보 받아옴
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