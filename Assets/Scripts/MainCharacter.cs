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
    float jumpForceApplied;

    [SerializeField]
    [Tooltip("The force of walking left or right")]
    float walkForce = 1f;

    [SerializeField]
    [Tooltip("The force applied upwards while jumping")]
    float jumpForce = 1f;

    [SerializeField]
    [Tooltip("Maximum force that can be applied to a single jump")]
    float maxJumpForce = 1f;

	void Start ()
    {
        animator = GetComponent<Animator>();
        ourRigidBody = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate ()
    {
        // Handle input.
        //

        // Walk right.
        if (Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("IsFacingLeft", false);
            animator.SetBool("IsWalking", true);
            ourRigidBody.AddForce(Vector2.right * walkForce);
        }

        // Walk left.
        else if (Input.GetAxis("Horizontal") < 0f)
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

        // Jump.
        if (Input.GetAxis("Vertical") > 0f)
        {
            // Apply jump force, up to the maximum smoothed with a cosine curve.
            if (jumpForceApplied < maxJumpForce)
            {
                ourRigidBody.AddForce(Vector2.up * jumpForce * 
                    Mathf.Cos(jumpForceApplied / maxJumpForce * Mathf.PI / 2f));
                jumpForceApplied += jumpForce;
            }
        }


        // If we're standing somewhere reset jump ability.
        if (ourRigidBody.velocity.y == 0f)
        {
            jumpForceApplied = 0f;
        }
    }

}
