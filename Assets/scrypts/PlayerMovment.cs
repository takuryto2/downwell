using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    float horizontalMovment;
    private bool isGrounded;
    [SerializeField] private float castDistance;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontalMovment*moveSpeed, rb.velocity.y);
        Grounded();
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovment = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
        else if (isGrounded == false)
        {
            if (rb.velocity.y <= -0.5f)
            {
                rb.velocity = new Vector2(rb.velocity.x, -0.5f);
            }
        }
    }

    public void Grounded()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up, quaternion.identity, castDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
