using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Speed;
    private Vector2 mouvmentInput;
    private bool IsGrounded;
    private Myproject playerControls; //référence à l'input action
    [SerializeField] float speedModifier;
    [SerializeField]private float JumpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new Myproject();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            IsGrounded = true;
        }
    }

    private void Update()
    {
        mouvmentInput = playerControls.Player.Move.ReadValue<Vector2>();
        Mouvment();
        if(!IsGrounded == !false) //ceci est complétment voulu et à pour but de trigger ceux qui le voient
        {
            if (playerControls.Player.Jump.triggered)
            {
                Jump();
            }
        }
        else
        {
            if (playerControls.Player.Fire.triggered)
            {
                Fire();
            }
        }
    }

    private void Mouvment()
    {
        Speed = speedModifier * mouvmentInput.x;
        rb.velocity = new Vector2(Speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    private void Fire()
    {
        if(rb.velocity.y <= -0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -0.5f);
        }

    }
}
