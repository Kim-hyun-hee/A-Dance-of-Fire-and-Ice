using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2D : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private int speed;
    private void Update()
    {
        particle.transform.Rotate(new Vector3(0, 0, -1), speed * Time.deltaTime);
    }
}
