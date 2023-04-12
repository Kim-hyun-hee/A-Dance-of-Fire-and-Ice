using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleController : MonoBehaviour
{
    private DotController red;
    private DotController blue;
    [SerializeField]
    private GameObject redRing;
    [SerializeField]
    private GameObject blueRing;
    [SerializeField]
    private float speed;
    private Color redRingColor;
    private Color blueRingColor;

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>().TryGetComponent(out blue);
        redRingColor = redRing.GetComponent<SpriteRenderer>().color;
        blueRingColor = blueRing.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        redRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, 1));
        blueRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, 1));
        if (red.iscenter)
        {
            redRingColor.a = 1;
            redRing.GetComponent<SpriteRenderer>().color = redRingColor;
            blueRingColor.a = 0;
            blueRing.GetComponent<SpriteRenderer>().color = blueRingColor;
        }
        else if (blue.iscenter)
        {
            blueRingColor.a = 1;
            blueRing.GetComponent<SpriteRenderer>().color = blueRingColor;
            redRingColor.a = 0;
            redRing.GetComponent<SpriteRenderer>().color = redRingColor;
        }
    }
}
