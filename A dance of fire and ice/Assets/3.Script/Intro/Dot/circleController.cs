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

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>().TryGetComponent(out blue);
    }

    void Update()
    {
        redRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, -1));
        blueRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, -1));
        if (red.iscenter && GameManager.instance.currentGameState == GameState.lobi)
        {
            blueRing.SetActive(false);
            redRing.SetActive(true);
        }
        else if (blue.iscenter && GameManager.instance.currentGameState == GameState.lobi)
        {
            blueRing.SetActive(true);
            redRing.SetActive(false);
        }
    }
}
