using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBoganMovement : MonoBehaviour
{
    private float latestDirectionChangeTime;
    public float directionChangeTime = 3f;
    public float speed = 2f;
    public float targetSpeed = 0.5f;
    private Vector2 movementDirection;
    private Vector2 velocity;
    public bool playerSpotted = false;
    public SpaceBoganInteraction spaceBoganInteraction;
    public Transform player;
    public Rope2D rope;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        UpdateRandomMovement();
    }

    void UpdateRandomMovement()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        velocity = movementDirection * speed;
    }

    void Update()
    {
        if (!spaceBoganInteraction.ropeContact)
        {
            if (playerSpotted)
            {
                Vector3 target = new Vector3(
                    (rope.startPoint.position.x + rope.endPoint.position.x) / 2,
                    (rope.startPoint.position.y + rope.endPoint.position.y) / 2,
                    0);

                transform.position = new Vector2(speed * Time.fixedDeltaTime * (target.x - transform.position.x) / (Mathf.Sqrt(Mathf.Pow(target.x - transform.position.x, 2) + Mathf.Pow(target.y - transform.position.y, 2))) + transform.position.x,
                    speed * Time.fixedDeltaTime * (target.y - transform.position.y) / (Mathf.Sqrt(Mathf.Pow(target.y - transform.position.y, 2) + Mathf.Pow(target.x - transform.position.x, 2))) + transform.position.y);
            }
            else
            {
                if (Time.time - latestDirectionChangeTime > directionChangeTime)
                {
                    latestDirectionChangeTime = Time.time;
                    UpdateRandomMovement();
                }

                transform.position = new Vector2(transform.position.x + (velocity.x * Time.deltaTime),
                    transform.position.y + (velocity.y * Time.deltaTime));
            }
        }
        else
        {
            Debug.Log("cut");
        }
    }
}
