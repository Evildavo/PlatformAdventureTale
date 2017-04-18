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
    Vector2 movementForce = new Vector2(0f, 0f);

    [SerializeField]
    [Tooltip("Speed the character walks left or right")]
    float walkSpeed = 1f;

	void Start ()
    {
        animator = GetComponent<Animator>();
        ourRigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Walk right.
        if (horizontalInput > 0f)
        {
            animator.SetBool("IsFacingLeft", false);
            animator.SetBool("IsWalking", true);
            movementForce.Set(walkSpeed, 0f);
            ourRigidBody.AddForce(movementForce);
        }

        // Walk left.
        else if (horizontalInput < 0f)
        {
            animator.SetBool("IsFacingLeft", true);
            animator.SetBool("IsWalking", true);
            movementForce.Set(-walkSpeed, 0f);
            ourRigidBody.AddForce(movementForce);
        }

        // Stand
        else
        {
            animator.SetBool("IsWalking", false);
            //ourRigidBody.velocity = Vector2.zero; // Stop abruptly.
        }
    }

}
