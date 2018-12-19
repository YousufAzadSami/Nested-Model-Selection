using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStuff : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        // set up initial mode (rotate, translations, scale)
        ChangeModes(false, true, false);


        startingPosition = transform.position;
        startingScale = transform.localScale;

        // highlight color stuff
        objectmaterial = GetComponent<Renderer>().material;
        originalColor = objectmaterial.color;
        highlightColor = Color.red;
        isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSelected = !isSelected;
            objectmaterial.color = Color.red;
        }

        if (translateMode)
        {
            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundX = Input.GetAxis("Horizontal") * 10;
            float tiltAroundY = Input.GetAxis("Vertical") * 10;

            Vector3 target = startingPosition + new Vector3(tiltAroundX, tiltAroundY, 0);

            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
        }
        else if (rotateMode) {
            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

            // Dampen towards the target rotation
            // transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }
        else if (scaleMode) {
            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundZ = Input.GetAxis("Horizontal") * .6f;
            float tiltAroundX = Input.GetAxis("Vertical") * .6f;

            Vector3 target = startingScale + new Vector3(tiltAroundX, 0, tiltAroundZ);

            transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * smooth);
        }


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

    private void ChangeModes(bool inModeTranslate, bool inModeRotate, bool inModeScale)
    {
        translateMode = inModeTranslate;
        rotateMode = inModeRotate;
        scaleMode = inModeScale;
    }
}
