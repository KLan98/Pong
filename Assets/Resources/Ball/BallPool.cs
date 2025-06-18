using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : BallSpawner<Ball>
{
    public static BallPool Instance;
    public Ball prefab;
    int poolSize = 30;

    private void Awake()
    {
        Instance = this;
        LoadPrefab();
        PoolEnqueue();
    }

    protected override void PoolEnqueue()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Ball ball = GameObject.Instantiate(prefab);
            ballQueue.Enqueue(ball);
            ball.gameObject.SetActive(false);
            ball.gameObject.transform.SetParent(this.transform);
        }
    }

    private void LoadPrefab()
    {
        prefab = this.gameObject.GetComponentInChildren<Ball>(true);
    }
}
