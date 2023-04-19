using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_CircleController : MonoBehaviour
{
    private G_DotController red;
    private G_DotController blue;
    [SerializeField]
    private GameObject redRing;
    [SerializeField]
    private GameObject blueRing;
    [SerializeField]
    private float speed;
    private SpriteRenderer blueRenderer;
    private SpriteRenderer redRenderer;
    private SpriteRenderer blueDotRenderer;

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Red").GetComponent<G_DotController>().TryGetComponent(out red);
        GameObject.FindGameObjectWithTag("Blue").GetComponent<G_DotController>().TryGetComponent(out blue);
        blueRenderer = blueRing.GetComponent<SpriteRenderer>();
        redRenderer = redRing.GetComponent<SpriteRenderer>();
        blueDotRenderer = blue.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(GameManager.instance.currentGameState == GameState.inGame)
        {
            blueRenderer.enabled = false;
            redRenderer.enabled = false;
            blueDotRenderer.enabled = false;
        }
        
        if(GameManager.instance.currentGameState == GameState.gameStart || GameManager.instance.currentGameState == GameState.gameClear)
        {
            blueDotRenderer.enabled = true;
            if (red.iscenter)
            {
                blueRenderer.enabled = false;
                redRenderer.enabled = true;
            }
            else if (blue.iscenter)
            {
                blueRenderer.enabled = true;
                redRenderer.enabled = false;
            }
            redRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, -1));
            blueRing.transform.Rotate(speed * Time.deltaTime * new Vector3(0, 0, -1));
        }
    }
    
}
