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
        IsColNextTile(); // IsCollision()�� IsNextTile() ���ļ� �ϳ��� ��������!!
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
            // ���� /  ����� Ÿ�Ͽ� ���� ���� �������� ���� ����
        }
    }

    private void ChangeState()
    {
        isCenter = !isCenter;
        anotherDot.isCenter = !anotherDot.isCenter;
    }
    private void IsColNextTile()
    {
        // ���� �ִ� ���� ���̶� �浹���� �ƴ��� ���� iscollision
        foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(anotherDot.transform.position.x, anotherDot.transform.position.y), 0.32f))
        {
            if(col.gameObject.CompareTag("Tile") && col.gameObject.transform.localPosition.x == tiles[curIndex + 1].localPosition.x && col.gameObject.transform.localPosition.y == tiles[curIndex + 1].localPosition.y)
            {
                collTile = col.gameObject;
                isCollision = true;
            } // ��ģ ����� Ÿ�ϸ���Ʈ �������� ������ ��ǥ�� ���� Ÿ���� �ε��� ���ϰ� �����ε����� ����
            // �����ε����� ���� �ε��� +1 �̸� �浹 true ��ȯ�ϱ� -> ���� ����ó�� �ϸ� �� ������ ���϶��� ����Ʈ ���� ����� ���� ��!
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
    //    // curIndex + 1 == nextIndex ���� �Ǵ�
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

    private void Judgement() // curIndex + 1 == nextIndex �϶�
    {
        float dist;
        dist = Vector2.Distance(anotherDot.transform.position, tiles[curIndex + 1].localPosition);
        Debug.Log(dist);
        // ���� �ִ� ���̶� Ÿ���� �Ÿ� ���ؼ� ���� / ��Ȯ! ����! ����!
    }

    //private void SetNextPos()
    //{
    //    movePos = new Vector2Int((int)tiles[nextIndex].localPosition.x, (int)tiles[nextIndex].localPosition.y);
    //    anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
    //    // ���� �ִ� ���� ��ġ�� nextIndex Ÿ���� ��ġ�� ����
    //}
}
    
