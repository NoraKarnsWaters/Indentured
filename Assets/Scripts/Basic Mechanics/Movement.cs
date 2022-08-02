using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    //An adjustable value that smooths the player movement
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
    [Range(0, .5f)][SerializeField] private float m_GroundCheckRadius = .03f;
    [SerializeField] private Vector3 m_GroundCheckOffset = new Vector3();


    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    //An empty Vectory for the SmoothDamp ref
    private Vector3 m_Velocity = Vector3.zero;

    private void Start()
    {
        //Gets the parent objects RigidBody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Finds a target velocity and uses a SmoothDamp method to move player with natural 2D movement
    /// </summary>
    /// <param name="dir">The current direction the player is moving in, usually between -1 and 1</param>
    public void MoveHorizontal(float dir)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(dir * speed, 0);

        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    /// <summary>
    /// Calls an AddForce function of the parent RigidBody2D component
    /// </summary>
    public void Jump()
    {
        //Detect if player is colliding with ground
        //If player is colliding with ground perform jump logic
        //When player is in air detect if colliding with ground
        //Else don't do anything
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    /// <summary>
    /// Checks if any of the current collisions are in touch with an object on layer "Ground" and returns result
    /// </summary>
    /// <returns>Returns true if colliding with an object on "Ground" layer, otherwise returns false</returns>
    public bool isGrounded()
    {
        //Instantiate and set the current value of grounded to false 
        bool grounded = false;

        //Gets and stores all object colliders on Layer "Ground" that are currently colliding with 
        //the circle overlapping between tf's position and the check radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.transform.position + m_GroundCheckOffset, m_GroundCheckRadius, LayerMask.GetMask("Ground"));

        Debug.Log("Current colliding with this many objects: " + colliders.Length);

        //Loop through all Collider2D objects in the colliders array variable
        for (int i = 0; i < colliders.Length; i++)
        {
            //If one of the objects related to the collider is not equal to the object this script is on
            //Grounded is set to true since it would have detected a Collider2D with the Layer "Ground"
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }

        //Return the value of grounded
        return grounded;
    }

}
