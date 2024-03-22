using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("L/R mouvment")]
    public float moveSpeed;
    float horizontalMovment;

    [Header("jump")]
    public float jumpForce;

    [Header("ground check")]
    public Transform groundCheckPos;
    public Vector2 grousndCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("shoot")]
    public GameObject bulletPrefab;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontalMovment*moveSpeed, rb.velocity.y);

    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovment = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() == true)
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
        else if (IsGrounded() == false)
        {
            if (context.started)
            {
                if (rb.velocity.y <= -0.5f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -0.5f);
                    Shoot();
                }
                else
                {
                    Shoot();
                }
            }
        }
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, grousndCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position, grousndCheckSize);
    }

    private void Shoot()
    {
        Vector2 BulletSpawn = new Vector2(transform.position.x, transform.position.y - 1.25f);
        Instantiate(bulletPrefab, BulletSpawn, Quaternion.identity);
    }
}
