using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Reflection;
public class TileManagement : MonoBehaviour
{
    [SerializeField]
    public List<Transform> tiles;
    [SerializeField]
    private GameObject logo;
    [SerializeField]
    private GameObject table;
    private GameObject tile;
    private Color tileColor;
    private Color tableColor;
    private Color logoColor;
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
    public ParticleSystem redEff;
    public ParticleSystem blueEff;
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<DotController>().TryGetComponent(out blue);

        for (int i = 0; i < 45; i++)
        {
            //tiles.Add(transform.GetChild(i));
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
        logoColor = logo.GetComponent<SpriteRenderer>().color;
        tableColor = table.GetComponent<SpriteRenderer>().color;
        for (int i = 0; i < changeTiles.Count; i++)
        {
            changeTiles[i].gameObject.GetComponent<Tilemap>().color = transColor;
        }
        isTileOn = false;
        redEff.Play();
        blueEff.Play();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(tileOnOff_co());
        }
    }
    IEnumerator tileOnOff_co()
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
        yield return null;
        
        if (centerpos.x == 0 && centerpos.y == 0 && !isTileOn)
        {
            StopCoroutine("LerpColor_co");
            StartCoroutine(LerpColor_co(tileColor, logoColor, tableColor, transColor, orignalColor)); // 타일 켜기 로고 끄기 테이블 켜기
            redEff.Stop();
            blueEff.Stop();
            isTileOn = true;
        }
        else if (aroundDot.movePos.x == 0 && aroundDot.movePos.y == 0 && isTileOn)
        {
            StopCoroutine("LerpColor_co");
            StartCoroutine(LerpColor_co(tileColor, logoColor, tableColor, orignalColor, transColor)); // 타일 끄기 로고 켜기 테이블 켜기
            redEff.Play();
            blueEff.Play();
            isTileOn = false;
        }
    }
    IEnumerator LerpColor_co(Color color1, Color color2, Color color3, Color color4, Color color5)
    {
        float progress = 0;
        float increment = 0.025f;
        while (progress < 1)
        {
            color2 = Color.Lerp(color5, color4, progress);
            logo.GetComponent<SpriteRenderer>().color = color2;
            color3 = Color.Lerp(color4, color5, progress);
            table.GetComponent<SpriteRenderer>().color = color3;
            color1 = Color.Lerp(color4, color5, progress);
            for(int i = 0; i < changeTiles.Count; i++)
            {
                changeTiles[i].gameObject.GetComponent<Tilemap>().color = color1;
            }
            progress += increment;
            yield return new WaitForSeconds (0.001f);
        }
    }
}
