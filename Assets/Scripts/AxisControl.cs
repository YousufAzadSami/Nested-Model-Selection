using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisControl : MonoBehaviour {

    private bool isXDown;
    private float xValueSign;
    private float xValue;
    private float maxXValue;
    private MouseClickDetection mouseClickDetection;
    private GameObject selectedGameObject;

    // Use this for initialization
    void Start () {
        isXDown = false;
        xValueSign = 0;
        xValue = 0;
        maxXValue = 1;
	}
	
	// Update is called once per frame
	void Update () {

        // uncomment the next line to see what happens and try dealing with it better
        // if (isXDown)
        {
            // call the functions necessary to tranlate
            xValue = Mathf.MoveTowards(xValue, maxXValue * xValueSign, Time.deltaTime);

            if (mouseClickDetection)
            {
                selectedGameObject.GetComponent<TransformationAndHighlight>().SetXValue(xValue);
            }
            else
            {
                Debug.LogError("mouseClickDetection not set. This is needed in order to get the selelcted object");
            }
        }
	}

    public void SetUp(MouseClickDetection inMouseClickDetection)
    {
        mouseClickDetection = inMouseClickDetection;
        selectedGameObject = mouseClickDetection.GetSelectedGameObject();
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
