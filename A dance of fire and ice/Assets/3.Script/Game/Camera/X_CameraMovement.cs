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
        if(centerpos.x == 31 && centerpos.y == 0)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.0833f));
        }
        else if (centerpos.x == 31 && centerpos.y == -1)
        {
            Debug.Log("돌아오기");
            StartCoroutine(cameraOriginal_co(0.1f, 0.01f, 0f));
        }
        else if (centerpos.x == 46 && centerpos.y == -1)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.0833f));
        }
        else if (centerpos.x == 46 && centerpos.y == -2)
        {
            Debug.Log("돌아오기");
            StartCoroutine(cameraOriginal_co(0.1f, 0.01f, 0f));
        }
        else if (centerpos.x == 61 && centerpos.y == -2)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.0833f));
        }
        else if (centerpos.x == 61 && centerpos.y == -3)
        {
            Debug.Log("돌아오기");
            StartCoroutine(cameraOriginal_co(0.1f, 0.01f, 0f));
        }
        else if (centerpos.x == 76 && centerpos.y == -3)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.0833f));
        }
        else if (centerpos.x == 76 && centerpos.y == -2)
        {
            Debug.Log("돌아오기");
            StartCoroutine(cameraOriginal_co(0.1f, 0.01f, 0f));
        }
        else if (centerpos.x == 91 && centerpos.y == -2)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.0833f));
        }
        else if (centerpos.x == 91 && centerpos.y == -1)
        {
            Debug.Log("돌아오기");
            StartCoroutine(cameraOriginal_co(0.1f, 0.01f, 0f));
        }
        else if (centerpos.x ==104 && centerpos.y == -1)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.05f));
        }
        else if (centerpos.x == 104 && centerpos.y == 0)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.1f));
        }
        else if (centerpos.x == 105 && centerpos.y == 0)
        {
            Debug.Log("기울기1");
            StartCoroutine(cameraRotate_co(0.1f, 0.01f, 0.15f));
        }
        else if (centerpos.x == 105 && centerpos.y == 1)
        {
            Debug.Log("돌아오기");
            StartCoroutine(cameraOriginal_co(0.1f, 0.01f, 0f));
        }
        else if (centerpos.x == 114 && centerpos.y == 1)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 114 && centerpos.y == 0)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 115 && centerpos.y == 0)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 115 && centerpos.y == -1)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 116 && centerpos.y == -1)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 116 && centerpos.y == -2)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 117 && centerpos.y == -2)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 117 && centerpos.y == -3)
        {
            Debug.Log("돌아오기");
        }
        else if (centerpos.x == 130 && centerpos.y == -3)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 130 && centerpos.y == -2)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 131 && centerpos.y == -2)
        {
            Debug.Log("기울기1");
        }
        else if (centerpos.x == 131 && centerpos.y == -1)
        {
            Debug.Log("돌아오기");
        }
        else if (centerpos.x == 140 && centerpos.y == -1)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 140 && centerpos.y == -2)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 141 && centerpos.y == -2)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 141 && centerpos.y == -3)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 142 && centerpos.y == -3)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 143 && centerpos.y == -3)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 144 && centerpos.y == -3)
        {
            Debug.Log("기울기");
        }
        else if (centerpos.x == 144 && centerpos.y == -2)
        {
            Debug.Log("돌아오기");
        }
        else if (centerpos.x >= 16)
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
        while (Camera.main.orthographicSize >= 4.95)
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

    IEnumerator cameraRotate_co(float increment1, float increment2, float degree) // 0.08333 == 15 0.1 0.01
    {
        while (Camera.main.transform.rotation.z <= degree)
        {
            Camera.main.transform.Rotate(0, 0, increment1);
            Camera.main.orthographicSize -= increment2;
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator cameraOriginal_co(float increment1, float increment2, float degree)
    {
        while (Camera.main.transform.rotation.z >= degree)
        {
            Camera.main.transform.Rotate(0, 0, -increment1);
            Camera.main.orthographicSize += increment2;
            yield return new WaitForSeconds(0.001f);
        }
    }
}

