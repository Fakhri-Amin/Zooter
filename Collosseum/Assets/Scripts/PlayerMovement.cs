using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 movementVector;
    private Vector3 lastFaceDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        lastFaceDirection = transform.localScale;
    }

    private void Update()
    {
        movementVector = InputManager.Instance.GetMovementVectorNormalized();

        HandleFaceDirection();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementVector.x * movementSpeed, rb.velocity.y);
    }

    private void HandleFaceDirection()
    {
        if (movementVector.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            lastFaceDirection = transform.localScale;
        }
        else if (movementVector.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            lastFaceDirection = transform.localScale;
        }
        else
        {
            transform.localScale = lastFaceDirection;
        }
    }
}
