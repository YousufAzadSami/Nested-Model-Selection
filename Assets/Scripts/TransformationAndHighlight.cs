using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TransformationAndHighlight : MonoBehaviour {

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    bool translateMode;
    bool rotateMode;
    bool scaleMode;

    Vector3 startingPosition;
    Vector3 startingScale;

    public Material objectmaterial;
    public Color originalColor;
    public Color highlightColor;
    public bool isSelected; // if selected, change the color to highlightColor
    public float highlightColorTransition;

    private float xValue;
    private float yValue;
    private float zValue;

    // Use this for initialization
    void Start () {
        // set up initial mode (translation, rotate, scale)
        // No mode is chosen as start
        ChangeModes(false, false, false);

        // highlight color stuff
        objectmaterial = GetComponent<Renderer>().material;
        originalColor = objectmaterial.color;
        highlightColor = Color.red;
        isSelected = false;
        highlightColorTransition = 0.75f;
	}
	
	// Update is called once per frame
	void Update () {

        // YAZ Debug code start 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSelectedStatus();
            // objectmaterial.color = Color.red;
        }
        // YAZ Debug code end

        if (isSelected)
        {
            objectmaterial.color = Color.Lerp(highlightColor, objectmaterial.color, highlightColorTransition);
        }
        else
        {
            objectmaterial.color = Color.Lerp(originalColor, objectmaterial.color, highlightColorTransition);
        }



        if (isSelected)
        {
            if (translateMode)
            {
                Vector3 target = transform.position + new Vector3(
                    CrossPlatformInputManager.GetAxis("xTranslation"),
                    CrossPlatformInputManager.GetAxis("yTranslation"),
                    CrossPlatformInputManager.GetAxis("zTranslation"));

                transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
            }
            else if (rotateMode)
            {
                Quaternion target = Quaternion.Euler(
                    CrossPlatformInputManager.GetAxis("xRotation"),
                    CrossPlatformInputManager.GetAxis("yRotation"),
                    CrossPlatformInputManager.GetAxis("zRotation"));

                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
            }
            else if (scaleMode)
            {
                // Smoothly tilts a transform towards a target rotation.
                float tiltAroundZ = Input.GetAxis("Horizontal") * .6f;
                float tiltAroundX = Input.GetAxis("Vertical") * .6f;

                Vector3 target = transform.localScale + new Vector3(tiltAroundX, 0, tiltAroundZ);

                transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * smooth);
            }
        }

       
        // Get keyinput 
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeModes(true, false, false);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeModes(false, true, false);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeModes(false, false, true);
        }
        
    }

    public void ChangeModes(bool inModeTranslate, bool inModeRotate, bool inModeScale)
    {
        translateMode = inModeTranslate;
        rotateMode = inModeRotate;
        scaleMode = inModeScale;
    }

    public void ChangeSelectedStatus()
    {
        isSelected = !isSelected;
    }

    public void Unselect()
    {
        isSelected = false;
    }

    public bool SelectedStatus()
    {
        return isSelected;
    }


    public void SetXValue(float inXValue)
    {
        xValue = inXValue;
    }

    public void SetYValue(float inYValue)
    {
        yValue = inYValue;
    }

    public void SetZValue(float inZValue)
    {
        zValue = inZValue;
    }
}
