using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    //An adjustable value that smooths the player movement
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;

    //An empty Vectory for the SmoothDamp ref
    private Vector3 m_Velocity = Vector3.zero;

    public void MoveHorizontal(Rigidbody2D rb, float dir, float spd)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(dir * spd, 0);

        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void Jump(Rigidbody2D rb, float jv)
    {
        //Detect if player is colliding with ground
        //If player is colliding with ground perform jump logic
        //When player is in air detect if colliding with ground
        //Else don't do anything
        rb.AddForce(new Vector2(0f, jv));
    }

    public bool isGrounded(Transform groundCheck, float checkRadius)
    {
        bool grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, checkRadius, LayerMask.GetMask("Ground"));

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }

        return grounded;
    }

}
