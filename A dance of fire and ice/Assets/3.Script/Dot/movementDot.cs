using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementDot : MonoBehaviour
{

    [SerializeField] private float speed;
    private DotController red;
    private DotController blue;
    private void Awake()
    {
        red = GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>();
    }
    void Update()
    {
        if(red.iscenter)
        {
            blue.transform.RotateAround(red.transform.position, new Vector3(0, 0, -1), speed * Time.deltaTime);
        }
        else if(blue.iscenter)
        {
            red.transform.RotateAround(blue.transform.position, new Vector3(0, 0, -1), speed * Time.deltaTime);
        }
    }

}
