﻿using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // Use this for initialization
    void Awake()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                Debug.Log("Current object : " + this.transform.name + " : Gesture object : " + FocusedObject.name);
                FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);

                this.GetComponent<MouseClickDetection>().SetSelectedGameObject(FocusedObject);
                TransformationAndHighlight transformAndHighlight = FocusedObject.GetComponent<TransformationAndHighlight>();
                if (transformAndHighlight)
                {
                    this.GetComponent<MouseClickDetection>().SelectObjectRelatedStuff(transformAndHighlight);
                    this.GetComponent<MouseClickDetection>().SetActiveUI(transformAndHighlight.SelectedStatus());
                }
            }

        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            Debug.Log("New selected object : " + FocusedObject.name);

            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}