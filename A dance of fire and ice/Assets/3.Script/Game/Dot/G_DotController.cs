using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class G_DotController : MonoBehaviour
{
    [SerializeField] private bool isCenter;
    [SerializeField] private G_DotController anotherDot;
    public bool iscenter => isCenter;
    private bool isCollision;
    [SerializeField]
    private int curIndex;
    private int nextIndex;
    public int nextindex => nextIndex;
    [SerializeField]
    private List<Transform> tiles;
    private G_TileManagement tileManagement;
    [SerializeField]
    private GameObject collTile;
    public Vector2Int movePos;
    private JudgementUI judgementui;

    private void Awake()
    {
        FindObjectOfType<G_TileManagement>().transform.TryGetComponent(out tileManagement);
        FindObjectOfType<JudgementUI>().gameObject.TryGetComponent(out judgementui);
        tiles = tileManagement.tiles;
    }
    private void Start()
    {
        for (int i = 1; i < tiles.Count; i++)
        {
            tiles[i].GetChild(0).gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(MoveDot_co());
        }
    }

    IEnumerator MoveDot_co()
    {
        IsColNextTile();
        yield return null;
        if (isCollision)
        {
            Judgement();
            //SetNextPos();
            movePos = new Vector2Int((int)tiles[nextIndex].localPosition.x, (int)tiles[nextIndex].localPosition.y);
            yield return null;
            anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
            tiles[nextIndex].GetChild(0).gameObject.SetActive(true);
            ChangeState();
            yield return null;
        }
        else if (anotherDot.transform.position.y > tiles[nextIndex].localPosition.y)
        {
            judgementui.SetJudgement(3);
        }
        else if (anotherDot.transform.position.y < tiles[nextIndex].localPosition.y)
        {
            judgementui.SetJudgement(4);
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
            if (col.gameObject.CompareTag("Tile")) // Ÿ�ϰ� �浹�ϸ�
            {
                int i;
                for (i = 0; i < tiles.Count; i++) // ��� Ÿ������ index ã��
                {
                    if (tiles[i].localPosition.x == col.gameObject.transform.localPosition.x && tiles[i].localPosition.y == col.gameObject.transform.localPosition.y)
                    {
                        nextIndex = i;
                        break;
                    }
                }
                if (nextIndex == curIndex + 1) // ã�� index�� currentIndex + 1 �̶��
                {
                    collTile = col.gameObject; // ���� ����
                    curIndex += 2;
                    isCollision = true;
                    break;
                }
            }
            else
            {
                collTile = GameObject.FindGameObjectWithTag("boundary").GetComponent<GameObject>();
                isCollision = false;
            }
        }
    }

    private void Judgement() // curIndex + 1 == nextIndex �϶�
    {
        float dist;
        dist = Vector2.Distance(anotherDot.transform.position, tiles[nextIndex].localPosition);
        if (dist < 0.3)
        {
            judgementui.SetJudgement(0);
        }
        else if (anotherDot.transform.position.y > tiles[nextIndex].localPosition.y)
        {
            judgementui.SetJudgement(1);
        }
        else if (anotherDot.transform.position.y < tiles[nextIndex].localPosition.y)
        {
            judgementui.SetJudgement(2);
        }
    }
}

    
