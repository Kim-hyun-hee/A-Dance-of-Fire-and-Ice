using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject scoreObject;

    private void Awake()
    {
        scoreObject.SetActive(false);
    }

    public void SetScore(int num)
    {
        scoreObject.SetActive(true);
        scoreText.text = num + "% ¿Ï·á";
    }
}
