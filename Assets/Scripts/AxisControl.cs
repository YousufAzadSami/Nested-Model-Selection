using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class AxisControl : MonoBehaviour {

    private MouseClickDetection mouseClickDetection;
    private GameObject selectedGameObject;

    private Slider[] sliders;

    // Use this for initialization
    void Start () {
        sliders = GetComponentsInChildren<Slider>();
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
        foreach(Slider slider in sliders)
        {
            slider.value = 0;
        }
    }
}
