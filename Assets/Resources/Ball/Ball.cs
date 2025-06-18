using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball will be spawned in the middle of the field and in random direction 
/// </summary>
public class Ball : MonoBehaviour
{
    private int ballSpeed = 8;
    private Rigidbody2D rb;
    private Vector2 initForce;

    private void Awake()
    {
        LoadRigidbody();
        InitDirection();
    }

    private void LoadRigidbody()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 spawnPosition)
    {
        this.transform.position = spawnPosition;
    }

    /// <summary>
    /// The init direction of moving is randomize
    /// </summary>
    private void InitDirection()
    {
        // add the normalize force
        initForce = new Vector2(Random.Range(-100, 100), Random.Range(-30, 30));

        Vector2 initDirection = initForce.normalized;
        //Debug.Log(initDirection);

        rb.AddForce(initDirection * ballSpeed, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Handle collision to wall
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Paddle"))
        {
            // Get paddle info
            float paddleY = collision.collider.transform.position.y;
            float ballY = transform.position.y;
            float paddleHeight = collision.collider.bounds.size.y;

            // How far from the paddle center the ball hit (-1 to 1)
            float yDiff = (ballY - paddleY) / (paddleHeight / 2f);
            yDiff = Mathf.Clamp(yDiff, -0.9f, 0.9f); 
            // Create a new direction: invert X and use yDiff for Y
            Vector2 newDir = new Vector2(-Mathf.Sign(rb.velocity.x), yDiff).normalized;
            rb.velocity = Vector2.zero; // Cancel current motion before applying new direction
            rb.AddForce(newDir * ballSpeed, ForceMode2D.Impulse);
        }

        else
        {
            Debug.Log("Hit wall");
            // Get wall info
            float wallX = collision.collider.transform.position.x;
            float ballX = transform.position.x;
            float wallWidth = collision.collider.bounds.size.x;

            // How far from the paddle center the ball hit (-1 to 1)
            float xDiff = (ballX - wallX) / (wallWidth / 2f);
            xDiff = Mathf.Clamp(xDiff, -0.9f, 0.9f);

            // Create a new direction: invert Y and use xDiff for X 
            Vector2 newDir = new Vector2(xDiff, -Mathf.Sign(rb.velocity.y)).normalized;
            rb.velocity = Vector2.zero; // Cancel current motion before applying new direction
            rb.AddForce(newDir * ballSpeed, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Handle behavior of the ball if it goes into a certain trigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ball enters goal");

        // return ball to pool
        BallPool.Instance.ReturnToPool(this);
    }
}
