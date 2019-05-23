/// Author: Sergio Teodoro Vite
/// Creation date: 2018/09/02
/// Last updated: 2018/11/01
/// ARAnatomyExplorer
/// UNAM, 2018
/// /// <summary>
/// This program process the touch screen for mobile devices.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleTouch : MonoBehaviour {

    public Toggle scaleToggle;
    public Toggle txToggle;
    public Toggle tyToggle;
    public Toggle rxToggle;
    public Toggle ryToggle;

    float scaleIncrement = 0.1f;

    public GameObject modelRoot;

    void Update()
    {
        if (Input.touchCount == 1) {
            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                //Left and right
                if (touchDeltaPosition.x < 0.0f)
                {
                    //if (txToggle.isOn)
                        modelRoot.transform.Translate(Vector3.left * 5 * Time.deltaTime, Space.World);
                    if (rxToggle.isOn)
                        modelRoot.transform.Rotate(Vector3.back * Time.deltaTime, Space.World);
                }
                else if (touchDeltaPosition.x > 0.0f)
                {
                    //if (txToggle.isOn)
                        modelRoot.transform.Translate(Vector3.right *5* Time.deltaTime, Space.World);
                    if (rxToggle.isOn)
                        modelRoot.transform.Rotate(Vector3.forward * Time.deltaTime, Space.World);
                }

                //Up and down
                if (touchDeltaPosition.y < 0.0f)
                {
                    //if (tyToggle.isOn)
                        modelRoot.transform.Translate(Vector3.back *5* Time.deltaTime, Space.World);
                    if (ryToggle.isOn)
                        modelRoot.transform.Rotate(Vector3.left * Time.deltaTime, Space.World);
                }
                else if (touchDeltaPosition.y > 0.0f)
                {
                    //if (tyToggle.isOn)
                        modelRoot.transform.Translate(Vector3.forward *5* Time.deltaTime, Space.World);
                    if (ryToggle.isOn)
                        modelRoot.transform.Rotate(Vector3.right * Time.deltaTime, Space.World);
                }
            }
            /*if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                double windowWidth = Screen.width / 2.0f;
                if (  )
                if (touchPosition.x < windowWidth )
                {
                    modelRoot.transform.Translate(Vector3.left * Time.deltaTime);
                }
                else if (touchPosition.x > windowWidth)
                {
                    modelRoot.transform.Translate(Vector3.right * Time.deltaTime);
                }

            }*/

        }
        // If there are two touches on the device...
        if ( Input.touchCount == 2 && scaleToggle.isOn ) {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (modelRoot.transform.localScale.x < 0.5f)
                modelRoot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            if (modelRoot.transform.localScale.x > 20.0f)
                modelRoot.transform.localScale = new Vector3(20.0f, 20.0f, 20.0f);

            if (modelRoot.transform.localScale.x >= 0.5f && modelRoot.transform.localScale.x <= 20.0f )
            {
                if (deltaMagnitudeDiff < 0)
                {
                    modelRoot.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
                }
                else
                {
                    modelRoot.transform.localScale -= new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
                }
            }
            
        }
    }
}
