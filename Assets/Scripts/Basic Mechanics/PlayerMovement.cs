using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; //speed mult

    private Movement move = new Movement();


   // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Call movement script and move horizontal
        move.MoveHorizontal(this.GetComponent<Rigidbody2D>(), Input.GetAxisRaw("Horizontal"), speed);
    }
}
