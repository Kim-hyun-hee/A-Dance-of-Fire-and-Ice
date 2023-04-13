using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_CameraMovement : MonoBehaviour
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
    }
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPos.x = centerpos.x;
        targetPos.y = centerpos.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * damping);
    }
}
