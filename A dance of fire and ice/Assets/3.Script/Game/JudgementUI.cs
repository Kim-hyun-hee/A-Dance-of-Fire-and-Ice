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
                Debug.Log("정확");
                return;
            case 1:
                Debug.Log("빠름");
                return;
            case 2:
                Debug.Log("느림");
                return;
            case 3:
                Debug.Log("매우 빠름");
                return;
            case 4:
                Debug.Log("매우 느림");
                return;
            default:
                return;
        }
    }
}
