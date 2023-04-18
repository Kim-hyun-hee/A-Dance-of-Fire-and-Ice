using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;

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
    public Vector3Int movePos;
    public Vector3 moveCenterPos;
    private Vector3 anotherV;
    private JudgementUI judgementui;
    private float angle;
    private float moveVx;
    private float moveVy;

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
        if(tiles[tiles.Count - 1].gameObject.transform.localPosition == transform.position) // �������� endPos�� ������ �̻��� ���ľ���!
        {
            GameManager.instance.SetGameState(GameState.gameClear);  
        }
        if(isCenter && GameManager.instance.currentGameState != GameState.gameOver && GameManager.instance.currentGameState != GameState.gameClear)
        {
            StartCoroutine(MoveDot_co());
            if (Input.anyKeyDown)
            {
                // �ʹ� ��Ʈ ������ ���� ��ŸƮ�� �ٲٱ� / �ƴϸ� �ʹݿ� 3 2 1 �Ҷ� ���ӿ��� ������ ������ �����
                GameManager.instance.StartGame();
                //
                if (angle < 70 || angle > 290)
                {
                    if (angle < 20 || angle >= 340) // ��Ȯ
                    {
                        judgementui.SetJudgement(0);
                    }
                    if (angle >= 20 && angle < 50) // ����(�ʷ�)
                    {
                        judgementui.SetJudgement(1);
                    }
                    if (angle >= 50 && angle < 70) // ����(��Ȳ)
                    {
                        judgementui.SetJudgement(2);
                    }
                    if (angle >= 290 && angle < 310) // ����(��Ȳ)
                    {
                        judgementui.SetJudgement(5);
                    }
                    if (angle >= 310 && angle < 340) // ����(�ʷ�)
                    {
                        judgementui.SetJudgement(6);
                    }
                    moveCenterPos = new Vector3((int)tiles[curIndex + 1].localPosition.x + moveVx, (int)tiles[curIndex + 1].localPosition.y + moveVy, 0); // ���� �� ��ũ ������
                    movePos = new Vector3Int((int)tiles[curIndex + 1].localPosition.x, (int)tiles[curIndex + 1].localPosition.y, 0); // ���� ���� ������ Ÿ�� ��ǥ
                    anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
                    transform.position = new Vector2(moveCenterPos.x, moveCenterPos.y);
                    tiles[curIndex + 1].GetChild(0).gameObject.SetActive(true);
                    if (curIndex + 2 < tiles.Count - 1)
                    {
                        curIndex += 2;
                    }
                    ChangeState();
                }///////////////////////// �ſ�����̶� �ſ���� ��ũ ���߷��� ���Ͱ� �̵���ų���� ��;;;
                if (angle >= 70 && angle <= 180) // �ſ����
                {
                    judgementui.SetJudgement(3);
                }
            }
            //if(GameManager.instance.currentGameState == GameState.gameStart)
            //{
            //    if (angle >= 250 && angle < 290) // �ſ����
            //    {
            //        judgementui.SetJudgement(4);
            //        // ����ó��
            //        GameManager.instance.SetGameState(GameState.gameOver);
            //    }
            //}
        }
    }

    IEnumerator MoveDot_co()
    {
        yield return null;
        anotherV = new Vector3(anotherDot.transform.position.x - tiles[curIndex].localPosition.x, anotherDot.transform.position.y - tiles[curIndex].localPosition.y, 0);
        Vector3 baseV = new Vector3(tiles[curIndex + 1].localPosition.x - tiles[curIndex].localPosition.x, tiles[curIndex + 1].localPosition.y - tiles[curIndex].localPosition.y, 0);
        float dot = Vector3.Dot(baseV, anotherV);
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        Vector3 cross = Vector3.Cross(baseV, anotherV); // 0���� ũ�� ���� ������
        if (cross.z < 0)
        {
            angle = 360 - angle;
        }
        float ang = angle * Mathf.Deg2Rad;
        moveVx = baseV.x * Mathf.Cos((ang + Mathf.PI)) - baseV.y * Mathf.Sin((ang + Mathf.PI));
        moveVy = baseV.x * Mathf.Sin((ang + Mathf.PI)) + baseV.y * Mathf.Cos((ang + Mathf.PI));
    }
    private void ChangeState()
    {
        isCenter = !isCenter;
        anotherDot.isCenter = !anotherDot.isCenter;
    }
}


