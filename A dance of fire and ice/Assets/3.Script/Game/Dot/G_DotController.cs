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
        IsColNextTile(); // IsCollision()랑 IsNextTile() 합쳐서 하나로 만들어야함!!
        yield return null;
        Debug.Log(isCollision);
        if (isCollision)
        {
            Judgement();
            //SetNextPos();
            movePos = new Vector2Int((int)tiles[curIndex + 1].localPosition.x, (int)tiles[curIndex + 1].localPosition.y);
            yield return null;
            curIndex += 2;
            anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
            ChangeState();
            yield return null;
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
    private void IsColNextTile()
    {
        // 돌고 있는 공이 블럭이랑 충돌인지 아닌지 구함 iscollision
        foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(anotherDot.transform.position.x, anotherDot.transform.position.y), 0.32f))
        {
            if(col.gameObject.CompareTag("Tile") && col.gameObject.transform.localPosition.x == tiles[curIndex + 1].localPosition.x && col.gameObject.transform.localPosition.y == tiles[curIndex + 1].localPosition.y)
            {
                collTile = col.gameObject;
                isCollision = true;
            } // 겹친 블록을 타일리스트 포문으로 돌려서 좌표가 같은 타일의 인덱스 구하고 다음인덱스라 지정
            // 다음인덱스가 현재 인덱스 +1 이면 충돌 true 반환하기 -> 지금 위에처럼 하면 맨 마지막 블럭일때는 리스트 범위 벗어나서 에러 뜸!
            else
            {
                collTile = GameObject.FindGameObjectWithTag("boundary").GetComponent<GameObject>();
                isCollision = false;
            }
        }
    }

    //private bool IsNextTile()
    //{
    //    int i;
    //    // curIndex + 1 == nextIndex 인지 판단
    //    for(i = 0; i < tiles.Count; i++)
    //    {
    //        if(tiles[i].localPosition.x == collTile.transform.localPosition.x && tiles[i].localPosition.y == collTile.transform.localPosition.y)
    //        {
    //            nextIndex = i;
    //            break;
    //        }
    //    }
    //    if (curIndex + 1 == nextIndex)
    //    {
    //        curIndex += 2;
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    private void Judgement() // curIndex + 1 == nextIndex 일때
    {
        float dist;
        dist = Vector2.Distance(anotherDot.transform.position, tiles[curIndex + 1].localPosition);
        Debug.Log(dist);
        // 돌고 있는 공이랑 타일의 거리 구해서 판정 / 정확! 빠름! 느림!
    }

    //private void SetNextPos()
    //{
    //    movePos = new Vector2Int((int)tiles[nextIndex].localPosition.x, (int)tiles[nextIndex].localPosition.y);
    //    anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
    //    // 돌고 있는 공의 위치를 nextIndex 타일의 위치로 조정
    //}
}
    
