using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManagement : MonoBehaviour
{
    [SerializeField]
    public List<Transform> tiles;
    private GameObject tile;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float smoothness = 0.02f;
    private Color tileColor;
    private Color orignalColor;
    private Color transColor;
    private DotController red;
    private DotController blue;
    private DotController center;
    private Vector2 centerpos;
    [SerializeField]
    public List<Transform> changeTiles;
    public bool isTileOn;
    private void Awake()
    {
        red = GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>();

        for (int i = 0; i < 45; i++)
        {
            tiles.Add(transform.GetChild(i));
            changeTiles.Add(transform.GetChild(i));
        }
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                changeTiles.RemoveAt(6 + 2 * i);
            }
        }
        orignalColor = new Color(255, 255, 255, 1f);
        transColor = new Color(255, 255, 255, 0f);
        tile = changeTiles[0].gameObject;
        tileColor = tile.GetComponent<Tilemap>().color;
        for (int i = 0; i < changeTiles.Count; i++)
        {
            changeTiles[i].gameObject.GetComponent<Tilemap>().color = transColor;
        }
        isTileOn = false;
    }
    private void Update()
    {
        if (red.iscenter)
        {
            center = red;
        }
        else if (blue.iscenter)
        {
            center = blue;
        }
        centerpos = new Vector2Int((int)center.transform.position.x, (int)center.transform.position.y);
        if (Input.anyKeyDown)
        {
            if (centerpos.x == 0 && centerpos.y == 0 && isTileOn)
            {
                StopCoroutine("LerpColor_co");
                StartCoroutine(LerpColor_co(tileColor, orignalColor, transColor)); //  ²ô±â
                isTileOn = false;
            }
            else
            {
                if(!isTileOn)
                {
                    StopCoroutine("LerpColor_co");
                    StartCoroutine(LerpColor_co(tileColor, transColor, orignalColor)); // ÄÑ±â
                    isTileOn = true;
                }
            }

        }
    }
    IEnumerator LerpColor_co(Color color1, Color color2, Color color3)
    {
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            color1 = Color.Lerp(color2, color3, progress);
            for(int i = 0; i < changeTiles.Count; i++)
            {
                changeTiles[i].gameObject.GetComponent<Tilemap>().color = color1;
            }
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
    }
}
