using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Transform Canvas;
    [SerializeField] private GameObject menuPrefab;
    [SerializeField] private GameObject stageMenu;

    private void Start()
    {
        SetMenuUI();
    }
    void SetMenuUI()
    {
        GameObject title1 = Instantiate(menuPrefab);
        title1.transform.SetParent(Canvas);
        title1.transform.localScale = Vector3.one;
        title1.GetComponent<UIPositionSet>().Setup(stageMenu);
    }
}
