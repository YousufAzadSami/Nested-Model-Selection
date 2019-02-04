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

        if (CrossPlatformInputManager.GetButtonDown("NewButton"))
        {
            Debug.Log("Button : Jump, Button name : \"NewButton\"");
        }

        if (CrossPlatformInputManager.GetButtonDown("NewButton02"))
        {
            Debug.Log("Button : Jump, Button name : \"NewButton02\", for this button, the button handler is attached to another object");
        }

        if (CrossPlatformInputManager.GetAxis("Vertical") > .01f)
        {
            Debug.Log("Slidebar : " + CrossPlatformInputManager.GetAxis("Vertical"));
        }

        // Debug.Log("For the MobileAircraftControls>Right prefab : " + CrossPlatformInputManager.GetAxis("Horizontal"));
    }
}
