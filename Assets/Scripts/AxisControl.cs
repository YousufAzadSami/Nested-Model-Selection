using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AxisControl : MonoBehaviour {

    private MouseClickDetection mouseClickDetection;
    private GameObject selectedGameObject;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {

        //Debug.Log("xAxis : " + CrossPlatformInputManager.GetAxis("xAxis")
        //    + ", yAxis : " + CrossPlatformInputManager.GetAxis("yAxis")
        //    + ", zAxis : " + CrossPlatformInputManager.GetAxis("zAxis"));

        //Debug.Log("yTranslationPositive" + CrossPlatformInputManager.GetAxis("yRotation"));
    }

    public void SetUp(MouseClickDetection inMouseClickDetection)
    {
        mouseClickDetection = inMouseClickDetection;
        selectedGameObject = mouseClickDetection.GetSelectedGameObject();
    }
}
