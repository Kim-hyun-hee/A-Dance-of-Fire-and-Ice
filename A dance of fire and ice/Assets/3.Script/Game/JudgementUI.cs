using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgementUI : MonoBehaviour
{

    public void SetJudgement(int num)
    {
        switch(num)
        {
            case 0:
                Debug.Log("��Ȯ");
                return;
            case 1:
                Debug.Log("����");
                return;
            case 2:
                Debug.Log("����");
                return;
            case 3:
                Debug.Log("�ſ� ����");
                return;
            case 4:
                Debug.Log("�ſ� ����");
                return;
            default:
                return;
        }
    }
}
