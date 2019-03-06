using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class AxisControl : MonoBehaviour {

    private MouseClickDetection mouseClickDetection;
    private GameObject selectedGameObject;

    private Transform xSlider;

    // Use this for initialization
    void Start () {
        xSlider = transform.Find("x");
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

    public void resetSlider()
    {
        xSlider.GetComponent<Slider>().value = 0;
    }
}
