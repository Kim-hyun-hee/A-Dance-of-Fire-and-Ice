using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementUIPositionSet : MonoBehaviour
{
    [SerializeField] private Vector3 distance = Vector3.up * 120f;
    private GameObject target;
    private RectTransform UItransform;
    public void Setup(GameObject target)
    {
        this.target = target;
        UItransform = GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(target.transform.localPosition);
        UItransform.position = pos + distance;
    }
}
