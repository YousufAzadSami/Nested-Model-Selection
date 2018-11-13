using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownTest: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            DisplayName();
        }
	}

    public void DisplayName()
    {
        // Debug.Log("Input.GetMouseButtonDown: " + transform.name);
    }
}
