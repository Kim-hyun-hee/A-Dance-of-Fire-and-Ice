using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_CircleController : MonoBehaviour
{
    private G_DotController red;
    private G_DotController blue;
    [SerializeField]
    private GameObject redRing;
    [SerializeField]
    private GameObject blueRing;
    [SerializeField]
    private float speed;

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>().TryGetComponent(out blue);
    }

    void Update()
    {
        redRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, -1));
        blueRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, -1));
        if (red.iscenter)
        {
            blueRing.SetActive(false);
            redRing.SetActive(true);
        }
        else if (blue.iscenter)
        {
            blueRing.SetActive(true);
            redRing.SetActive(false);
        }
    }
}
