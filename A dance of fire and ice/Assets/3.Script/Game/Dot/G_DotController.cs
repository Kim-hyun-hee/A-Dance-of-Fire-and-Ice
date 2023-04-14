using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_DotController : MonoBehaviour
{
    [SerializeField] private bool isCenter;
    [SerializeField] private G_DotController anotherDot;
    public bool iscenter => isCenter;
    private bool isCollision;
    [SerializeField]
    private int curIndex;
    private int nextIndex;
    [SerializeField]
    private List<Transform> tiles;
    private G_TileManagement tileManagement;
    [SerializeField]
    private GameObject collTile;
    public Vector2Int movePos;

    private void Awake()
    {
        FindObjectOfType<G_TileManagement>().transform.TryGetComponent(out tileManagement);
        tiles = tileManagement.tiles;
        
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if(iscenter)
            {
                StartCoroutine(MoveDot_co());
            }
        }
    }

    IEnumerator MoveDot_co()
    {
        IsCollision(); // IsCollision()랑 IsNextTile() 합쳐서 하나로 만들어야함!!
        if (isCollision)
        {
            if (IsNextTile())
            {
                //Judgement();
                //SetNextPos();
                movePos = new Vector2Int((int)tiles[nextIndex].localPosition.x, (int)tiles[nextIndex].localPosition.y);
                yield return null;
                anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
                ChangeState();
                yield return null;
            }
            else
            {
                // 실패 / 근데 여기까지 오기전에 실패처리됨
            }
        }
        else
        {
            // 실패 /  여기는 타일에 들어가기 전에 눌렀을때 실패 판정
        }
    }

    private void ChangeState()
    {
        isCenter = !isCenter;
        anotherDot.isCenter = !anotherDot.isCenter;
    }
    private void IsCollision()
    {
        // 돌고 있는 공이 블럭이랑 충돌인지 아닌지 구함 iscollision
        foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(anotherDot.transform.position.x, anotherDot.transform.position.y), 0.32f))
        {
            collTile = col.gameObject;
        }
        if(collTile.CompareTag("Tile"))
        {
            isCollision = true;
        }
        else
        {
            collTile = GameObject.FindGameObjectWithTag("boundary").GetComponent<GameObject>();
            isCollision = false;
        }
    }

    private bool IsNextTile()
    {
        int i;
        // curIndex + 1 == nextIndex 인지 판단
        for(i = 0; i < tiles.Count; i++)
        {
            if(tiles[i].localPosition.x == collTile.transform.localPosition.x && tiles[i].localPosition.y == collTile.transform.localPosition.y)
            {
                nextIndex = i;
                break;
            }
        }
        if (curIndex + 1 == nextIndex)
        {
            curIndex += 2;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Judgement() // curIndex + 1 == nextIndex 일때
    {
        // 돌고 있는 공이랑 타일의 거리 구해서 판정 / 정확! 빠름! 느림!
    }

    //private void SetNextPos()
    //{
    //    movePos = new Vector2Int((int)tiles[nextIndex].localPosition.x, (int)tiles[nextIndex].localPosition.y);
    //    anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
    //    // 돌고 있는 공의 위치를 nextIndex 타일의 위치로 조정
    //}
}
    
