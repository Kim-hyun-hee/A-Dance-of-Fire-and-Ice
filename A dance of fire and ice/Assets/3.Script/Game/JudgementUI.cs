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
                Debug.Log("����(�ʷ�)");
                return;
            case 2:
                Debug.Log("����(��Ȳ)");
                return;
            case 3:
                Debug.Log("�ſ� ����");
                return;
            case 4:
                Debug.Log("�ſ� ����");
                return;
            case 5:
                Debug.Log("����(��Ȳ)");
                return;
            case 6:
                Debug.Log("����(�ʷ�)");
                return;
            default:
                return;
        }
    }
}
