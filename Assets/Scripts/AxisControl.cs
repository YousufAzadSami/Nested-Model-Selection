using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisControl : MonoBehaviour {

    private bool isXDown;
    private float xValueSign;
    private float xValue;
    private float maxXValue;

    // Use this for initialization
    void Start () {
        isXDown = false;
        xValueSign = 0;
        xValue = 0;
        maxXValue = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (isXDown)
        {
            // call the functions necessary to tranlate
            xValue = Mathf.MoveTowards(xValue, maxXValue * xValueSign, Time.deltaTime);
        }
	}

	public void XDown(float inXValue) 
	{
        isXDown = true;
        xValueSign = inXValue;
        xValue = 0;
    }

	public void XUp(float inXValue)
	{
        isXDown = false;
        xValueSign = inXValue;
        xValue = 0;
    }
}
