using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _go;

    private Transform tf;
    private Transform gotf;

    [SerializeField]
    private float _cameraSmoothSpeed;

    [SerializeField]
    private float _cameraBoundary;

    private float[] boundaries = new float[4];

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        gotf = _go.GetComponent<Transform>();
        
        tf.position = new Vector3(gotf.position.x, gotf.position.y, gotf.position.z - 1);

        UpdateCameraBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCameraBoundaries()
    {
        //Boundaries are set from a clockwise position starting at North and ending at West
        boundaries[0] = tf.position.y - _cameraBoundary;
        boundaries[1] = tf.position.x + _cameraBoundary;
        boundaries[2] = tf.position.y + _cameraBoundary;
        boundaries[3] = tf.position.x - _cameraBoundary;
    }


}
