using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AxisControl : MonoBehaviour {

    // We might not need this one
    private bool isXDown;

    private float xValueSign;
    private float xValue;
    private float maxXValue;

    private float yValueSign;
    private float yValue;
    private float maxYValue;

    private float zValueSign;
    private float zValue;
    private float maxZValue;

    private MouseClickDetection mouseClickDetection;
    private GameObject selectedGameObject;

    // Use this for initialization
    void Start () {
        isXDown = false;

        xValueSign = yValueSign = zValueSign = 0;
        xValue = yValue = zValue = 0;
        maxXValue = maxYValue = maxZValue = 1;
    }

    // Update is called once per frame
    void Update() {

        // uncomment the next line to see what happens and try dealing with it better
        // if (isXDown)
        {
            // call the functions necessary to tranlate
            xValue = Mathf.MoveTowards(xValue, maxXValue * xValueSign, Time.deltaTime);
            yValue = Mathf.MoveTowards(yValue, maxYValue * yValueSign, Time.deltaTime);
            zValue = Mathf.MoveTowards(zValue, maxZValue * zValueSign, Time.deltaTime);

            if (mouseClickDetection)
            {
                selectedGameObject.GetComponent<TransformationAndHighlight>().SetXValue(xValue);
                selectedGameObject.GetComponent<TransformationAndHighlight>().SetYValue(yValue);
                selectedGameObject.GetComponent<TransformationAndHighlight>().SetZValue(zValue);
            }
            else
            {
                //Debug.LogError("mouseClickDetection not set. This is needed in order to get the selelcted object");
            }
        }

        Debug.Log("xAxis : " + CrossPlatformInputManager.GetAxis("xAxis") + ", yAxis : " + CrossPlatformInputManager.GetAxis("yAxis"));
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

    public void YDown(float inYValue)
    {
        yValueSign = inYValue;
        yValue = 0;
    }

    public void YUp(float inYValue)
    {
        yValueSign = inYValue;
        yValue = 0;
    }

    public void ZDown(float inZValue)
    {
        zValueSign = inZValue;
        zValue = 0;
    }

    public void ZUp(float inZValue)
    {
        zValueSign = inZValue;
        zValue = 0;
    }
}
