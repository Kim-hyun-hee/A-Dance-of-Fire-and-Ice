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
    [SerializeField]
    public int curIndex;
    [SerializeField] 
    public List<Transform> tiles;
    private G_TileManagement tileManagement;
    [SerializeField]
    private GameObject collTile;
    [SerializeField]
    public Vector3Int movePos;
    public Vector3 moveCenterPos;
    private Vector3 anotherV;
    private JudgementUI judgementui;
    [SerializeField]
    private ScoreUI scoreui;
    public float angle;
    private float moveVx;
    private float moveVy;
    private int count;
    private int sCount;
    private int cCount;
    public int Bpm;
    private float tickTime;

    private void Awake()
    {
        FindObjectOfType<G_TileManagement>().transform.TryGetComponent(out tileManagement);
        FindObjectOfType<JudgementUI>().gameObject.TryGetComponent(out judgementui);
        tiles = tileManagement.tiles;
        count = 0;
        sCount = 0;
        cCount = 0;
        tickTime = 0;
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
        tickTime += Time.deltaTime;
        Debug.Log(tickTime);
        if (tiles[tiles.Count - 1].gameObject.transform.localPosition == transform.position && cCount == 0)
        {
            GameManager.instance.SetGameState(GameState.gameClear);
            cCount = 1;
        }

        if(isCenter && GameManager.instance.currentGameState != GameState.gameOver && GameManager.instance.currentGameState != GameState.gameClear)
        {
            StartCoroutine(GetMoveDotPos_co());
            if(angle < 180)
            {
                sCount = 1;
            }
            if (Input.anyKeyDown && GameManager.instance.currentGameState != GameState.loading && GameManager.instance.currentGameState != GameState.pause)
            {
                if(!Input.GetKeyDown(KeyCode.Escape))
                {
                    count++;
                    //if(tickTime >= (60 / Bpm) / 2)
                    //{
                    //    tickTime -= (60 / Bpm) / 2;
                    //    if(tickTime >= 60 / Bpm)
                    //    {
                    //        Debug.Log("똑딱똑딱");
                    //    }
                    //}
                    GameManager.instance.SetGameState(GameState.gameStart);
                    // 3 2 1 자리 / 이땐 판정 안들어가게 해야함 / 했음
                    //
                    //StartCoroutine(GetMoveDotPos_co());
                }
            }
            if (GameManager.instance.currentGameState == GameState.gameStart && sCount == 1) // 얘를 어떡하지
            {
                if ((angle > 270 && angle < 290) && (count + anotherDot.count > 1)) // 매우느림
                {
                    judgementui.SetJudgement(4);
                    // 실패처리
                    GameManager.instance.SetGameState(GameState.gameOver);
                    if (SceneManager.GetActiveScene().buildIndex == 7)
                    {
                        scoreui.SetScore((curIndex + 1) * 100 / tiles.Count);
                    }
                }
            }
        }
    }
    IEnumerator GetMoveDotPos_co()
    {
        yield return null;
        anotherV = new Vector3(anotherDot.transform.position.x - tiles[curIndex].localPosition.x, anotherDot.transform.position.y - tiles[curIndex].localPosition.y, 0);
        Vector3 baseV = new Vector3(tiles[curIndex + 1].localPosition.x - tiles[curIndex].localPosition.x, tiles[curIndex + 1].localPosition.y - tiles[curIndex].localPosition.y, 0);
        float dot = Vector3.Dot(baseV, anotherV);
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        Vector3 cross = Vector3.Cross(baseV, anotherV); // 0보다 크면 빨리 누른거
        if (cross.z < 0)
        {
            angle = 360 - angle;
        }
        float ang = angle * Mathf.Deg2Rad;
        moveVx = baseV.x * Mathf.Cos((ang + Mathf.PI)) - baseV.y * Mathf.Sin((ang + Mathf.PI));
        moveVy = baseV.x * Mathf.Sin((ang + Mathf.PI)) + baseV.y * Mathf.Cos((ang + Mathf.PI));
        if (GameManager.instance.currentGameState == GameState.gameStart && Input.anyKeyDown && sCount == 1)
        {
            if(!Input.GetKeyDown(KeyCode.Escape))
            {
                if ((angle < 15 || angle >= 345) && (count + anotherDot.count > 1)) // 정확
                {
                    judgementui.SetJudgement(0);
                }
                if ((angle >= 15 && angle < 30) && (count + anotherDot.count > 1)) // 빠름(초록)
                {
                    judgementui.SetJudgement(1);
                }
                if ((angle >= 30 && angle < 60) && (count + anotherDot.count > 1)) // 빠름(주황)
                {
                    judgementui.SetJudgement(2);
                }
                if ((angle >= 290 && angle < 330) && (count + anotherDot.count > 1)) // 느림(주황)
                {
                    judgementui.SetJudgement(5);
                }
                if ((angle >= 330 && angle < 345) && (count + anotherDot.count > 1)) // 느림(초록)
                {
                    judgementui.SetJudgement(6);
                }
                if ((angle >= 60 && angle <= 180) && (count + anotherDot.count > 1)) // 매우빠름
                {
                    judgementui.SetJudgement(3);
                }
                if ((angle < 70 || angle > 290) && (angle < 60 || angle > 180))
                {
                    sCount = 0;
                    moveCenterPos = new Vector3((int)tiles[curIndex + 1].localPosition.x + moveVx, (int)tiles[curIndex + 1].localPosition.y + moveVy, 0); // 센터 공 싱크 조절용
                    movePos = new Vector3Int((int)tiles[curIndex + 1].localPosition.x, (int)tiles[curIndex + 1].localPosition.y, 0); // 도는 공이 정착할 타일 좌표
                    anotherDot.transform.position = new Vector2(movePos.x, movePos.y);
                    transform.position = new Vector2(moveCenterPos.x, moveCenterPos.y);
                    tiles[curIndex + 1].GetChild(0).gameObject.SetActive(true);
                    if (curIndex + 2 < tiles.Count - 1)
                    {
                        curIndex += 2;
                    }
                    ChangeState();
                }
            }
        }
    }
    private void ChangeState()
    {
        isCenter = !isCenter;
        anotherDot.isCenter = !anotherDot.isCenter;
    }
}


