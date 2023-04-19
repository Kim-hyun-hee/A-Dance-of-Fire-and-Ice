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
    private G_DotController red;
    private G_DotController blue;
    [SerializeField] private Transform Canvas;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>().TryGetComponent(out blue);
        prefabQueue = new Queue<GameObject>();
    }
    public void SetJudgement(int num)
    {
        switch(num)
        {
            case 0:
                Debug.Log("정확");
                StartCoroutine(SetPrefab_co(perfectPrefab));
                return;
            case 1:
                Debug.Log("빠름(초록)");
                StartCoroutine(SetPrefab_co(ePerfectPrefab));
                return;
            case 2:
                Debug.Log("빠름(주황)");
                StartCoroutine(SetPrefab_co(earlyPrefab));
                return;
            case 3:
                Debug.Log("매우 빠름");
                StartCoroutine(SetPrefab_co(vEarlyPrefab));
                return;
            case 4:
                Debug.Log("매우 느림");
                StartCoroutine(SetPrefab_co(vLatePrefab));
                return;
            case 5:
                Debug.Log("느림(주황)");
                StartCoroutine(SetPrefab_co(latePrefab));
                return;
            case 6:
                Debug.Log("느림(초록)");
                StartCoroutine(SetPrefab_co(lPerfectPrefab));
                return;
            default:
                return;
        }
    }
    IEnumerator SetPrefab_co(GameObject prefab)
    {
        curPrefab = Instantiate(prefab);
        prefabQueue.Enqueue(curPrefab);
        curPrefab.transform.SetParent(Canvas);
        curPrefab.transform.localScale = Vector3.one;
        if (red.iscenter)
        {
            curPrefab.GetComponent<JudgementUIPositionSet>().Setup(red.tiles[red.curIndex + 1].gameObject);
        }
        if (blue.iscenter)
        {
            curPrefab.GetComponent<JudgementUIPositionSet>().Setup(blue.tiles[red.curIndex].gameObject);
        }
        yield return new WaitForSeconds(1f);
        Destroy(prefabQueue.Dequeue());
    }
}
