using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private DotController red;
    private DotController blue;
    private float damping = 5.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        red = GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>();
    }

    private void LateUpdate() // LateUpdate()�Լ��� Scene�� �ִ� ��� ��ũ��Ʈ�� Update()�Լ��� �Ϸ�� �� ȣ��� -> �������� �Ϸ�Ǳ� ���� ī�޶� �̵��� ��� �������� �߻� ����
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (red.iscenter)
        {
            targetPos.x = red.transform.position.x;
            targetPos.y = red.transform.position.y;
        }
        else if (blue.iscenter)
        {
            targetPos.x = blue.transform.position.x;
            targetPos.y = blue.transform.position.y;
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * damping);
    }
}
