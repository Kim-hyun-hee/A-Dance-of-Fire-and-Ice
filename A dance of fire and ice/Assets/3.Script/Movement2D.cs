using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float initPosX;
    public float initPosY;
    public float distance;
    public float turningPoint;
    public float moveSpeed;
    public bool turn;
    void Awake()
    {
        if(gameObject.CompareTag("UpDown"))
        {
            initPosY = transform.position.y;
            turningPoint = initPosY - distance;
        }

        //if(gameObject.CompareTag("LeftRight"))
        //{
        //    initPosX = transform.position.x;
        //    turningPoint = initPosX - distance;
        //}

    }
    private void Update()
    {
        if(gameObject.CompareTag("UpDown"))
        {
            UpDown();
        }
        //if(gameObject.CompareTag("LeftRight"))
        //{
        //    LeftRight();
        //}
        if(gameObject.CompareTag("Rotate"))
        {
            Rotate();
        }
    }
    void UpDown()
    {
        float curPosY = transform.position.y;
        if (curPosY >= initPosY)
        {
            turn = false;
        }
        else if (curPosY <= turningPoint)
        {
            turn = true;
        }

        if(turn)
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        }
    }

    //void LeftRight()
    //{
    //    float curPosX = transform.position.x;
    //    if (curPosX >= initPosX + distance)
    //    {
    //        turn = false;
    //    }
    //    else if (curPosX <= turningPoint)
    //    {
    //        turn = true;
    //    }

    //    if(turn)
    //    {
    //        transform.position = transform.position + new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
    //    }
    //    else
    //    {
    //        transform.position = transform.position + new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
    //    }
    //}

    void Rotate()
    {
        float curPosY = transform.position.y;
        float curPosX = transform.position.x;
        if (curPosY >= initPosY - 1f && curPosX >= initPosX + 0.2f)
        {
            turn = false;
        }
        else if (curPosY >= initPosY - 1f && curPosX < initPosX - 0.2f)
        {
            turn = true;
        }

        if (turn)
        {
            transform.RotateAround(new Vector2(initPosX, initPosY), new Vector3(0, 0, 1), moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(new Vector2(initPosX, initPosY), new Vector3(0, 0, -1), moveSpeed * Time.deltaTime);
        }
    }
}
