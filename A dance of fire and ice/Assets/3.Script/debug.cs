using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.transform.localPosition.x + "  " + gameObject.transform.localPosition.y);
        Debug.Log(gameObject.transform.position.x + "  " + gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
