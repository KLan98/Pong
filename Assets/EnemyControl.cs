using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform ballTransform;
    //public Ball ball;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBallOnScreen())
        {
            LoadBallTransform();
            gameObject.transform.position = new Vector2 (gameObject.transform.position.x, ballTransform.position.y);
        }

        else
        {
            ballTransform = null;
        }
    }

    private void LoadBallTransform()
    {
        ballTransform = GameObject.Find("BallPool").GetComponentInChildren<Ball>().transform;
    }

    //private void LoadBallPool()
    //{
    //    ballPool = GameObject.Find("BallPool").GetComponent<BallPool>();
    //}

    private bool IsBallOnScreen()
    {
        if (GameObject.Find("BallPool").GetComponentInChildren<Ball>() != null)
        {
            Debug.Log("Ball on screen");
            return true;
        }

        else 
            Debug.Log("No ball on screen");
            return false;
    }
}
