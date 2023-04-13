using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_DotController : MonoBehaviour
{
    [SerializeField] private bool isCenter;
    [SerializeField] private G_DotController anotherDot;
    public bool iscenter => isCenter;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if(isCenter)
            {
                isCenter = false;
            }
            else if(!isCenter)
            {
                isCenter = true;
            }
        }
    }
}
