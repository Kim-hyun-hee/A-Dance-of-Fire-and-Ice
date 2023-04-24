using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private DotController red;
    private DotController blue;
    [SerializeField]
    private float damping = 2.0f;
    private DotController center;
    private Vector2 centerpos;
    private void Awake()
    {
        red = GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>();
    }
    private void Update()
    {
        if(red.iscenter)
        {
            center = red;
        }
        else if(blue.iscenter)
        {
            center = blue;
        }
        centerpos = new Vector2(center.transform.position.x, center.transform.position.y);

        if(Input.anyKeyDown)
        {
            StartCoroutine(cameraBounce_co());
        }
    }
    private void LateUpdate() // LateUpdate()�Լ��� Scene�� �ִ� ��� ��ũ��Ʈ�� Update()�Լ��� �Ϸ�� �� ȣ��� -> �������� �Ϸ�Ǳ� ���� ī�޶� �̵��� ��� �������� �߻� ����
    {
        // ī�޶� ��ĩ��ĩ,,
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // ī�޶� �̵��� ��ǥ
        if(centerpos.x > 2)
        {
            targetPos.x = centerpos.x;
            targetPos.y = 1;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * damping);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10), Time.deltaTime * damping);
        }
    }
    
    IEnumerator cameraBounce_co()
    {
        float increment1 = 0.05f;
        float increment2 = 0.01f;
        while (Camera.main.orthographicSize >= 5.4)
        {
            Camera.main.orthographicSize -= increment1;
            yield return new WaitForSeconds(0.001f);
        }
        while (Camera.main.orthographicSize < 5.5)
        {
            Camera.main.orthographicSize += increment2;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
