using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Reflection;
public class TileManagement : MonoBehaviour
{
    [SerializeField]
    public List<Transform> tiles;
    private GameObject tile;
    private Color tileColor;
    private Color orignalColor;
    private Color transColor;
    private DotController red;
    private DotController blue;
    private DotController center;
    private DotController aroundDot;
    private Vector2 centerpos;
    [SerializeField]
    public List<Transform> changeTiles;
    public bool isTileOn;
    private int keyDownCount;
    void Awake()
    {
        keyDownCount = 0;
        GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>().TryGetComponent(out blue);

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
    void Update()
    {
        if (red.iscenter)
        {
            center = red;
            aroundDot = GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>();
        }
        else if (blue.iscenter)
        {
            center = blue;
            aroundDot = GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>();
        }
        centerpos = new Vector2(center.transform.position.x, center.transform.position.y);
        //var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        //var type = assembly.GetType("UnityEditor.LogEntries");
        //var method = type.GetMethod("Clear");
        //method.Invoke(new object(), null);
        //Debug.Log(center.gameObject);
        //Debug.Log(centerpos.x);
        //Debug.Log(centerpos.y);
        //Debug.Log(isTileOn);
        //Debug.Log(keyDownCount);
        if (Input.anyKeyDown) // ================= 조건 어떻게 해야 할지 생각 해보기,,,
        {
            if (centerpos.x == 0 && centerpos.y == 0 && isTileOn && keyDownCount == 0) // 첫번째 클릭만 해당
            {
                StopCoroutine("LerpColor_co");
                StartCoroutine(LerpColor_co(tileColor, orignalColor, transColor)); //  끄기
                isTileOn = false;
            }
            else if(aroundDot.movePos.x == 0 && aroundDot.movePos.y == 0 && isTileOn)
            {
                StopCoroutine("LerpColor_co");
                StartCoroutine(LerpColor_co(tileColor, orignalColor, transColor)); //  끄기
                isTileOn = false;
            }
            else
            {
                if(!isTileOn)
                {
                    StopCoroutine("LerpColor_co");
                    StartCoroutine(LerpColor_co(tileColor, transColor, orignalColor)); // 켜기
                    isTileOn = true;
                }
            }
            keyDownCount++;
        }
    }
    IEnumerator LerpColor_co(Color color1, Color color2, Color color3)
    {
        float progress = 0;
        float increment = 0.01f;
        while (progress < 1)
        {
            color1 = Color.Lerp(color2, color3, progress);
            for(int i = 0; i < changeTiles.Count; i++)
            {
                changeTiles[i].gameObject.GetComponent<Tilemap>().color = color1;
            }
            progress += increment;
            yield return new WaitForSeconds (0.005f);
        }
    }
}
