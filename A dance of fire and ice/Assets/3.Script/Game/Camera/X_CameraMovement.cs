using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_CameraMovement : MonoBehaviour
{
    private G_DotController red;
    private G_DotController blue;
    [SerializeField]
    private float damping = 2.0f;
    private G_DotController center;
    private Vector2 centerpos;
    private void Awake()
    {
        red = GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>();
    }
    private void Update()
    {
        if (red.iscenter)
        {
            center = red;
        }
        else if (blue.iscenter)
        {
            center = blue;
        }
        centerpos = new Vector2(center.transform.position.x, center.transform.position.y);
        if(centerpos.x >= 31 && centerpos.x < 32)
        {
            Debug.Log("기울기");
        }
        if (centerpos.x >= 31 && centerpos.x < 32 && centerpos.y <= -1)
        {
            Debug.Log("돌아오기");
        }
        if (centerpos.x >= 16)
        {
            if (Input.anyKeyDown)
            {
                if(!Input.GetKeyDown(KeyCode.Escape))
                {
                    StopCoroutine(cameraBounce_co_2());
                    StartCoroutine(cameraBounce_co_2());
                }
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                if (!Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.currentGameState == GameState.gameStart)
                {
                    StopCoroutine(cameraBounce_co_1());
                    StartCoroutine(cameraBounce_co_1());
                }
            }
        }
    }
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPos.x = centerpos.x;
        targetPos.y = centerpos.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * damping);
    }

    IEnumerator cameraBounce_co_1()
    {
        float increment1 = 0.05f;
        float increment2 = 0.01f;
        while (Camera.main.orthographicSize >= 4.9)
        {
            Camera.main.orthographicSize -= increment1;
            yield return new WaitForSeconds(0.001f);
        }
        while (Camera.main.orthographicSize < 5)
        {
            Camera.main.orthographicSize += increment2;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator cameraBounce_co_2()
    {
        float increment1 = 0.05f;
        float increment2 = 0.01f;
        while (Camera.main.orthographicSize >= 4.8)
        {
            Camera.main.orthographicSize -= increment1;
            yield return new WaitForSeconds(0.001f);
        }
        while (Camera.main.orthographicSize < 5)
        {
            Camera.main.orthographicSize += increment2;
            yield return new WaitForSeconds(0.02f);
        }
    }
}

