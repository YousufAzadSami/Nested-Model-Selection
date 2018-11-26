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
            // DisplayName("Input.GetMouseButtonDown");
        }
    }

    public void DisplayName(string functionName = "")
    {
        Debug.Log(functionName + ": " + transform.name);
    }

    private void OnMouseEnter()
    {
        DisplayName("OnMouseEnter");
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseExit()
    {
        DisplayName("OnMouseExit");
    }
}
