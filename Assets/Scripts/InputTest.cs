using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Debug.Log("Button : Jump, Button name : \"Jump\"");
        }

        if (CrossPlatformInputManager.GetButtonDown("CustomJump"))
        {
            Debug.Log("Button : Jump, Button name : \"CustomJump\"");
        }

        if (CrossPlatformInputManager.GetAxis("Vertical") > .01f)
        {
            Debug.Log("Slidebar : " + CrossPlatformInputManager.GetAxis("Vertical"));
        }

        Debug.Log("For the MobileAircraftControls>Right prefab : " + CrossPlatformInputManager.GetAxis("Horizontal"));
    }
}
