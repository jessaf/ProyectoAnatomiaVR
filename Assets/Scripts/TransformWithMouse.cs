/// Author: Sergio Teodoro Vite
/// Creation date: 2018/09/02
/// ARAnatomyExplorer
/// UNAM, 2018
/// /// <summary>
/// This program transform the models in the scene.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformWithMouse : MonoBehaviour {

    public float rotateIncrement = 3.0f;
    public float translationIncrement = 0.1f;
    public float scaleIncrement = 0.001f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                //Code for action on mouse moving left
                // local rotation
                //transform.rotation *= Quaternion.AngleAxis(rotateIncrement, Vector3.up);
                // global rotation
                transform.Rotate(rotateIncrement * Vector3.forward, Space.World);
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                //Code for action on mouse moving right
                // local rotation
                //transform.rotation *= Quaternion.AngleAxis(rotateIncrement, -Vector3.up);
                // global rotation
                transform.Rotate(-rotateIncrement * Vector3.forward, Space.World);
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                //Code for action on mouse moving down
                // local rotation
                //transform.rotation *= Quaternion.AngleAxis(rotateIncrement, Vector3.right);
                // global rotation
                transform.Rotate(-rotateIncrement * Vector3.right, Space.World);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                //Code for action on mouse moving up
                // local rotation
                //transform.rotation *= Quaternion.AngleAxis(rotateIncrement, -Vector3.right);
                // global rotation
                transform.Rotate(rotateIncrement * Vector3.right, Space.World);
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.Translate(-translationIncrement * Vector3.right, Space.World);
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.Translate(translationIncrement * Vector3.right, Space.World);
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.Translate(-translationIncrement * Vector3.forward, Space.World);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                transform.Translate(translationIncrement * Vector3.forward, Space.World);
            }
        }
        if (Input.GetMouseButton(2))
        {
            if (transform.localScale.x > 0.0f &&
                 transform.localScale.y > 0.0f &&
                 transform.localScale.z > 0.0f)
            {
                if (Input.GetAxis("Mouse Y") < 0)
                {
                    transform.localScale += new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
                }
                if (Input.GetAxis("Mouse Y") > 0)
                {
                    transform.localScale -= new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
                }
            }
            else
            {
                transform.localScale = new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
            }
        }
    }
}
