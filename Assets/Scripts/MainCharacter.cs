using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Main player character. Requires an animator and a rigidbody.
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class MainCharacter : MonoBehaviour
{
    Animator animator;
    Rigidbody2D ourRigidBody;

    [SerializeField]
    [Tooltip("The force of walking left or right")]
    float walkForce = 1f;

    [SerializeField]
    [Tooltip("The force of jumps")]
    float jumpForce = 1f;

	void Start ()
    {
        animator = GetComponent<Animator>();
        ourRigidBody = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Walk right.
        if (horizontalInput > 0f)
        {
            animator.SetBool("IsFacingLeft", false);
            animator.SetBool("IsWalking", true);
            ourRigidBody.AddForce(Vector2.right * walkForce);
        }

        // Walk left.
        else if (horizontalInput < 0f)
        {
            animator.SetBool("IsFacingLeft", true);
            animator.SetBool("IsWalking", true);
            ourRigidBody.AddForce(Vector2.left * walkForce);
        }

        // Stand
        else
        {
            animator.SetBool("IsWalking", false);
            //ourRigidBody.velocity = Vector2.zero; // Stop abruptly.
        }

        // Jump if we're not already moving through the air.
        if (verticalInput > 0f /*&& ourRigidBody.velocity.y == 0f*/)
        {
            ourRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
