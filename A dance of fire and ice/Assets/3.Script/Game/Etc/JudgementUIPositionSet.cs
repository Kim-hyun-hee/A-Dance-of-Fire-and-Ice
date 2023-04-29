using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementUIPositionSet : MonoBehaviour
{
    [SerializeField] private Vector3 distance = Vector3.up * 120f;
    private GameObject target;
    private RectTransform UItransform;
    private int num;
    private Vector3 pos;
    public void Setup(GameObject target, int num)
    {
        this.num = num;
        this.target = target;
        UItransform = GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        if (num == 3)
        {
            pos = Camera.main.WorldToScreenPoint(target.transform.localPosition) + Vector3.up * 30f + Vector3.left * 60f;
        }
        else if (num == 4)
        {
            pos = Camera.main.WorldToScreenPoint(target.transform.localPosition) + Vector3.down * 180f + Vector3.right * 60f;
        }
        else
        {
            pos = Camera.main.WorldToScreenPoint(target.transform.localPosition);
        }
        UItransform.position = pos + distance;
    }
}
