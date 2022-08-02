using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Movement move;

    private bool pressedJump = false;
    private float dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets a value between -1 and 1 for which direct the control stick is held in
        dir = Input.GetAxisRaw("Horizontal");
        //Checks if the Jump button has been pressed and triggers a flag if it is
        if (Input.GetButtonDown("Jump"))
            pressedJump = true;
    }

    void FixedUpdate()
    {
        //Call movement script and move horizontally based on inputed direction
        move.MoveHorizontal(dir);

        //If the player is grounded and the jump button is pressed than trigger the jump logic
        if (pressedJump && move.isGrounded())
        {
            Debug.Log("WE'RE JUMPING");
            move.Jump();
        }

        //Set that jump has been pressed to false
        //This is placed at the end to avoid a false flag from being raised until the Jump command is called again
        pressedJump = false;
    }

}
