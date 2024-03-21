//using Unity.Mathematics;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

//public class PlayerManager : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    private Transform Transform;
//    private float Speed;
//    private Vector2 mouvmentInput;
//    private Myproject playerControls; //référence à l'input action

//    [SerializeField]private float speedModifier;
//    [SerializeField]private float JumpForce;
//    //[SerializeField] private float castDistance;
//    //[SerializeField] private Vector2 boxSize;
//    //[SerializeField] private LayerMask groundLayer;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        Transform = GetComponent<Transform>();
//        playerControls = new Myproject();
//    }

//    private void OnEnable()
//    {
//        playerControls.Enable();
//    }

//    private void OnDisable()
//    {
//        playerControls.Disable();
//    }

//    private void Move(InputAction.CallbackContext context)
//    {
//        mouvmentInput = context.ReadValue<Vector2>().x;
//        Speed = speedModifier * mouvmentInput.x;
//        rb.velocity = new Vector2(Speed, rb.velocity.y);
//    }

//    private void Jump(InputAction.CallbackContext context)
//    {
//        if(IsGrounded() == true)
//        {
//            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
//        }
//    }

//    private void Fire(InputAction.CallbackContext context)
//    {
//        if (IsGrounded() == false)
//        {
//            if (rb.velocity.y <= -0.5f)
//            {
//                rb.velocity = new Vector2(rb.velocity.x, -0.5f);
//            }

//        }
//    }

//    //public bool IsGrounded()
//    //{
//    //    if (Physics.BoxCast(transform.position, boxSize, -transform.up, quaternion.identity, castDistance, groundLayer))
//    //    {
//    //        return true;
//    //    }
//    //    else
//    //    {
//    //        return false;
//    //    }
//    //}

//    //private void OnDrawGizmos()
//    //{
//    //    Gizmos.DrawWireCube(transform.position-transform.up*castDistance, boxSize);
//    //}
//}
