using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgementUI : MonoBehaviour
{
    [SerializeField] GameObject perfectPrefab;
    [SerializeField] GameObject ePerfectPrefab;
    [SerializeField] GameObject lPerfectPrefab;
    [SerializeField] GameObject earlyPrefab;
    [SerializeField] GameObject latePrefab;
    [SerializeField] GameObject vEarlyPrefab;
    [SerializeField] GameObject vLatePrefab;
    private GameObject curPrefab;
    public Queue<GameObject> prefabQueue;
    public Queue<GameObject> overloadQueue;
    private G_DotController red;
    private G_DotController blue;
    [SerializeField] private Transform Canvas;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>().TryGetComponent(out blue);
        prefabQueue = new Queue<GameObject>();
        overloadQueue = new Queue<GameObject>();
    }
    public void SetJudgement(int num)
    {
        switch(num)
        {
            case 0:
                Debug.Log("정확");
                StartCoroutine(SetPrefab_co(perfectPrefab, num));
                return;
            case 1:
                Debug.Log("빠름(초록)");
                StartCoroutine(SetPrefab_co(ePerfectPrefab, num));
                return;
            case 2:
                Debug.Log("빠름(주황)");
                StartCoroutine(SetPrefab_co(earlyPrefab, num));
                return;
            case 3:
                Debug.Log("매우 빠름");
                StartCoroutine(SetPrefab_co(vEarlyPrefab, num));
                return;
            case 4:
                Debug.Log("매우 느림");
                StartCoroutine(SetPrefab_co(vLatePrefab, num));
                return;
            case 5:
                Debug.Log("느림(주황)");
                StartCoroutine(SetPrefab_co(latePrefab, num));
                return;
            case 6:
                Debug.Log("느림(초록)");
                StartCoroutine(SetPrefab_co(lPerfectPrefab, num));
                return;
            default:
                return;
        }
    }
    IEnumerator SetPrefab_co(GameObject prefab, int num)
    {
        curPrefab = Instantiate(prefab);
        curPrefab.transform.SetParent(Canvas);
        curPrefab.transform.localScale = Vector3.one;
        if (red.iscenter && num != 3 && num != 4)
        {
            prefabQueue.Enqueue(curPrefab);
            curPrefab.GetComponent<JudgementUIPositionSet>().Setup(red.tiles[red.curIndex + 1].gameObject, num);
        }
        else if (red.iscenter) // 3, 4
        {
            if(num == 3)
            {
                overloadQueue.Enqueue(curPrefab);
                prefabQueue.Enqueue(curPrefab);
                curPrefab.GetComponent<JudgementUIPositionSet>().Setup(red.tiles[red.curIndex].gameObject, num);
            }
            else
            {
                prefabQueue.Enqueue(curPrefab);
                curPrefab.GetComponent<JudgementUIPositionSet>().Setup(red.tiles[red.curIndex].gameObject, num);
            }
        }
        if (blue.iscenter && num != 3 && num != 4)
        {
            prefabQueue.Enqueue(curPrefab);
            curPrefab.GetComponent<JudgementUIPositionSet>().Setup(blue.tiles[red.curIndex].gameObject, num);
        }
        else if (blue.iscenter) // 3, 4
        {
            if (num == 3)
            {
                overloadQueue.Enqueue(curPrefab);
                prefabQueue.Enqueue(curPrefab);
                curPrefab.GetComponent<JudgementUIPositionSet>().Setup(blue.tiles[red.curIndex - 1].gameObject, num);
            }
            else
            {
                prefabQueue.Enqueue(curPrefab);
                curPrefab.GetComponent<JudgementUIPositionSet>().Setup(red.tiles[red.curIndex - 1].gameObject, num);
            }
        }
        if(overloadQueue.Count > 2) // 과부하
        {
            if (red.iscenter && num != 3 && num != 4)
            {
                latePrefab.GetComponent<JudgementUIPositionSet>().Setup(red.tiles[red.curIndex + 1].gameObject, num);
            }
            if (blue.iscenter && num != 3 && num != 4)
            {
                latePrefab.GetComponent<JudgementUIPositionSet>().Setup(blue.tiles[red.curIndex].gameObject, num);
            }
            GameManager.instance.SetGameState(GameState.gameOver);
        }
        yield return new WaitForSeconds(0.9f);
        if(prefabQueue.Count > 0)
        {
            Destroy(prefabQueue.Dequeue());
        }
        if(overloadQueue.Count > 0)
        {
            Destroy(overloadQueue.Dequeue());
        }
    }
}
 