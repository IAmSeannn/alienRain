using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float Speed = 0.5f;
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.W))
        {
            //move forward
            transform.Translate(Vector3.forward * Speed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            //move backward
            transform.Translate(Vector3.back * Speed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            //move left
            transform.Translate(Vector3.left * Speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            //move right
            transform.Translate(Vector3.right * Speed);
        }
	}
}
