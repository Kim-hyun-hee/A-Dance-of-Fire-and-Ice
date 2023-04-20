using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEff : MonoBehaviour
{
    private RectTransform UItransform;
    public float moveSpeed;
    public Vector3 moveDirection = Vector3.zero;
    private void Awake()
    {
        UItransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        StartCoroutine(Move_co());
    }
    IEnumerator Move_co()
    {
        while (true)
        {
            if (UItransform.transform.position.x < -3000)
            {
                break;
            }
            UItransform.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            yield return 0.01f;
        }
    }
}
