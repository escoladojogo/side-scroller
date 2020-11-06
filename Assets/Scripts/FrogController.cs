using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpForce = 400f;
    public float waitToJump = 5.0f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public GameObject jumpListener;

    float secondsPassed = 0;

    void Update()
    {
        secondsPassed += Time.deltaTime;

        if (secondsPassed >= waitToJump)
        {
            animator.SetBool("IsJumping", true);
            rigidBody.AddForce(new Vector2(0, jumpForce));
            secondsPassed = 0;

            if (jumpListener != null)
            {
                jumpListener.SendMessage("Jumped");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsJumping", false);
    }
}
