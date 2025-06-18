using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner<T>: MonoBehaviour where T : Ball
{
    public Queue<T> ballQueue = new Queue<T>();

    /// <summary>
    /// Pool enqueue means loading game objects into the pool
    /// </summary>
    protected virtual void PoolEnqueue()
    {

    }

    /// <summary>
    /// Method for spawning the object
    /// </summary>
    public T SpawnBall(Vector2 spawnPosition)
    {
        if(ballQueue.Count == 0)
        {
            PoolEnqueue();
        }

        // the ball is the dequeued object of the queue
        T ball = ballQueue.Dequeue();

        // set the ball to active
        ball.gameObject.SetActive(true);

        // init value of ball
        ball.Initialize(spawnPosition);
        return ball;
    }

    /// <summary>
    /// Return game object to pool, by loading it into pool
    /// </summary>
    public void ReturnToPool(T ball)
    {
        ball.gameObject.SetActive(false);
        ballQueue.Enqueue(ball);
    }
}
