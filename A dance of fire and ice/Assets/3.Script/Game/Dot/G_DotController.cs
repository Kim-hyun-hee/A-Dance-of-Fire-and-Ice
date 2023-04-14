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
        IsCollision(); // IsCollision()�� IsNextTile() ���ļ� �ϳ��� ��������!!
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
                // ���� / �ٵ� ������� �������� ����ó����
            }
        }
        else
        {
            // ���� /  ����� Ÿ�Ͽ� ���� ���� �������� ���� ����
        }
    }

    private void ChangeState()
    {
        isCenter = !isCenter;
        anotherDot.isCenter = !anotherDot.isCenter;
    }
    private void IsCollision()
    {
        // ���� �ִ� ���� ���̶� �浹���� �ƴ��� ���� iscollision
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
        // curIndex + 1 == nextIndex ���� �Ǵ�
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

    private void Judgement() // curIndex + 1 == nextIndex �϶�
    {
        // ���� �ִ� ���̶� Ÿ���� �Ÿ� ���ؼ� ���� / ��Ȯ! ����! ����!
    }

    //private void SetNextPos()
    //{
    //    movePos = new Vector2Int((int)tiles[nextIndex].localPosition.x, (int)tiles[nextIndex].localPosition.y);
    //    anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
    //    // ���� �ִ� ���� ��ġ�� nextIndex Ÿ���� ��ġ�� ����
    //}
}
    
