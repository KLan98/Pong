using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the states of your game
/// 1. game start with 1 second delay before anything is done
/// 2. ball is spawned
/// </summary>
public class GameController : MonoBehaviour
{
    public GoalManager goalManager;
    public GoalManager enemyGoalManager;

    private enum GameStates
    {
        WaitingToSpawnBall,
        SpawnBall,
        BallInPlay
    }

    private float waitTimer = 0f;
    private float waitTime = 1f;
    private GameStates gameState;

    private void Awake()
    {
        gameState = GameStates.WaitingToSpawnBall;
    }

    private void Update()
    {
        switch(gameState)
        {
            case GameStates.WaitingToSpawnBall:
                //Debug.Log("Game State = waiting to spawn ball");
                waitTimer += Time.deltaTime;
                //Debug.Log(waitTimer);
                if (waitTimer >= waitTime)
                {
                    gameState = GameStates.SpawnBall;
                    waitTimer = 0;
                }
                break;

            case GameStates.SpawnBall:
                //Debug.Log("Spawn ball");
                BallPool.Instance.SpawnBall(new Vector2(0, 0));
                gameState = GameStates.BallInPlay;
                break;

            case GameStates.BallInPlay:
                //Debug.Log("Game State = ball in play");
                if (goalManager.goalScored || enemyGoalManager.goalScored)
                {
                    gameState = GameStates.WaitingToSpawnBall;
                    goalManager.goalScored = false;
                    enemyGoalManager.goalScored = false;
                }
                break;
        }
    }
}
