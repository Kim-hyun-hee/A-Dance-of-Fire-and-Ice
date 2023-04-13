using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_TileManagement : MonoBehaviour
{
    [SerializeField]
    public List<Transform> tiles;
    [SerializeField]
    private int num;

    private void Awake()
    {
        for (int i = 0; i < num; i++)
        {
            tiles.Add(transform.GetChild(i));
        }
    }
}
