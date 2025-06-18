using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public PointHUD pointHUD;

    public bool goalScored;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // update point
        pointHUD.Point++;
        goalScored = true;
    }
}
