using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float maxVelocity = 3;
    public float rotationSpeed = 1;
    public SpaceBoganInteraction spaceBoganInteraction;
    public GameObject image;
    private RectTransform imagePosition;
    public Camera mainCamera;
    public float parallaxScale = 0.0001f;
    public bool ropeContact;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        imagePosition = image.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ropeContact)
        {
            float yAxis = Input.GetAxis("Vertical");
            float xAxis = Input.GetAxis("Horizontal");

            ThrustForward(yAxis);
            Rotate(transform, -xAxis * rotationSpeed);
            ClampVelocity();
        }

        moveBackground();
    }

    void ClampVelocity()
    {
        float x = Mathf.Clamp(rigidBody.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rigidBody.velocity.y, -maxVelocity, maxVelocity);

        rigidBody.velocity = new Vector2(x, y);
    }

    void moveBackground()
    {
        imagePosition.position = new Vector3(
            imagePosition.position.x - parallaxScale*mainCamera.velocity.x,
            imagePosition.position.y - parallaxScale*mainCamera.velocity.y,
            0);
    }

    void ThrustForward(float amount)
    {
        Vector2 thrust = transform.up * amount;
        rigidBody.AddForce(thrust);
    }

    void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }
}