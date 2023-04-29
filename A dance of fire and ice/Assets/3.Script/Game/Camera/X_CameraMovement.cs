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
    [SerializeField]
    private GameObject backGround;

    private Color orignalColor;
    private Color bgColor;
    private Color transColor;
    private void Awake()
    {
        red = GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>();

        transColor = Color.gray;
        bgColor = backGround.GetComponent<SpriteRenderer>().color;
        orignalColor = bgColor;
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
            StartCoroutine(cameraRotate_co(0.1f, 0.0833f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 31 && centerpos.y == -1)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 46 && centerpos.y == -1)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.0833f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 46 && centerpos.y == -2)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 61 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.0833f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 61 && centerpos.y == -3)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 76 && centerpos.y == -3)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.0833f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 76 && centerpos.y == -2)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 91 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.0833f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 91 && centerpos.y == -1)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x ==104 && centerpos.y == -1)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.05f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 104 && centerpos.y == 0)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.1f));
            StartCoroutine(cameraBounce_co(0.05f, 3.5f));
        }
        else if (centerpos.x == 105 && centerpos.y == 0)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.15f));
            StartCoroutine(cameraBounce_co(0.05f, 3f));
        }
        else if (centerpos.x == 105 && centerpos.y == 1)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 114 && centerpos.y == 1)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.04f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 114 && centerpos.y == 0)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.08f));
            StartCoroutine(cameraBounce_co(0.05f, 3.5f));
        }
        else if (centerpos.x == 115 && centerpos.y == 0)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.12f));
            StartCoroutine(cameraBounce_co(0.05f, 3f));
        }
        else if (centerpos.x == 115 && centerpos.y == -1)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.16f));
            StartCoroutine(cameraBounce_co(0.05f, 2.5f));
        }
        else if (centerpos.x == 116 && centerpos.y == -1)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.2f));
            StartCoroutine(cameraBounce_co(0.05f, 2f));
        }
        else if (centerpos.x == 116 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.24f));
        }
        else if (centerpos.x == 117 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.28f));
        }
        else if (centerpos.x == 117 && centerpos.y == -3)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 130 && centerpos.y == -3)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.05f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 130 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.1f));
            StartCoroutine(cameraBounce_co(0.05f, 3.5f));
        }
        else if (centerpos.x == 131 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.15f));
            StartCoroutine(cameraBounce_co(0.05f, 3f));
        }
        else if (centerpos.x == 131 && centerpos.y == -1)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x == 140 && centerpos.y == -1)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.03f));
            StartCoroutine(cameraBounce_co(0.05f, 4f));
            StartCoroutine(LerpColor_co(orignalColor, transColor));
        }
        else if (centerpos.x == 140 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.06f));
            StartCoroutine(cameraBounce_co(0.05f, 3.6f));
        }
        else if (centerpos.x == 141 && centerpos.y == -2)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.09f));
            StartCoroutine(cameraBounce_co(0.05f, 3.2f));
        }
        else if (centerpos.x == 141 && centerpos.y == -3)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.12f));
            StartCoroutine(cameraBounce_co(0.05f, 2.8f));
        }
        else if (centerpos.x == 142 && centerpos.y == -3)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.15f));
            StartCoroutine(cameraBounce_co(0.05f, 2.4f));
        }
        else if (centerpos.x == 143 && centerpos.y == -3)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.18f));
            StartCoroutine(cameraBounce_co(0.05f, 2f));
        }
        else if (centerpos.x == 144 && centerpos.y == -3)
        {
            StartCoroutine(cameraRotate_co(0.1f, 0.21f));
        }
        else if (centerpos.x == 144 && centerpos.y == -2)
        {
            StartCoroutine(cameraOriginal_co(0.1f, 0f));
            StartCoroutine(cameraBounceOriginal_co(0.05f, 5f));
            StartCoroutine(LerpColor_co(transColor, orignalColor));
        }
        else if (centerpos.x >= 16)
        {
            if (Input.anyKeyDown)
            {
                if(!Input.GetKeyDown(KeyCode.Escape))
                {
                    StopCoroutine(cameraBounce_big_co());
                    StartCoroutine(cameraBounce_big_co());
                }
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                if (!Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.currentGameState == GameState.gameStart)
                {
                    StopCoroutine(cameraBounce_small_co());
                    StartCoroutine(cameraBounce_small_co());
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
    IEnumerator LerpColor_co(Color current, Color after)
    {
        float progress = 0;
        float increment = 0.05f;
        while (progress < 1)
        {
            bgColor = Color.Lerp(current, after, progress);
            backGround.GetComponent<SpriteRenderer>().color = bgColor;

            progress += increment;
            yield return new WaitForSeconds(0.001f);
        }
    }
    IEnumerator cameraBounce_small_co()
    {
        float increment1 = 0.05f;
        float increment2 = 0.01f;
        while (Camera.main.orthographicSize >= 4.96)
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

    IEnumerator cameraBounce_big_co()
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

    IEnumerator cameraRotate_co(float increment1, float degree) // 0.08333 == 15 0.1 0.01
    {
        while (Camera.main.transform.rotation.z <= degree)
        {
            Camera.main.transform.Rotate(0, 0, increment1);
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator cameraOriginal_co(float increment1, float degree)
    {
        while (Camera.main.transform.rotation.z >= degree)
        {
            Camera.main.transform.Rotate(0, 0, -increment1);
            yield return new WaitForSeconds(0.001f);
        }
    }
    IEnumerator cameraBounce_co(float increment1, float degree)
    {
        while (Camera.main.orthographicSize >= degree)
        {
            Camera.main.orthographicSize -= increment1;
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator cameraBounceOriginal_co(float increment1, float degree)
    {
        while (Camera.main.orthographicSize < degree)
        {
            Camera.main.orthographicSize += increment1;
            yield return new WaitForSeconds(0.02f);
        }
    }
}

