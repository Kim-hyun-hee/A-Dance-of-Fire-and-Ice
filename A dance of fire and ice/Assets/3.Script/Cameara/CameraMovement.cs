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
    // Start is called before the first frame update
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
    }
    private void LateUpdate() // LateUpdate()함수는 Scene에 있는 모든 스크립트의 Update()함수가 완료된 후 호출됨 -> 움직임이 완료되기 전에 카메라가 이동할 경우 떨림현상 발생 가능
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // 카메라가 이동할 좌표
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
}
