using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; //speed mult

    private Rigidbody2D rb; //variable rb is for rigid body 


   // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //sets rb to be player rigidbody   
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); //horizontal movement along x axis
	    rb.velocity = new Vector2(xMove, 0) * speed; //creates directional velocity
    }
}
