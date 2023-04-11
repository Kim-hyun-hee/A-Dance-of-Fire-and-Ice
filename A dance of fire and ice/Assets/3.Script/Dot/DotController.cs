using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class DotController : MonoBehaviour
{
    [SerializeField] private bool isCenter;
    [SerializeField] private DotController anotherDot; // gameObject�� aroundDot�϶� centerDot
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
            if (isCenter)
            {
                if (!pass)
                {
                    isCenter = false;
                }
                else
                {
                    isCenter = true;
                }
            }
            else if(!isCenter)
            {
                if(!pass)
                {
                    gameObject.transform.position = new Vector2(movePos.x, movePos.y);
                    isCenter = true;
                }
                else
                {
                    isCenter = false;
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
            // Debug.Log("��ģ �� ��ǥ" + col.gameObject.transform.localPosition.x + "  " + col.gameObject.transform.localPosition.y);
            //
            if (col.gameObject.transform.localPosition != anotherDot.transform.position
                && Vector2.Distance(col.gameObject.transform.localPosition, anotherDot.transform.position) < 1.1)
            {
                // Debug.Log("�ѹ� ���͸�" + col.gameObject.transform.localPosition.x + "  " + col.gameObject.transform.localPosition.y);
                
                dist = Vector2.Distance(col.gameObject.transform.localPosition, gameObject.transform.position);
                if (dist < minDist)
                {
                    movePos = new Vector2(col.gameObject.transform.localPosition.x, col.gameObject.transform.localPosition.y);
                    minDist = dist;
                    if(col.gameObject.CompareTag("boundary")) // ���������� ���ŵ� Ÿ�� ���� �޾ƿ�
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
