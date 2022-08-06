using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //The Game Object the camera will follow
    [SerializeField]
    private GameObject _go;

    //Used to make the camera go higher or lower than the player (Look and feel shit)
    [SerializeField]
    private float _yOffset;

    //Transform component for the Camera Object
    private Transform tf;
    //Transform component for the Game Object the camera will follow
    private Transform gotf;

    //Stores old GameObject Transform position to reference later
    private Vector3 pgotf;

    void Start()
    {
        //Set the transform objects based on the provided components
        tf = GetComponent<Transform>();
        gotf = _go.GetComponent<Transform>();

        //Store initial position for later checks
        pgotf = gotf.position;

        //Sets the initial camera position
        Follow();
    }

    void Update()
    {
        //Saves on memory by checking if the position has changed before performing additional calculations
        if(pgotf != gotf.position)
        {
            //Follows the game object and sets the current position as the old position
            Follow();
            pgotf = gotf.position;
        }
    }

    //Reduce redundancy by packing in the logic for following the game object
    private void Follow()
    {
        //Sets the position of the camera based on the Game Object transform with additional offsets and camera positioning
        tf.position = new Vector3(gotf.position.x, gotf.position.y + _yOffset, gotf.position.z - 1);
    }

    

}
