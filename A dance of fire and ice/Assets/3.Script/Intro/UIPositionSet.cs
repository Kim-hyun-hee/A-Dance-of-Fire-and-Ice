using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPositionSet : MonoBehaviour
{
    private GameObject target;
    private RectTransform UItransform;
    [SerializeField] private Vector3 distance = Vector3.down * 100f;
    public void Setup(GameObject target)
    {
        this.target = target;
        UItransform = GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(target.transform.position);
        UItransform.position = pos + distance;
    }
}
