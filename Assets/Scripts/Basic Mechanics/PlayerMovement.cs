using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tf;

    private float dir = 0;

    [SerializeField]
    private float speed = 10f; //speed mult

    [SerializeField]
    private float jv = 5f; //jump mult

    [SerializeField]
    GameObject grndCheck;

    private bool jump = false;

    [SerializeField]
    private float rd = 0.3f;

    private Movement move;


   // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        rb = this.GetComponent<Rigidbody2D>();
        tf = this.grndCheck.transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()
    {
        //Call movement script and move horizontal
        move.MoveHorizontal(this.GetComponent<Rigidbody2D>(), dir, speed);

        //If the player is grounded 
        if (move.isGrounded(tf, rd) && jump)
        {
            Debug.Log("JUMPED");
            jump = false;
            move.Jump(this.GetComponent<Rigidbody2D>(), jv);
        }
        


    }

}
