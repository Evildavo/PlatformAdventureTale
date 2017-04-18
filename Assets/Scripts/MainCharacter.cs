using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Main player character.
public class MainCharacter : MonoBehaviour
{
    Animator animator;

	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Walk right.
        if (horizontalInput > 0f)
        {
            animator.SetBool("IsFacingLeft", false);
            animator.SetBool("IsWalking", true);
        }

        // Walk left.
        else if (horizontalInput < 0f)
        {
            animator.SetBool("IsFacingLeft", true);
            animator.SetBool("IsWalking", true);
        }

        // Stand
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

}
